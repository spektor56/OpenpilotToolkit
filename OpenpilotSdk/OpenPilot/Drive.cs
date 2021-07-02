using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenpilotSdk.OpenPilot
{
    public class Drive
    {
        public ReadOnlyCollection<DriveSegment> Segments { get; }
        public DateTime Date { get; }

        public Drive(DateTime date, IList<DriveSegment> driveSegments)
        {
            Date = date;
            Segments = new ReadOnlyCollection<DriveSegment>(driveSegments);
        }

        public override string ToString()
        {
            return Date.ToString("yyyy-MM-dd--HH-mm-ss");
        }
    }

}
