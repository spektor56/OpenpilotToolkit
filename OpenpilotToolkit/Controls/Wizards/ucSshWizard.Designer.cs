
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mtcSSHWizard = new MaterialSkin.Controls.MaterialTabControl();
            this.tpGithubLogin = new System.Windows.Forms.TabPage();
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.tpGenerateKey = new System.Windows.Forms.TabPage();
            this.btnGenerateSSHKey = new MaterialSkin.Controls.MaterialButton();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNext = new MaterialSkin.Controls.MaterialButton();
            this.btnPrevious = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.mtcSSHWizard.SuspendLayout();
            this.tpGithubLogin.SuspendLayout();
            this.tpGenerateKey.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.mtcSSHWizard.Size = new System.Drawing.Size(550, 305);
            this.mtcSSHWizard.TabIndex = 0;
            this.mtcSSHWizard.TabStop = false;
            this.mtcSSHWizard.Selected += new System.Windows.Forms.TabControlEventHandler(this.mtcSSHWizard_Selected);
            this.mtcSSHWizard.TabIndexChanged += new System.EventHandler(this.materialTabControl1_TabIndexChanged);
            // 
            // tpGithubLogin
            // 
            this.tpGithubLogin.BackColor = System.Drawing.Color.White;
            this.tpGithubLogin.Controls.Add(this.txtUsername);
            this.tpGithubLogin.Controls.Add(this.btnLogin);
            this.tpGithubLogin.Location = new System.Drawing.Point(4, 24);
            this.tpGithubLogin.Name = "tpGithubLogin";
            this.tpGithubLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tpGithubLogin.Size = new System.Drawing.Size(542, 277);
            this.tpGithubLogin.TabIndex = 0;
            this.tpGithubLogin.Text = "Github Login";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsername.AnimateReadOnly = false;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsername.Hint = "Github Username";
            this.txtUsername.LeadingIcon = null;
            this.txtUsername.Location = new System.Drawing.Point(99, 91);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(341, 50);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "";
            this.txtUsername.TrailingIcon = null;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.AutoSize = false;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.Enabled = false;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(99, 150);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnLogin.Size = new System.Drawing.Size(341, 36);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = true;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tpGenerateKey
            // 
            this.tpGenerateKey.BackColor = System.Drawing.Color.White;
            this.tpGenerateKey.Controls.Add(this.btnGenerateSSHKey);
            this.tpGenerateKey.Location = new System.Drawing.Point(4, 24);
            this.tpGenerateKey.Name = "tpGenerateKey";
            this.tpGenerateKey.Padding = new System.Windows.Forms.Padding(3);
            this.tpGenerateKey.Size = new System.Drawing.Size(542, 277);
            this.tpGenerateKey.TabIndex = 1;
            this.tpGenerateKey.Text = "Generate Key";
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
            this.btnGenerateSSHKey.TabIndex = 0;
            this.btnGenerateSSHKey.Text = "Generate new SSH Key";
            this.btnGenerateSSHKey.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGenerateSSHKey.UseAccentColor = true;
            this.btnGenerateSSHKey.UseVisualStyleBackColor = true;
            this.btnGenerateSSHKey.Click += new System.EventHandler(this.btnGenerateSSHKey_Click);
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.White;
            this.tpSettings.Controls.Add(this.tableLayoutPanel2);
            this.tpSettings.Location = new System.Drawing.Point(4, 24);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(542, 277);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(542, 277);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::OpenpilotToolkit.Properties.Resources.ssh;
            this.pictureBox1.Location = new System.Drawing.Point(3, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(536, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(536, 105);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 50);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNext);
            this.flowLayoutPanel1.Controls.Add(this.btnPrevious);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(550, 50);
            this.flowLayoutPanel1.TabIndex = 0;
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
            this.btnNext.Location = new System.Drawing.Point(478, 6);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNext.Name = "btnNext";
            this.btnNext.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnNext.Size = new System.Drawing.Size(68, 36);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "&Next";
            this.btnNext.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNext.UseAccentColor = true;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
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
            this.btnPrevious.Location = new System.Drawing.Point(370, 6);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPrevious.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnPrevious.Size = new System.Drawing.Size(100, 36);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "&Previous";
            this.btnPrevious.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPrevious.UseAccentColor = true;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Visible = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // ucSshWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucSshWizard";
            this.Size = new System.Drawing.Size(553, 367);
            this.Load += new System.EventHandler(this.ucWizard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.mtcSSHWizard.ResumeLayout(false);
            this.tpGithubLogin.ResumeLayout(false);
            this.tpGenerateKey.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private MaterialSkin.Controls.MaterialTextBox txtUsername;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
