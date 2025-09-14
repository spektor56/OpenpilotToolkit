using Nito.AsyncEx;
using OpenpilotSdk.Hardware;
using System.Collections.Frozen;
using System.Runtime.CompilerServices;

namespace OpenpilotSdk.OpenPilot.Media
{
    /// <summary>
    /// Manages a collection of <see cref="CombinedStream"/> instances, typically one for each camera type available in a route.
    /// Streams are loaded asynchronously and on-demand using <see cref="AsyncLazy{T}"/>.
    /// </summary>
    public sealed class CombinedStreamCollection : IAsyncDisposable
    {
        /// <summary>
        /// Gets a frozen dictionary where keys are <see cref="CameraType"/> and values are <see cref="AsyncLazy{T}"/> instances
        /// that provide access to a <see cref="CombinedStream"/> for that camera type.
        /// The <see cref="CombinedStream"/> is initialized asynchronously when first awaited.
        /// </summary>
        public FrozenDictionary<CameraType, AsyncLazy<CombinedStream>> CameraStreams { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CombinedStreamCollection"/> class.
        /// It populates the <see cref="CameraStreams"/> dictionary based on the available cameras in the <paramref name="openpilotDevice"/>
        /// and the segments present in the <paramref name="route"/>.
        /// </summary>
        /// <param name="openpilotDevice">The Openpilot device from which to read video stream segments.</param>
        /// <param name="route">The route containing segment information for various camera types.</param>
        /// <param name="seekToKeyFrames">When seeking the read operation will skip to the nearest keyframe</param>
        public CombinedStreamCollection(OpenpilotDevice openpilotDevice, Route route, bool seekToKeyFrames)
        {
            var streamsDictionary = new Dictionary<CameraType, AsyncLazy<CombinedStream>>(openpilotDevice.Cameras.Count);

            foreach (var (cameraType, _) in openpilotDevice.Cameras)
            {
                if (route.Segments.Any(segment => segment.RawVideoSegments.ContainsKey(cameraType)))
                {
                    streamsDictionary[cameraType] = CreateAsyncLazyStream(openpilotDevice, cameraType, route, seekToKeyFrames);
                }
            }

            CameraStreams = streamsDictionary.ToFrozenDictionary();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncLazy<CombinedStream> CreateAsyncLazyStream(
            OpenpilotDevice openpilotDevice,
            CameraType cameraType,
            Route route,
            bool seekToKeyFrames)
        {
            var asyncLazyStream = new AsyncLazy<CombinedStream>(async () =>
            {
                var videoStreamTasks = route.Segments
                    .Where(segment => segment.RawVideoSegments.ContainsKey(cameraType))
                    .Select(segment => openpilotDevice.OpenReadAsync(segment.RawVideoSegments[cameraType].File.FullName))
                    .ToArray();

                var streams = await Task.WhenAll(videoStreamTasks).ConfigureAwait(false);
                return new CombinedStream(streams,true, seekToKeyFrames);
            });

            _ = asyncLazyStream.Task.ContinueWith(
                static (task, state) =>
                {
                    // Silently ignore - exceptions will be handled by consumers
                },
                cameraType,
                TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously
            );

            return asyncLazyStream;
        }

        /// <summary>
        /// Asynchronously disposes of all initialized <see cref="CombinedStream"/> instances managed by this collection.
        /// If a <see cref="CombinedStream"/> was never awaited (and thus not initialized), it will not be disposed.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous dispose operation.</returns>
        public async ValueTask DisposeAsync()
        {
            if (CameraStreams.Count == 0)
                return;

            var disposalTasks = new ValueTask[CameraStreams.Count];
            var taskIndex = 0;

            foreach (var (_, asyncLazyStream) in CameraStreams)
            {
                if (asyncLazyStream.IsStarted && asyncLazyStream.Task.IsCompletedSuccessfully)
                {
                    disposalTasks[taskIndex++] = DisposeStreamAsync(asyncLazyStream);
                }
            }

            if (taskIndex > 0)
            {
                var activeTasks = taskIndex == disposalTasks.Length
                    ? disposalTasks
                    : disposalTasks.AsSpan(0, taskIndex).ToArray();

                await Task.WhenAll(activeTasks.Select(static vt => vt.AsTask())).ConfigureAwait(false);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            static async ValueTask DisposeStreamAsync(AsyncLazy<CombinedStream> asyncLazyStream)
            {
                var stream = await asyncLazyStream.ConfigureAwait(false);
                await stream.DisposeAsync().ConfigureAwait(false);
            }
        }

        /*
        public async Task PopulateKeyframes()
        {
            foreach (var cameraStream in CameraStreams)
            {
                (await cameraStream.Value.ConfigureAwait(false)).SeekToKeyframes = seekToKeyframes;
            }
        }
        */

        public async Task SetSeekToKeyframesAsync(bool seekToKeyframes)
        {
            foreach (var cameraStream in CameraStreams)
            {
                (await cameraStream.Value.ConfigureAwait(false)).SeekToKeyframes = seekToKeyframes;
            }
        }
    }
}