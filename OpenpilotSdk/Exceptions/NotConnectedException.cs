using System;

namespace OpenpilotSdk.Exceptions
{
    public class NotConnectedException : Exception
    {
        public NotConnectedException()
        {
        }

        public NotConnectedException(string message)
            : base(message)
        {
        }

        public NotConnectedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
