using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenpilotToolkit.Stream
{
    public class CombinedStream : System.IO.Stream
    {
        private readonly List<System.IO.Stream> _streams;
        private long _position;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private int _currentStreamIndex = 0;
        private readonly Lazy<long> _length;
        private readonly bool _shouldDisposeStreams;

        public CombinedStream(IEnumerable<System.IO.Stream> streams, bool shouldDisposeStreams = true)
        {
            _streams = new List<System.IO.Stream>(streams);
            if (_streams.Any(s => !s.CanSeek))
                throw new ArgumentException("All streams must be seekable.");
            _length = new Lazy<long>(() => _streams.Sum(s => s.Length));
            _shouldDisposeStreams = shouldDisposeStreams;
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _length.Value;

        public override long Position
        {
            get => _position;
            set => Seek(value, SeekOrigin.Begin);
        }

        public override void Flush() { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            _semaphore.Wait();
            try
            {
                var totalBytesRead = 0;

                while (count > 0 && _currentStreamIndex < _streams.Count)
                {
                    var currentStream = _streams[_currentStreamIndex];
                    var bytesRead = currentStream.Read(buffer, offset, count);
                    if (bytesRead == 0)
                    {
                        _currentStreamIndex++;
                        continue;
                    }

                    totalBytesRead += bytesRead;
                    offset += bytesRead;
                    count -= bytesRead;
                    _position += bytesRead;
                }

                return totalBytesRead;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                var totalBytesRead = 0;

                while (count > 0 && _currentStreamIndex < _streams.Count)
                {
                    var currentStream = _streams[_currentStreamIndex];
                    var bytesRead = await currentStream.ReadAsync(buffer, offset, count, cancellationToken);
                    if (bytesRead == 0)
                    {
                        _currentStreamIndex++;
                        continue;
                    }

                    totalBytesRead += bytesRead;
                    offset += bytesRead;
                    count -= bytesRead;
                    _position += bytesRead;
                }

                return totalBytesRead;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            _semaphore.Wait();
            try
            {
                switch (origin)
                {
                    case SeekOrigin.Begin:
                        _position = offset;
                        break;
                    case SeekOrigin.Current:
                        _position += offset;
                        break;
                    case SeekOrigin.End:
                        _position = _length.Value + offset;
                        break;
                }

                var remainingOffset = _position;

                for (_currentStreamIndex = 0; _currentStreamIndex < _streams.Count; _currentStreamIndex++)
                {
                    if (remainingOffset < _streams[_currentStreamIndex].Length)
                    {
                        _streams[_currentStreamIndex].Position = remainingOffset;
                        for (int i = _currentStreamIndex + 1; i < _streams.Count; i++)
                        {
                            _streams[i].Position = 0;
                        }
                        return _position;
                    }

                    remainingOffset -= _streams[_currentStreamIndex].Length;
                }

                if (_streams.Count > 0)
                {
                    var lastStream = _streams[_streams.Count - 1];
                    lastStream.Position = lastStream.Length;
                }

                _position = _length.Value;
                return _position;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask; // No-op since this stream is read-only.
        }

        public override async Task CopyToAsync(System.IO.Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                // Seek to the beginning of the CombinedStream.
                _position = 0;
                _currentStreamIndex = 0;
                foreach (var stream in _streams)
                {
                    stream.Position = 0;
                }

                // Copy the data.
                for (int i = _currentStreamIndex; i < _streams.Count; i++)
                {
                    await _streams[i].CopyToAsync(destination, bufferSize, cancellationToken);
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<bool> SeekToNextStreamAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                if (_currentStreamIndex >= _streams.Count - 1)
                {
                    return false;
                }

                _streams[_currentStreamIndex].Position = 0;
                _currentStreamIndex++;
                _position += _streams[_currentStreamIndex - 1].Length - _streams[_currentStreamIndex - 1].Position;
                _streams[_currentStreamIndex].Position = 0;
                return true;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<bool> SeekToPreviousStreamAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                if (_currentStreamIndex <= 0)
                {
                    return false;
                }

                var currentPosition = _streams[_currentStreamIndex].Position;
                _streams[_currentStreamIndex].Position = 0;
                _currentStreamIndex--;
                _position -= (_streams[_currentStreamIndex].Length + currentPosition);
                _streams[_currentStreamIndex].Position = 0;
                return true;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _shouldDisposeStreams)
            {
                _semaphore.Wait();
                try
                {
                    foreach (var stream in _streams)
                    {
                        stream.Dispose();
                    }
                }
                finally
                {
                    _semaphore.Release();
                }
            }

            base.Dispose(disposing);
        }

        public override async ValueTask DisposeAsync()
        {
            if (_shouldDisposeStreams)
            {
                await _semaphore.WaitAsync();
                try
                {
                    foreach (var stream in _streams)
                    {
                        if (stream is IAsyncDisposable asyncDisposable)
                        {
                            await asyncDisposable.DisposeAsync();
                        }
                        else
                        {
                            stream.Dispose();
                        }
                    }
                }
                finally
                {
                    _semaphore.Release();
                }
            }
        }
    }
}
