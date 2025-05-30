using Serilog;

namespace OpenpilotSdk.OpenPilot.Media
{
    /// <summary>
    /// Represents a stream that combines multiple input streams into a single, continuous stream.
    /// It allows reading and seeking across the concatenated streams as if they were one.
    /// </summary>
    public class CombinedStream : Stream
    {
        private readonly Stream[] _streams;
        private long _position;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private long[] _streamLengths;
        private long[] _cumulativeLengths;
        private readonly double _duration;
        private readonly bool _shouldDisposeStreams;

        /// <summary>
        /// Occurs when the <see cref="CurrentStreamIndex"/> changes, indicating a transition to a different underlying stream.
        /// </summary>
        public event Action<int>? CurrentStreamIndexChanged;

        private int _currentStreamIndex;
        /// <summary>
        /// Gets the index of the current underlying stream being read from or seeked within.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="CombinedStream"/> class.
        /// </summary>
        /// <param name="streams">The collection of streams to combine. All streams must be seekable.</param>
        /// <param name="shouldDisposeStreams">A value indicating whether the underlying streams should be disposed when this <see cref="CombinedStream"/> is disposed. Defaults to true.</param>
        /// <exception cref="ArgumentException">Thrown if any of the provided streams are not seekable.</exception>
        public CombinedStream(IEnumerable<Stream> streams, bool shouldDisposeStreams = true)
        {
            _streams = streams.ToArray();
            if (_streams.Any(s => !s.CanSeek))
                throw new ArgumentException("All streams must be seekable.", nameof(streams));

            _streamLengths = new long[_streams.Length];
            _cumulativeLengths = new long[_streams.Length];

            if (_streams.Length > 0)
            {
                for (int i = 0; i < _streams.Length; i++)
                {
                    _streamLengths[i] = _streams[i].Length;
                    if (i == 0)
                    {
                        _cumulativeLengths[i] = _streamLengths[i];
                    }
                    else
                    {
                        _cumulativeLengths[i] = _cumulativeLengths[i - 1] + _streamLengths[i];
                    }
                }
            }
            _shouldDisposeStreams = shouldDisposeStreams;
        }

        /// <summary>
        /// Gets the read-only list of underlying streams.
        /// </summary>
        public IReadOnlyList<Stream> Streams => _streams;

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading. Always true for <see cref="CombinedStream"/>.
        /// </summary>
        public override bool CanRead => true;

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking. Always true for <see cref="CombinedStream"/>.
        /// </summary>
        public override bool CanSeek => true;

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing. Always false for <see cref="CombinedStream"/>.
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        /// Gets the total length of the combined stream in bytes.
        /// </summary>
        public override long Length
        {
            get
            {
                if (_cumulativeLengths == null || _cumulativeLengths.Length == 0)
                {
                    return 0;
                }
                return _cumulativeLengths[_cumulativeLengths.Length - 1];
            }
        }

        /// <summary>
        /// Gets or sets the current position within the combined stream.
        /// Setting the position will attempt to seek to the specified offset from the beginning of the stream.
        /// </summary>
        public override long Position
        {
            get => _position;
            set
            {
                Seek(value, SeekOrigin.Begin);
                Log.Debug(string.Format("Position Set to: {0:#0.#}%", (decimal)value / Length * 100));
            }
        }

        /// <summary>
        /// This method is not supported by <see cref="CombinedStream"/> and does nothing.
        /// </summary>
        public override void Flush() { }

