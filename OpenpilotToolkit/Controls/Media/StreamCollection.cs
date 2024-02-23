using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nito.AsyncEx;
using Nito.Disposables;
using OpenpilotSdk.Hardware;
using OpenpilotSdk.OpenPilot;
using OpenpilotToolkit.Stream;

namespace OpenpilotToolkit.Controls.Media
{
    internal class CombinedStreamCollection : IAsyncDisposable
    {
        public Dictionary<CameraType, AsyncLazy<CombinedStream>> CameraStreams { get; }

        public CombinedStreamCollection(OpenpilotDevice openpilotDevice, Drive drive)
        {
            var cameraStreams = new Dictionary<CameraType, AsyncLazy<CombinedStream>>();

            if (drive.Segments.Any(segment => segment.FrontVideo != null))
            {
                var frontVideoStreamTask = drive.Segments.Where(segment => segment.FrontVideo != null).Select((segment) => openpilotDevice.OpenReadAsync(segment.FrontVideo
                    .File
                    .FullName));
                cameraStreams.Add(CameraType.Front,
                    new AsyncLazy<CombinedStream>(async () =>
                        new CombinedStream(await Task.WhenAll(frontVideoStreamTask.ToArray()))));
            }
            if (drive.Segments.Any(segment => segment.WideVideo != null))
            {
                var wideVideoStreamTask = drive.Segments.Where(segment => segment.WideVideo != null).Select((segment) => openpilotDevice.OpenReadAsync(segment.WideVideo
                    .File
                    .FullName));
                cameraStreams.Add(CameraType.Wide,
                    new AsyncLazy<CombinedStream>(async () =>
                        new CombinedStream(await Task.WhenAll(wideVideoStreamTask.ToArray()))));
            }
            if (drive.Segments.Any(segment => segment.DriverVideo != null))
            {
                var driverVideoStreamTask = drive.Segments.Where(segment => segment.DriverVideo != null).Select((segment) => openpilotDevice.OpenReadAsync(segment.DriverVideo
                    .File
                    .FullName));
                cameraStreams.Add(CameraType.Driver,
                    new AsyncLazy<CombinedStream>(async () =>
                        new CombinedStream(await Task.WhenAll(driverVideoStreamTask.ToArray()))));
            }

            CameraStreams = cameraStreams;
        }

        public async ValueTask DisposeAsync()
        {
            foreach (var cameraStream in CameraStreams)
            {
                if (cameraStream.Value.IsStarted)
                {
                    var stream = await cameraStream.Value;
                    await stream.DisposeAsync();
                }
                
            }
        }
    }
}
