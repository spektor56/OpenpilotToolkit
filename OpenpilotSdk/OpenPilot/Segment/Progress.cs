namespace OpenpilotSdk.OpenPilot.Segment
{
    public sealed class Progress
    {
        public int Segment { get; }
        public int Percent { get; set; }

        public Progress(int segment)
        {
            Segment = segment;
        }
    }
}
