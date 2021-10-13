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

        public override void OnFormResubmission(WebView? view, Message? dontResend, Message? resend)
        {
            base.OnFormResubmission(view, dontResend, resend);
        }

        public override void OnLoadResource(WebView? view, string? url)
        {
            base.OnLoadResource(view, url);

        }

        public override void OnPageStarted(WebView? view, string? url, Bitmap? favicon)
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

        public override void OnReceivedHttpAuthRequest(WebView? view, HttpAuthHandler? handler, string? host, string? realm)
        {
            base.OnReceivedHttpAuthRequest(view, handler, host, realm);
        }

        public override void OnReceivedLoginRequest(WebView? view, string? realm, string? account, string? args)
        {
            base.OnReceivedLoginRequest(view, realm, account, args);
        }

        public override void OnPageFinished(WebView? view, string? url)
        {
            base.OnPageFinished(view, url);
        }
    }
}