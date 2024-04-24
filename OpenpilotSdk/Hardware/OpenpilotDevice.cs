using System.Collections.Immutable;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using FFMpegCore;
using GeoCoordinatePortable;
using NetTopologySuite.IO;
using OpenpilotSdk.Git;
using OpenpilotSdk.OpenPilot;
using OpenpilotSdk.OpenPilot.Fork;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using OpenpilotSdk.Sftp;
using Renci.SshNet.Common;
using Serilog;
using System.Globalization;
using System.Runtime.CompilerServices;
using OpenpilotSdk.Exceptions;
using OpenpilotSdk.OpenPilot.Segment;
using DnsClient;
using OpenpilotSdk.OpenPilot.FileTypes;
using OpenpilotSdk.OpenPilot.Media;

namespace OpenpilotSdk.Hardware
{
    public abstract class OpenpilotDevice
    {
        private const int SshPort = 8022;

        protected virtual string NotConnectedMessage => "No connection has been made to the openpilot device";

        public bool IsAuthenticated { get; protected set; } = false;
        protected readonly string TempDirectory = Path.Combine(AppContext.BaseDirectory ?? Environment.GetFolderPath(Environment.SpecialFolder.Personal), "tmp");
        public int Port { get; set; } = 8022;
        public IPAddress IpAddress { get; init; }
        protected SftpClient? SftpClient;
        protected SshClient? SshClient;
        private static readonly LookupClient LookupClient = new LookupClient();

        public virtual string DeviceName => "";
        public virtual string StorageDirectory => @"/data/media/0/realdata/";
        public virtual string RebootCommand => @"am start -a android.intent.action.REBOOT";
        public virtual string ShutdownCommand => @"am start -n android/com.android.internal.app.ShutdownActivity";
        public virtual string FlashCommand => @"pkill -f openpilot & cd /data/openpilot/panda/board && ./recover.sh";
        public virtual string InstallEmuCommand => @"cd /data/openpilot && echo 'y' | bash <(curl -fsSL install.emu.sh) && source /data/community/.bashrc";
        public virtual string GitCloneCommand => @"cd /data && rm -rf openpilot; git clone -b {1} --depth 1 --single-branch --progress --recurse-submodules --shallow-submodules {0} openpilot";

        public abstract IReadOnlyDictionary<CameraType,Camera> Cameras { get; }

        private static readonly string PrivateSshKeyFile = Path.Combine(
            OperatingSystem.IsWindows()
                ? AppContext.BaseDirectory
                : Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "opensshkey");

        private static readonly IPrivateKeySource[] PrivateKeys =
        [
            new PrivateKeyFile(PrivateSshKeyFile)
        ];

        public string WorkingDirectory
        {
            get
            {
                if (SftpClient != null)
                {
                    return SftpClient.WorkingDirectory;
                }
                else
                {
                    return "";
                }
            }
        }

        public async Task UploadFileAsync(string source, string destination)
        {
            await ConnectAsync().ConfigureAwait(false);
            if (SftpClient != null)
            {
                FileStream fileStream;
                await using ((fileStream = File.Open(source, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)).ConfigureAwait(false))
                {
                    await Task.Factory.FromAsync(
                        SftpClient.BeginUploadFile(fileStream, destination),
                        SftpClient.EndUploadFile).ConfigureAwait(false);

                }
            }
        }

        public async Task<SftpFileStream> OpenReadAsync(string path)
        {
            await ConnectAsync().ConfigureAwait(false);

            if (SftpClient != null)
            {
                return await SftpClient.OpenAsync(path, FileMode.Open, FileAccess.Read, CancellationToken.None).ConfigureAwait(false);
            }

            throw new NotConnectedException("SftpClient is not connected");
        }

        public async Task<SftpFileStream> OpenWriteAsync(string path)
        {
            await ConnectAsync().ConfigureAwait(false);

            if (SftpClient != null)
            {
                return await SftpClient.OpenAsync(path, FileMode.Create, FileAccess.Write, CancellationToken.None).ConfigureAwait(false);
            }

            throw new NotConnectedException("SftpClient is not connected");
        }

        public SftpFileStream OpenRead(string path)
        {
            Connect();

            if (SftpClient != null)
            {
                return SftpClient.OpenRead(path);
            }

            throw new NotConnectedException("SftpClient is not connected");
        }
        
        public async Task<Bitmap?> GetThumbnailAsync(Route route)
        {
            await ConnectAsync().ConfigureAwait(false);

            var firstSegment = route.Segments.FirstOrDefault();
            if (firstSegment != null)
            {
                return await GetThumbnailAsync(firstSegment).ConfigureAwait(false);
            }

            return null;
        }

        public async Task DeleteFile(SftpFile file)
        {
            await ConnectAsync().ConfigureAwait(false);

            if (SshClient != null)
            {
                using (var command = SshClient.CreateCommand("rm -rf '" + file.FullName + "'"))
                {
                    await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                }
            }
        }

