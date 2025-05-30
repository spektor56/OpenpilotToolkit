using Nito.AsyncEx;
using OpenpilotSdk.Hardware;
using Serilog;

namespace OpenpilotSdk.OpenPilot.Media
{
    /// <summary>
    /// Manages a collection of <see cref="CombinedStream"/> instances, typically one for each camera type available in a route.
    /// Streams are loaded asynchronously and on-demand using <see cref="AsyncLazy{T}"/>.
    /// </summary>
    public class CombinedStreamCollection : IAsyncDisposable
    {
        /// <summary>
        /// Gets a dictionary where keys are <see cref="CameraType"/> and values are <see cref="AsyncLazy{T}"/> instances
        /// that provide access to a <see cref="CombinedStream"/> for that camera type.
        /// The <see cref="CombinedStream"/> is initialized asynchronously when first awaited.
        /// </summary>
        public Dictionary<CameraType, AsyncLazy<CombinedStream>> CameraStreams { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CombinedStreamCollection"/> class.
        /// It populates the <see cref="CameraStreams"/> dictionary based on the available cameras in the <paramref name="openpilotDevice"/>
        /// and the segments present in the <paramref name="route"/>.
        /// </summary>
        /// <param name="openpilotDevice">The Openpilot device from which to read video stream segments.</param>
        /// <param name="route">The route containing segment information for various camera types.</param>
        public CombinedStreamCollection(OpenpilotDevice openpilotDevice, Route route)
        {
            CameraStreams = new Dictionary<CameraType, AsyncLazy<CombinedStream>>();

            foreach (var cameraType in openpilotDevice.Cameras)
            {
                AddCameraStream(route, openpilotDevice, cameraType.Key);
            }
        }

        private void AddCameraStream(Route route, OpenpilotDevice openpilotDevice, CameraType cameraType)
        {
            if (route.Segments.Any(segment => segment.RawVideoSegments.ContainsKey(cameraType)))
            {
                var videoStreamTask = route.Segments
                    .Where(segment => segment.RawVideoSegments.ContainsKey(cameraType))
                    .Select(segment => openpilotDevice.OpenReadAsync(segment.RawVideoSegments[cameraType].File.FullName));

                var asyncLazyStream = new AsyncLazy<CombinedStream>(async () =>
                    new CombinedStream(await Task.WhenAll(videoStreamTask.ToArray()).ConfigureAwait(false))
                );

                // Attach a continuation to log errors
                asyncLazyStream.Task.ContinueWith(t =>
                {
                    if (t.IsFaulted && t.Exception != null)
                    {
                        Log.Error(t.Exception, "Failed to initialize CombinedStream for camera type {CameraType}", cameraType);
                    }
                }, TaskContinuationOptions.OnlyOnFaulted);

                CameraStreams.Add(cameraType, asyncLazyStream);
            }
        }

        /// <summary>
        /// Asynchronously disposes of all initialized <see cref="CombinedStream"/> instances managed by this collection.
        /// If a <see cref="CombinedStream"/> was never awaited (and thus not initialized), it will not be disposed.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous dispose operation.</returns>
        public async ValueTask DisposeAsync()
        {
            foreach (var cameraStream in CameraStreams)
            {
                if (cameraStream.Value.IsStarted)
                {
                    var stream = await cameraStream.Value.ConfigureAwait(false);
                    await stream.DisposeAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
