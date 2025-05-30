using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace OpenpilotSdk.OpenPilot.Media
{
    public sealed class CombinedStream : Stream
    {
        private readonly SemaphoreSlim _asyncLock = new(1, 1); // For async operations
        private readonly bool _shouldDisposeStreams;
        private readonly Stream[] _streams;
        private readonly long[] _streamStartPositions; // Precomputed cumulative positions for O(log n) seeking
        private readonly Lock _syncLock = new(); // C# 13 Lock type for synchronous operations

        private int _currentStreamIndex;
        private long _position;

        public CombinedStream(IEnumerable<Stream> streams, bool shouldDisposeStreams = true)
        {
            _streams = streams.ToArray();
            if (_streams.Length == 0)
            {
                throw new ArgumentException("At least one stream is required.", nameof(streams));
            }

            // Check all streams are seekable in one pass
            foreach (var stream in _streams.AsSpan())
            {
                if (!stream.CanSeek)
                {
                    throw new ArgumentException("All streams must be seekable.");
                }
            }

            _shouldDisposeStreams = shouldDisposeStreams;

            // Precompute cumulative positions for O(log n) seeking
            _streamStartPositions = new long[_streams.Length];
            long cumulativeLength = 0;

            for (var i = 0; i < _streams.Length; i++)
            {
                _streamStartPositions[i] = cumulativeLength;
                cumulativeLength += _streams[i].Length;
            }

            Length = cumulativeLength;
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
            get => _position;
            set => Seek(value, SeekOrigin.Begin);
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
            var totalBytesRead = 0;
            var remainingCount = buffer.Length;

            while (remainingCount > 0 && _currentStreamIndex < _streams.Length)
            {
                var currentStream = _streams[_currentStreamIndex];
                var bytesToRead = Math.Min(remainingCount,
                    (int)Math.Min(currentStream.Length - currentStream.Position, remainingCount));

                if (bytesToRead <= 0)
                {
                    // Move to next stream
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
                _position += bytesRead;
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
                _position += bytesRead;
            }

            return totalBytesRead;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool MoveToNextStreamUnsafe()
        {
            if (_currentStreamIndex >= _streams.Length - 1)
            {
                _position = Length;
                return false;
            }

            // Ensure next stream starts at position 0
            var nextIndex = _currentStreamIndex + 1;
            if (_streams[nextIndex].Position != 0)
            {
                _streams[nextIndex].Position = 0;
            }

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
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var targetPosition = origin switch
            {
                SeekOrigin.Begin => Math.Clamp(offset, 0, Length),
                SeekOrigin.Current => Math.Clamp(_position + offset, 0, Length),
                SeekOrigin.End => Math.Clamp(Length + offset, 0, Length),
                _ => throw new ArgumentException("Invalid seek origin.", nameof(origin))
            };

            if (targetPosition == _position)
            {
                return _position;
            }

            // Binary search to find the correct stream - O(log n) instead of O(n)
            var streamIndex = FindStreamIndex(targetPosition);
            var localOffset = targetPosition - _streamStartPositions[streamIndex];

            // Set position in target stream
            _streams[streamIndex].Position = localOffset;

            // Reset positions in streams after the target
            for (var i = streamIndex + 1; i < _streams.Length; i++)
            {
                if (_streams[i].Position != 0)
                {
                    _streams[i].Position = 0;
                }
            }

            _position = targetPosition;
            CurrentStreamIndex = streamIndex;

            stopwatch.Stop();
            Debug.Print("EX:" + stopwatch.ElapsedMilliseconds);
            return _position;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int FindStreamIndex(long targetPosition)
        {
            // Use built-in binary search - returns bitwise complement of next larger element if not found
            var streamPositions = _streamStartPositions.AsSpan();
            var index = streamPositions.BinarySearch(targetPosition);

            if (index >= 0)
            {
                // Exact match found
                return index;
            }

            // Not found - get the index of the stream that should contain this position
            var insertionPoint = ~index;
            // We want the stream before the insertion point (since we're looking for the stream that contains this position)
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
                // Reset to beginning
                _position = 0;
                CurrentStreamIndex = 0;

                // Reset all stream positions - use array iteration instead of Span in async method
                for (var i = 0; i < _streams.Length; i++)
                {
                    if (_streams[i].Position != 0)
                    {
                        _streams[i].Position = 0;
                    }
                }

                // Copy each stream sequentially
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
                _position = _streamStartPositions[_currentStreamIndex + 1];

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
                _position = _streamStartPositions[_currentStreamIndex - 1];

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
                _position = _streamStartPositions[streamIndex];

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