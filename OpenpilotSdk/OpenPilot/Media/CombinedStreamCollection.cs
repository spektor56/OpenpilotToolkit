using Nito.AsyncEx;
using OpenpilotSdk.Hardware;

namespace OpenpilotSdk.OpenPilot.Media
{
    public class CombinedStreamCollection : IAsyncDisposable
    {
        public Dictionary<CameraType, AsyncLazy<CombinedStream>> CameraStreams { get; }

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

                CameraStreams.Add(cameraType, new AsyncLazy<CombinedStream>(async () =>
                    new CombinedStream(await Task.WhenAll(videoStreamTask.ToArray()).ConfigureAwait(false))));
            }
        }

        public async ValueTask DisposeAsync()
        {
            foreach (var cameraStream in CameraStreams)
            {
                if (cameraStream.Value.IsStarted)
                {
                    var stream = await cameraStream.Value;
                    await stream.DisposeAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
