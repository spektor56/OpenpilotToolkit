using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenpilotSdk.OpenPilot.Fork
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
