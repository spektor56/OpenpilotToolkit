using System;
using System.Collections.Generic;
using System.Text;

namespace OpenpilotSdk.OpenPilot.Segment
{
    public class Progress
    {
        public int Segment { get; }
        public int Percent { get; set; }

        public Progress(int segment)
        {
            Segment = segment;
        }
    }
}