        /// <summary>
        /// Reads a sequence of bytes from the current combined stream and advances the position within the stream by the number of bytes read.
        /// If the end of one underlying stream is reached, reading continues from the beginning of the next stream.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between <paramref name="offset"/> and (<paramref name="offset"/> + <paramref name="count"/> - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the combined stream has been reached.</returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            Log.Debug("CombinedStream.Read: Starting read. CurrentStreamIndex: {_currentStreamIndex}, Count: {count}, Offset: {offset}", _currentStreamIndex, count, offset);
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
                            _position = Length;
                            break;
                        }
                        Log.Debug("CombinedStream.Read: Current stream exhausted. Advancing from index {PreviousStreamIndex} to {NextStreamIndex}", _currentStreamIndex, _currentStreamIndex + 1);
                        if (_streams[_currentStreamIndex + 1].Position != 0)
                        {
                            _streams[_currentStreamIndex + 1].Position = 0;
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

        /// <summary>
        /// Asynchronously reads a sequence of bytes from the current combined stream and advances the position within the stream by the number of bytes read.
        /// If the end of one underlying stream is reached, reading continues from the beginning of the next stream.
        /// </summary>
        /// <param name="buffer">The buffer to write the data into.</param>
        /// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin writing data from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous read operation. The value of the TResult parameter contains the total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the combined stream has been reached.</returns>
        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            Log.Debug("CombinedStream.ReadAsync: Starting read. CurrentStreamIndex: {_currentStreamIndex}, Count: {count}, Offset: {offset}", _currentStreamIndex, count, offset);
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
                            _position = Length;
                            break;
                        }
                        Log.Debug("CombinedStream.ReadAsync: Current stream exhausted. Advancing from index {PreviousStreamIndex} to {NextStreamIndex}", _currentStreamIndex, _currentStreamIndex + 1);
                        if (_streams[_currentStreamIndex + 1].Position != 0)
                        {
                            _streams[_currentStreamIndex + 1].Position = 0;
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

        /// <summary>
        /// Sets the position within the current combined stream. This involves identifying the correct underlying stream and setting its position.
        /// </summary>
        /// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
        /// <param name="origin">A value of type <see cref="SeekOrigin"/> indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the combined stream.</returns>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="origin"/> is invalid.</exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            Log.Debug("CombinedStream.Seek: Seeking with Offset: {offset}, Origin: {origin}", offset, origin);
            _semaphore.Wait();
            try
            {
                long currentTotalLength = this.Length;
                long newTargetPosition;

                switch (origin)
                {
                    case SeekOrigin.Begin:
                        newTargetPosition = offset;
                        break;
                    case SeekOrigin.Current:
                        newTargetPosition = _position + offset;
                        break;
                    case SeekOrigin.End:
                        newTargetPosition = currentTotalLength + offset;
                        break;
                    default:
                        throw new ArgumentException("Invalid seek origin.");
                }
                newTargetPosition = Math.Max(0, Math.Min(currentTotalLength, newTargetPosition));
                Log.Debug("CombinedStream.Seek: Calculated TargetPosition: {TargetPosition}", newTargetPosition);

                if (_streams.Length == 0)
                {
                    _position = 0;
                    CurrentStreamIndex = 0; // Or -1 if preferred, but property setter handles event
                    Log.Debug("CombinedStream.Seek: No streams. Position set to 0, CurrentStreamIndex to 0.");
                    return _position;
                }

                int targetStreamIndex;
                if (newTargetPosition == 0)
                {
                    targetStreamIndex = 0;
                }
                else
                {
                    int searchIndex = Array.BinarySearch(_cumulativeLengths, newTargetPosition);
                    if (searchIndex >= 0)
                    {
                        // Exact match on a cumulative length. targetPosition is the END of stream 'searchIndex'.
                        targetStreamIndex = searchIndex;
                    }
                    else
                    {
                        // No exact match. ~searchIndex is the index of the first element *larger* than targetPosition.
                        // This means targetPosition falls *within* the stream at index ~searchIndex.
                        targetStreamIndex = ~searchIndex;
                        // If targetPosition is greater than all cumulative lengths (e.g. targetPosition = this.Length),
                        // then ~searchIndex will be _streams.Length. Clamp it to the last valid index.
                        if (targetStreamIndex >= _streams.Length)
                        {
                            targetStreamIndex = _streams.Length - 1;
                        }
                    }
                }

                long positionInTargetStream;
                if (targetStreamIndex == 0)
                {
                    positionInTargetStream = newTargetPosition;
                }
                else
                {
                    positionInTargetStream = newTargetPosition - _cumulativeLengths[targetStreamIndex - 1];
                }

                // If the target position is the total length, ensure we are at the end of the last stream.
                if (newTargetPosition == currentTotalLength && _streams.Length > 0)
                {
                    targetStreamIndex = _streams.Length - 1;
                    positionInTargetStream = _streamLengths[targetStreamIndex];
                }

                Log.Debug("CombinedStream.Seek: TargetStreamIndex: {TargetStreamIndex}, PositionInTargetStream: {PositionInTargetStream}", targetStreamIndex, positionInTargetStream);

                for (int i = 0; i < _streams.Length; i++)
                {
                    if (i < targetStreamIndex)
                    {
                        _streams[i].Position = _streamLengths[i]; // End of this stream
                    }
                    else if (i == targetStreamIndex)
                    {
                        _streams[i].Position = positionInTargetStream;
                    }
                    else // i > targetStreamIndex
                    {
                        _streams[i].Position = 0; // Start of this stream
                    }
                }

                CurrentStreamIndex = targetStreamIndex;
                _position = newTargetPosition;

                Log.Debug("CombinedStream.Seek: Seek complete. Position: {Position}, CurrentStreamIndex: {CurrentStreamIndex}", _position, _currentStreamIndex);
                return _position;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// This method is not supported by <see cref="CombinedStream"/>.
        /// </summary>
        /// <param name="value">The desired length of the stream in bytes.</param>
        /// <exception cref="NotSupportedException">Always thrown.</exception>
        public override void SetLength(long value) => throw new NotSupportedException();

        /// <summary>
        /// This method is not supported by <see cref="CombinedStream"/>.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from <paramref name="buffer"/> to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        /// <exception cref="NotSupportedException">Always thrown.</exception>
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        /// <summary>
        /// Asynchronously clears all buffers for this stream and causes any buffered data to be written to the underlying device.
        /// This implementation is a no-op as <see cref="CombinedStream"/> is read-only.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous flush operation.</returns>
        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask; // No-op since this stream is read-only.
        }

        /// <summary>
        /// Asynchronously reads all the bytes from the current combined stream and writes them to another stream, using a specified buffer size and cancellation token.
        /// This operation resets the <see cref="Position"/> and <see cref="CurrentStreamIndex"/> to the beginning before copying.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="bufferSize">The size, in bytes, of the buffer. This value must be greater than zero.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        public override async Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
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
        /// <summary>
        /// Asynchronously seeks to the beginning of the next underlying stream in the <see cref="CombinedStream"/>.
        /// If currently at the last stream, this method does nothing and returns false.
        /// Updates <see cref="Position"/> and <see cref="CurrentStreamIndex"/> accordingly.
        /// </summary>
        /// <returns>A task that represents the asynchronous seek operation. The value of the TResult parameter is true if the seek was successful (i.e., not on the last stream); otherwise, false.</returns>
        public async Task<bool> SeekToNextStreamAsync()
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                int oldIndex = _currentStreamIndex;
                Log.Debug("CombinedStream.SeekToNextStreamAsync: Attempting to seek to next stream from index {CurrentStreamIndex}", oldIndex);

                if (oldIndex >= _streams.Length - 1)
                {
                    Log.Debug("CombinedStream.SeekToNextStreamAsync: Already at the last stream (index {StreamIndex}). No change.", oldIndex);
                    return false;
                }
                int newIndex = oldIndex + 1;

                _streams[oldIndex].Position = _streamLengths[oldIndex]; // Mark old stream as fully read
                _streams[newIndex].Position = 0;

                _position = _cumulativeLengths[oldIndex]; // Global position is end of oldIndex / start of newIndex
                CurrentStreamIndex = newIndex;
                Log.Debug("CombinedStream.SeekToNextStreamAsync: Advanced from stream index {OldStreamIndex} to {NewStreamIndex}. New position: {Position}", oldIndex, CurrentStreamIndex, _position);

                return true;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// <summary>
        /// Asynchronously seeks to the beginning of the previous underlying stream in the <see cref="CombinedStream"/>.
        /// If currently at the first stream, this method does nothing and returns false.
        /// Updates <see cref="Position"/> and <see cref="CurrentStreamIndex"/> accordingly.
        /// </summary>
        /// <returns>A task that represents the asynchronous seek operation. The value of the TResult parameter is true if the seek was successful (i.e., not on the first stream); otherwise, false.</returns>
        public async Task<bool> SeekToPreviousStreamAsync()
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                int oldIndex = _currentStreamIndex;
                Log.Debug("CombinedStream.SeekToPreviousStreamAsync: Attempting to seek to previous stream from index {CurrentStreamIndex}", oldIndex);

                if (oldIndex <= 0)
                {
                    Log.Debug("CombinedStream.SeekToPreviousStreamAsync: Already at the first stream (index {StreamIndex}). No change.", oldIndex);
                    return false;
                }
                int newIndex = oldIndex - 1;

                _streams[oldIndex].Position = 0; // Reset position of the stream we are leaving
                _streams[newIndex].Position = 0;

                _position = (newIndex == 0) ? 0 : _cumulativeLengths[newIndex - 1]; // Global position is start of newIndex
                CurrentStreamIndex = newIndex;
                Log.Debug("CombinedStream.SeekToPreviousStreamAsync: Advanced from stream index {OldStreamIndex} to {NewStreamIndex}. New position: {Position}", oldIndex, CurrentStreamIndex, _position);

                return true;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Asynchronously seeks to the beginning of a specific underlying stream by its index.
        /// Updates <see cref="Position"/> and <see cref="CurrentStreamIndex"/> accordingly.
        /// </summary>
        /// <param name="stream">The zero-based index of the stream to seek to.</param>
        /// <returns>A task that represents the asynchronous seek operation. The value of the TResult parameter is true if the seek was successful; otherwise, false (though currently always true if no exception is thrown).</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the specified <paramref name="stream"/> index is invalid.</exception>
        public async Task<bool> SeekToStreamAsync(int stream)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                int oldIndex = _currentStreamIndex;
                Log.Debug("CombinedStream.SeekToStreamAsync: Attempting to seek from stream index {OldStreamIndex} to target index {TargetStreamIndex}", oldIndex, stream);

                if (stream < 0 || stream >= _streams.Length)
                {
                    throw new IndexOutOfRangeException($"Invalid target stream index {stream}. Must be between 0 and {_streams.Length - 1}.");
                }

                if (oldIndex != stream && oldIndex >= 0 && oldIndex < _streams.Length)
                {
                    _streams[oldIndex].Position = 0; // Reset position of the stream we are leaving
                }
                _streams[stream].Position = 0;

                _position = (stream == 0) ? 0 : _cumulativeLengths[stream - 1]; // Global position is start of target stream
                CurrentStreamIndex = stream;
                Log.Debug("CombinedStream.SeekToStreamAsync: Successfully seeked from stream index {OldStreamIndex} to {NewStreamIndex}. New position: {Position}", oldIndex, CurrentStreamIndex, _position);

                return true;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="CombinedStream"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
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
                            Log.Warning(ex, "Error disposing stream {StreamType}", stream.GetType().FullName);
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

        /// <summary>
        /// Asynchronously releases the unmanaged resources used by the <see cref="CombinedStream"/> and optionally releases the managed resources.
        /// Underlying streams are disposed if <c>_shouldDisposeStreams</c> was set to true during construction.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous dispose operation.</returns>
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
                            Log.Warning(ex, "Error disposing stream {StreamType} during async dispose", stream.GetType().FullName);
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