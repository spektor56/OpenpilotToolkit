namespace OpenpilotSdk.OpenPilot.Fork
{
    public sealed class InstallProgress
    {
        public int Progress { get; private set; }
        public string ProgressText { get; private set; }


        public InstallProgress(int progress, string progressText)
        {
            Progress = progress;
            ProgressText = progressText;
        }
    }
}
