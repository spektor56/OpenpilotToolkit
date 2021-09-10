using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenpilotToolkitAndroid.Openpilot.Fork
{
    public class InstallProgress
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

