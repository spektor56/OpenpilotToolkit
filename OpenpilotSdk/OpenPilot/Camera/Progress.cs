using System;
using System.Collections.Generic;
using System.Text;

namespace OpenpilotSdk.OpenPilot.Camera
{
    public class Progress
    {
        public Hardware.Camera Camera { get; }
        public int Percent { get; set; }

        public Progress(Hardware.Camera camera)
        {
            Camera = camera;
        }
    }
}
