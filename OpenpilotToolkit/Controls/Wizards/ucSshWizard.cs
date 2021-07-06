using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Fluent;
using CefSharp.WinForms;
using Octokit;

namespace OpenpilotToolkit.Controls.Wizards
{
    public partial class ucSshWizard : UserControl
    {
        readonly GitHubClient _githubClient = new GitHubClient(new ProductHeaderValue("OpenpilotToolkit", "2.1.0"));
        private string _clientId = "MDExMDk0NjJlYzU2YzliODM1ZDI=";
        private string _clientSecret = "M2ViZmJkNjI5ZjhiNWM4M2RjYjNjZDk5Y2I3MGM5Y2Y2OTgyOTE3OQ==";
        private string _oauthCode = "";
        private Form _loginDialog;

        public event EventHandler WizardCompleted;

        protected virtual void OnWizardCompleted(EventArgs e)
        {
            EventHandler handler = WizardCompleted;
            handler?.Invoke(this, e);
        }

        public ucSshWizard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            mtcSSHWizard.SelectedIndex = 0;
        }

        private async void ucWizard_Load(object sender, EventArgs e)
        {
            _clientId = Encoding.UTF8.GetString(Convert.FromBase64String(_clientId));
            _clientSecret = Encoding.UTF8.GetString(Convert.FromBase64String(_clientSecret));
            
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.GithubToken))
            {
                _githubClient.Credentials = new Credentials(Properties.Settings.Default.GithubToken, AuthenticationType.Oauth);
                NextStep();
            }
            
        }

        private void BrowserOnAddressChanged(object? sender, AddressChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Address))
            {
                var uri = new Uri(e.Address);
                if (!string.IsNullOrWhiteSpace(uri.Query))
                {
                    var oauthCode = HttpUtility.ParseQueryString(uri.Query).Get("code");
                    _oauthCode = oauthCode;

                    if (!string.IsNullOrWhiteSpace(_oauthCode))
                    {
                        _loginDialog.Invoke(new MethodInvoker(() => { _loginDialog.Close(); }));
                    }
                }
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            
            var oauthLoginRequest = new OauthLoginRequest(_clientId);
            oauthLoginRequest.Scopes.Add("write:public_key");
            var loginUrl = _githubClient.Oauth.GetGitHubLoginUrl(oauthLoginRequest);

            using (var browser = new ChromiumWebBrowser(loginUrl.ToString()))
            {
                browser.AddressChanged += BrowserOnAddressChanged;
                using (_loginDialog = new Form())
                {
                    _loginDialog.Size = new Size(374, 662);
                    _loginDialog.StartPosition = FormStartPosition.CenterScreen;
                    _loginDialog.Controls.Add(browser);
                    browser.Dock = DockStyle.Fill;
                    _loginDialog.ShowDialog();
                }
            }
            
            if (!string.IsNullOrWhiteSpace(_oauthCode))
            {
                var accessToken = await _githubClient.Oauth.CreateAccessToken(new OauthTokenRequest(_clientId, _clientSecret, _oauthCode));
                _githubClient.Credentials = new Credentials(accessToken.AccessToken, AuthenticationType.Oauth);
                Properties.Settings.Default.GithubToken = accessToken.AccessToken;
                mtcSSHWizard.SelectedIndex =
                    Math.Min(mtcSSHWizard.TabCount, mtcSSHWizard.SelectedIndex + 1);
            }
            else
            {
                btnLogin.Enabled = true;
            }
        }

        public void NextStep()
        {
            if (mtcSSHWizard.SelectedIndex >= mtcSSHWizard.TabCount - 1)
            {
                OnWizardCompleted(EventArgs.Empty);
            }

            mtcSSHWizard.SelectedIndex =
                Math.Min(mtcSSHWizard.TabCount, mtcSSHWizard.SelectedIndex + 1);
            
        }

        public void PreviousStep()
        {
            mtcSSHWizard.SelectedIndex =
                Math.Max(0, mtcSSHWizard.SelectedIndex - 1);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PreviousStep();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextStep();
        }

        private void materialTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void btnGenerateSSHKey_Click(object sender, EventArgs e)
        {
            btnGenerateSSHKey.Enabled = false;
            var keygen = new SshKeyGenerator.SshKeyGenerator(4096);
            
            /*
            var keys = await _githubClient.User.GitSshKey.GetAllForCurrent();
            if (keys.Any(publicKey => publicKey.Title.Equals("OpenpilotToolkitKey", StringComparison.OrdinalIgnoreCase)))
            {
                MaterialSkin.Controls.MaterialMessageBox.Show("SSH key already exists, do you want to skip this step?");
            }
            */
            await _githubClient.User.GitSshKey.Create(new NewPublicKey("OpenpilotToolkitKey", keygen.ToRfcPublicKey()));
            await File.WriteAllTextAsync("opensshkey", keygen.ToPrivateKey());

            btnGenerateSSHKey.Enabled = true;

            NextStep();
        }

        private void mtcSSHWizard_Selected(object sender, TabControlEventArgs e)
        {
            btnPrevious.Visible = true;
            btnNext.Visible = true;
            if (e.TabPage != null && e.TabPage == tpGithubLogin)
            {
                btnPrevious.Visible = false;
                if (string.IsNullOrWhiteSpace(Properties.Settings.Default.GithubToken))
                {
                    btnNext.Visible = false;
                }
            }
        }
    }
}