        public async Task<TimeSpan?> GetVideoDuration(VideoSegment videoSegment)
        {
            await ConnectAsync().ConfigureAwait(false);

            if (SshClient != null)
            {
                using (var command = SshClient.CreateCommand(
                           string.Format(
                               @"ffprobe -v error -select_streams v:0 -show_entries packet=duration_time -of csv=p=0 {0}",
                               videoSegment.File.FullName)))
                {
                    var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute)
                        .ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        return new TimeSpan(result.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x))
                            .Select(x => TimeSpan.FromSeconds(Convert.ToDouble(x))).Sum(x => x.Ticks));
                    }
                }
            }

            return null;
        }

        public async Task DeleteRouteAsync(Route route)
        {
            await ConnectAsync().ConfigureAwait(false);
            if (SshClient != null)
            {
                var deleteTasks = route.Segments.Select(async segment =>
                {

                    using (var command = SshClient.CreateCommand("rm -rf " + segment.Path))
                    {
                        return await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                    }
                });
                await Task.WhenAll(deleteTasks).ConfigureAwait(false);
            }
        }

        public async Task<CombinedStream> GetVideoStream(Route route, Camera camera)
        {
            await ConnectAsync().ConfigureAwait(false);

            return new CombinedStream(await Task
                .WhenAll(route.Segments.Select(v => OpenReadAsync(v.RawVideoSegments[camera.Type].File.FullName)).ToArray()).ConfigureAwait(false));
        }

        public async Task<CombinedStreamCollection> GetVideoStreams(Route route)
        {
            return new CombinedStreamCollection(this, route);
        }

        public async Task ExportRouteAsync(string exportPath, Route route, Camera camera, bool combineSegments = false, IProgress<OpenPilot.Camera.Progress>? progress = null)
        {
            await ConnectAsync().ConfigureAwait(false);

            var cameraProgress = new OpenPilot.Camera.Progress(camera);
            Progress<Progress>? segmentProgress = null;
            if (progress != null)
            {
                segmentProgress = new Progress<Progress>();
                var segmentProgressDictionary = route.Segments.ToDictionary(segment => segment.Index, _ => 0);
                int previousProgress = 0;
                segmentProgress.ProgressChanged += async (sender, segmentProgressResult) =>
                {
                    segmentProgressDictionary[segmentProgressResult.Segment] = segmentProgressResult.Percent;

                    cameraProgress.Percent = (segmentProgressDictionary.Sum(segment => segment.Value) * 100) /
                                             (segmentProgressDictionary.Count * 100);

                    if (cameraProgress.Percent > previousProgress)
                    {
                        previousProgress = cameraProgress.Percent;
                        progress.Report(cameraProgress);
                    }
                };
            }

            if (!Directory.Exists(exportPath))
            {
                Directory.CreateDirectory(exportPath);
            }

            if (combineSegments)
            {
                var exportTasks =
                    route.Segments.Select((segment) => ExportSegmentAsync(exportPath, segment, camera, false, segmentProgress)).ToArray();

                if (exportTasks.Length > 0)
                {
                    var outputFilePath = Path.Combine(exportPath, route.ToString() + (char)camera.Type) + ".hevc";
                    bool fileWritten = false;

                    FileStream outputFile;
                    await using ((outputFile = File.Create(outputFilePath)).ConfigureAwait(false))
                    {
                        for (int i = 0; i < exportTasks.Length; i++)
                        {
                            var fileName = await exportTasks[i].ConfigureAwait(false);
                            
                            if (!string.IsNullOrWhiteSpace(fileName))
                            {
                                var tempFilePath = Path.Combine(exportPath, fileName);

                                FileStream inputFile;
                                await using ((inputFile = File.OpenRead(tempFilePath)).ConfigureAwait(false))
                                {
                                    await inputFile.CopyToAsync(outputFile).ConfigureAwait(false);
                                }
                                File.Delete(tempFilePath);
                            }
                        }

                        fileWritten = outputFile.Length > 0;
                    }

                    if (fileWritten)
                    {
                        await FFMpegArguments.FromFileInput(outputFilePath, true,
                                                    options => options.WithFramerate(camera.FrameRate))
                                                .OutputToFile(Path.Combine(exportPath, route.ToString() + (char)camera.Type) + ".mp4", true, options => options.CopyChannel())
                                                .ProcessAsynchronously().ConfigureAwait(false);
                    }
                    File.Delete(outputFilePath);
                }
            }
            else
            {
                var m3uFileName = route.ToString() + (char)camera.Type + ".m3u";

                var exportTasks =
                    route.Segments.Select((segment) => ExportSegmentAsync(exportPath, segment, camera, true, segmentProgress)).ToArray();

                var exportedSegments = (await Task.WhenAll(exportTasks).ConfigureAwait(false)).Where(file => !string.IsNullOrWhiteSpace(file)).ToArray();

                if (exportedSegments.Length > 1)
                {
                    await File.WriteAllTextAsync(Path.Combine(exportPath, m3uFileName),
                        string.Join(Environment.NewLine, exportedSegments)).ConfigureAwait(false);
                }
            }
        }

        public async Task<string> ExportSegmentAsync(string path, RouteSegment routeSegment, Camera camera, bool containerize,
            IProgress<Progress>? progress = null)
        {
            var segmentProgress = new Progress(routeSegment.Index);

            
            VideoSegment? video = null;
            routeSegment.RawVideoSegments.TryGetValue(camera.Type, out video);

            string fileName = "";
            var videoPath = video?.File?.FullName;
            if (!string.IsNullOrWhiteSpace(videoPath))
            {
                var fileNameWithoutExtension = new DirectoryInfo(Path.GetDirectoryName(videoPath)).Name + (char)camera.Type;
                
                fileName = fileNameWithoutExtension + (containerize ? ".mp4" : Path.GetExtension(videoPath));
                var outputFilePath = Path.Combine(path, fileNameWithoutExtension + Path.GetExtension(videoPath));
                var convertedFilePath = Path.Combine(path, fileName);
                if (!File.Exists(convertedFilePath))
                {
                    if (!File.Exists(outputFilePath))
                    {
                        FileStream outputFile;
                        await using ((outputFile = File.Create(outputFilePath)).ConfigureAwait(false))
                        {
                            if (Directory.Exists(Path.GetDirectoryName(path)))
                            {
                                var connectionInfo = new ConnectionInfo(IpAddress.ToString(), Port,
                                    "comma",
                                    new PrivateKeyAuthenticationMethod("comma", PrivateKeys));

                                using (var sftpClient = new SftpClient(connectionInfo))
                                {
                                    await _maxConcurrentConnectionLock.WaitAsync().ConfigureAwait(false);
                                    try
                                    {
                                        await sftpClient.ConnectAsync(CancellationToken.None).ConfigureAwait(false);
                                    }
                                    finally
                                    {
                                        _maxConcurrentConnectionLock.Release();
                                    }

                                    SftpFileStream stream;
                                    await using ((stream = await sftpClient.OpenAsync(videoPath, FileMode.Open,
                                                     FileAccess.Read, CancellationToken.None).ConfigureAwait(false)).ConfigureAwait(false))
                                    {
                                        var buffer = new byte[81920];
                                        int bytesRead;
                                        var sourceLength = stream.Length;
                                        int totalBytesRead = 0;
                                        int previousProgress = 0;

                                        while ((bytesRead = await stream.ReadAsync(buffer).ConfigureAwait(false)) > 0)
                                        {
                                            await outputFile.WriteAsync(buffer.AsMemory(0, bytesRead)).ConfigureAwait(false);

                                            if (progress != null)
                                            {
                                                totalBytesRead += bytesRead;

                                                segmentProgress.Percent = (int)(((double)totalBytesRead / (double)sourceLength) * 100);
                                                if (segmentProgress.Percent > previousProgress)
                                                {
                                                    previousProgress = segmentProgress.Percent;
                                                    progress.Report(segmentProgress);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (containerize)
                    {
                        await FFMpegArguments.FromFileInput(outputFilePath, true,
                                options => options.WithFramerate(video.Camera.FrameRate))
                            .OutputToFile(Path.Combine(path, fileName), true, options => options.CopyChannel())
                            .ProcessAsynchronously().ConfigureAwait(false);
                        File.Delete(outputFilePath);
                    }
                }
            }

            if (progress != null)
            {
                segmentProgress.Percent = 100;
                progress.Report(segmentProgress);
            }

            return fileName;
        }

        public async Task<Bitmap?> GetThumbnailAsync(RouteSegment routeSegment)
        {
            await ConnectAsync().ConfigureAwait(false);
            /*
             Bitmap? thumbnail = null;
             var videoFile = routeSegment.RawVideoSegments.FrontVideoSegmentQuick ?? routeSegment.FrontVideo;
             var route = new DirectoryInfo(Path.GetDirectoryName(videoFile.File.FullName)).Name;
             var cachedThumbnail = Path.Combine(TempDirectory, route + ".jpg");


            if (!File.Exists(cachedThumbnail))
            {
                bool quickVideo = routeSegment.FrontVideoSegmentQuick != null;
                var offset = 0;

                var imageBuffer = quickVideo ? new byte[10000] : new byte[200000];

                SftpFileStream sftpFileStream;
                await using ((sftpFileStream = SftpClient.OpenRead(videoFile.File.FullName)).ConfigureAwait(false))
                {
                    while (offset < imageBuffer.Length)
                    {
                        offset = await sftpFileStream.ReadAsync(imageBuffer, offset, imageBuffer.Length - offset).ConfigureAwait(false);
                    }
                }

                //using (var sftpFileStream = SftpClient.OpenRead(routeSegment.FrontCamera.FullName))
                MemoryStream msInput;
                MemoryStream msOutput;
                await using ((msInput = new MemoryStream(imageBuffer)).ConfigureAwait(false))
                await using ((msOutput = new MemoryStream()).ConfigureAwait(false))
                {
                    try
                    {
                        await FFMpegArguments
                            .FromPipeInput(new StreamPipeSource(msInput), options => options.WithFramerate(20))
                            .OutputToPipe(new StreamPipeSink(msOutput), options =>
                                options.WithVideoCodec(VideoCodec.Png)
                                    .WithFrameOutputCount(1)
                                    .ForceFormat("rawvideo"))
                            .ProcessAsynchronously().ConfigureAwait(false);
                    }
                    catch (FFMpegException)
                    {
                        Debug.Print("FFMpeg pipe exception");
                    }

                    msOutput.Position = 0;
                    thumbnail = new Bitmap(msOutput);
                    thumbnail.Save(cachedThumbnail);
                }
            }
           
            return thumbnail ?? (Bitmap)Image.FromFile(cachedThumbnail);
             */
            return null;
        }

        public async Task<RouteSegment> GetRouteSegmentAsync(DateTime routeDate, int index)
        {
            await ConnectAsync().ConfigureAwait(false);

            var segmentFolder = Path.Combine(StorageDirectory, routeDate.ToUniversalTime().ToString("yyyy-MM-dd--HH-mm-ss--" + index, CultureInfo.InvariantCulture));
            var segmentFiles = SftpClient.GetFilesAsync(segmentFolder);

            var rawVideoSegments = new Dictionary<CameraType, VideoSegment>();
            var videoSegments = new Dictionary<CameraType, VideoSegment>();
            LogFile quickLog = null;
            LogFile rawLog = null;

            await foreach (var segmentFile in segmentFiles.ConfigureAwait(false))
            {
                if (segmentFile.Name.Equals("fcamera.hevc", StringComparison.OrdinalIgnoreCase))
                {
                    rawVideoSegments.Add(CameraType.Front, new VideoSegment(segmentFile, Cameras[CameraType.Front]));
                }
                else if (segmentFile.Name.Equals("dcamera.hevc", StringComparison.OrdinalIgnoreCase))
                {
                    rawVideoSegments.Add(CameraType.Driver, new VideoSegment(segmentFile, Cameras[CameraType.Driver]));
                }
                else if (segmentFile.Name.Equals("ecamera.hevc", StringComparison.OrdinalIgnoreCase))
                {
                    rawVideoSegments.Add(CameraType.Wide, new VideoSegment(segmentFile, Cameras[CameraType.Wide]));
                }
                else if (segmentFile.Name.StartsWith("rlog", StringComparison.OrdinalIgnoreCase))
                {
                    rawLog = new LogFile(segmentFile,
                        segmentFile.Name.Contains(".bz2", StringComparison.OrdinalIgnoreCase));
                }
                else if (segmentFile.Name.StartsWith("qlog", StringComparison.OrdinalIgnoreCase))
                {
                    quickLog = new LogFile(segmentFile,
                        segmentFile.Name.Contains(".bz2", StringComparison.OrdinalIgnoreCase));
                }
                else if (segmentFile.Name.Equals("qcamera.ts", StringComparison.OrdinalIgnoreCase))
                {
                    videoSegments.Add(CameraType.Front, new VideoSegment(segmentFile, Cameras[CameraType.Front]));
                }
            }

            return new RouteSegment(index, segmentFolder, rawVideoSegments, videoSegments, quickLog, rawLog);
        }

        public RouteSegment GetSegment(DateTime routeDate, int index)
        {
            Connect();

            var segmentFolder = Path.Combine(StorageDirectory, routeDate.ToString("yyyy-MM-dd--HH-mm-ss--" + index));
            var segmentFiles = SftpClient.GetFiles(segmentFolder);


            var rawVideoSegments = new Dictionary<CameraType, VideoSegment>();
            var videoSegments = new Dictionary<CameraType, VideoSegment>();

            LogFile quickLog = null;
            LogFile rawLog = null;

            foreach (var segmentFile in segmentFiles)
            {
                if (segmentFile.Name.Equals("fcamera.hevc", StringComparison.OrdinalIgnoreCase))
                {
                    rawVideoSegments.Add(CameraType.Front, new VideoSegment(segmentFile, Cameras[CameraType.Front]));
                }
                else if (segmentFile.Name.Equals("dcamera.hevc", StringComparison.OrdinalIgnoreCase))
                {
                    rawVideoSegments.Add(CameraType.Driver, new VideoSegment(segmentFile, Cameras[CameraType.Driver]));
                }
                else if (segmentFile.Name.Equals("ecamera.hevc", StringComparison.OrdinalIgnoreCase))
                {
                    rawVideoSegments.Add(CameraType.Wide, new VideoSegment(segmentFile, Cameras[CameraType.Wide]));
                }
                else if (segmentFile.Name.StartsWith("rlog", StringComparison.OrdinalIgnoreCase))
                {
                    rawLog = new LogFile(segmentFile,
                        segmentFile.Name.Contains(".bz2", StringComparison.OrdinalIgnoreCase));
                }
                else if (segmentFile.Name.StartsWith("qlog", StringComparison.OrdinalIgnoreCase))
                {
                    quickLog = new LogFile(segmentFile,
                        segmentFile.Name.Contains(".bz2", StringComparison.OrdinalIgnoreCase));
                }
                else if (segmentFile.Name.Equals("qcamera.ts", StringComparison.OrdinalIgnoreCase))
                {
                    videoSegments.Add(CameraType.Front, new VideoSegment(segmentFile, Cameras[CameraType.Front]));
                }
            }

            return new RouteSegment(index, segmentFolder, rawVideoSegments, videoSegments, quickLog, rawLog);
        }

        public async Task<List<GpxWaypoint>> MapillaryExportAsync(Route route)
        {
            await ConnectAsync().ConfigureAwait(false);

            var waypoints = new List<GpxWaypoint>();

            var wayPointTasks = route.Segments.OrderBy(segment => segment.Index)
                .Select(GetWaypointsFromSegment).ToArray();
            
            foreach (var wayPointTask in wayPointTasks)
            {
                waypoints.AddRange(await wayPointTask.ConfigureAwait(false));
            }

            List<GpxWaypoint> waypointsToExport = new List<GpxWaypoint>();
            if (waypoints.Count > 1)
            {
                var firstWaypoint = waypoints.First();
                waypointsToExport.Add(firstWaypoint);
                var geoCoordinate = new GeoCoordinate(firstWaypoint.Latitude, firstWaypoint.Longitude,
                    (double)firstWaypoint.ElevationInMeters);

                for (int i = 1; i < waypoints.Count-1; i++)
                {
                    var nextCoordinate = new GeoCoordinate(waypoints[i].Latitude, waypoints[i].Latitude,
                        (double)waypoints[i].ElevationInMeters);

                    var distance = geoCoordinate.GetDistanceTo(nextCoordinate);
                    if (distance >= 5)
                    {
                        waypointsToExport.Add(waypoints[i]);
                        geoCoordinate = nextCoordinate;
                    }
                }

                waypointsToExport.Add(waypoints[waypoints.Count - 1]);
            }

            var waypointTable = new ImmutableGpxWaypointTable(waypointsToExport);
            var trackSegment = new GpxTrackSegment(waypointTable, null);
            var track = new GpxTrack(route.ToString(), null, null, "openpilot", ImmutableArray<GpxWebLink>.Empty, null, null, null, ImmutableArray.Create(trackSegment));
            var gpxFile = new GpxFile();
            gpxFile.Tracks.Add(track);
            File.WriteAllText(@"D:\OpenPilot\testf\test.gpx", gpxFile.BuildString(new GpxWriterSettings()));

            return waypointsToExport;
        }

        public async Task<IEnumerable<Firmware>> GetFirmwareVersions(IProgress<int>? progress = null)
        {
            await ConnectAsync().ConfigureAwait(false);

            var firmwares = new List<Firmware>();

            await foreach (var route in GetRoutesAsync().ConfigureAwait(false))
            {
                foreach (var routeSegment in route.Segments.OrderBy(segment => segment.Index))
                {
                    var firmware = await OpenPilot.Logging.LogFile.GetFirmwareAsync(SftpClient.OpenRead(routeSegment.QuickLog.File.FullName), routeSegment.QuickLog.IsCompressed).ConfigureAwait(false);

                    if (firmware != null && firmware.Any())
                    {
                        return firmware;
                    }
                }
            }


            return firmwares;
        }

        private async Task<IEnumerable<GpxWaypoint>> GetWaypoints(Route route)
        {
            var waypoints = new List<GpxWaypoint>();

            var wayPointTasks = route.Segments.OrderBy(segment => segment.Index)
                .Select(GetWaypointsFromSegment);

            int i = 0;
            foreach (var wayPointTask in wayPointTasks)
            {
                i++;
                waypoints.AddRange(await wayPointTask.ConfigureAwait(false));
            }

            return waypoints;
        }

        private async Task<IEnumerable<GpxWaypoint>> GetWaypointsFromSegment(RouteSegment routeSegment)
        {
            SftpFileStream fileStream;
            await using ((fileStream = await SftpClient.OpenAsync(routeSegment.QuickLog.File.FullName, FileMode.Open, FileAccess.Read, CancellationToken.None)).ConfigureAwait(false))
            {
                return await OpenPilot.Logging.LogFile.GetWaypointsAsync(fileStream, routeSegment.QuickLog.IsCompressed).ConfigureAwait(false);
            }
        }

        public async Task<GpxFile> GenerateGpxFileAsync(Route route, IProgress<int>? progress = null)
        {
            await ConnectAsync().ConfigureAwait(false);

            var waypoints = new List<GpxWaypoint>();

            var wayPointTasks = route.Segments.OrderBy(segment => segment.Index)
                .Select(GetWaypointsFromSegment).ToArray();
            
            int i = 0;
            foreach (var wayPointTask in wayPointTasks)
            {
                i++;
                waypoints.AddRange(await wayPointTask.ConfigureAwait(false));

                if (progress != null)
                {
                    progress.Report(i);
                }
            }

            var waypointTable = new ImmutableGpxWaypointTable(waypoints);
            var trackSegment = new GpxTrackSegment(waypointTable, null);
            var track = new GpxTrack(route.ToString(), null, null, "openpilot", ImmutableArray<GpxWebLink>.Empty, null, null, null, ImmutableArray.Create(trackSegment));
            var gpxFile = new GpxFile();
            gpxFile.Tracks.Add(track);

            return gpxFile;
        }

        public async IAsyncEnumerable<Route> GetRoutesAsync([EnumeratorCancellation]CancellationToken cancellationToken = default(CancellationToken))
        {
            await ConnectAsync(cancellationToken).ConfigureAwait(false);

            IOrderedEnumerable<IGrouping<DateTime, ISftpFile>>? directoryListing;

            try
            {
                directoryListing = (await SftpClient.ListDirectoryAsync(StorageDirectory, cancellationToken).ConfigureAwait(false))
                    .Where(dir => OpenPilot.Extensions.FolderRegex.IsMatch(dir.Name))
                    .GroupBy(dir =>
                    {
                        return DateTime.ParseExact(dir.Name.AsSpan().Slice(0, 20), "yyyy-MM-dd--HH-mm-ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal).ToUniversalTime(); 
                    })
                    .OrderByDescending(dir =>
                    {
                        var date = dir.Key;
                        return date;
                    });
            }
            catch (SftpPathNotFoundException)
            {
                yield break;
            }

            foreach (var segmentGroup in directoryListing)
            {
                var routeDate = segmentGroup.Key;

                var segmentTasks = segmentGroup.Select(segmentFolder => {
                    var segmentIndex = int.Parse(segmentFolder.Name.AsSpan().Slice(22));
                    return GetRouteSegmentAsync(routeDate, segmentIndex);
                }).ToArray();

                var segments = await Task.WhenAll(segmentTasks).ConfigureAwait(false);
                
                yield return new Route(routeDate, segments.OrderBy(segment => segment.Index).ToList());
            }
        }

        public IEnumerable<Route> GetRoutes()
        {
            Connect();

            IOrderedEnumerable<ISftpFile> directoryListing;
            try
            {
                directoryListing = SftpClient.ListDirectory(StorageDirectory)
                    .Where(dir => OpenPilot.Extensions.FolderRegex.IsMatch(dir.Name))
                    .OrderBy(dir =>
                    {
                        var date = DateTime.ParseExact(dir.Name.AsSpan().Slice(0,20), "yyyy-MM-dd--HH-mm-ss", CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
                        return date;
                    }).ThenBy(dir =>
                        {
                            var index = int.Parse(dir.Name.AsSpan().Slice(22));
                            return index;
                        }
                    );
            }
            catch (SftpPathNotFoundException)
            {
                yield break;
            }

            DateTime? previousSegmentDate = null;
            DateTime routeDate = DateTime.Today;
            var segmentList = new List<RouteSegment>();

            foreach (var segmentFolder in directoryListing)
            {
                var matches = OpenPilot.Extensions.FolderRegex.Match(segmentFolder.Name);
                routeDate = DateTime.Parse(
                    matches.Groups[1].Value + " " + matches.Groups[2].Value.Replace("-", ":"));
                if (previousSegmentDate == null)
                {
                    previousSegmentDate = routeDate;
                }

                var segmentIndex = int.Parse(matches.Groups[3].Value);
                var routeSegment = GetSegment(routeDate, segmentIndex);

                if (previousSegmentDate == routeDate)
                {
                    segmentList.Add(routeSegment);
                }
                else
                {
                    yield return new Route((DateTime)previousSegmentDate, segmentList);
                    previousSegmentDate = routeDate;
                    segmentList = new List<RouteSegment> { routeSegment };
                }
            }

            if (segmentList.Count > 0)
            {
                yield return new Route(routeDate, segmentList);
            }
        
        }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(DeviceName) ? IpAddress.ToString() : IpAddress + " - " + DeviceName;
        }

        protected bool Equals(OpenpilotDevice other)
        {
            return Equals(IpAddress, other.IpAddress);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((OpenpilotDevice)obj);
        }

        public override int GetHashCode()
        {
            return IpAddress != null ? IpAddress.GetHashCode() : 0;
        }

        public static bool operator ==(OpenpilotDevice left, OpenpilotDevice right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OpenpilotDevice? left, OpenpilotDevice? right)
        {
            return !Equals(left, right);
        }

        public async Task ChangeDirectoryAsync(string path)
        {
            await ConnectAsync().ConfigureAwait(false);

            SftpClient.ChangeDirectory(path);
        }

        public void ChangeDirectory(string path)
        {
            Connect();

            SftpClient.ChangeDirectory(path);
        }

        public async Task<IEnumerable<ISftpFile>> EnumerateFileSystemEntriesAsync(string path = "/")
        {
            await ConnectAsync().ConfigureAwait(false);

            var fileSystemEntries = SftpClient.EnumerateFileSystemEntries(path);
            return fileSystemEntries;
        }

        public IEnumerable<ISftpFile> EnumerateFileSystemEntries(string path = "/")
        {
            Connect();

            var fileSystemEntries = SftpClient.EnumerateFileSystemEntries(path);
            return fileSystemEntries;
        }
        
        public async Task<IEnumerable<ISftpFile>?> EnumerateFilesAsync(string path = ".")
        {
            await ConnectAsync().ConfigureAwait(false);

            var directoryListing = await SftpClient.ListDirectoryAsync(path, CancellationToken.None).ConfigureAwait(false);
            return directoryListing;
        }
        
        public IEnumerable<ISftpFile> EnumerateFiles(string path = ".")
        {
            Connect();
            
            var directoryListing = SftpClient.ListDirectory(path);
            return directoryListing;
        }

        public static async IAsyncEnumerable<OpenpilotDevice> DiscoverAsync()
        {
            Log.Information("Scanning network for devices.");
            var connectionRequests = new List<Task<OpenpilotDevice?>>();
            var addressList = new HashSet<string>();

            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                Log.Information("Found network interface: {interface}", networkInterface.Name);

                if (!(networkInterface.OperationalStatus == OperationalStatus.Up ||
                     networkInterface.OperationalStatus == OperationalStatus.Unknown ||
                     networkInterface.OperationalStatus == OperationalStatus.Dormant ||
                     networkInterface.OperationalStatus == OperationalStatus.Testing) || networkInterface.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    Log.Information("Network interface is not enabled: {interface}", networkInterface.Name);
                    continue;
                }

                var unicastAddresses = networkInterface.GetIPProperties().UnicastAddresses;
                foreach (var unicastAddress in unicastAddresses)
                {
                    if (unicastAddress.Address.AddressFamily != AddressFamily.InterNetwork)
                    {
                        Log.Information("Network is not an IPv4 network: {interface}", networkInterface.Name);
                        continue;
                    }

                    var subnetMask = unicastAddress.IPv4Mask.GetAddressBytes();
                    var ipAddress = unicastAddress.Address.GetAddressBytes();
                    
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(subnetMask);
                        Array.Reverse(ipAddress);
                    }
                    var endAddress = ~BitConverter.ToUInt32(subnetMask, 0);
                    if (endAddress > 1024)
                    {
                        Log.Information("Subnet contains more than 1024 addresses, skipping: {interface}.  End Address: {address}", networkInterface.Name, endAddress);
                        continue;
                    }
                    var localIp = BitConverter.ToUInt32(ipAddress, 0);

                    var startAddress = BitConverter.ToUInt32(ipAddress, 0) & BitConverter.ToUInt32(subnetMask, 0);

                    var startAddressBytes = BitConverter.GetBytes(startAddress + 1);
                    if (BitConverter.IsLittleEndian) Array.Reverse(startAddressBytes);
                    var startIPAddress = Convert.ToString(startAddressBytes[0]) + "." + Convert.ToString(startAddressBytes[1]) + "." +
                        Convert.ToString(startAddressBytes[2]) + "." + Convert.ToString(startAddressBytes[3]);
                    
                    if (startIPAddress == "192.168.43.1")
                    {
                        if (addressList.Add(startIPAddress))
                        {
                            connectionRequests.Add(GetOpenpilotDeviceAsync(startIPAddress, SshPort));
                            continue;
                        }
                    }

                    var endAddressBytes = BitConverter.GetBytes(startAddress + endAddress);
                    if (BitConverter.IsLittleEndian) Array.Reverse(endAddressBytes);
                    var endIPAddress = Convert.ToString(endAddressBytes[0]) + "." + Convert.ToString(endAddressBytes[1]) + "." +
                                         Convert.ToString(endAddressBytes[2]) + "." + Convert.ToString(endAddressBytes[3]);

                    Log.Information("Scanning IP range: {startAddress} - {endAddress}", startIPAddress, endIPAddress);

                    for (uint i = 1; i <= endAddress; i++)
                    {
                        var host = startAddress + i;
                        if (host == localIp) continue;

                        var hostBytes = BitConverter.GetBytes(host);
                        if (BitConverter.IsLittleEndian) Array.Reverse(hostBytes);

                        var hostAddress = Convert.ToString(hostBytes[0]) + "." + Convert.ToString(hostBytes[1]) + "." +
                                          Convert.ToString(hostBytes[2]) + "." + Convert.ToString(hostBytes[3]);

                        if (addressList.Add(hostAddress))
                        {
                            connectionRequests.Add(GetOpenpilotDeviceAsync(hostAddress, SshPort));
                        }
                    }
                }
            }

            var timeout = TimeSpan.FromSeconds(10);
            var cts = new CancellationTokenSource(timeout);
            await foreach (var connectionRequest in Task.WhenEach(connectionRequests).WithCancellation(cts.Token).ConfigureAwait(false))
            {
                if (!cts.TryReset())
                {
                    cts.Token.ThrowIfCancellationRequested();
                }

                var openpilotDevice = await connectionRequest.ConfigureAwait(false);
                if (openpilotDevice != null)
                {
                    yield return openpilotDevice;
                };
                cts.CancelAfter(timeout); // Start the timer again
            }
        }

        public static async Task<OpenpilotDevice?> GetOpenpilotDeviceAsync(string address, int port, int timeout = 500)
        {
            
            try
            {
                //Use socket to find service on specific port instead of ping
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    var cts = new CancellationTokenSource(timeout);
                    var socketTask = socket.ConnectAsync(address, port, cts.Token);

                    await Task.WhenAny(Task.Delay(timeout), socketTask.AsTask()).ConfigureAwait(false);

                    if (!socket.Connected)
                    {
                       return null;
                    }
                    
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }

                Log.Information("Connected to {Address} on port {port}", address, port);

                using (var client = new SshClient(address, port, "comma", PrivateKeys))
                {
                    try
                    {
                        await client.ConnectAsync(CancellationToken.None).ConfigureAwait(false);
                    }
                    catch (SshAuthenticationException)
                    {
                        return new UnknownDevice();
                    }

                    if (!client.IsConnected)
                    {
                        return null;
                    }
                }

                var ipAddress = IPAddress.Parse(address);

                string? hostName;
                try
                {
                    hostName = await LookupClient.GetHostNameAsync(ipAddress).ConfigureAwait(false);
                }
                catch (Exception)
                {
                    hostName = null;
                }
                
                if (hostName != null && (hostName.StartsWith("comma") || hostName.Equals("tici")))
                {
                    Log.Information("Connected to Comma3 device at {Address} on port {port}",
                        address, port);
                    return new Comma3(ipAddress);
                }

                Log.Information("Connected to Comma2 device at {Address} on port {port}", address, port);
                return new Comma2(IPAddress.Parse(address));
            }
            catch (Exception e)
            {
                Log.Error("Failed to connect to {Address} with the following exception: {Exception}", address, e.Message);
            }

            return null;
        }

        public virtual async Task<ForkResult> ReinstallOpenpilotAsync(IProgress<InstallProgress>? progress = null)
        {
            await ConnectAsync().ConfigureAwait(false);

            using (var command = SshClient.CreateCommand("cd /data/openpilot && git remote get-url origin && git rev-parse --abbrev-ref HEAD"))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0;
                if (success)
                {
                    var results = result.Split("\n");
                    var username = results[0].Split("/")[3];
                    var branch = results[1];
                    if (progress == null)
                    {
                        return await InstallForkAsync(username, branch).ConfigureAwait(false);
                    }
                    else
                    {
                        return await InstallForkAsync(username, branch, progress).ConfigureAwait(false);
                    }
                }
                return new ForkResult(string.IsNullOrWhiteSpace(result) ? command.Error : result, false);
            }
            
        }

        public virtual async Task<bool> FlashPandaAsync()
        {
            await ConnectAsync().ConfigureAwait(false);

            using (var command = SshClient.CreateCommand(FlashCommand))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0;
                if (success)
                {
                    using (var rebootCommand = SshClient.CreateCommand(RebootCommand))
                    {
                        rebootCommand.BeginExecute();
                    }
                }
                return success;
            }
        }

        public virtual async Task<bool> InstallEmuAsync()
        {
            await ConnectAsync().ConfigureAwait(false);

            using (var command = SshClient.CreateCommand(InstallEmuCommand))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0;
                return success;
            }
        }

        public virtual async Task<bool> ShutdownAsync()
        {
            await ConnectAsync().ConfigureAwait(false);

            using (var command = SshClient.CreateCommand(ShutdownCommand))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0;
                return success;
            }
        }

        public virtual async Task<bool> RebootAsync()
        {
            await ConnectAsync().ConfigureAwait(false);

            using (var command = SshClient.CreateCommand(RebootCommand))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0;
                return success;
            }
        }

        public virtual async Task<ForkResult> InstallForkAsync(string username, string branch, IProgress<InstallProgress>? progress, string repository = "openpilot")
        {
            if (progress == null)
            {
                return await InstallForkAsync(username, branch, repository).ConfigureAwait(false);
            }

            await ConnectAsync().ConfigureAwait(false);

            var installCommand =
                string.Format(@"cd /data && rm -rf openpilot ; git clone -b {1} --depth 1 --single-branch --progress --recurse-submodules --shallow-submodules https://github.com/{0}/{2}.git openpilot", username, branch, repository);

            var progressRegex = new Regex(@"\d+(?=%)", RegexOptions.Compiled);
            int previousProgress = 0;
            string lastLineRead = "";

            using (var command = SshClient.CreateCommand(installCommand))
            {
                var asyncResult = command.BeginExecute();
                using (var streamReader = new StreamReader(command.ExtendedOutputStream))
                {
                    while (!asyncResult.IsCompleted)
                    {
                        var output = await streamReader.ReadLineAsync().ConfigureAwait(false);
                        if (!string.IsNullOrWhiteSpace(output))
                        {
                            lastLineRead = output;
                            var match = progressRegex.Match(output);

                            if (!string.IsNullOrWhiteSpace(match.Value))
                            {
                                if (int.TryParse(match.Value, out int currentProgress))
                                {
                                    if (previousProgress != currentProgress)
                                    {
                                        previousProgress = currentProgress;
                                        var progressText = output.Substring(0, match.Index).Trim();
                                        progressText = progressText.Remove(progressText.Length - 1);
                                        progress.Report(new InstallProgress(currentProgress, progressText));
                                    }
                                }
                            }
                        }
                    }

                    var result = command.EndExecute(asyncResult);
                    var success = command.ExitStatus == 0;

                    if (success)
                    {
                        using (var rebootCommand = SshClient.CreateCommand(RebootCommand))
                        {
                            rebootCommand.BeginExecute();
                        }
                    }

                    return new ForkResult(string.IsNullOrWhiteSpace(result) ? lastLineRead : result,
                        success);
                }
            }
        }

        public virtual async Task<ForkResult> InstallForkAsync(string username, string branch, string repository = "openpilot")
        {
            await ConnectAsync().ConfigureAwait(false);

            var installCommand =
                string.Format(@"cd /data && rm -rf openpilot; git clone -b {1} --depth 1 --single-branch --recurse-submodules --shallow-submodules https://github.com/{0}/{2}.git openpilot", username, branch, repository);

            using (var command = SshClient.CreateCommand(installCommand))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0 || !(string.IsNullOrWhiteSpace(result) && !string.IsNullOrWhiteSpace(command.Error));

                if (success)
                {
                    using (var rebootCommand = SshClient.CreateCommand(RebootCommand))
                    {
                        rebootCommand.BeginExecute();
                    }
                }

                return new ForkResult(string.IsNullOrWhiteSpace(result) ? command.Error : result,
                    success);
            }
        }

        public async Task<ShellStream> GetShellStreamAsync()
        {
            await ConnectAsync().ConfigureAwait(false);
            var client = SshClient.CreateShellStream("xterm-256color", 0, 0, 0, 0, 1024);
            return client;
        }

        public ShellStream GetShellStream()
        {
            Connect();
            var client = SshClient.CreateShellStream("xterm-256color", 0, 0, 0, 0, 1024);
            return client;
        }

        //More than 10 concurrent requests to SftpClient.ConnectAsync will throw an exception
        //ConnectionInfo.MaxSessions
        private readonly SemaphoreSlim _maxConcurrentConnectionLock = new SemaphoreSlim(10, 10);
        private readonly SemaphoreSlim _connectionLock = new SemaphoreSlim(1, 1);
        public void Connect()
        {
            _connectionLock.Wait();
            try
            {
                if (SftpClient == null || !SftpClient.IsConnected)
                {
                    var connectionInfo = new ConnectionInfo(IpAddress.ToString(), Port, "comma", new PrivateKeyAuthenticationMethod("comma", PrivateKeys));

                    SftpClient = new SftpClient(connectionInfo)
                    {
                        KeepAliveInterval = TimeSpan.FromSeconds(10)
                    };
                    SshClient = new SshClient(connectionInfo)
                    {
                        KeepAliveInterval = TimeSpan.FromSeconds(10)
                    };

                    SftpClient.Connect();
                    SshClient.Connect();
                }
            }
            finally
            {
                _connectionLock.Release();
            }
            
        }

        public async Task ConnectAsync(CancellationToken cancellationToken = default)
        {
            if(SftpClient != null && SftpClient.IsConnected)
            {
                return;
            }

            await _connectionLock.WaitAsync(cancellationToken).ConfigureAwait(false);

            try
            {
                if (SftpClient == null || !SftpClient.IsConnected)
                {

                    var connectionInfo = new ConnectionInfo(IpAddress.ToString(), Port,
                        "comma",
                        new PrivateKeyAuthenticationMethod("comma",PrivateKeys));

                    SftpClient = new SftpClient(connectionInfo)
                    {
                        KeepAliveInterval = TimeSpan.FromSeconds(10)
                    };
                    SshClient = new SshClient(connectionInfo)
                    {
                        KeepAliveInterval = TimeSpan.FromSeconds(10)
                    };

                    await _maxConcurrentConnectionLock.WaitAsync(cancellationToken).ConfigureAwait(false);
                    try
                    {
                        await SftpClient.ConnectAsync(cancellationToken).ConfigureAwait(false);
                        //SftpClient.ChangeDirectory("/data/openpilot/");
                        
                        await SshClient.ConnectAsync(cancellationToken).ConfigureAwait(false);
                    }
                    finally
                    {
                        _maxConcurrentConnectionLock.Release();
                    }
                }
            }
            finally
            {
                _connectionLock.Release();
            }
        }
    }
}
