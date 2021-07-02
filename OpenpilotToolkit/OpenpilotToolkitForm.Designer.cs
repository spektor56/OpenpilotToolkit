
using LibVLCSharp.Shared;
using MaterialSkin.Controls;
using OpenpilotToolkit.Controls.Wizards;

namespace OpenpilotToolkit
{
    partial class OpenpilotToolkitForm
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
                this._libVlc?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenpilotToolkitForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbDrives = new System.Windows.Forms.ListBox();
            this.lbCommaList = new System.Windows.Forms.ListBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.fbdExportFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblCommaList = new MaterialSkin.Controls.MaterialLabel();
            this.btnBrowse = new MaterialSkin.Controls.MaterialButton();
            this.btnRefreshVideos = new MaterialSkin.Controls.MaterialButton();
            this.btnExportMapillary = new MaterialSkin.Controls.MaterialButton();
            this.btnExportGpx = new MaterialSkin.Controls.MaterialButton();
            this.btnExport = new MaterialSkin.Controls.MaterialButton();
            this.btnScan = new MaterialSkin.Controls.MaterialButton();
            this.txtExportFolder = new MaterialSkin.Controls.MaterialTextBox();
            this.lblDrives = new MaterialSkin.Controls.MaterialLabel();
            this.adbConnected = new MaterialSkin.Controls.MaterialButton();
            this.ilTabs = new System.Windows.Forms.ImageList(this.components);
            this.themeButton = new MaterialSkin.Controls.MaterialButton();
            this.tcSettings = new MaterialSkin.Controls.MaterialTabControl();
            this.tpExport = new System.Windows.Forms.TabPage();
            this.vlcVideoPlayer = new OpenpilotToolkit.Controls.Media.VideoPlayer();
            this.tlpTasks = new System.Windows.Forms.TableLayoutPanel();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCombineSegments = new MaterialSkin.Controls.MaterialCheckbox();
            this.tpLogFile = new System.Windows.Forms.TabPage();
            this.txtLog = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.tpExplore = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvExplorer = new OpenpilotToolkit.Controls.MaterialSkinDataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.txtWorkingDirectory = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbDevice = new MaterialSkin.Controls.MaterialComboBox();
            this.tpFingerprint = new System.Windows.Forms.TabPage();
            this.txtFingerprint = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.tpSSH = new System.Windows.Forms.TabPage();
            this.ucSshWizard = new OpenpilotToolkit.Controls.Wizards.ucSshWizard();
            this.tpFork = new System.Windows.Forms.TabPage();
            this.txtForkBranch = new MaterialSkin.Controls.MaterialTextBox();
            this.txtForkUsername = new MaterialSkin.Controls.MaterialTextBox();
            this.btnInstallFork = new MaterialSkin.Controls.MaterialButton();
            this.tpFlash = new System.Windows.Forms.TabPage();
            this.tpDonate = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPaypal = new MaterialSkin.Controls.MaterialButton();
            this.btnKofi = new MaterialSkin.Controls.MaterialButton();
            this.btnBuyMeCoffee = new MaterialSkin.Controls.MaterialButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flpColours = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.themePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.wifiConnected = new MaterialSkin.Controls.MaterialButton();
            this.sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.tcSettings.SuspendLayout();
            this.tpExport.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpLogFile.SuspendLayout();
            this.tpExplore.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExplorer)).BeginInit();
            this.tpFingerprint.SuspendLayout();
            this.tpSSH.SuspendLayout();
            this.tpFork.SuspendLayout();
            this.tpDonate.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.themePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDrives
            // 
            this.lbDrives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDrives.FormattingEnabled = true;
            this.lbDrives.ItemHeight = 15;
            this.lbDrives.Location = new System.Drawing.Point(120, 107);
            this.lbDrives.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbDrives.Name = "lbDrives";
            this.lbDrives.Size = new System.Drawing.Size(143, 454);
            this.lbDrives.TabIndex = 0;
            this.lbDrives.SelectedIndexChanged += new System.EventHandler(this.lbDrives_SelectedIndexChanged);
            // 
            // lbCommaList
            // 
            this.lbCommaList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCommaList.FormattingEnabled = true;
            this.lbCommaList.ItemHeight = 15;
            this.lbCommaList.Location = new System.Drawing.Point(7, 107);
            this.lbCommaList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbCommaList.Name = "lbCommaList";
            this.lbCommaList.Size = new System.Drawing.Size(106, 454);
            this.lbCommaList.TabIndex = 5;
            this.lbCommaList.SelectedIndexChanged += new System.EventHandler(this.lbCommaList_SelectedIndexChanged);
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreview.Location = new System.Drawing.Point(271, 106);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(709, 461);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 8;
            this.pbPreview.TabStop = false;
            // 
            // lblCommaList
            // 
            this.lblCommaList.AutoSize = true;
            this.lblCommaList.Depth = 0;
            this.lblCommaList.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCommaList.Location = new System.Drawing.Point(7, 85);
            this.lblCommaList.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCommaList.Name = "lblCommaList";
            this.lblCommaList.Size = new System.Drawing.Size(96, 19);
            this.lblCommaList.TabIndex = 19;
            this.lblCommaList.Text = "Comma2 List";
            // 
            // btnBrowse
            // 
            this.btnBrowse.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBrowse.Depth = 0;
            this.btnBrowse.HighEmphasis = true;
            this.btnBrowse.Icon = null;
            this.btnBrowse.Location = new System.Drawing.Point(324, 9);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnBrowse.Size = new System.Drawing.Size(80, 36);
            this.btnBrowse.TabIndex = 20;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBrowse.UseAccentColor = true;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnRefreshVideos
            // 
            this.btnRefreshVideos.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnRefreshVideos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshVideos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefreshVideos.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefreshVideos.Depth = 0;
            this.btnRefreshVideos.HighEmphasis = true;
            this.btnRefreshVideos.Icon = null;
            this.btnRefreshVideos.Location = new System.Drawing.Point(412, 9);
            this.btnRefreshVideos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefreshVideos.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefreshVideos.Name = "btnRefreshVideos";
            this.btnRefreshVideos.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnRefreshVideos.Size = new System.Drawing.Size(162, 36);
            this.btnRefreshVideos.TabIndex = 21;
            this.btnRefreshVideos.Text = "Refresh Drive List";
            this.btnRefreshVideos.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRefreshVideos.UseAccentColor = true;
            this.btnRefreshVideos.UseVisualStyleBackColor = true;
            this.btnRefreshVideos.Click += new System.EventHandler(this.btnRefreshVideos_Click);
            // 
            // btnExportMapillary
            // 
            this.btnExportMapillary.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnExportMapillary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportMapillary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportMapillary.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExportMapillary.Depth = 0;
            this.btnExportMapillary.Enabled = false;
            this.btnExportMapillary.HighEmphasis = true;
            this.btnExportMapillary.Icon = null;
            this.btnExportMapillary.Location = new System.Drawing.Point(582, 9);
            this.btnExportMapillary.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExportMapillary.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExportMapillary.Name = "btnExportMapillary";
            this.btnExportMapillary.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnExportMapillary.Size = new System.Drawing.Size(101, 36);
            this.btnExportMapillary.TabIndex = 22;
            this.btnExportMapillary.Text = "Mapillary";
            this.btnExportMapillary.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExportMapillary.UseAccentColor = true;
            this.btnExportMapillary.UseVisualStyleBackColor = true;
            this.btnExportMapillary.Click += new System.EventHandler(this.btnExportMapillary_Click);
            // 
            // btnExportGpx
            // 
            this.btnExportGpx.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnExportGpx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportGpx.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportGpx.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExportGpx.Depth = 0;
            this.btnExportGpx.Enabled = false;
            this.btnExportGpx.HighEmphasis = true;
            this.btnExportGpx.Icon = null;
            this.btnExportGpx.Location = new System.Drawing.Point(691, 9);
            this.btnExportGpx.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExportGpx.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExportGpx.Name = "btnExportGpx";
            this.btnExportGpx.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnExportGpx.Size = new System.Drawing.Size(64, 36);
            this.btnExportGpx.TabIndex = 23;
            this.btnExportGpx.Text = "GPX";
            this.btnExportGpx.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExportGpx.UseAccentColor = true;
            this.btnExportGpx.UseVisualStyleBackColor = true;
            this.btnExportGpx.Click += new System.EventHandler(this.btnExportGpx_Click);
            // 
            // btnExport
            // 
            this.btnExport.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExport.Depth = 0;
            this.btnExport.HighEmphasis = true;
            this.btnExport.Icon = null;
            this.btnExport.Location = new System.Drawing.Point(763, 9);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExport.Name = "btnExport";
            this.btnExport.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnExport.Size = new System.Drawing.Size(195, 36);
            this.btnExport.TabIndex = 24;
            this.btnExport.Text = "Export Selected Drive";
            this.btnExport.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExport.UseAccentColor = true;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnScan
            // 
            this.btnScan.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnScan.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnScan.Depth = 0;
            this.btnScan.HighEmphasis = true;
            this.btnScan.Icon = null;
            this.btnScan.Location = new System.Drawing.Point(966, 9);
            this.btnScan.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnScan.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnScan.Name = "btnScan";
            this.btnScan.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnScan.Size = new System.Drawing.Size(232, 36);
            this.btnScan.TabIndex = 25;
            this.btnScan.Text = "Scan Network For Comma2";
            this.btnScan.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnScan.UseAccentColor = true;
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtExportFolder
            // 
            this.txtExportFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExportFolder.Depth = 0;
            this.txtExportFolder.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtExportFolder.Hint = "Export Folder";
            this.txtExportFolder.LeadingIcon = null;
            this.txtExportFolder.Location = new System.Drawing.Point(6, 6);
            this.txtExportFolder.MaxLength = 50;
            this.txtExportFolder.MouseState = MaterialSkin.MouseState.OUT;
            this.txtExportFolder.Multiline = false;
            this.txtExportFolder.Name = "txtExportFolder";
            this.txtExportFolder.Size = new System.Drawing.Size(311, 50);
            this.txtExportFolder.TabIndex = 26;
            this.txtExportFolder.Text = "C:\\Openpilot";
            this.txtExportFolder.TrailingIcon = null;
            // 
            // lblDrives
            // 
            this.lblDrives.AutoSize = true;
            this.lblDrives.Depth = 0;
            this.lblDrives.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDrives.Location = new System.Drawing.Point(120, 85);
            this.lblDrives.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDrives.Name = "lblDrives";
            this.lblDrives.Size = new System.Drawing.Size(67, 19);
            this.lblDrives.TabIndex = 27;
            this.lblDrives.Text = "Drive List";
            // 
            // adbConnected
            // 
            this.adbConnected.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.adbConnected.AutoSize = false;
            this.adbConnected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.adbConnected.BackColor = System.Drawing.Color.Transparent;
            this.adbConnected.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.adbConnected.Depth = 0;
            this.adbConnected.DrawShadows = false;
            this.adbConnected.Enabled = false;
            this.adbConnected.HighEmphasis = true;
            this.adbConnected.Icon = global::OpenpilotToolkit.Properties.Resources.outline_adb_white_24dp;
            this.adbConnected.ImageKey = "outline_adb_white_24dp.png";
            this.adbConnected.ImageList = this.ilTabs;
            this.adbConnected.Location = new System.Drawing.Point(883, 2);
            this.adbConnected.Margin = new System.Windows.Forms.Padding(2);
            this.adbConnected.MouseState = MaterialSkin.MouseState.HOVER;
            this.adbConnected.Name = "adbConnected";
            this.adbConnected.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.adbConnected.Size = new System.Drawing.Size(40, 36);
            this.adbConnected.TabIndex = 32;
            this.adbConnected.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.adbConnected.UseAccentColor = false;
            this.adbConnected.UseVisualStyleBackColor = false;
            // 
            // ilTabs
            // 
            this.ilTabs.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilTabs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTabs.ImageStream")));
            this.ilTabs.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTabs.Images.SetKeyName(0, "outline_file_download_white_24dp.png");
            this.ilTabs.Images.SetKeyName(1, "outline_settings_white_24dp.png");
            this.ilTabs.Images.SetKeyName(2, "outline_description_white_24dp.png");
            this.ilTabs.Images.SetKeyName(3, "outline_folder_open_white_24dp.png");
            this.ilTabs.Images.SetKeyName(4, "outline_fingerprint_white_24dp.png");
            this.ilTabs.Images.SetKeyName(5, "outline_ssh_black_24dp.png");
            this.ilTabs.Images.SetKeyName(6, "outline_flash_on_white_24dp.png");
            this.ilTabs.Images.SetKeyName(7, "outline_adb_white_24dp.png");
            this.ilTabs.Images.SetKeyName(8, "outline_wifi_white_24dp.png");
            this.ilTabs.Images.SetKeyName(9, "outline_favorite_white_24dp.png");
            this.ilTabs.Images.SetKeyName(10, "git_fork_black.png");
            // 
            // themeButton
            // 
            this.themeButton.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.themeButton.AutoSize = false;
            this.themeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.themeButton.BackColor = System.Drawing.Color.Transparent;
            this.themeButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.themeButton.Depth = 0;
            this.themeButton.DrawShadows = false;
            this.themeButton.HighEmphasis = true;
            this.themeButton.Icon = global::OpenpilotToolkit.Properties.Resources.light_mode_white;
            this.themeButton.Location = new System.Drawing.Point(927, 2);
            this.themeButton.Margin = new System.Windows.Forms.Padding(2);
            this.themeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.themeButton.Name = "themeButton";
            this.themeButton.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.themeButton.Size = new System.Drawing.Size(40, 36);
            this.themeButton.TabIndex = 31;
            this.themeButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.themeButton.UseAccentColor = false;
            this.themeButton.UseVisualStyleBackColor = false;
            this.themeButton.Click += new System.EventHandler(this.themeButton_Click);
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tpExport);
            this.tcSettings.Controls.Add(this.tpSettings);
            this.tcSettings.Controls.Add(this.tpLogFile);
            this.tcSettings.Controls.Add(this.tpExplore);
            this.tcSettings.Controls.Add(this.tpFingerprint);
            this.tcSettings.Controls.Add(this.tpSSH);
            this.tcSettings.Controls.Add(this.tpFork);
            this.tcSettings.Controls.Add(this.tpFlash);
            this.tcSettings.Controls.Add(this.tpDonate);
            this.tcSettings.Controls.Add(this.tabPage1);
            this.tcSettings.Depth = 0;
            this.tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSettings.ImageList = this.ilTabs;
            this.tcSettings.Location = new System.Drawing.Point(3, 64);
            this.tcSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.tcSettings.Multiline = true;
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(1212, 608);
            this.tcSettings.TabIndex = 33;
            this.tcSettings.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcSettings_Selected);
            // 
            // tpExport
            // 
            this.tpExport.Controls.Add(this.pbPreview);
            this.tpExport.Controls.Add(this.vlcVideoPlayer);
            this.tpExport.Controls.Add(this.txtExportFolder);
            this.tpExport.Controls.Add(this.lblCommaList);
            this.tpExport.Controls.Add(this.lbDrives);
            this.tpExport.Controls.Add(this.btnExport);
            this.tpExport.Controls.Add(this.lblDrives);
            this.tpExport.Controls.Add(this.btnExportGpx);
            this.tpExport.Controls.Add(this.tlpTasks);
            this.tpExport.Controls.Add(this.lbCommaList);
            this.tpExport.Controls.Add(this.btnBrowse);
            this.tpExport.Controls.Add(this.btnRefreshVideos);
            this.tpExport.Controls.Add(this.btnScan);
            this.tpExport.Controls.Add(this.btnExportMapillary);
            this.tpExport.ImageKey = "outline_file_download_white_24dp.png";
            this.tpExport.Location = new System.Drawing.Point(4, 31);
            this.tpExport.Name = "tpExport";
            this.tpExport.Padding = new System.Windows.Forms.Padding(3);
            this.tpExport.Size = new System.Drawing.Size(1204, 573);
            this.tpExport.TabIndex = 0;
            this.tpExport.Text = "Export";
            this.tpExport.UseVisualStyleBackColor = true;
            // 
            // vlcVideoPlayer
            // 
            this.vlcVideoPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcVideoPlayer.Location = new System.Drawing.Point(271, 106);
            this.vlcVideoPlayer.Name = "vlcVideoPlayer";
            this.vlcVideoPlayer.Size = new System.Drawing.Size(709, 461);
            this.vlcVideoPlayer.TabIndex = 29;
            // 
            // tlpTasks
            // 
            this.tlpTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTasks.AutoScroll = true;
            this.tlpTasks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpTasks.ColumnCount = 1;
            this.tlpTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTasks.Location = new System.Drawing.Point(988, 106);
            this.tlpTasks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpTasks.Name = "tlpTasks";
            this.tlpTasks.RowCount = 1;
            this.tlpTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTasks.Size = new System.Drawing.Size(209, 461);
            this.tlpTasks.TabIndex = 16;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.groupBox1);
            this.tpSettings.ImageKey = "outline_settings_white_24dp.png";
            this.tpSettings.Location = new System.Drawing.Point(4, 31);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1204, 573);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCombineSegments);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drive Exporter";
            // 
            // cbCombineSegments
            // 
            this.cbCombineSegments.AutoSize = true;
            this.cbCombineSegments.Depth = 0;
            this.cbCombineSegments.Location = new System.Drawing.Point(3, 19);
            this.cbCombineSegments.Margin = new System.Windows.Forms.Padding(0);
            this.cbCombineSegments.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbCombineSegments.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbCombineSegments.Name = "cbCombineSegments";
            this.cbCombineSegments.Ripple = true;
            this.cbCombineSegments.Size = new System.Drawing.Size(173, 37);
            this.cbCombineSegments.TabIndex = 0;
            this.cbCombineSegments.Text = "Combine Segments";
            this.cbCombineSegments.UseVisualStyleBackColor = true;
            this.cbCombineSegments.CheckedChanged += new System.EventHandler(this.cbCombineSegments_CheckedChanged);
            // 
            // tpLogFile
            // 
            this.tpLogFile.Controls.Add(this.txtLog);
            this.tpLogFile.ImageKey = "outline_description_white_24dp.png";
            this.tpLogFile.Location = new System.Drawing.Point(4, 31);
            this.tpLogFile.Name = "tpLogFile";
            this.tpLogFile.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogFile.Size = new System.Drawing.Size(1204, 573);
            this.tpLogFile.TabIndex = 2;
            this.tpLogFile.Text = "Log";
            this.tpLogFile.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Depth = 0;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtLog.Location = new System.Drawing.Point(3, 3);
            this.txtLog.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(1198, 567);
            this.txtLog.TabIndex = 2;
            this.txtLog.Text = "";
            // 
            // tpExplore
            // 
            this.tpExplore.Controls.Add(this.panel1);
            this.tpExplore.ImageKey = "outline_folder_open_white_24dp.png";
            this.tpExplore.Location = new System.Drawing.Point(4, 31);
            this.tpExplore.Name = "tpExplore";
            this.tpExplore.Padding = new System.Windows.Forms.Padding(3);
            this.tpExplore.Size = new System.Drawing.Size(1204, 573);
            this.tpExplore.TabIndex = 3;
            this.tpExplore.Text = "Explorer";
            this.tpExplore.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dgvExplorer);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.txtWorkingDirectory);
            this.panel1.Controls.Add(this.cmbDevice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 567);
            this.panel1.TabIndex = 0;
            // 
            // dgvExplorer
            // 
            this.dgvExplorer.AllowUserToAddRows = false;
            this.dgvExplorer.AllowUserToDeleteRows = false;
            this.dgvExplorer.AllowUserToOrderColumns = true;
            this.dgvExplorer.AllowUserToResizeRows = false;
            this.dgvExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExplorer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExplorer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvExplorer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExplorer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvExplorer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Custom;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExplorer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExplorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExplorer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colSize,
            this.colType,
            this.colChanged});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExplorer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExplorer.Depth = 0;
            this.dgvExplorer.EnableHeadersVisualStyles = false;
            this.dgvExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvExplorer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvExplorer.Location = new System.Drawing.Point(3, 60);
            this.dgvExplorer.MouseState = MaterialSkin.MouseState.HOVER;
            this.dgvExplorer.Name = "dgvExplorer";
            this.dgvExplorer.ReadOnly = true;
            this.dgvExplorer.RowHeadersVisible = false;
            this.dgvExplorer.RowTemplate.Height = 25;
            this.dgvExplorer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExplorer.ShowCellToolTips = false;
            this.dgvExplorer.Size = new System.Drawing.Size(1192, 504);
            this.dgvExplorer.TabIndex = 32;
            this.dgvExplorer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExplorer_CellDoubleClick);
            this.dgvExplorer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvExplorer_CellFormatting);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colSize
            // 
            this.colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSize.DataPropertyName = "Attributes.Size";
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            this.colSize.Width = 63;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colType.DataPropertyName = "Attributes.IsDirectory";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 66;
            // 
            // colChanged
            // 
            this.colChanged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colChanged.DataPropertyName = "LastWriteTimeUTC";
            this.colChanged.HeaderText = "Changed";
            this.colChanged.Name = "colChanged";
            this.colChanged.ReadOnly = true;
            this.colChanged.Width = 97;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Depth = 0;
            this.txtSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.Hint = "Search";
            this.txtSearch.LeadingIcon = null;
            this.txtSearch.Location = new System.Drawing.Point(941, 4);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(254, 50);
            this.txtSearch.TabIndex = 28;
            this.txtSearch.Text = "";
            this.txtSearch.TrailingIcon = null;
            // 
            // txtWorkingDirectory
            // 
            this.txtWorkingDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkingDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWorkingDirectory.Depth = 0;
            this.txtWorkingDirectory.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtWorkingDirectory.Hint = "Working Directory";
            this.txtWorkingDirectory.LeadingIcon = null;
            this.txtWorkingDirectory.Location = new System.Drawing.Point(275, 4);
            this.txtWorkingDirectory.MaxLength = 50;
            this.txtWorkingDirectory.MouseState = MaterialSkin.MouseState.OUT;
            this.txtWorkingDirectory.Multiline = false;
            this.txtWorkingDirectory.Name = "txtWorkingDirectory";
            this.txtWorkingDirectory.ReadOnly = true;
            this.txtWorkingDirectory.Size = new System.Drawing.Size(660, 50);
            this.txtWorkingDirectory.TabIndex = 27;
            this.txtWorkingDirectory.Text = "Current Directory";
            this.txtWorkingDirectory.TrailingIcon = null;
            // 
            // cmbDevice
            // 
            this.cmbDevice.AutoResize = false;
            this.cmbDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbDevice.Depth = 0;
            this.cmbDevice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbDevice.DropDownHeight = 174;
            this.cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice.DropDownWidth = 121;
            this.cmbDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Hint = "Openpilot Device";
            this.cmbDevice.IntegralHeight = false;
            this.cmbDevice.ItemHeight = 43;
            this.cmbDevice.Location = new System.Drawing.Point(3, 3);
            this.cmbDevice.MaxDropDownItems = 4;
            this.cmbDevice.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(266, 49);
            this.cmbDevice.StartIndex = 0;
            this.cmbDevice.TabIndex = 1;
            // 
            // tpFingerprint
            // 
            this.tpFingerprint.Controls.Add(this.txtFingerprint);
            this.tpFingerprint.ImageKey = "outline_fingerprint_white_24dp.png";
            this.tpFingerprint.Location = new System.Drawing.Point(4, 31);
            this.tpFingerprint.Name = "tpFingerprint";
            this.tpFingerprint.Padding = new System.Windows.Forms.Padding(3);
            this.tpFingerprint.Size = new System.Drawing.Size(1204, 573);
            this.tpFingerprint.TabIndex = 4;
            this.tpFingerprint.Text = "Fingerprint";
            this.tpFingerprint.UseVisualStyleBackColor = true;
            // 
            // txtFingerprint
            // 
            this.txtFingerprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtFingerprint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFingerprint.Depth = 0;
            this.txtFingerprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFingerprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFingerprint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtFingerprint.Location = new System.Drawing.Point(3, 3);
            this.txtFingerprint.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFingerprint.Name = "txtFingerprint";
            this.txtFingerprint.ReadOnly = true;
            this.txtFingerprint.Size = new System.Drawing.Size(1198, 567);
            this.txtFingerprint.TabIndex = 3;
            this.txtFingerprint.Text = "";
            // 
            // tpSSH
            // 
            this.tpSSH.Controls.Add(this.ucSshWizard);
            this.tpSSH.ImageKey = "outline_ssh_black_24dp.png";
            this.tpSSH.Location = new System.Drawing.Point(4, 31);
            this.tpSSH.Name = "tpSSH";
            this.tpSSH.Padding = new System.Windows.Forms.Padding(3);
            this.tpSSH.Size = new System.Drawing.Size(1204, 573);
            this.tpSSH.TabIndex = 5;
            this.tpSSH.Text = "SSH Wizard";
            this.tpSSH.UseVisualStyleBackColor = true;
            // 
            // ucSshWizard
            // 
            this.ucSshWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSshWizard.Location = new System.Drawing.Point(3, 3);
            this.ucSshWizard.Name = "ucSshWizard";
            this.ucSshWizard.Size = new System.Drawing.Size(1198, 567);
            this.ucSshWizard.TabIndex = 1;
            this.ucSshWizard.WizardCompleted += new System.EventHandler(this.ucSshWizard_WizardCompleted);
            // 
            // tpFork
            // 
            this.tpFork.Controls.Add(this.txtForkBranch);
            this.tpFork.Controls.Add(this.txtForkUsername);
            this.tpFork.Controls.Add(this.btnInstallFork);
            this.tpFork.ImageKey = "git_fork_black.png";
            this.tpFork.Location = new System.Drawing.Point(4, 31);
            this.tpFork.Name = "tpFork";
            this.tpFork.Size = new System.Drawing.Size(1204, 573);
            this.tpFork.TabIndex = 9;
            this.tpFork.Text = "Fork Installer";
            this.tpFork.UseVisualStyleBackColor = true;
            // 
            // txtForkBranch
            // 
            this.txtForkBranch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtForkBranch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtForkBranch.Depth = 0;
            this.txtForkBranch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtForkBranch.Hint = "Branch Name";
            this.txtForkBranch.LeadingIcon = null;
            this.txtForkBranch.Location = new System.Drawing.Point(432, 221);
            this.txtForkBranch.MaxLength = 50;
            this.txtForkBranch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtForkBranch.Multiline = false;
            this.txtForkBranch.Name = "txtForkBranch";
            this.txtForkBranch.Size = new System.Drawing.Size(341, 50);
            this.txtForkBranch.TabIndex = 33;
            this.txtForkBranch.Text = "";
            this.txtForkBranch.TrailingIcon = null;
            // 
            // txtForkUsername
            // 
            this.txtForkUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtForkUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtForkUsername.Depth = 0;
            this.txtForkUsername.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtForkUsername.Hint = "Fork Username";
            this.txtForkUsername.LeadingIcon = null;
            this.txtForkUsername.Location = new System.Drawing.Point(432, 165);
            this.txtForkUsername.MaxLength = 50;
            this.txtForkUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtForkUsername.Multiline = false;
            this.txtForkUsername.Name = "txtForkUsername";
            this.txtForkUsername.Size = new System.Drawing.Size(341, 50);
            this.txtForkUsername.TabIndex = 32;
            this.txtForkUsername.Text = "";
            this.txtForkUsername.TrailingIcon = null;
            // 
            // btnInstallFork
            // 
            this.btnInstallFork.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnInstallFork.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInstallFork.AutoSize = false;
            this.btnInstallFork.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInstallFork.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnInstallFork.Depth = 0;
            this.btnInstallFork.HighEmphasis = true;
            this.btnInstallFork.Icon = null;
            this.btnInstallFork.Location = new System.Drawing.Point(432, 280);
            this.btnInstallFork.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnInstallFork.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnInstallFork.Name = "btnInstallFork";
            this.btnInstallFork.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnInstallFork.Size = new System.Drawing.Size(341, 36);
            this.btnInstallFork.TabIndex = 31;
            this.btnInstallFork.Text = "Install";
            this.btnInstallFork.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnInstallFork.UseAccentColor = true;
            this.btnInstallFork.UseVisualStyleBackColor = true;
            this.btnInstallFork.Click += new System.EventHandler(this.btnInstallFork_Click);
            // 
            // tpFlash
            // 
            this.tpFlash.ImageKey = "outline_flash_on_white_24dp.png";
            this.tpFlash.Location = new System.Drawing.Point(4, 31);
            this.tpFlash.Name = "tpFlash";
            this.tpFlash.Padding = new System.Windows.Forms.Padding(3);
            this.tpFlash.Size = new System.Drawing.Size(1204, 573);
            this.tpFlash.TabIndex = 6;
            this.tpFlash.Text = "Flash Wizard";
            this.tpFlash.UseVisualStyleBackColor = true;
            // 
            // tpDonate
            // 
            this.tpDonate.Controls.Add(this.label1);
            this.tpDonate.Controls.Add(this.btnPaypal);
            this.tpDonate.Controls.Add(this.btnKofi);
            this.tpDonate.Controls.Add(this.btnBuyMeCoffee);
            this.tpDonate.ImageKey = "outline_favorite_white_24dp.png";
            this.tpDonate.Location = new System.Drawing.Point(4, 31);
            this.tpDonate.Name = "tpDonate";
            this.tpDonate.Padding = new System.Windows.Forms.Padding(3);
            this.tpDonate.Size = new System.Drawing.Size(1204, 573);
            this.tpDonate.TabIndex = 8;
            this.tpDonate.Text = "Donate";
            this.tpDonate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1222, 109);
            this.label1.TabIndex = 25;
            this.label1.Text = "If you wish to donate to support development you can do so on the following platf" +
    "orms:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPaypal
            // 
            this.btnPaypal.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnPaypal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPaypal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPaypal.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPaypal.Depth = 0;
            this.btnPaypal.HighEmphasis = true;
            this.btnPaypal.Icon = null;
            this.btnPaypal.Location = new System.Drawing.Point(579, 166);
            this.btnPaypal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPaypal.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPaypal.Name = "btnPaypal";
            this.btnPaypal.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnPaypal.Size = new System.Drawing.Size(76, 36);
            this.btnPaypal.TabIndex = 24;
            this.btnPaypal.Text = "Paypal";
            this.btnPaypal.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPaypal.UseAccentColor = true;
            this.btnPaypal.UseVisualStyleBackColor = true;
            this.btnPaypal.Click += new System.EventHandler(this.btnPaypal_Click);
            // 
            // btnKofi
            // 
            this.btnKofi.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnKofi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKofi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnKofi.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnKofi.Depth = 0;
            this.btnKofi.HighEmphasis = true;
            this.btnKofi.Icon = null;
            this.btnKofi.Location = new System.Drawing.Point(585, 118);
            this.btnKofi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnKofi.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnKofi.Name = "btnKofi";
            this.btnKofi.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnKofi.Size = new System.Drawing.Size(64, 36);
            this.btnKofi.TabIndex = 23;
            this.btnKofi.Text = "Ko-Fi";
            this.btnKofi.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnKofi.UseAccentColor = true;
            this.btnKofi.UseVisualStyleBackColor = true;
            this.btnKofi.Click += new System.EventHandler(this.btnKofi_Click);
            // 
            // btnBuyMeCoffee
            // 
            this.btnBuyMeCoffee.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnBuyMeCoffee.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuyMeCoffee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuyMeCoffee.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBuyMeCoffee.Depth = 0;
            this.btnBuyMeCoffee.HighEmphasis = true;
            this.btnBuyMeCoffee.Icon = null;
            this.btnBuyMeCoffee.Location = new System.Drawing.Point(545, 214);
            this.btnBuyMeCoffee.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBuyMeCoffee.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBuyMeCoffee.Name = "btnBuyMeCoffee";
            this.btnBuyMeCoffee.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnBuyMeCoffee.Size = new System.Drawing.Size(144, 36);
            this.btnBuyMeCoffee.TabIndex = 22;
            this.btnBuyMeCoffee.Text = "Buy me a coffee";
            this.btnBuyMeCoffee.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBuyMeCoffee.UseAccentColor = true;
            this.btnBuyMeCoffee.UseVisualStyleBackColor = true;
            this.btnBuyMeCoffee.Click += new System.EventHandler(this.btnBuyMeCoffee_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flpColours);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1204, 573);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flpColours
            // 
            this.flpColours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpColours.Location = new System.Drawing.Point(3, 3);
            this.flpColours.Name = "flpColours";
            this.flpColours.Size = new System.Drawing.Size(1198, 567);
            this.flpColours.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(0, 0);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(200, 100);
            this.tabPage8.TabIndex = 4;
            this.tabPage8.Text = "tabPage1";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // themePanel
            // 
            this.themePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.themePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.themePanel.BackColor = System.Drawing.Color.Transparent;
            this.themePanel.Controls.Add(this.themeButton);
            this.themePanel.Controls.Add(this.adbConnected);
            this.themePanel.Controls.Add(this.wifiConnected);
            this.themePanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.themePanel.Location = new System.Drawing.Point(246, 24);
            this.themePanel.Name = "themePanel";
            this.themePanel.Size = new System.Drawing.Size(969, 40);
            this.themePanel.TabIndex = 34;
            this.themePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.themePanel_Paint);
            // 
            // wifiConnected
            // 
            this.wifiConnected.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.wifiConnected.AutoSize = false;
            this.wifiConnected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wifiConnected.BackColor = System.Drawing.Color.Red;
            this.wifiConnected.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.wifiConnected.Depth = 0;
            this.wifiConnected.DrawShadows = false;
            this.wifiConnected.Enabled = false;
            this.wifiConnected.HighEmphasis = true;
            this.wifiConnected.Icon = global::OpenpilotToolkit.Properties.Resources.outline_wifi_black_24dp;
            this.wifiConnected.ImageKey = "outline_wifi_white_24dp.png";
            this.wifiConnected.ImageList = this.ilTabs;
            this.wifiConnected.Location = new System.Drawing.Point(839, 2);
            this.wifiConnected.Margin = new System.Windows.Forms.Padding(2);
            this.wifiConnected.MouseState = MaterialSkin.MouseState.HOVER;
            this.wifiConnected.Name = "wifiConnected";
            this.wifiConnected.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.wifiConnected.Size = new System.Drawing.Size(40, 36);
            this.wifiConnected.TabIndex = 32;
            this.wifiConnected.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.wifiConnected.UseAccentColor = false;
            this.wifiConnected.UseVisualStyleBackColor = true;
            // 
            // sqliteCommand1
            // 
            this.sqliteCommand1.CommandTimeout = 30;
            this.sqliteCommand1.Connection = null;
            this.sqliteCommand1.Transaction = null;
            this.sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // OpenpilotToolkitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 675);
            this.Controls.Add(this.tcSettings);
            this.Controls.Add(this.themePanel);
            this.DrawerAutoHide = false;
            this.DrawerBackgroundWithAccent = true;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.tcSettings;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1085, 412);
            this.Name = "OpenpilotToolkitForm";
            this.Text = "Openpilot Toolkit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportDrivesForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OpenpilotToolkitForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.tcSettings.ResumeLayout(false);
            this.tpExport.ResumeLayout(false);
            this.tpExport.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpLogFile.ResumeLayout(false);
            this.tpExplore.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExplorer)).EndInit();
            this.tpFingerprint.ResumeLayout(false);
            this.tpSSH.ResumeLayout(false);
            this.tpFork.ResumeLayout(false);
            this.tpDonate.ResumeLayout(false);
            this.tpDonate.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.themePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDrives;
        private System.Windows.Forms.ListBox lbCommaList;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.FolderBrowserDialog fbdExportFolder;
        private MaterialSkin.Controls.MaterialLabel lblCommaList;
        private MaterialButton btnBrowse;
        private MaterialButton btnRefreshVideos;
        private MaterialButton btnExportMapillary;
        private MaterialButton btnExportGpx;
        private MaterialButton btnExport;
        private MaterialButton btnScan;
        private MaterialSkin.Controls.MaterialTextBox txtExportFolder;
        private MaterialSkin.Controls.MaterialLabel lblDrives;
        private MaterialButton themeButton;
        private MaterialSkin.Controls.MaterialTabControl tcSettings;
        private System.Windows.Forms.TabPage tpExport;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.ImageList ilTabs;
        private System.Windows.Forms.TabPage tpLogFile;
        private MaterialSkin.Controls.MaterialMultiLineTextBox txtLog;
        private System.Windows.Forms.TabPage tpExplore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tpFingerprint;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tpSSH;
        private MaterialButton adbConnected;
        private System.Windows.Forms.FlowLayoutPanel themePanel;
        private MaterialButton wifiConnected;
        private System.Windows.Forms.TabPage tpFlash;
        private System.Windows.Forms.TableLayoutPanel tlpTasks;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private ucSshWizard ucSshWizard;
        private MaterialComboBox cmbDevice;
        private MaterialTextBox txtWorkingDirectory;
        private MaterialTextBox txtSearch;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flpColours;
        private Controls.MaterialSkinDataGridView dgvExplorer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChanged;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialCheckbox cbCombineSegments;
        private System.Windows.Forms.TabPage tpDonate;
        private System.Windows.Forms.Label label1;
        private MaterialButton btnPaypal;
        private MaterialButton btnKofi;
        private MaterialButton btnBuyMeCoffee;
        private Controls.Media.VideoPlayer vlcVideoPlayer;
        private MaterialMultiLineTextBox txtFingerprint;
        private System.Windows.Forms.TabPage tpFork;
        private MaterialTextBox txtForkBranch;
        private MaterialTextBox txtForkUsername;
        private MaterialButton btnInstallFork;
    }
}

