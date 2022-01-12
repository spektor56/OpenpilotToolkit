using Android.OS;
using System;
using Android.Graphics;
using Android.Webkit;
using System.Web;

namespace OpenpilotToolkitAndroid
{
    public class SshWebViewClient : WebViewClient
    {
        public event EventHandler<TokenEventArgs> TokenReceived;

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.

        protected virtual void OnTokenReceived(TokenEventArgs e)
        {
            EventHandler<TokenEventArgs> handler = TokenReceived;
            handler?.Invoke(this, e);
        }

        public override void OnPageStarted(WebView view, string url, Bitmap favicon)
        {
            base.OnPageStarted(view, url, favicon);

            if (url != null && !string.IsNullOrWhiteSpace(url))
            {
                var uri = new Uri(url);
                if (!string.IsNullOrWhiteSpace(uri.Query))
                {
                    var oauthCode = HttpUtility.ParseQueryString(uri.Query).Get("code");
                    
                    if (!string.IsNullOrWhiteSpace(oauthCode))
                    {
                        OnTokenReceived(new TokenEventArgs(oauthCode));
                    }
                }
            }

        }
    }
}