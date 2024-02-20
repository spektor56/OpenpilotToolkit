using System.Net;

namespace OpenpilotSdk.Hardware
{
    public sealed class Comma2 : OpenpilotDevice
    {
        protected override string NotConnectedMessage => "No connection has been made to the Comma2";

        public static string OpenSettingsCommand => @"am start -a android.settings.SETTINGS";
        public static string CloseSettingsCommand => @"kill $(pgrep com.android.settings)";
        public override string DeviceName => @"Comma2";

        private readonly Lazy<IReadOnlyDictionary<CameraType, Camera>> _cameras = new Lazy<IReadOnlyDictionary<CameraType, Camera>>(() => new Dictionary<CameraType, Camera>
        {
            { CameraType.Front, new Camera(CameraType.Front) },
            { CameraType.Driver, new Camera(CameraType.Driver,10) },
        });

        public override IReadOnlyDictionary<CameraType, Camera> Cameras => _cameras.Value;

        public Comma2(IPAddress hostAddress, bool isAuthenticated = true)
        {
            IsAuthenticated = isAuthenticated;
            IpAddress = hostAddress;
        }

        private async Task<bool> ExecuteCommandAsync(string commandString)
        {
            await ConnectAsync();

            using (var command = SshClient.CreateCommand(commandString))
            {
                var result = await Task.Factory.FromAsync(command.BeginExecute(), command.EndExecute).ConfigureAwait(false);
                var success = command.ExitStatus == 0;
                return success;
            }
        }

        public Task<bool> OpenSettingsAsync() => ExecuteCommandAsync(OpenSettingsCommand);
        public Task<bool> CloseSettingsAsync() => ExecuteCommandAsync(CloseSettingsCommand);
    }
}