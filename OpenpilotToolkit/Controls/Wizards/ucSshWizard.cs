using System;
using System.CodeDom;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using CefSharp;
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
        private ToolkitForm _loginDialog;

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

        private void ucWizard_Load(object sender, EventArgs e)
        {
            _clientId = Encoding.UTF8.GetString(Convert.FromBase64String(_clientId));
            _clientSecret = Encoding.UTF8.GetString(Convert.FromBase64String(_clientSecret));
            
            if (!this.DesignMode)
            {
                string githubToken = "";
                try
                {
                    githubToken = Properties.Settings.Default.GithubToken;
                }
                catch(Exception)
                {
                    Debug.Print("Uri Exception");
                }
                
                if (!string.IsNullOrWhiteSpace(githubToken))
                {
                    _githubClient.Credentials =
                        new Credentials(Properties.Settings.Default.GithubToken, AuthenticationType.Oauth);
                    NextStep();
                }
                
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            
            var oauthLoginRequest = new OauthLoginRequest(_clientId)
            {
                Login = txtUsername.Text
            };
            oauthLoginRequest.Scopes.Add("admin:public_key");
            var loginUrl = _githubClient.Oauth.GetGitHubLoginUrl(oauthLoginRequest);
    
            using (var browser = new ChromiumWebBrowser(loginUrl.ToString()))
            {
                browser.FrameLoadStart += BrowserOnFrameLoadStart;
                browser.LoadError += BrowserOnLoadError; 
                using (_loginDialog = new ToolkitForm())
                {
                    _loginDialog.StartPosition = FormStartPosition.CenterParent;
                    _loginDialog.Text = "Github Login";
                    _loginDialog.Size = new Size(374, 662);
                    _loginDialog.MinimumSize = new Size(365, 613);
                    _loginDialog.StartPosition = FormStartPosition.CenterScreen;
                    _loginDialog.Controls.Add(browser);
                    browser.Dock = DockStyle.Fill;
                    _loginDialog.ShowDialog(this);
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
                SetLoginButtonEnabled(true);
            }
        }

        private void BrowserOnLoadError(object sender, LoadErrorEventArgs e)
        {
            _loginDialog.Invoke(new MethodInvoker(() =>
            {
                _loginDialog.Close();
                ToolkitMessageDialog.ShowDialog(e.ErrorText, this);
            }));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (mtcSSHWizard.SelectedTab == tpGithubLogin && txtUsername.Focused)
                {
                    btnLogin.PerformClick();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BrowserOnFrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Url))
            {
                var uri = new Uri(e.Url);
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

            try
            {
                await Task.Run(async () =>
                {
                    var keygen = new SshKeyGenerator.SshKeyGenerator(4096);

                    try
                    {
                        var keys = await _githubClient.User.GitSshKey.GetAllForCurrent();
                        foreach (var key in keys.Where(publicKey =>
                            publicKey.Title.Equals("OpenpilotToolkitKey", StringComparison.OrdinalIgnoreCase)))
                        {
                            try
                            {
                                await _githubClient.User.GitSshKey.Delete(key.Id);
                                Serilog.Log.Information("Deleted github SSH public key '{key}'", key.Title);
                            }
                            catch (Exception exception)
                            {
                                Serilog.Log.Error(exception, "Failed to delete github SSH public key '{key}'", key.Title);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        Serilog.Log.Error(exception, "Failed to retrieve github SSH public key list");
                    }

                    try
                    {
                        await _githubClient.User.GitSshKey.Create(new NewPublicKey("OpenpilotToolkitKey",
                            keygen.ToRfcPublicKey()));
                        Serilog.Log.Information("Created new github SSH public key '{key}'", "OpenpilotToolkitKey");
                    }
                    catch (Exception exception)
                    {
                        Serilog.Log.Error(exception, "Failed to create github SSH public key");
                        throw;
                    }

                    try
                    {
                        await File.WriteAllTextAsync("opensshkey", keygen.ToPrivateKey());
                        Serilog.Log.Information("Updated opensshkey private key file");
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
                ToolkitMessageDialog.ShowDialog(exception.Message, this);
                return;
            }
            finally
            {
                btnGenerateSSHKey.Enabled = true;
            }

            NextStep();
        }

        private void mtcSSHWizard_Selected(object sender, TabControlEventArgs e)
        {
            btnNext.Text = "&Next";

            btnPrevious.Visible = true;
            btnNext.Visible = true;
            if (e.TabPage != null )
            {
                if (e.TabPage == tpGithubLogin)
                {
                    btnPrevious.Visible = false;
                    if (string.IsNullOrWhiteSpace(Properties.Settings.Default.GithubToken))
                    {
                        btnNext.Visible = false;
                    }
                }
                else if(e.TabPage == tpSettings)
                {
                    btnNext.Text = "&Finish";
                }
            }
        }

        private void SetLoginButtonEnabled(bool enable)
        {
            if (txtUsername.Text.Length > 0 && enable)
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            SetLoginButtonEnabled(true);
        }
    }
}
