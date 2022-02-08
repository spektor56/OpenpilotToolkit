using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenpilotSdk.OpenPilot
{
    public class Drive
    {
        protected bool Equals(Drive other)
        {
            return Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Drive)obj);
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode();
        }

        public static bool operator ==(Drive left, Drive right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Drive left, Drive right)
        {
            return !Equals(left, right);
        }

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
