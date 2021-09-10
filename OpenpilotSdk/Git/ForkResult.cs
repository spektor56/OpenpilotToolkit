namespace OpenpilotSdk.Git
{
    public class ForkResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public ForkResult(string message, bool success)
        {
            Success = success;
            Message = message ?? "";
        }
    }
}
