using System.Collections.ObjectModel;

namespace OpenpilotSdk.OpenPilot
{
    public sealed class Route
    {
        private bool Equals(Route other)
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

            return Equals((Route)obj);
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode();
        }

        public static bool operator ==(Route left, Route right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Route left, Route right)
        {
            return !Equals(left, right);
        }

        public ReadOnlyCollection<RouteSegment> Segments { get; }
        public DateTime Date { get; }

        public Route(DateTime date, IList<RouteSegment> routeSegments)
        {
            Date = date;
            Segments = new ReadOnlyCollection<RouteSegment>(routeSegments);
        }

        public override string ToString()
        {
            return Date.ToString("yyyy-MM-dd--HH-mm-ss");
        }
    }

}
