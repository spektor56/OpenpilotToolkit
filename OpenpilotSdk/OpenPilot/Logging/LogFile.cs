using System.Collections.Immutable;
using Capnp;
using Cereal;
using ICSharpCode.SharpZipLib.BZip2;
using NetTopologySuite.IO;

namespace OpenpilotSdk.OpenPilot.Logging
{
    public sealed class LogFile
    {
        public static async Task<IEnumerable<GpxWaypoint>> GetWaypointsAsync(Stream fileStream, bool compressed)
        {
            List<GpxWaypoint> waypoints = new List<GpxWaypoint>();

            if (compressed)
            {
                using (var bz2Stream = new BZip2InputStream(fileStream))
                {
                    var pump = new FramePump(bz2Stream);
                    pump.FrameReceived += frame =>
                    {
                        var deserializer = DeserializerState.CreateRoot(frame);
                        var reader = new Event.READER(deserializer);
                        if (reader.which == Event.WHICH.GpsLocationExternal)
                        {
                            if (reader.Valid && reader.GpsLocationExternal.Latitude != 0 &&
                                reader.GpsLocationExternal.Longitude != 0 &&
                                (double)reader.GpsLocationExternal.Accuracy < 1)
                            {
                                DateTime utcDate =
                                    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                                        .AddSeconds((double)reader.GpsLocationExternal.UnixTimestampMillis / 1000);

                                var waypoint = new GpxWaypoint(
                                    new GpxLongitude(Math.Round(reader.GpsLocationExternal.Longitude, 7)),
                                    new GpxLatitude(Math.Round(reader.GpsLocationExternal.Latitude, 7)),
                                    Math.Round(reader.GpsLocationExternal.Altitude), utcDate, null, null, null, null,
                                    null, reader.GpsLocationExternal.Source.ToString(), ImmutableArray<GpxWebLink>.Empty, null, null, null, null, null, null, null,
                                    null, null, null);
                                waypoints.Add(waypoint);
                            }
                        }
                    };
                    await Task.Run(() =>
                    {
                        pump.Run();
                    }).ConfigureAwait(false);
                }
            }
            else
            {
                var pump = new FramePump(fileStream);
                pump.FrameReceived += frame =>
                {
                    var deserializer = DeserializerState.CreateRoot(frame);
                    var reader = new Event.READER(deserializer);
                    if (reader.which == Event.WHICH.GpsLocation)
                    {
                        if (reader.Valid && reader.GpsLocation.Latitude != 0 &&
                            reader.GpsLocation.Longitude != 0 &&
                            (double)reader.GpsLocation.Accuracy < 1)
                        {
                            DateTime utcDate =
                                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                                    .AddSeconds((double)reader.GpsLocation.UnixTimestampMillis / 1000);

                            var waypoint = new GpxWaypoint(
                                new GpxLongitude(Math.Round(reader.GpsLocation.Longitude, 7)),
                                new GpxLatitude(Math.Round(reader.GpsLocation.Latitude, 7)),
                                Math.Round(reader.GpsLocation.Altitude), utcDate, null, null, null, null,
                                null, reader.GpsLocation.Source.ToString(), ImmutableArray<GpxWebLink>.Empty, null, null, null, null, null, null, null,
                                null, null, null);
                            waypoints.Add(waypoint);
                        }
                    }
                };
                await Task.Run(() =>
                {
                    pump.Run();
                }).ConfigureAwait(false);
            }

            
            return waypoints;
        }

        public static async Task<IEnumerable<Firmware>> GetFirmwareAsync(Stream fileStream, bool compressed)
        {
            List<Firmware> firmwares = new List<Firmware>();

            if (compressed)
            {
                using (var bz2Stream = new BZip2InputStream(fileStream))
                {
                    var pump = new FramePump(bz2Stream);
                    pump.FrameReceived += frame =>
                    {
                        var deserializer = DeserializerState.CreateRoot(frame);
                        var reader = new Event.READER(deserializer);
                        if (reader.which == Event.WHICH.CarParams)
                        {
                            foreach (var fw in reader.CarParams.TheCarFw)
                            {
                                var firmware = new Firmware(fw.Ecu, fw.FwVersion.ToArray(), fw.Address, fw.SubAddress);
                                firmwares.Add(firmware);
                            }
                        }
                    };
                    await Task.Run(() =>
                    {
                        pump.Run();
                    }).ConfigureAwait(false);

                }
            }
            else
            {
                var pump = new FramePump(fileStream);
                pump.FrameReceived += frame =>
                {
                    var deserializer = DeserializerState.CreateRoot(frame);
                    var reader = new Event.READER(deserializer);
                    if (reader.which == Event.WHICH.CarParams)
                    {
                        foreach (var fw in reader.CarParams.TheCarFw)
                        {
                            var firmware = new Firmware(fw.Ecu, fw.FwVersion.ToArray(), fw.Address, fw.SubAddress);
                            firmwares.Add(firmware);
                        }
                    }
                };
                await Task.Run(() =>
                {
                    pump.Run();
                }).ConfigureAwait(false);
            }
            
            return firmwares;
        }
    }
}
