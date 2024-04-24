
namespace OpenpilotToolkit.Controls.Wizards
{
    partial class ucSshWizard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSshWizard));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            mtcSSHWizard = new MaterialSkin.Controls.MaterialTabControl();
            tpGithubLogin = new System.Windows.Forms.TabPage();
            txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            btnLogin = new MaterialSkin.Controls.MaterialButton();
            tpGenerateKey = new System.Windows.Forms.TabPage();
            cmbKeyAlgorithm = new MaterialSkin.Controls.MaterialComboBox();
            btnGenerateSSHKey = new MaterialSkin.Controls.MaterialButton();
            tpSettings = new System.Windows.Forms.TabPage();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            btnNext = new MaterialSkin.Controls.MaterialButton();
            btnPrevious = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel1.SuspendLayout();
            mtcSSHWizard.SuspendLayout();
            tpGithubLogin.SuspendLayout();
            tpGenerateKey.SuspendLayout();
            tpSettings.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.Controls.Add(mtcSSHWizard, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            tableLayoutPanel1.Size = new System.Drawing.Size(553, 367);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // mtcSSHWizard
            // 
            mtcSSHWizard.Controls.Add(tpGithubLogin);
            mtcSSHWizard.Controls.Add(tpGenerateKey);
            mtcSSHWizard.Controls.Add(tpSettings);
            mtcSSHWizard.Depth = 0;
            mtcSSHWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            mtcSSHWizard.Location = new System.Drawing.Point(3, 3);
            mtcSSHWizard.MouseState = MaterialSkin.MouseState.HOVER;
            mtcSSHWizard.Multiline = true;
            mtcSSHWizard.Name = "mtcSSHWizard";
            mtcSSHWizard.SelectedIndex = 0;
            mtcSSHWizard.Size = new System.Drawing.Size(550, 305);
            mtcSSHWizard.TabIndex = 0;
            mtcSSHWizard.TabStop = false;
            mtcSSHWizard.Selected += mtcSSHWizard_Selected;
            mtcSSHWizard.TabIndexChanged += materialTabControl1_TabIndexChanged;
            // 
            // tpGithubLogin
            // 
            tpGithubLogin.BackColor = System.Drawing.Color.White;
            tpGithubLogin.Controls.Add(txtUsername);
            tpGithubLogin.Controls.Add(btnLogin);
            tpGithubLogin.Location = new System.Drawing.Point(4, 24);
            tpGithubLogin.Name = "tpGithubLogin";
            tpGithubLogin.Padding = new System.Windows.Forms.Padding(3);
            tpGithubLogin.Size = new System.Drawing.Size(542, 277);
            tpGithubLogin.TabIndex = 0;
            tpGithubLogin.Text = "Github Login";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtUsername.AnimateReadOnly = false;
            txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtUsername.Depth = 0;
            txtUsername.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtUsername.Hint = "Github Username";
            txtUsername.LeadingIcon = null;
            txtUsername.Location = new System.Drawing.Point(99, 91);
            txtUsername.MaxLength = 50;
            txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            txtUsername.Multiline = false;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(341, 50);
            txtUsername.TabIndex = 0;
            txtUsername.Text = "";
            txtUsername.TrailingIcon = null;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnLogin.AutoSize = false;
            btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnLogin.Depth = 0;
            btnLogin.Enabled = false;
            btnLogin.HighEmphasis = true;
            btnLogin.Icon = null;
            btnLogin.Location = new System.Drawing.Point(99, 150);
            btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            btnLogin.Name = "btnLogin";
            btnLogin.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnLogin.Size = new System.Drawing.Size(341, 36);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnLogin.UseAccentColor = true;
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // tpGenerateKey
            // 
            tpGenerateKey.BackColor = System.Drawing.Color.White;
            tpGenerateKey.Controls.Add(cmbKeyAlgorithm);
            tpGenerateKey.Controls.Add(btnGenerateSSHKey);
            tpGenerateKey.Location = new System.Drawing.Point(4, 24);
            tpGenerateKey.Name = "tpGenerateKey";
            tpGenerateKey.Padding = new System.Windows.Forms.Padding(3);
            tpGenerateKey.Size = new System.Drawing.Size(542, 277);
            tpGenerateKey.TabIndex = 1;
            tpGenerateKey.Text = "Generate Key";
            // 
            // cmbKeyAlgorithm
            // 
            cmbKeyAlgorithm.Anchor = System.Windows.Forms.AnchorStyles.None;
            cmbKeyAlgorithm.AutoResize = false;
            cmbKeyAlgorithm.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            cmbKeyAlgorithm.Depth = 0;
            cmbKeyAlgorithm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            cmbKeyAlgorithm.DropDownHeight = 174;
            cmbKeyAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbKeyAlgorithm.DropDownWidth = 121;
            cmbKeyAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            cmbKeyAlgorithm.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            cmbKeyAlgorithm.FormattingEnabled = true;
            cmbKeyAlgorithm.Hint = "Key Algorithm";
            cmbKeyAlgorithm.IntegralHeight = false;
            cmbKeyAlgorithm.ItemHeight = 43;
            cmbKeyAlgorithm.Location = new System.Drawing.Point(99, 62);
            cmbKeyAlgorithm.MaxDropDownItems = 4;
            cmbKeyAlgorithm.MouseState = MaterialSkin.MouseState.OUT;
            cmbKeyAlgorithm.Name = "cmbKeyAlgorithm";
            cmbKeyAlgorithm.Size = new System.Drawing.Size(341, 49);
            cmbKeyAlgorithm.StartIndex = 0;
            cmbKeyAlgorithm.TabIndex = 1;
            // 
            // btnGenerateSSHKey
            // 
            btnGenerateSSHKey.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnGenerateSSHKey.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnGenerateSSHKey.AutoSize = false;
            btnGenerateSSHKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnGenerateSSHKey.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGenerateSSHKey.Depth = 0;
            btnGenerateSSHKey.HighEmphasis = true;
            btnGenerateSSHKey.Icon = null;
            btnGenerateSSHKey.Location = new System.Drawing.Point(99, 120);
            btnGenerateSSHKey.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnGenerateSSHKey.MouseState = MaterialSkin.MouseState.HOVER;
            btnGenerateSSHKey.Name = "btnGenerateSSHKey";
            btnGenerateSSHKey.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnGenerateSSHKey.Size = new System.Drawing.Size(341, 36);
            btnGenerateSSHKey.TabIndex = 0;
            btnGenerateSSHKey.Text = "Generate new SSH Key";
            btnGenerateSSHKey.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGenerateSSHKey.UseAccentColor = true;
            btnGenerateSSHKey.UseVisualStyleBackColor = true;
            btnGenerateSSHKey.Click += btnGenerateSSHKey_Click;
            // 
            // tpSettings
            // 
            tpSettings.BackColor = System.Drawing.Color.White;
            tpSettings.Controls.Add(tableLayoutPanel2);
            tpSettings.Location = new System.Drawing.Point(4, 24);
            tpSettings.Name = "tpSettings";
            tpSettings.Size = new System.Drawing.Size(542, 277);
            tpSettings.TabIndex = 2;
            tpSettings.Text = "Settings";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(pictureBox1, 0, 1);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(542, 277);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.ssh;
            pictureBox1.Location = new System.Drawing.Point(3, 108);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(536, 166);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(536, 105);
            label1.TabIndex = 0;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 314);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(550, 50);
            panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnNext);
            flowLayoutPanel1.Controls.Add(btnPrevious);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(550, 50);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnNext
            // 
            btnNext.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnNext.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNext.Depth = 0;
            btnNext.HighEmphasis = true;
            btnNext.Icon = null;
            btnNext.Location = new System.Drawing.Point(478, 6);
            btnNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnNext.MouseState = MaterialSkin.MouseState.HOVER;
            btnNext.Name = "btnNext";
            btnNext.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnNext.Size = new System.Drawing.Size(68, 36);
            btnNext.TabIndex = 1;
            btnNext.Text = "&Next";
            btnNext.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNext.UseAccentColor = true;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Visible = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnPrevious.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnPrevious.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnPrevious.Depth = 0;
            btnPrevious.HighEmphasis = true;
            btnPrevious.Icon = null;
            btnPrevious.Location = new System.Drawing.Point(370, 6);
            btnPrevious.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnPrevious.MouseState = MaterialSkin.MouseState.HOVER;
            btnPrevious.Name = "btnPrevious";
            btnPrevious.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnPrevious.Size = new System.Drawing.Size(100, 36);
            btnPrevious.TabIndex = 0;
            btnPrevious.Text = "&Previous";
            btnPrevious.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnPrevious.UseAccentColor = true;
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Visible = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // ucSshWizard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ucSshWizard";
            Size = new System.Drawing.Size(553, 367);
            Load += ucWizard_Load;
            tableLayoutPanel1.ResumeLayout(false);
            mtcSSHWizard.ResumeLayout(false);
            tpGithubLogin.ResumeLayout(false);
            tpGenerateKey.ResumeLayout(false);
            tpSettings.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialButton btnPrevious;
        private MaterialSkin.Controls.MaterialButton btnNext;
        public MaterialSkin.Controls.MaterialTabControl mtcSSHWizard;
        private System.Windows.Forms.TabPage tpGithubLogin;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private System.Windows.Forms.TabPage tpGenerateKey;
        private MaterialSkin.Controls.MaterialButton btnGenerateSSHKey;
        private System.Windows.Forms.TabPage tpSettings;
        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialComboBox cmbKeyAlgorithm;
    }
}
