using System.Text.RegularExpressions;

namespace OpenpilotSdk.OpenPilot
{
    public static class Extensions
    {
        public static readonly Regex FolderRegex = new Regex(@"^((\d{4}-\d{2}-\d{2})--(\d{2}-\d{2}-\d{2})--(\d+)){1}|((([a-fA-F0-9]{8})--([a-fA-F0-9]{10}))--(\d+)){1}$", RegexOptions.Compiled);
        private static Object _lockObject = new Object();
    }
}
