using Capnp;
using Cereal;
using FFMpegCore.Enums;
using ICSharpCode.SharpZipLib.BZip2;
using MathNet.Numerics;
using MathNet.Numerics.Interpolation;
using NetTopologySuite.IO;
using System.Collections.Immutable;
using System.Diagnostics;

namespace OpenpilotSdk.OpenPilot.Logging
{
    public sealed class LogFile
    {
        public static async Task<IEnumerable<GpxWaypoint>> GetWaypointsAsync(Stream fileStream, CompressionAlgorithm compressionAlgorithm)
        {
            List<GpxWaypoint> waypoints = new List<GpxWaypoint>();

            if (compressionAlgorithm == CompressionAlgorithm.BZip2)
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
                            
                            if (reader.Valid && reader.GpsLocation.HasFix && reader.GpsLocationExternal.Latitude != 0 &&
                                reader.GpsLocationExternal.Longitude != 0 &&
                                (double)reader.GpsLocationExternal.HorizontalAccuracy < 1)
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
            else if (compressionAlgorithm == CompressionAlgorithm.ZStd)
            {
                using (var zstdStream = new ZstdSharp.DecompressionStream(fileStream))
                {
                    var pump = new FramePump(zstdStream);
                    pump.FrameReceived += frame =>
                    {
                        var deserializer = DeserializerState.CreateRoot(frame);
                        var reader = new Event.READER(deserializer);
                        if (reader.which == Event.WHICH.GpsLocation)
                        {

                            if (reader.Valid && reader.GpsLocation.HasFix && reader.GpsLocation.Latitude != 0 &&
                                reader.GpsLocation.Longitude != 0 &&
                                (double)reader.GpsLocation.HorizontalAccuracy < 1)
                            {
                                DateTime utcDate =
                                    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                                        .AddSeconds((double)reader.GpsLocation.UnixTimestampMillis / 1000);

                                uint satelliteCount = 0;
                                if (reader.GpsLocation.SatelliteCount > 0)
                                {
                                    satelliteCount = (uint)reader.GpsLocation.SatelliteCount;

                                }

                                var waypoint = new GpxWaypoint(
                                    new GpxLongitude(Math.Round(reader.GpsLocation.Longitude, 7)),
                                    new GpxLatitude(Math.Round(reader.GpsLocation.Latitude, 7)),
                                    Math.Round(reader.GpsLocation.Altitude), utcDate, null, null, null, null,
                                    null, reader.GpsLocation.Source.ToString(), ImmutableArray<GpxWebLink>.Empty, null, null, null, satelliteCount, null, null, null,
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
                        if (reader.Valid && reader.GpsLocation.HasFix && reader.GpsLocation.Latitude != 0 &&
                            reader.GpsLocation.Longitude != 0 &&
                            (double)reader.GpsLocation.HorizontalAccuracy < 1)
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

        public static async Task<IEnumerable<Firmware>> GetFirmwareAsync(Stream fileStream, CompressionAlgorithm compressionAlgorithm)
        {
            List<Firmware> firmwares = new List<Firmware>();

            if (compressionAlgorithm == CompressionAlgorithm.BZip2)
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
            else if (compressionAlgorithm == CompressionAlgorithm.ZStd)
            {
                using (var zstdStream = new ZstdSharp.DecompressionStream(fileStream))
                {
                    var pump = new FramePump(zstdStream);
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
        static double[] LOW_SPEED_X = { 0, 10, 20, 30 };
        static double[] LOW_SPEED_Y = { 15, 13, 10, 5 };
        public static async Task<List<TorqueTest>> GetTorque(Stream fileStream, CompressionAlgorithm compressionAlgorithm)
        {
            List<TorqueTest> torque = new List<TorqueTest>();

            if (compressionAlgorithm == CompressionAlgorithm.BZip2)
            {
                using (var bz2Stream = new BZip2InputStream(fileStream))
                {
                    var enabled = false;
                    float speed = 0;
                    var pump = new FramePump(bz2Stream);
                    pump.FrameReceived += frame =>
                    {
                        var deserializer = DeserializerState.CreateRoot(frame);
                        var reader = new Event.READER(deserializer);

                        if (reader.which == Event.WHICH.SelfdriveState)
                        {
                            enabled = (reader.SelfdriveState.State == SelfdriveState.OpenpilotState.enabled);
                        }

                        if (reader.which == Event.WHICH.CarState)
                        {
                            speed = reader.CarState.VEgo;
                        }

                        if (reader.which == Event.WHICH.ControlsState)
                        {
                            if (enabled)
                            {
                                if (reader.Valid && reader.ControlsState.LateralControlState.TorqueState.Active &&
                                    !reader.ControlsState.LateralControlState.TorqueState.Saturated &&
                                    (reader.ControlsState.LateralControlState.TorqueState.Output != 0 ||
                                     reader.ControlsState.LateralControlState.TorqueState.ActualLateralAccel != 0))
                                {
                                    //torque.Add(new TorqueTest(reader.ControlsState.LateralControlState.TorqueState, speed));
                                }
                            }
                        }
                    };
                    await Task.Run(() =>
                    {
                        pump.Run();
                    }).ConfigureAwait(false);

                }
            }
            else if (compressionAlgorithm == CompressionAlgorithm.ZStd)
            {
                using (var zstdStream = new ZstdSharp.DecompressionStream(fileStream))
                {
                    var enabled = false;
                    float speed = 0;
                    float roll = 0;
                    var pump = new FramePump(zstdStream);
                    int selfDriveCount = 0;
                    int carStateCount = 0;
                    int controlStateCount = 0;
                    float currentTorque = 0;
                    bool seenSelfdriveState = false;
                    bool seenCarState = false;
                    bool seenLiveParameters = false;
                    bool seenCarOutput = false;
                    bool ignore = true;

                    var interpolator = LinearSpline.Interpolate(LOW_SPEED_X, LOW_SPEED_Y);

                    var addresses = new List<string>();
                    pump.FrameReceived += frame =>
                    {
                        var deserializer = DeserializerState.CreateRoot(frame);
                        var reader = new Event.READER(deserializer);
                        
                        if (reader.which == Event.WHICH.SelfdriveState)
                        {
                            //Debug.Print(reader.LogMonoTime + " SelfDriveState" );
                            seenSelfdriveState = true;
                            selfDriveCount++;
                            enabled = (reader.SelfdriveState.State == SelfdriveState.OpenpilotState.enabled);
                        }

                        if (reader.which == Event.WHICH.CarState)
                        {
                            seenCarState = true;
                            //Debug.Print(reader.LogMonoTime + " CarState");
                            carStateCount++;
                            speed = reader.CarState.VEgo;
                        }

                        if (reader.which == Event.WHICH.LiveParameters)
                        {
                            seenLiveParameters = true;
                            roll = reader.LiveParameters.Roll;
                        }

                        if (reader.which == Event.WHICH.CarOutput)
                        {
                            seenCarOutput = true;
                            currentTorque = -reader.CarOutput.ActuatorsOutput.Torque;
                        }

                        if (reader.which == Event.WHICH.InitData)
                        {
                            if (reader.InitData.GitBranch != "myMaster")
                            {
                                ignore = false;
                            }
                        }

                        if (reader.which == Event.WHICH.Can)
                        {
                            foreach (var message in reader.Can)
                            {
                                if (message.Address == 676)
                                {
                                    addresses.Add(message.Src.ToString());
                                    //Debug.Print(message.Address + "-" + message.Src);
                                }

                                if (message.Address == 416)
                                {
                                    //Debug.Print(message.Address + "-" + message.Src);
                                }
                            }
                        }

                        if (reader.which == Event.WHICH.ControlsState)
                        {
                            controlStateCount++;
                            //Debug.Print(reader.LogMonoTime + " ControlsState");
                            if (!ignore && enabled && seenSelfdriveState && seenCarState && seenLiveParameters && seenCarOutput)
                            {
                                if (reader.Valid && reader.ControlsState.LateralControlState.TorqueState.Active &&
                                    !reader.ControlsState.LateralControlState.TorqueState.Saturated &&
                                    (reader.ControlsState.LateralControlState.TorqueState.Output != 0 ||
                                     reader.ControlsState.LateralControlState.TorqueState.ActualLateralAccel != 0))
                                {
                                    var lateralAccelRollCompensated =
                                        (float)((reader.ControlsState.Curvature * Math.Pow(speed, 2)) - (roll * 9.81));

                                    var lowSpeedFactor = Math.Pow(interpolator.Interpolate(speed), 2);

                                    lateralAccelRollCompensated += (float)(lowSpeedFactor * reader.ControlsState.Curvature);

                                    torque.Add(new TorqueTest(currentTorque, lateralAccelRollCompensated, speed));
                                }
                            }
                        }
                    };
                    await Task.Run(() =>
                    {
                        pump.Run();
                    }).ConfigureAwait(false);
                    Debug.Print("Addresses: " + string.Join(",", addresses.Distinct()));
                    //Debug.Print("Selfdrivecount: " + selfDriveCount);
                    //Debug.Print("carStateCount: " + carStateCount);
                    //Debug.Print("controlStateCount: " + controlStateCount);
                }
            }
            else
            {
                var enabled = false;
                float speed = 0;
                var pump = new FramePump(fileStream);
                pump.FrameReceived += frame =>
                {
                    var deserializer = DeserializerState.CreateRoot(frame);
                    var reader = new Event.READER(deserializer);

                    if (reader.which == Event.WHICH.SelfdriveState)
                    {
                        enabled = (reader.SelfdriveState.State == SelfdriveState.OpenpilotState.enabled);
                    }

                    if (reader.which == Event.WHICH.CarState)
                    {
                        speed = reader.CarState.VEgo;
                    }

                    if (reader.which == Event.WHICH.ControlsState)
                    {
                        if (enabled)
                        {
                            if (reader.Valid && reader.ControlsState.LateralControlState.TorqueState.Active &&
                                !reader.ControlsState.LateralControlState.TorqueState.Saturated &&
                                (reader.ControlsState.LateralControlState.TorqueState.Output != 0 ||
                                 reader.ControlsState.LateralControlState.TorqueState.ActualLateralAccel != 0))
                            {
                                //torque.Add(new TorqueTest(reader.ControlsState.LateralControlState.TorqueState, speed));
                            }
                        }
                    }

                };
                await Task.Run(() =>
                {
                    pump.Run();
                }).ConfigureAwait(false);
            }

            return torque;
        }

        public static CompressionAlgorithm GetCompressionAlgorithm(string fileName)
        {
            var extension = Path.GetExtension(fileName)?.ToLowerInvariant();

            switch (extension)
            {
                case ".bz2":
                    return CompressionAlgorithm.BZip2;
                case ".zst":
                    return CompressionAlgorithm.ZStd;
                case "":
                    return CompressionAlgorithm.None;
                default:
                    return CompressionAlgorithm.Unknown;
            }
        }
    }
}
