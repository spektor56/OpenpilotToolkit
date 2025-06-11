using Serilog;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OpenpilotSdk.OpenPilot.Media
{
    public sealed class CombinedStream : Stream
    {
        private readonly SemaphoreSlim _asyncLock = new(1, 1);
        private readonly bool _shouldDisposeStreams;
        private readonly Stream[] _streams;
        private readonly long[] _streamStartPositions;
        private readonly Lock _syncLock = new();
        private bool _seekToKeyframe;
        private bool _seekToKeyframes;
        private readonly byte[] _keyframeBuffer = new byte[1000000];
        private static readonly byte[] HevcSyncSequence = [0x00, 0x00, 0x00, 0x01, 0x26, 0x01];
        private int _currentStreamIndex;
        private long _globalPosition;

        public CombinedStream(IEnumerable<Stream> streams, bool shouldDisposeStreams = true, bool seekToKeyframes = true)
        {
            ArgumentNullException.ThrowIfNull(streams, nameof(streams));

            _streams = streams.ToArray();
            if (_streams.Length == 0)
            {
                throw new ArgumentException("At least one stream is required.", nameof(streams));
            }

            foreach (var stream in _streams.AsSpan())
            {
                if (!stream.CanSeek)
                {
                    throw new ArgumentException("All streams must be seekable.");
                }
            }

            _shouldDisposeStreams = shouldDisposeStreams;
            _seekToKeyframes = seekToKeyframes;

            _streamStartPositions = new long[_streams.Length];
            long totalLength = 0;

            for (var i = 0; i < _streams.Length; i++)
            {
                _streamStartPositions[i] = totalLength;
                totalLength += _streams[i].Length;
            }

            Length = totalLength;
        }

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

        public ReadOnlySpan<Stream> Streams => _streams.AsSpan();

        public override bool CanRead => true;
        public override bool CanSeek => true;
        public override bool CanWrite => false;
        public override long Length { get; }

        public override long Position
        {
            get => _globalPosition;
            set
            {
                if (value == _globalPosition)
                    return;

                var offsetFromCurrent = value - _globalPosition;
                var offsetFromEnd = value - Length;

                if (Math.Abs(value) <= Math.Abs(offsetFromCurrent) && Math.Abs(value) <= Math.Abs(offsetFromEnd))
                {
                    Seek(value, SeekOrigin.Begin);
                }
                else if (Math.Abs(offsetFromCurrent) <= Math.Abs(offsetFromEnd))
                {
                    Seek(offsetFromCurrent, SeekOrigin.Current);
                }
                else
                {
                    Seek(offsetFromEnd, SeekOrigin.End);
                }
            }
        }

        public bool SeekToKeyframes
        {
            get => _seekToKeyframes;
            set
            {
                if (!value)
                {
                    _seekToKeyframe = false;
                }
                
                _seekToKeyframes = value;
            }
        }

        public event Action<int>? CurrentStreamIndexChanged;

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return ReadCore(buffer.AsSpan(offset, count));
        }

        public override int Read(Span<byte> buffer)
        {
            return ReadCore(buffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int ReadCore(Span<byte> buffer)
        {
            if (buffer.IsEmpty)
            {
                return 0;
            }

            lock (_syncLock)
            {
                return ReadCoreUnsafe(buffer);
            }
        }

        private int ReadCoreUnsafe(Span<byte> buffer)
        {
            if (_seekToKeyframe)
            {
                _seekToKeyframe = false;
                SeekToNextKeyframe();
            }

            var totalBytesRead = 0;
            var remainingCount = buffer.Length;

            while (remainingCount > 0 && _currentStreamIndex < _streams.Length)
            {
                var currentStream = _streams[_currentStreamIndex];
                var bytesToRead = Math.Min(remainingCount,
                    (int)Math.Min(currentStream.Length - currentStream.Position, remainingCount));

                if (bytesToRead <= 0)
                {
                    if (!MoveToNextStreamUnsafe())
                    {
                        break;
                    }

                    continue;
                }

                var currentBuffer = buffer.Slice(totalBytesRead, bytesToRead);
                var bytesRead = currentStream.Read(currentBuffer);

                if (bytesRead == 0)
                {
                    if (!MoveToNextStreamUnsafe())
                    {
                        break;
                    }

                    continue;
                }

                totalBytesRead += bytesRead;
                remainingCount -= bytesRead;
                _globalPosition += bytesRead;
            }

            return totalBytesRead;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count,
            CancellationToken cancellationToken = default)
        {
            return await ReadAsync(buffer.AsMemory(offset, count), cancellationToken).ConfigureAwait(false);
        }

        public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        {
            if (buffer.IsEmpty)
            {
                return 0;
            }

            await _asyncLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                return await ReadAsyncCoreUnsafe(buffer, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _asyncLock.Release();
            }
        }

        private async ValueTask<int> ReadAsyncCoreUnsafe(Memory<byte> buffer, CancellationToken cancellationToken)
        {
            var totalBytesRead = 0;
            var remainingCount = buffer.Length;

            while (remainingCount > 0 && _currentStreamIndex < _streams.Length &&
                   !cancellationToken.IsCancellationRequested)
            {
                var currentStream = _streams[_currentStreamIndex];
                var bytesToRead = Math.Min(remainingCount,
                    (int)Math.Min(currentStream.Length - currentStream.Position, remainingCount));

                if (bytesToRead <= 0)
                {
                    if (!MoveToNextStreamUnsafe())
                    {
                        break;
                    }

                    continue;
                }

                var currentBuffer = buffer.Slice(totalBytesRead, bytesToRead);
                var bytesRead = await currentStream.ReadAsync(currentBuffer, cancellationToken).ConfigureAwait(false);

                if (bytesRead == 0)
                {
                    if (!MoveToNextStreamUnsafe())
                    {
                        break;
                    }

                    continue;
                }

                totalBytesRead += bytesRead;
                remainingCount -= bytesRead;
                _globalPosition += bytesRead;
            }

            return totalBytesRead;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool MoveToNextStreamUnsafe()
        {
            if (_currentStreamIndex >= _streams.Length - 1)
            {
                _globalPosition = Length;
                return false;
            }

            var nextIndex = _currentStreamIndex + 1;
            if (_streams[nextIndex].Position != 0)
            {
                _streams[nextIndex].Position = 0;
            }

            _globalPosition = _streamStartPositions[nextIndex];
            CurrentStreamIndex = nextIndex;
            return true;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            lock (_syncLock)
            {
                return SeekCoreUnsafe(offset, origin);
            }
        }

        private long SeekCoreUnsafe(long offset, SeekOrigin origin)
        {
            var targetPosition = origin switch
            {
                SeekOrigin.Begin => Math.Clamp(offset, 0, Length),
                SeekOrigin.Current => Math.Clamp(_globalPosition + offset, 0, Length),
                SeekOrigin.End => Math.Clamp(Length + offset, 0, Length),
                _ => throw new ArgumentException("Invalid seek origin.", nameof(origin))
            };

            if (targetPosition == _globalPosition)
            {
                return _globalPosition;
            }

            var streamIndex = FindStreamIndex(targetPosition);
            var localOffset = targetPosition - _streamStartPositions[streamIndex];

            if (_seekToKeyframes)
            {
                if (localOffset != 0)
                {
                    _seekToKeyframe = true;
                }
            }

            _streams[streamIndex].Position = localOffset;

            for (var i = streamIndex + 1; i < _streams.Length; i++)
            {
                if (_streams[i].Position != 0)
                {
                    _streams[i].Position = 0;
                }
            }

            _globalPosition = targetPosition;
            CurrentStreamIndex = streamIndex;

            return _globalPosition;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int FindStreamIndex(long targetPosition)
        {
            var streamPositions = _streamStartPositions.AsSpan();
            var index = streamPositions.BinarySearch(targetPosition);

            if (index >= 0)
            {
                return index;
            }

            var insertionPoint = ~index;
            return Math.Max(0, insertionPoint - 1);
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public override async Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            await _asyncLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                _globalPosition = 0;
                CurrentStreamIndex = 0;

                for (var i = 0; i < _streams.Length; i++)
                {
                    if (_streams[i].Position != 0)
                    {
                        _streams[i].Position = 0;
                    }
                }

                for (var i = 0; i < _streams.Length; i++)
                {
                    CurrentStreamIndex = i;
                    await _streams[i].CopyToAsync(destination, bufferSize, cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                _asyncLock.Release();
            }
        }

        /// <summary>
        ///     Seeks to the next stream in the CombinedStream.
        /// </summary>
        /// <returns>True if the next stream is successfully selected, false if there are no more streams.</returns>
        public ValueTask<bool> SeekToNextStreamAsync()
        {
            lock (_syncLock)
            {
                if (_currentStreamIndex >= _streams.Length - 1)
                {
                    return ValueTask.FromResult(false);
                }

                // Calculate new position
                _globalPosition = _streamStartPositions[_currentStreamIndex + 1];

                // Reset stream positions
                _streams[_currentStreamIndex].Position = 0;
                _streams[_currentStreamIndex + 1].Position = 0;

                CurrentStreamIndex++;
                return ValueTask.FromResult(true);
            }
        }

        /// <summary>
        ///     Seeks to the previous stream in the CombinedStream.
        /// </summary>
        /// <returns>True if the previous stream is successfully selected, false if there are no previous streams.</returns>
        public ValueTask<bool> SeekToPreviousStreamAsync()
        {
            lock (_syncLock)
            {
                if (_currentStreamIndex <= 0)
                {
                    return ValueTask.FromResult(false);
                }

                // Calculate new position
                _globalPosition = _streamStartPositions[_currentStreamIndex - 1];

                // Reset stream positions
                _streams[_currentStreamIndex].Position = 0;
                _streams[_currentStreamIndex - 1].Position = 0;

                CurrentStreamIndex--;
                return ValueTask.FromResult(true);
            }
        }

        public ValueTask<bool> SeekToStreamAsync(int streamIndex)
        {
            lock (_syncLock)
            {
                if (streamIndex < 0 || streamIndex >= _streams.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(streamIndex), "Invalid stream index");
                }

                // Set position to start of target stream
                _globalPosition = _streamStartPositions[streamIndex];

                // Reset current and target stream positions
                if (_currentStreamIndex < _streams.Length)
                {
                    _streams[_currentStreamIndex].Position = 0;
                }

                _streams[streamIndex].Position = 0;

                CurrentStreamIndex = streamIndex;
                return ValueTask.FromResult(true);
            }
        }

        private void SeekToNextKeyframe()
        {
            ref var currentStream = ref _streams[_currentStreamIndex];
            var bufferSpan = _keyframeBuffer.AsSpan();

            while (currentStream.Position < (currentStream.Length - (HevcSyncSequence.Length - 1)))
            {
                var bytesToRead = Math.Min(_keyframeBuffer.Length, (int)(currentStream.Length - currentStream.Position));
                var bytesRead = currentStream.Read(bufferSpan.Slice(0, bytesToRead));

                if (bytesRead == 0)
                {
                    MoveToNextStreamUnsafe();
                    return;
                }
                var searchSpan = bufferSpan.Slice(0, bytesRead);
                var index = searchSpan.IndexOf(HevcSyncSequence);

                if (index >= 0)
                {
                    currentStream.Position -= (bytesRead - index);
                    _globalPosition = _streamStartPositions[_currentStreamIndex] + currentStream.Position;
                    return;
                }

                if (bytesToRead == _keyframeBuffer.Length && currentStream.Position < (currentStream.Length - (HevcSyncSequence.Length - 1)))
                {
                    currentStream.Position -= (HevcSyncSequence.Length - 1);
                }
                else
                {
                    MoveToNextStreamUnsafe();
                    return;
                }
            }

            MoveToNextStreamUnsafe();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _shouldDisposeStreams)
            {
                lock (_syncLock)
                {
                    foreach (var stream in _streams.AsSpan())
                    {
                        try
                        {
                            stream.Dispose();
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error disposing stream: {ex}");
                        }
                    }
                }
            }

            _asyncLock.Dispose();
            base.Dispose(disposing);
        }

        public override async ValueTask DisposeAsync()
        {
            if (_shouldDisposeStreams)
            {
                await _asyncLock.WaitAsync().ConfigureAwait(false);
                try
                {
                    // Use array iteration instead of Span in async method
                    for (var i = 0; i < _streams.Length; i++)
                    {
                        try
                        {
                            if (_streams[i] is IAsyncDisposable asyncDisposable)
                            {
                                await asyncDisposable.DisposeAsync().ConfigureAwait(false);
                            }
                            else
                            {
                                _streams[i].Dispose();
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error disposing stream: {ex}");
                        }
                    }
                }
                finally
                {
                    _asyncLock.Release();
                }
            }

            _asyncLock.Dispose();
            await base.DisposeAsync().ConfigureAwait(false);
        }
    }
}