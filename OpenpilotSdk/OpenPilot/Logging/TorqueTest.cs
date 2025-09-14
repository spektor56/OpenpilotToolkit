using System;
using System.Collections.Generic;
using System.Text;
using Cereal;

namespace OpenpilotSdk.OpenPilot.Logging
{
    public class TorqueTest
    {
        public float Torque { get; set; }
        public float Speed { get; set; }
        public float LateralAccel { get; set; }
        
        public TorqueTest(float torque, float compensatedLateralAccel, float speed)
        {
            LateralAccel = compensatedLateralAccel;
            Torque = torque;
            Speed = speed;
        }
    }
}
