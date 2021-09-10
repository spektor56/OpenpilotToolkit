using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.Exceptions;
using FFMpegCore.Pipes;
using GeoCoordinatePortable;
using NetTopologySuite.IO;
using OpenpilotSdk.Exceptions;
using OpenpilotSdk.OpenPilot;
using Renci.SshNet.Sftp;
using OpenpilotSdk.Sftp;

namespace OpenpilotSdk.Hardware
{
    public class Comma2 : OpenpilotDevice
    {
        public Comma2(IPAddress hostAddress, bool isAuthenticated = true)
        {
            IsAuthenticated = isAuthenticated;
            IpAddress = hostAddress;
        }

        public SftpFileStream OpenRead(string path)
        {
            if (!SftpClient.IsConnected)
            {
                throw new NotConnectedException("No connection has been made to the comma2");
            }

            return SftpClient.OpenRead(path);
        }

        public async Task<Bitmap> GetThumbnailAsync(Drive drive)
        {
            var firstSegment = drive.Segments.FirstOrDefault();
            if (firstSegment != null)
            {
                return await GetThumbnailAsync(firstSegment);
            }

            return null;
        }

        public async Task ExportDriveAsync(string path, Drive drive, bool combineSegments = false, IProgress<int> progress = null)
        {
            if (!SftpClient.IsConnected)
            {
                throw new NotConnectedException("No connection has been made to the comma2");
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (combineSegments)
            {
                using (var fs = File.Create(Path.Combine(path, drive.ToString()) + ".hevc"))
                {
                    foreach (var segment in drive.Segments)
                    {
                        using (var segmentFile = SftpClient.OpenRead(segment.FrontCamera.FullName))
                        {
                            await segmentFile.CopyToAsync(fs);
                            if (progress != null)
                            {
                                progress.Report(segment.Index);
                            }
                        }
                    }
                }
            }
            else
            {
                var m3uFileName = drive.ToString() + ".m3u";
                var m3uList = new List<string>();

                foreach (var segment in drive.Segments)
                {
                    var fileName = await ExportSegmentAsync(path, segment, progress);
                    m3uList.Add(fileName);
                }

                using (var file = File.CreateText(Path.Combine(path, m3uFileName)))
                {
                    await file.WriteAsync(string.Join(Environment.NewLine, m3uList));
                }
            }
            
        }

        public void ExportDrive(string path, Drive drive, IProgress<int> progress = null)
        {
            if (!SftpClient.IsConnected)
            {
                throw new NotConnectedException("No connection has been made to the comma2");
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var m3uFileName = drive.ToString() + ".m3u";
            var m3uList = new StringBuilder();

            foreach (var segment in drive.Segments)
            {
                m3uList.AppendLine(ExportSegment(path, segment));
            }

            using (var file = File.CreateText(Path.Combine(path, m3uFileName)))
            {
                file.WriteAsync(m3uList.ToString());
            }
        }

        public async Task<string> ExportSegmentAsync(string path, DriveSegment driveSegment,
            IProgress<int> progress = null)
        {
            if (!SftpClient.IsConnected)
            {
                throw new NotConnectedException("No connection has been made to the comma2");
            }

            var newFileName = new DirectoryInfo(Path.GetDirectoryName(driveSegment.FrontCamera.FullName)).Name +
                              Path.GetExtension(driveSegment.FrontCamera.FullName);

            if (!File.Exists(Path.Combine(path, newFileName)))
            {
                using (var outputFile = File.Create(Path.Combine(path, newFileName)))
                {
                    if (Directory.Exists(Path.GetDirectoryName(path)))
                    {
                        await Task.Factory.FromAsync(
                            SftpClient.BeginDownloadFile(driveSegment.FrontCamera.FullName, outputFile),
                            SftpClient.EndDownloadFile);
                    }
                }
            }
            /*
            if (driveSegment.RawLog != null)
            {
                newFileName = new DirectoryInfo(Path.GetDirectoryName(driveSegment.RawLog.FullName)).Name +
                              Path.GetExtension(driveSegment.RawLog.FullName);

                if (!File.Exists(Path.Combine(path, newFileName)))
                {
                    using (var outputFile = File.Create(Path.Combine(path, newFileName)))
                    {
                        if (Directory.Exists(Path.GetDirectoryName(path)))
                        {
                            await Task.Factory.FromAsync(
                                SftpClient.BeginDownloadFile(driveSegment.RawLog.FullName, outputFile),
                                SftpClient.EndDownloadFile);
                        }
                    }
                }
            }
            */


            if (progress != null)
            {
                progress.Report(driveSegment.Index);
            }

            return newFileName;
        }

        public string ExportSegment(string path, DriveSegment driveSegment)
        {
            if (!SftpClient.IsConnected)
            {
                throw new NotConnectedException("No connection has been made to the comma2");
            }

            var newFileName = new DirectoryInfo(Path.GetDirectoryName(driveSegment.FrontCamera.FullName)).Name +
                              Path.GetExtension(driveSegment.FrontCamera.FullName);

            var filePath = Path.Combine(path, newFileName);
            if (!File.Exists(filePath))
            {
                using (var outputFile = File.Create(Path.Combine(path, newFileName)))
                {
                    if (Directory.Exists(Path.GetDirectoryName(path)))
                    {
                        SftpClient.DownloadFile(driveSegment.FrontCamera.FullName, outputFile, obj => { });
                    }
                }
            }

            return newFileName;
        }

        public async Task<Bitmap> GetThumbnailAsync(DriveSegment driveSegment)
        {
            Bitmap thumbnail = null;
            var drive = new DirectoryInfo(Path.GetDirectoryName(driveSegment.FrontCamera.FullName)).Name;
            var cachedThumbnail = Path.Combine(TempDirectory, drive + ".jpg");
            

            if (!File.Exists(cachedThumbnail))
            {
                bool quickVideo = driveSegment.FrontCameraQuick != null;
                var offset = 0;
                
                var videoFile = driveSegment.FrontCameraQuick ?? driveSegment.FrontCamera;
                var imageBuffer = quickVideo ? new byte[10000] : new byte[200000];

                using (var sftpFileStream = SftpClient.OpenRead(videoFile.FullName))
                {
                    while (offset < imageBuffer.Length)
                    {
                        offset = await sftpFileStream.ReadAsync(imageBuffer, offset, imageBuffer.Length - offset);
                    }
                }
                
                //using (var sftpFileStream = SftpClient.OpenRead(driveSegment.FrontCamera.FullName))
                using (var msInput = new MemoryStream(imageBuffer))
                using (var msOutput = new MemoryStream())
                {
                    try
                    {
                        await FFMpegArguments
                            .FromPipeInput(new StreamPipeSource(msInput), options => options.WithFramerate(20).ForceFormat(quickVideo ? "mpegts" : "rawvideo"))
                            .OutputToPipe(new StreamPipeSink(msOutput), options =>
                                options.WithVideoCodec(VideoCodec.Png)
                                    .WithFrameOutputCount(1)
                                    .ForceFormat("rawvideo"))
                            .ProcessAsynchronously();
                    }
                    catch (FFMpegException e)
                    {
                        System.Diagnostics.Debug.Print("FFMpeg pipe exception");
                    }

                    msOutput.Position = 0;
                    thumbnail = new Bitmap(msOutput);
                    thumbnail.Save(cachedThumbnail);
                }
                
            }

            return thumbnail ?? (Bitmap)Image.FromFile(cachedThumbnail);
        }

        public DriveSegment GetSegment(DateTime driveDate, int index)
        {
            var segmentFolder = @"/storage/emulated/0/realdata/" + driveDate.ToString("yyyy-MM-dd--HH-mm-ss--" + index);
            var segmentFiles = SftpClient.GetFiles(segmentFolder);
            

            SftpFile frontCamera = null;
            SftpFile driverCamera = null;
            SftpFile quickLog = null;
            SftpFile rawLog = null;
            SftpFile frontCameraQuick = null;

            foreach (var segmentFile in segmentFiles)
            {
                if (segmentFile.Name.Equals("fcamera.hevc", StringComparison.OrdinalIgnoreCase))
                {
                    frontCamera = segmentFile;
                }
                else if (segmentFile.Name.Equals("dcamera.hevc", StringComparison.OrdinalIgnoreCase))
                {
                    driverCamera = segmentFile;
                }
                else if (segmentFile.Name.Equals("rlog.bz2", StringComparison.OrdinalIgnoreCase))
                {
                    rawLog = segmentFile;
                }
                else if (segmentFile.Name.Equals("qlog.bz2", StringComparison.OrdinalIgnoreCase))
                {
                    quickLog = segmentFile;
                }
                else if (segmentFile.Name.Equals("qcamera.ts", StringComparison.OrdinalIgnoreCase))
                {
                    frontCameraQuick = segmentFile;
                }
            }


            //
            //directoryItem.Name.Equals("rlog.bz2", StringComparison.OrdinalIgnoreCase))


            return new DriveSegment(index, frontCamera, quickLog, rawLog, driverCamera, frontCameraQuick);
        }

        public async Task<List<GpxWaypoint>> MapillaryExportAsync(Drive drive)
        {
            var waypoints = new List<GpxWaypoint>();

            foreach (var driveSegment in drive.Segments.OrderBy(segment => segment.Index))
            {
                waypoints.AddRange(await OpenPilot.Logging.LogFile.GetWayPointsAsync(SftpClient.OpenRead(driveSegment.RawLog.FullName)));

            }

            List<GpxWaypoint> waypointsToExport = new List<GpxWaypoint>();
            if (waypoints.Count > 1)
            {
                var firstWaypoint = waypoints.First();
                waypointsToExport.Add(firstWaypoint);
                var geoCoordinate = new GeoCoordinate(firstWaypoint.Latitude, firstWaypoint.Longitude,
                    (double)firstWaypoint.ElevationInMeters);

                for (int i = 1; i < waypoints.Count; i++)
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

            var waypointTable = new ImmutableGpxWaypointTable(waypointsToExport.Take(100));
            var trackSegment = new GpxTrackSegment(waypointTable, null);
            var track = new GpxTrack(drive.ToString(), null, null, "openpilot", ImmutableArray<GpxWebLink>.Empty, null, null, null, ImmutableArray.Create(trackSegment));
            var gpxFile = new GpxFile();
            gpxFile.Tracks.Add(track);
            File.WriteAllText(@"D:\OpenPilot\testf\test.gpx", gpxFile.BuildString(new GpxWriterSettings()));

            return waypointsToExport;
        }

        public async Task<IEnumerable<Firmware>> GetFirmwareVersions(IProgress<int> progress = null)
        {
            
            var firmwares = new List<Firmware>();

            var drives = GetDrives();

            foreach (var drive in drives)
            {
                foreach (var driveSegment in drive.Segments.OrderBy(segment => segment.Index))
                {
                    var firmware = await OpenPilot.Logging.LogFile.GetFirmware(SftpClient.OpenRead(driveSegment.QuickLog.FullName));

                    if (firmware != null && firmware.Any())
                    {
                        return firmware;
                    }
                }
            }
            

            return firmwares;
        }

        public async Task<GpxFile> GenerateGpxFileAsync(Drive drive, IProgress<int> progress = null)
        {
            var waypoints = new List<GpxWaypoint>();
            
            foreach (var driveSegment in drive.Segments.OrderBy(segment => segment.Index))
            {
                waypoints.AddRange(await OpenPilot.Logging.LogFile.GetWayPointsAsync(SftpClient.OpenRead(driveSegment.RawLog.FullName)));
                
                if (progress != null)
                {
                    progress.Report(driveSegment.Index);
                }
            }
            
            var waypointTable = new ImmutableGpxWaypointTable(waypoints);
            var trackSegment = new GpxTrackSegment(waypointTable, null);
            var track = new GpxTrack(drive.ToString(), null, null, "openpilot", ImmutableArray<GpxWebLink>.Empty, null, null, null, ImmutableArray.Create(trackSegment));
            var gpxFile = new GpxFile();
            gpxFile.Tracks.Add(track);
            
            return gpxFile;
        }

        public IEnumerable<Drive> GetDrives()
        {
            if (!SftpClient.IsConnected)
            {
                throw new NotConnectedException("No connection has been made to the comma2");
            }
            
            var directoryListing = SftpClient.ListDirectory(@"/storage/emulated/0/realdata").Where(dir => OpenPilot.Extensions.FolderRegex.IsMatch(dir.Name))
                .OrderBy(dir =>
                {
                    var matches = OpenPilot.Extensions.FolderRegex.Match(dir.Name);
                    var date = DateTime.Parse(matches.Groups[1].Value + " " +
                                              matches.Groups[2].Value.Replace("-", ":"));
                    return date;
                }).ThenBy(dir =>
                    {
                        var matches = OpenPilot.Extensions.FolderRegex.Match(dir.Name);
                        var index = int.Parse(matches.Groups[3].Value);
                        return index;
                    }
                );

            DateTime? previousSegmentDate = null;
            DateTime driveDate = DateTime.Today;
            var segmentList = new List<DriveSegment>();

            foreach (var segmentFolder in directoryListing)
            {
                var matches = OpenPilot.Extensions.FolderRegex.Match(segmentFolder.Name);
                driveDate = DateTime.Parse(matches.Groups[1].Value + " " + matches.Groups[2].Value.Replace("-", ":"));
                if (previousSegmentDate == null)
                {
                    previousSegmentDate = driveDate;
                }

                var segmentIndex = int.Parse(matches.Groups[3].Value);
                var driveSegment = GetSegment(driveDate, segmentIndex);

                if (previousSegmentDate == driveDate)
                {
                    segmentList.Add(driveSegment);
                }
                else
                {
                    yield return new Drive((DateTime) previousSegmentDate, segmentList);
                    previousSegmentDate = driveDate;
                    segmentList = new List<DriveSegment> {driveSegment};
                }
            }

            if (segmentList.Count > 0)
            {
                yield return new Drive(driveDate, segmentList);
            }
        }
    }
}