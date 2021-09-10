using System;

namespace OpenpilotToolkitAndroid
{
    public class TokenEventArgs : EventArgs
    {
        public TokenEventArgs(string token) { Token = token; }
        public string Token { get; } // readonly
    }
}