﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenpilotToolkit.Stream
{
    public class CombinedStream : System.IO.Stream
    {
        private readonly System.IO.Stream[] _streams;
        private long _position;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly Lazy<long> _length;
        private readonly bool _shouldDisposeStreams;

        public event Action<int> CurrentStreamIndexChanged;

        private int _currentStreamIndex;
        public int CurrentStreamIndex
        {
            get => _currentStreamIndex;
            private set
            {
                if (_currentStreamIndex != value)
                {
                    _currentStreamIndex = value;
                    CurrentStreamIndexChanged?.Invoke(_currentStreamIndex);
                }
            }
        }

        public CombinedStream(IEnumerable<System.IO.Stream> streams, bool shouldDisposeStreams = true)
        {
            _streams = streams.ToArray();
            if (_streams.Any(s => !s.CanSeek))
                throw new ArgumentException("All streams must be seekable.");
            _length = new Lazy<long>(() => _streams.Sum(s => s.Length));
            _shouldDisposeStreams = shouldDisposeStreams;
        }

        public IReadOnlyList<System.IO.Stream> Streams => _streams;

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

                while (count > 0 && _currentStreamIndex < _streams.Length)
                {
                    var currentStream = _streams[_currentStreamIndex];
                    var bytesRead = currentStream.Read(buffer, offset, count);
                    if (bytesRead == 0)
                    {
                        if (_currentStreamIndex == _streams.Length - 1)
                        {
                            break;
                        }
                        CurrentStreamIndex++;
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
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var totalBytesRead = 0;

                while (count > 0 && _currentStreamIndex < _streams.Length)
                {
                    var currentStream = _streams[_currentStreamIndex];
                    var bytesRead = await currentStream.ReadAsync(buffer.AsMemory(offset, count), cancellationToken).ConfigureAwait(false);
                    if (bytesRead == 0)
                    {
                        if (_currentStreamIndex == _streams.Length - 1)
                        {
                            _position = _length.Value;
                            break;
                        }
                        CurrentStreamIndex++;
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
                long position;

                switch (origin)
                {
                    case SeekOrigin.Begin:
                        position = Math.Max(0, Math.Min(_length.Value, offset));
                        break;
                    case SeekOrigin.Current:
                        position = Math.Max(0, Math.Min(_length.Value, _position + offset));
                        break;
                    case SeekOrigin.End:
                        position = Math.Max(0, Math.Min(_length.Value, _length.Value + offset));
                        break;
                    default:
                        throw new ArgumentException("Invalid seek origin.");
                }

                var remainingOffset = position;

                for (CurrentStreamIndex = 0; _currentStreamIndex < _streams.Length; CurrentStreamIndex++)
                {
                    if (remainingOffset < _streams[_currentStreamIndex].Length)
                    {
                        _streams[_currentStreamIndex].Position = remainingOffset;
                        for (int i = _currentStreamIndex + 1; i < _streams.Length; i++)
                        {
                            _streams[i].Position = 0;
                        }
                        _position = position;
                        return _position;
                    }

                    remainingOffset -= _streams[_currentStreamIndex].Length;
                }

                if (_streams.Length > 0)
                {
                    var lastStream = _streams[_streams.Length - 1];
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
            await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                _position = 0;
                CurrentStreamIndex = 0;
                foreach (var stream in _streams)
                {
                    stream.Position = 0;
                }

                for (int i = _currentStreamIndex; i < _streams.Length; i++)
                {
                    await _streams[i].CopyToAsync(destination, bufferSize, cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Seeks to the next stream in the CombinedStream.
        /// </summary>
        /// <returns>True if the next stream is successfully selected, false if there are no more streams.</returns>
        public async Task<bool> SeekToNextStreamAsync()
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                if (_currentStreamIndex >= _streams.Length - 1)
                {
                    return false;
                }

                _position += _streams[_currentStreamIndex].Length - _streams[_currentStreamIndex].Position;

                _streams[_currentStreamIndex].Position = 0;
                _streams[_currentStreamIndex + 1].Position = 0;

                CurrentStreamIndex++;

                return true;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Seeks to the previous stream in the CombinedStream.
        /// </summary>
        /// <returns>True if the previous stream is successfully selected, false if there are no previous streams.</returns>
        public async Task<bool> SeekToPreviousStreamAsync()
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                if (_currentStreamIndex <= 0)
                {
                    return false;
                }

                _position -= (_streams[_currentStreamIndex].Position + _streams[_currentStreamIndex - 1].Length);

                _streams[_currentStreamIndex].Position = 0;
                _streams[_currentStreamIndex - 1].Position = 0;

                CurrentStreamIndex--;

                return true;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<bool> SeekToStreamAsync(int stream)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                if (stream > _streams.Length - 1 || stream < 0)
                {
                    throw new IndexOutOfRangeException("Invalid Index");
                }

                long position = 0;
                for (int i = 0; i < stream; i++)
                {
                    position += _streams[i].Length;
                }

                _streams[_currentStreamIndex].Position = 0;
                _streams[stream].Position = 0;
                
                _position = position;
                CurrentStreamIndex = stream;

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
                        try
                        {
                            stream.Dispose();
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error disposing stream: {ex}");
                        }
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
                await _semaphore.WaitAsync().ConfigureAwait(false);
                try
                {
                    foreach (var stream in _streams)
                    {
                        try
                        {
                            if (stream is IAsyncDisposable asyncDisposable)
                            {
                                await asyncDisposable.DisposeAsync().ConfigureAwait(false);
                            }
                            else
                            {
                                stream.Dispose();
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error disposing stream: {ex}");
                        }
                    }
                }
                finally
                {
                    _semaphore.Release();
                }
            }

            await base.DisposeAsync().ConfigureAwait(false);
        }
    }
}