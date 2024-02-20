namespace OpenpilotSdk.Git
{
    public sealed class ForkResult
    {
        public bool Success { get; }
        public string Message { get; }

        public ForkResult(string message, bool success)
        {
            Success = success;
            Message = message ?? "";
        }
    }
}
