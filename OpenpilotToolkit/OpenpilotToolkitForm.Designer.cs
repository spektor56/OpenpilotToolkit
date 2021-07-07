
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
            this.themePanel23 = new System.Windows.Forms.Panel();
            this.adbConnected = new MaterialSkin.Controls.MaterialButton();
            this.ilTabs = new System.Windows.Forms.ImageList(this.components);
            this.themeButton = new MaterialSkin.Controls.MaterialButton();
            this.tcSettings = new MaterialSkin.Controls.MaterialTabControl();
            this.tpExport = new System.Windows.Forms.TabPage();
            this.tlpTasks = new System.Windows.Forms.TableLayoutPanel();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.tpLogFile = new System.Windows.Forms.TabPage();
            this.txtLog = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.tpExplore = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialListBox2 = new MaterialSkin.Controls.MaterialListBox();
            this.tpFingerprint = new System.Windows.Forms.TabPage();
            this.tpSSH = new System.Windows.Forms.TabPage();
            this.ucSshWizard = new OpenpilotToolkit.Controls.Wizards.ucSshWizard();
            this.tpFlash = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.themePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.wifiConnected = new MaterialSkin.Controls.MaterialButton();
            this.sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.tcSettings.SuspendLayout();
            this.tpExport.SuspendLayout();
            this.tpLogFile.SuspendLayout();
            this.tpExplore.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpFingerprint.SuspendLayout();
            this.tpSSH.SuspendLayout();
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
            this.lbDrives.Size = new System.Drawing.Size(143, 499);
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
            this.lbCommaList.Size = new System.Drawing.Size(106, 499);
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
            this.pbPreview.Size = new System.Drawing.Size(739, 525);
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
            this.btnBrowse.Location = new System.Drawing.Point(354, 9);
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
            this.btnRefreshVideos.Location = new System.Drawing.Point(442, 9);
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
            this.btnExportMapillary.Location = new System.Drawing.Point(612, 9);
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
            this.btnExportGpx.Location = new System.Drawing.Point(721, 9);
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
            this.btnExport.Location = new System.Drawing.Point(793, 9);
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
            this.btnScan.Location = new System.Drawing.Point(996, 9);
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
            this.txtExportFolder.Size = new System.Drawing.Size(341, 50);
            this.txtExportFolder.TabIndex = 26;
            this.txtExportFolder.Text = "D:\\OpenPilot";
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
            // themePanel23
            // 
            this.themePanel23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.themePanel23.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.themePanel23.BackColor = System.Drawing.Color.Transparent;
            this.themePanel23.Location = new System.Drawing.Point(894, 26);
            this.themePanel23.Name = "themePanel23";
            this.themePanel23.Size = new System.Drawing.Size(348, 36);
            this.themePanel23.TabIndex = 32;
            this.themePanel23.LocationChanged += new System.EventHandler(this.themePanel_LocationChanged);
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
            this.adbConnected.Location = new System.Drawing.Point(913, 2);
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
            this.themeButton.Location = new System.Drawing.Point(957, 2);
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
            this.tcSettings.Controls.Add(this.tpFlash);
            this.tcSettings.Depth = 0;
            this.tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSettings.ImageList = this.ilTabs;
            this.tcSettings.Location = new System.Drawing.Point(3, 64);
            this.tcSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.tcSettings.Multiline = true;
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.SelectedIndex = 0;
            this.tcSettings.Size = new System.Drawing.Size(1242, 672);
            this.tcSettings.TabIndex = 33;
            this.tcSettings.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcSettings_Selected);
            // 
            // tpExport
            // 
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
            this.tpExport.Controls.Add(this.pbPreview);
            this.tpExport.Controls.Add(this.btnExportMapillary);
            this.tpExport.ImageKey = "outline_file_download_white_24dp.png";
            this.tpExport.Location = new System.Drawing.Point(4, 31);
            this.tpExport.Name = "tpExport";
            this.tpExport.Padding = new System.Windows.Forms.Padding(3);
            this.tpExport.Size = new System.Drawing.Size(1234, 637);
            this.tpExport.TabIndex = 0;
            this.tpExport.Text = "Export";
            this.tpExport.UseVisualStyleBackColor = true;
            // 
            // tlpTasks
            // 
            this.tlpTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTasks.AutoScroll = true;
            this.tlpTasks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpTasks.ColumnCount = 1;
            this.tlpTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTasks.Location = new System.Drawing.Point(1018, 106);
            this.tlpTasks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpTasks.Name = "tlpTasks";
            this.tlpTasks.RowCount = 1;
            this.tlpTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTasks.Size = new System.Drawing.Size(209, 525);
            this.tlpTasks.TabIndex = 16;
            // 
            // tpSettings
            // 
            this.tpSettings.ImageKey = "outline_settings_white_24dp.png";
            this.tpSettings.Location = new System.Drawing.Point(4, 31);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1234, 637);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // tpLogFile
            // 
            this.tpLogFile.Controls.Add(this.txtLog);
            this.tpLogFile.ImageKey = "outline_description_white_24dp.png";
            this.tpLogFile.Location = new System.Drawing.Point(4, 31);
            this.tpLogFile.Name = "tpLogFile";
            this.tpLogFile.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogFile.Size = new System.Drawing.Size(1234, 637);
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
            this.txtLog.Size = new System.Drawing.Size(1228, 631);
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
            this.tpExplore.Size = new System.Drawing.Size(1234, 637);
            this.tpExplore.TabIndex = 3;
            this.tpExplore.Text = "Explorer";
            this.tpExplore.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.materialListBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1228, 631);
            this.panel1.TabIndex = 0;
            // 
            // materialListBox2
            // 
            this.materialListBox2.BackColor = System.Drawing.Color.White;
            this.materialListBox2.BorderColor = System.Drawing.Color.LightGray;
            this.materialListBox2.Depth = 0;
            this.materialListBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialListBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialListBox2.Location = new System.Drawing.Point(0, 0);
            this.materialListBox2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialListBox2.Name = "materialListBox2";
            this.materialListBox2.SelectedIndex = -1;
            this.materialListBox2.SelectedItem = null;
            this.materialListBox2.Size = new System.Drawing.Size(1228, 631);
            this.materialListBox2.TabIndex = 0;
            // 
            // tpFingerprint
            // 
            this.tpFingerprint.ImageKey = "outline_fingerprint_white_24dp.png";
            this.tpFingerprint.Location = new System.Drawing.Point(4, 31);
            this.tpFingerprint.Name = "tpFingerprint";
            this.tpFingerprint.Padding = new System.Windows.Forms.Padding(3);
            this.tpFingerprint.Size = new System.Drawing.Size(1234, 637);
            this.tpFingerprint.TabIndex = 4;
            this.tpFingerprint.Text = "Fingerprint";
            this.tpFingerprint.UseVisualStyleBackColor = true;
            // 
            // tpSSH
            // 
            this.tpSSH.Controls.Add(this.ucSshWizard);
            this.tpSSH.ImageKey = "outline_ssh_black_24dp.png";
            this.tpSSH.Location = new System.Drawing.Point(4, 31);
            this.tpSSH.Name = "tpSSH";
            this.tpSSH.Padding = new System.Windows.Forms.Padding(3);
            this.tpSSH.Size = new System.Drawing.Size(1234, 637);
            this.tpSSH.TabIndex = 5;
            this.tpSSH.Text = "SSH Wizard";
            this.tpSSH.UseVisualStyleBackColor = true;
            // 
            // ucSshWizard
            // 
            this.ucSshWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSshWizard.Location = new System.Drawing.Point(3, 3);
            this.ucSshWizard.Name = "ucSshWizard";
            this.ucSshWizard.Size = new System.Drawing.Size(1228, 631);
            this.ucSshWizard.TabIndex = 1;
            this.ucSshWizard.WizardCompleted += new System.EventHandler(this.ucSshWizard_WizardCompleted);
            // 
            // tpFlash
            // 
            this.tpFlash.ImageKey = "outline_flash_on_white_24dp.png";
            this.tpFlash.Location = new System.Drawing.Point(4, 31);
            this.tpFlash.Name = "tpFlash";
            this.tpFlash.Padding = new System.Windows.Forms.Padding(3);
            this.tpFlash.Size = new System.Drawing.Size(1234, 637);
            this.tpFlash.TabIndex = 6;
            this.tpFlash.Text = "Flash Wizard";
            this.tpFlash.UseVisualStyleBackColor = true;
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
            this.themePanel.Size = new System.Drawing.Size(999, 40);
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
            this.wifiConnected.Location = new System.Drawing.Point(869, 2);
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
            this.ClientSize = new System.Drawing.Size(1248, 739);
            this.Controls.Add(this.tcSettings);
            this.Controls.Add(this.themePanel);
            this.Controls.Add(this.themePanel23);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.tcSettings.ResumeLayout(false);
            this.tpExport.ResumeLayout(false);
            this.tpExport.PerformLayout();
            this.tpLogFile.ResumeLayout(false);
            this.tpExplore.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tpFingerprint.ResumeLayout(false);
            this.tpSSH.ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialListBox materialListBox1;
        private System.Windows.Forms.Panel themePanel23;
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
        private MaterialSkin.Controls.MaterialListBox materialListBox2;
        private System.Windows.Forms.TabPage tpSSH;
        private MaterialButton adbConnected;
        private System.Windows.Forms.FlowLayoutPanel themePanel;
        private MaterialButton wifiConnected;
        private System.Windows.Forms.TabPage tpFlash;
        private System.Windows.Forms.TableLayoutPanel tlpTasks;
        private ucSshWizard ucWizard1;
        private ucSshWizard ucWizard2;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private ucSshWizard ucSshWizard;
    }
}

