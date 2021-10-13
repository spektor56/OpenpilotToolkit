using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenpilotSdk.Git;
using OpenpilotSdk.OpenPilot.Fork;

namespace OpenpilotSdk.Hardware
{
    public class Comma3 : OpenpilotDevice
    {
        public override string StorageDirectory { get; protected set; } = @"/data/media/0/realdata/";

        public Comma3(IPAddress hostAddress, bool isAuthenticated = true)
        {
            IsAuthenticated = isAuthenticated;
            IpAddress = hostAddress;
        }

        public override async Task<bool> RebootAsync()
        {
            using (var command = SshClient.CreateCommand("sudo reboot"))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0;
                return success;
            }
        }

        public override async Task<ForkResult> InstallFork(string username, string branch, IProgress<InstallProgress> progress)
        {
            if (progress == null)
            {
                return await InstallFork(username, branch).ConfigureAwait(false);
            }

            var installCommand =
                string.Format(@"cd /data && rm -rf openpilot ; git clone -b {1} --depth 1 --single-branch --progress --recurse-submodules --shallow-submodules https://github.com/{0}/openpilot.git openpilot", username, branch);

            var progressRegex = new Regex(@"\d+(?=%)", RegexOptions.Compiled);
            int previousProgress = 0;
            string lastLineRead = "";

            using (var command = SshClient.CreateCommand(installCommand))
            {
                var asyncResult = command.BeginExecute();
                using (var streamReader = new StreamReader(command.ExtendedOutputStream))
                {
                    while (!asyncResult.IsCompleted)
                    {
                        var output = await streamReader.ReadLineAsync().ConfigureAwait(false);
                        if (!string.IsNullOrWhiteSpace(output))
                        {
                            lastLineRead = output;
                            var match = progressRegex.Match(output);

                            if (!string.IsNullOrWhiteSpace(match.Value))
                            {
                                if (int.TryParse(match.Value, out int currentProgress))
                                {
                                    if (previousProgress != currentProgress)
                                    {
                                        previousProgress = currentProgress;
                                        var progressText = output.Substring(0, match.Index).Trim();
                                        progressText = progressText.Remove(progressText.Length - 1);
                                        progress.Report(new InstallProgress(currentProgress, progressText));
                                    }
                                }
                            }
                        }
                    }

                    var result = command.EndExecute(asyncResult);
                    var success = command.ExitStatus == 0;

                    if (success)
                    {
                        using (var rebootCommand = SshClient.CreateCommand("sudo reboot"))
                        {
                            rebootCommand.BeginExecute();
                        }
                    }

                    return new ForkResult(string.IsNullOrWhiteSpace(result) ? lastLineRead : result,
                        success);
                }
            }
        }

        public override async Task<ForkResult> InstallFork(string username, string branch)
        {
            var installCommand =
                string.Format(@"cd /data && rm -rf openpilot; git clone -b {1} --depth 1 --single-branch --recurse-submodules --shallow-submodules https://github.com/{0}/openpilot.git openpilot", username, branch);

            using (var command = SshClient.CreateCommand(installCommand))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0 || !(string.IsNullOrWhiteSpace(result) && !string.IsNullOrWhiteSpace(command.Error));

                if (success)
                {
                    using (var rebootCommand = SshClient.CreateCommand("sudo reboot"))
                    {
                        rebootCommand.BeginExecute();
                    }
                }

                return new ForkResult(string.IsNullOrWhiteSpace(result) ? command.Error : result,
                    success);
            }
        }
    }
}
