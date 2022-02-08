using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Capnp;
using Cereal;
using ICSharpCode.SharpZipLib.BZip2;
using NetTopologySuite.IO;

namespace OpenpilotSdk.OpenPilot.Logging
{
    public class LogFile
    {
        public static async Task<IEnumerable<GpxWaypoint>> GetWaypointsAsync(Stream fileStream)
        {
            List<GpxWaypoint> waypoints = new List<GpxWaypoint>();

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
                                    .AddSeconds((double)reader.GpsLocationExternal.Timestamp / 1000);

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
                });

            }
            return waypoints;
        }

        public static async Task<IEnumerable<Firmware>> GetFirmware(Stream fileStream)
        {
            List<Firmware> firmwares = new List<Firmware>();

            //using (var fileStream = File.OpenRead(file))
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
                });

            }
            return firmwares;
        }
    }
}
