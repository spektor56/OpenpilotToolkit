using System.Collections.ObjectModel;
using OpenpilotSdk.Hardware;
using OpenpilotSdk.OpenPilot.FileTypes;

namespace OpenpilotSdk.OpenPilot
{
    public sealed class RouteSegment
    {
        public IReadOnlyDictionary<CameraType,VideoSegment> RawVideoSegments { get; }
        public IReadOnlyDictionary<CameraType, VideoSegment> VideoSegments { get; }

        public LogFile? QuickLog { get; }
        public LogFile? RawLog { get; }

        public string Path { get; }

        public int Index { get; }

        public RouteSegment(int index, string path, Dictionary<CameraType, VideoSegment> rawVideoSegments, Dictionary<CameraType, VideoSegment> videoSegments, LogFile quickLog, LogFile rawLog = null)
        {
            Path = path;
            Index = index;
            RawVideoSegments = new ReadOnlyDictionary<CameraType,VideoSegment>(rawVideoSegments);
            VideoSegments = new ReadOnlyDictionary<CameraType, VideoSegment>(videoSegments);
            QuickLog = quickLog;
            RawLog = rawLog;
        }

        public override string ToString()
        {
            return Index.ToString();
        }
    }
}
