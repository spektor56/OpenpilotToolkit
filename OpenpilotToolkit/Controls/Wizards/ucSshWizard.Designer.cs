
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrevious = new MaterialSkin.Controls.MaterialButton();
            this.btnNext = new MaterialSkin.Controls.MaterialButton();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tpGenerateKey = new System.Windows.Forms.TabPage();
            this.btnGenerateSSHKey = new MaterialSkin.Controls.MaterialButton();
            this.tpGithubLogin = new System.Windows.Forms.TabPage();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.mtcSSHWizard = new MaterialSkin.Controls.MaterialTabControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tpGenerateKey.SuspendLayout();
            this.tpGithubLogin.SuspendLayout();
            this.mtcSSHWizard.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.mtcSSHWizard, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(553, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 50);
            this.panel1.TabIndex = 1;
            // 
            // btnPrevious
            // 
            this.btnPrevious.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrevious.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPrevious.Depth = 0;
            this.btnPrevious.HighEmphasis = true;
            this.btnPrevious.Icon = null;
            this.btnPrevious.Location = new System.Drawing.Point(380, 8);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPrevious.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnPrevious.Size = new System.Drawing.Size(91, 36);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPrevious.UseAccentColor = false;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNext.Depth = 0;
            this.btnNext.HighEmphasis = true;
            this.btnNext.Icon = null;
            this.btnNext.Location = new System.Drawing.Point(479, 8);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNext.Name = "btnNext";
            this.btnNext.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnNext.Size = new System.Drawing.Size(64, 36);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNext.UseAccentColor = false;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.pictureBox1);
            this.tpSettings.Location = new System.Drawing.Point(4, 24);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(539, 277);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::OpenpilotToolkit.Properties.Resources.ssh;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tpGenerateKey
            // 
            this.tpGenerateKey.Controls.Add(this.btnGenerateSSHKey);
            this.tpGenerateKey.Location = new System.Drawing.Point(4, 24);
            this.tpGenerateKey.Name = "tpGenerateKey";
            this.tpGenerateKey.Padding = new System.Windows.Forms.Padding(3);
            this.tpGenerateKey.Size = new System.Drawing.Size(539, 277);
            this.tpGenerateKey.TabIndex = 1;
            this.tpGenerateKey.Text = "Generate Key";
            this.tpGenerateKey.UseVisualStyleBackColor = true;
            // 
            // btnGenerateSSHKey
            // 
            this.btnGenerateSSHKey.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnGenerateSSHKey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenerateSSHKey.AutoSize = false;
            this.btnGenerateSSHKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerateSSHKey.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGenerateSSHKey.Depth = 0;
            this.btnGenerateSSHKey.HighEmphasis = true;
            this.btnGenerateSSHKey.Icon = null;
            this.btnGenerateSSHKey.Location = new System.Drawing.Point(99, 120);
            this.btnGenerateSSHKey.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGenerateSSHKey.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerateSSHKey.Name = "btnGenerateSSHKey";
            this.btnGenerateSSHKey.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnGenerateSSHKey.Size = new System.Drawing.Size(341, 36);
            this.btnGenerateSSHKey.TabIndex = 30;
            this.btnGenerateSSHKey.Text = "Generate new SSH Key";
            this.btnGenerateSSHKey.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGenerateSSHKey.UseAccentColor = false;
            this.btnGenerateSSHKey.UseVisualStyleBackColor = true;
            this.btnGenerateSSHKey.Click += new System.EventHandler(this.btnGenerateSSHKey_Click);
            // 
            // tpGithubLogin
            // 
            this.tpGithubLogin.Controls.Add(this.btnLogin);
            this.tpGithubLogin.Location = new System.Drawing.Point(4, 24);
            this.tpGithubLogin.Name = "tpGithubLogin";
            this.tpGithubLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tpGithubLogin.Size = new System.Drawing.Size(539, 277);
            this.tpGithubLogin.TabIndex = 0;
            this.tpGithubLogin.Text = "Github Login";
            this.tpGithubLogin.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.AutoSize = false;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(99, 120);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnLogin.Size = new System.Drawing.Size(341, 36);
            this.btnLogin.TabIndex = 29;
            this.btnLogin.Text = "Login";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = false;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // mtcSSHWizard
            // 
            this.mtcSSHWizard.Controls.Add(this.tpGithubLogin);
            this.mtcSSHWizard.Controls.Add(this.tpGenerateKey);
            this.mtcSSHWizard.Controls.Add(this.tpSettings);
            this.mtcSSHWizard.Depth = 0;
            this.mtcSSHWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtcSSHWizard.Location = new System.Drawing.Point(3, 3);
            this.mtcSSHWizard.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtcSSHWizard.Multiline = true;
            this.mtcSSHWizard.Name = "mtcSSHWizard";
            this.mtcSSHWizard.SelectedIndex = 0;
            this.mtcSSHWizard.Size = new System.Drawing.Size(547, 305);
            this.mtcSSHWizard.TabIndex = 0;
            this.mtcSSHWizard.Selected += new System.Windows.Forms.TabControlEventHandler(this.mtcSSHWizard_Selected);
            this.mtcSSHWizard.TabIndexChanged += new System.EventHandler(this.materialTabControl1_TabIndexChanged);
            // 
            // ucWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucWizard";
            this.Size = new System.Drawing.Size(553, 367);
            this.Load += new System.EventHandler(this.ucWizard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tpGenerateKey.ResumeLayout(false);
            this.tpGithubLogin.ResumeLayout(false);
            this.mtcSSHWizard.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
