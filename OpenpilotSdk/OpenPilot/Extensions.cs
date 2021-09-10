using System;
using System.Text.RegularExpressions;

namespace OpenpilotSdk.OpenPilot
{
    public static class Extensions
    {
        public static readonly Regex FolderRegex = new Regex(@"^(\d{4}-\d{2}-\d{2})--(\d{2}-\d{2}-\d{2})--(\d+)$", RegexOptions.Compiled);
        private static Object _lockObject = new Object();
    }
}
