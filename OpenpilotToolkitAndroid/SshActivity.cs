using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Webkit;
using AndroidX.AppCompat.App;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.Navigation;
using Java.Interop;
using Octokit;
using OpenpilotSdk.Hardware;
using OpenpilotSdk.Git;
using Serilog;
using Serilog.Core;
using Xamarin.Essentials;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace OpenpilotToolkitAndroid
{
    [Activity(Label = "SSH Wizard", Theme = "@style/AppTheme.NoActionBar")]
    public class SshActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        readonly GitHubClient _githubClient = new GitHubClient(new ProductHeaderValue("OpenpilotToolkit", "2.1.0"));
        private string _clientId = "MDExMDk0NjJlYzU2YzliODM1ZDI=";
        private string _clientSecret = "M2ViZmJkNjI5ZjhiNWM4M2RjYjNjZDk5Y2I3MGM5Y2Y2OTgyOTE3OQ==";
        private string _oauthCode = "";
        private WebView web_view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .Enrich.WithProperty(Constants.SourceContextPropertyName, "OpenpilotToolkit")
                .CreateLogger();
            
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightYes;

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            
            SetContentView(Resource.Layout.activity_ssh);

            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);


            _clientId = Encoding.UTF8.GetString(Convert.FromBase64String(_clientId));
            _clientSecret = Encoding.UTF8.GetString(Convert.FromBase64String(_clientSecret));

            web_view = FindViewById<WebView>(Resource.Id.webView1);

            WebStorage.Instance.DeleteAllData();

            CookieManager.Instance.RemoveAllCookies(null);
            CookieManager.Instance.Flush();

            web_view.ClearCache(true);
            web_view.ClearFormData();
            web_view.ClearHistory();
            web_view.ClearSslPreferences();

            web_view.Settings.JavaScriptEnabled = true;
            var sshWebViewClient = new SshWebViewClient();
            sshWebViewClient.TokenReceived += SshWebViewClientOnTokenReceived;
            web_view.SetWebViewClient(sshWebViewClient);
            web_view.Visibility = ViewStates.Gone;
        }

        [Export("GithubLogin")]
        public async void GithubLogin(View view)
        {
            var username = FindViewById<EditText>(Resource.Id.txtUsername);
            

            var oauthLoginRequest = new OauthLoginRequest(_clientId)
            {
                Login = username.Text
            };
            oauthLoginRequest.Scopes.Add("admin:public_key");
            var loginUrl = _githubClient.Oauth.GetGitHubLoginUrl(oauthLoginRequest);
            
            
            web_view.Visibility = ViewStates.Visible;
            web_view.LoadUrl(loginUrl.ToString());
        }

        private async void SshWebViewClientOnTokenReceived(object sender, TokenEventArgs e)
        {
            web_view = FindViewById<WebView>(Resource.Id.webView1);
            var sshLayout = FindViewById<LinearLayout>(Resource.Id.sshLoginLayout);
            var progressSection = FindViewById<LinearLayout>(Resource.Id.progressSectionSSH);
            var progressText = FindViewById<TextView>(Resource.Id.progressTextSSH);

            web_view.Visibility = ViewStates.Gone;
            sshLayout.Visibility = ViewStates.Invisible;
            progressSection.Visibility = ViewStates.Visible;

            try
            {
                await Task.Run(async () =>
                {
                    var accessToken =
                        await _githubClient.Oauth.CreateAccessToken(new OauthTokenRequest(_clientId, _clientSecret,
                            e.Token));
                    _githubClient.Credentials = new Credentials(accessToken.AccessToken, AuthenticationType.Oauth);

                    var keygen = new SshKeyGenerator.SshKeyGenerator(4096);

                    try
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            progressText.Text = "Removing old public keys";
                        });

                        var keys = await _githubClient.User.GitSshKey.GetAllForCurrent();
                        foreach (var key in keys.Where(publicKey =>
                            publicKey.Title.Equals("OpenpilotToolkitAndroidKey", StringComparison.OrdinalIgnoreCase)))
                        {
                            try
                            {
                                await _githubClient.User.GitSshKey.Delete(key.Id);
                                Serilog.Log.Information("Deleted github SSH public key '{key}'", key.Title);
                            }
                            catch (Exception exception)
                            {
                                Serilog.Log.Error(exception, "Failed to delete github SSH public key '{key}'",
                                    key.Title);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        Serilog.Log.Error(exception, "Failed to retrieve github SSH public key list");
                    }

                    try
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            progressText.Text = "Uploading public SSH key";
                        });
                        await _githubClient.User.GitSshKey.Create(new NewPublicKey("OpenpilotToolkitAndroidKey",
                            keygen.ToRfcPublicKey()));
                        Serilog.Log.Information("Created new github SSH public key '{key}'",
                            "OpenpilotToolkitAndroidKey");
                    }
                    catch (Exception exception)
                    {
                        Serilog.Log.Error(exception, "Failed to create github SSH public key");
                        throw;
                    }

                    try
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            progressText.Text = "Saving private key";
                        });
                        await File.WriteAllTextAsync(
                            Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                                "opensshkey"), keygen.ToPrivateKey());
                        Serilog.Log.Information("Updated opensshkey private key file");

                        Intent mainActivity = new Intent(this, typeof(MainActivity));
                        StartActivity(mainActivity);
                        OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.FadeOut);
                        Finish();
                    }
                    catch (Exception exception)
                    {
                        Serilog.Log.Error(exception, "Failed to save github SSH private key");
                        throw;
                    }
                });

            }
            catch (Exception exception)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Android.Widget.Toast.MakeText(ApplicationContext,
                        exception.Message,
                        Android.Widget.ToastLength.Long).Show();
                });
            }
            finally
            {
                sshLayout.Visibility = ViewStates.Visible;
            }
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
                    [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.ssh_wizard)
            {

            }
            else if (id == Resource.Id.fork_installer)
            {
                Intent mainActivity = new Intent(this, typeof(MainActivity));
                StartActivity(mainActivity);
                OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.FadeOut);
                Finish();

            }
            else if (id == Resource.Id.log_file)
            {
                var logActivity = new Intent(this, typeof(LogActivity));
                StartActivity(logActivity);
                OverridePendingTransition(Android.Resource.Animation.SlideInLeft, Android.Resource.Animation.FadeOut);
                Finish();
            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

    }
}