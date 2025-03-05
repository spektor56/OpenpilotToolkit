using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using AndroidX.AppCompat.App;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.Navigation;
using Google.Android.Material.Snackbar;
using Java.Interop;
using Octokit;
using Serilog;
using Serilog.Core;
using SshNet.Keygen;
using SshNet.Keygen.Extensions;
using System.Text;
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
        private AutoCompleteTextView _cmbSshAlgorithms;
        private string _githubToken = "";

        protected override void OnCreate(Bundle? savedInstanceState)
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
            
            var algorithmList = Enum.GetValues(typeof(SshKeyType)).Cast<SshKeyType>().Select(key => key.ToString()).ToArray();
            ArrayAdapter<String> adapter = new ArrayAdapter<String>(this,
                Resource.Layout.list_item, algorithmList);
            _cmbSshAlgorithms = FindViewById<AutoCompleteTextView>(Resource.Id.autocomplete_algorithm);
            _cmbSshAlgorithms.Adapter = adapter;
            _cmbSshAlgorithms.SetText(SshKeyType.ED25519.ToString(), false);
        }

        [Export("GithubLogin")]
        public async void GithubLogin(View? view)
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

        [Export("GenerateSshKey")]
        public async void GenerateSshKey(View? view)
        {
            var keyAlgorithm = _cmbSshAlgorithms.Text;
            if (string.IsNullOrWhiteSpace(keyAlgorithm))
            {
                Snackbar.Make(view, $"Key Algorithm is required.", BaseTransientBottomBar.LengthLong).Show();
                return;
            }

            var sshAlgorithmLayout = FindViewById<LinearLayout>(Resource.Id.sshAlgorithmLayout);
            var progressSection = FindViewById<LinearLayout>(Resource.Id.progressSectionSSH);
            var progressText = FindViewById<TextView>(Resource.Id.progressTextSSH);
            var sshLayout = FindViewById<LinearLayout>(Resource.Id.sshLoginLayout);

            sshAlgorithmLayout.Visibility = ViewStates.Gone;
            progressSection.Visibility = ViewStates.Visible;

            try
            {
                await Task.Run(async () =>
                {
                    var accessToken =
                        await _githubClient.Oauth.CreateAccessToken(new OauthTokenRequest(_clientId, _clientSecret,
                            _githubToken));
                    _githubClient.Credentials = new Credentials(accessToken.AccessToken, AuthenticationType.Oauth);

                    var sshKeyGenerateInfo = new SshKeyGenerateInfo(Enum.Parse<SshKeyType>(keyAlgorithm.ToString()));
                    var generatedKey = SshKey.Generate(sshKeyGenerateInfo);

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
                            generatedKey.ToPublic()));
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
                                "opensshkey"), generatedKey.ToOpenSshFormat());
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
        
        private async void SshWebViewClientOnTokenReceived(object? sender, TokenEventArgs e)
        {
            web_view = FindViewById<WebView>(Resource.Id.webView1);
            var sshLayout = FindViewById<LinearLayout>(Resource.Id.sshLoginLayout);
            var sshAlgorithmLayout = FindViewById<LinearLayout>(Resource.Id.sshAlgorithmLayout);

            _githubToken = e.Token;

            if (!string.IsNullOrWhiteSpace(_githubToken))
            {
                web_view.Visibility = ViewStates.Gone;
                sshLayout.Visibility = ViewStates.Gone;
                sshAlgorithmLayout.Visibility = ViewStates.Visible;
            }
            else
            {
                web_view.Visibility = ViewStates.Gone;
                sshLayout.Visibility = ViewStates.Visible;
                sshAlgorithmLayout.Visibility = ViewStates.Gone;
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