
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbDrives = new System.Windows.Forms.ListBox();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.fbdExportFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new MaterialSkin.Controls.MaterialButton();
            this.btnRefreshVideos = new MaterialSkin.Controls.MaterialButton();
            this.btnExportMapillary = new MaterialSkin.Controls.MaterialButton();
            this.btnExportGpx = new MaterialSkin.Controls.MaterialButton();
            this.btnExport = new MaterialSkin.Controls.MaterialButton();
            this.btnScan = new MaterialSkin.Controls.MaterialButton();
            this.txtExportFolder = new MaterialSkin.Controls.MaterialTextBox();
            this.adbConnected = new MaterialSkin.Controls.MaterialButton();
            this.ilTabs = new System.Windows.Forms.ImageList(this.components);
            this.themeButton = new MaterialSkin.Controls.MaterialButton();
            this.tcSettings = new MaterialSkin.Controls.MaterialTabControl();
            this.tpExport = new System.Windows.Forms.TabPage();
            this.tlpTasks = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDriveInfo = new OpenpilotToolkit.Controls.MaterialSkinDataGridView();
            this.colProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbFrontCamera = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbDriverCamera = new MaterialSkin.Controls.MaterialCheckbox();
            this.cbWideCamera = new MaterialSkin.Controls.MaterialCheckbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOsmUpload = new MaterialSkin.Controls.MaterialButton();
            this.btnDeleteDrives = new MaterialSkin.Controls.MaterialButton();
            this.vlcVideoPlayer = new OpenpilotToolkit.Controls.Media.VideoPlayer();
            this.tpRemote = new System.Windows.Forms.TabPage();
            this.btnUpdate = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.btnCloseSettings = new MaterialSkin.Controls.MaterialButton();
            this.btnFlashPanda = new MaterialSkin.Controls.MaterialButton();
            this.btnOpenSettings = new MaterialSkin.Controls.MaterialButton();
            this.btnShutdown = new MaterialSkin.Controls.MaterialButton();
            this.btnReboot = new MaterialSkin.Controls.MaterialButton();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOsmTest = new MaterialSkin.Controls.MaterialButton();
            this.txtOsmPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtOsmUsername = new MaterialSkin.Controls.MaterialTextBox2();
            this.cbCombineSegments = new MaterialSkin.Controls.MaterialCheckbox();
            this.tpLogFile = new System.Windows.Forms.TabPage();
            this.txtLog = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.tpExplore = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpExplorerTasks = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtWorkingDirectory = new MaterialSkin.Controls.MaterialTextBox();
            this.dgvExplorer = new OpenpilotToolkit.Controls.MaterialSkinDataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.tpFingerprint = new System.Windows.Forms.TabPage();
            this.txtFingerprint = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.tpSSH = new System.Windows.Forms.TabPage();
            this.ucSshWizard = new OpenpilotToolkit.Controls.Wizards.ucSshWizard();
            this.tpFork = new System.Windows.Forms.TabPage();
            this.txtForkBranch = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtForkUsername = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnInstallFork = new MaterialSkin.Controls.MaterialButton();
            this.tpFlash = new System.Windows.Forms.TabPage();
            this.tpShell = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnTmuxEndScroll = new MaterialSkin.Controls.MaterialButton();
            this.btnTmuxScroll = new MaterialSkin.Controls.MaterialButton();
            this.btnTmux = new MaterialSkin.Controls.MaterialButton();
            this.btnExitTmux = new MaterialSkin.Controls.MaterialButton();
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
            this.cmbDevices = new MaterialSkin.Controls.MaterialComboBox();
            this.lblActiveDevice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.tcSettings.SuspendLayout();
            this.tpExport.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriveInfo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tpRemote.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tpLogFile.SuspendLayout();
            this.tpExplore.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExplorer)).BeginInit();
            this.tpFingerprint.SuspendLayout();
            this.tpSSH.SuspendLayout();
            this.tpFork.SuspendLayout();
            this.tpShell.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.lbDrives.Location = new System.Drawing.Point(217, 123);
            this.lbDrives.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbDrives.Name = "lbDrives";
            this.lbDrives.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbDrives.Size = new System.Drawing.Size(143, 364);
            this.lbDrives.TabIndex = 4;
            this.lbDrives.SelectedIndexChanged += new System.EventHandler(this.lbDrives_SelectedIndexChanged);
            this.lbDrives.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lbDrives_PreviewKeyDown);
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreview.Location = new System.Drawing.Point(368, 123);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(532, 373);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 8;
            this.pbPreview.TabStop = false;
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
            this.btnBrowse.Location = new System.Drawing.Point(1006, 9);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnBrowse.Size = new System.Drawing.Size(89, 36);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBrowse.UseAccentColor = true;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnRefreshVideos
            // 
            this.btnRefreshVideos.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnRefreshVideos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshVideos.AutoSize = false;
            this.btnRefreshVideos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefreshVideos.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefreshVideos.Depth = 0;
            this.btnRefreshVideos.HighEmphasis = true;
            this.btnRefreshVideos.Icon = null;
            this.btnRefreshVideos.Location = new System.Drawing.Point(4, 6);
            this.btnRefreshVideos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefreshVideos.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRefreshVideos.Name = "btnRefreshVideos";
            this.btnRefreshVideos.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnRefreshVideos.Size = new System.Drawing.Size(196, 36);
            this.btnRefreshVideos.TabIndex = 0;
            this.btnRefreshVideos.Text = "&Refresh Drive List";
            this.btnRefreshVideos.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRefreshVideos.UseAccentColor = true;
            this.btnRefreshVideos.UseVisualStyleBackColor = true;
            this.btnRefreshVideos.Click += new System.EventHandler(this.btnRefreshVideos_Click);
            // 
            // btnExportMapillary
            // 
            this.btnExportMapillary.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnExportMapillary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportMapillary.AutoSize = false;
            this.btnExportMapillary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportMapillary.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExportMapillary.Depth = 0;
            this.btnExportMapillary.Enabled = false;
            this.btnExportMapillary.HighEmphasis = true;
            this.btnExportMapillary.Icon = null;
            this.btnExportMapillary.Location = new System.Drawing.Point(4, 246);
            this.btnExportMapillary.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExportMapillary.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExportMapillary.Name = "btnExportMapillary";
            this.btnExportMapillary.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnExportMapillary.Size = new System.Drawing.Size(194, 36);
            this.btnExportMapillary.TabIndex = 5;
            this.btnExportMapillary.Text = "&Mapillary Export";
            this.btnExportMapillary.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExportMapillary.UseAccentColor = true;
            this.btnExportMapillary.UseVisualStyleBackColor = true;
            this.btnExportMapillary.Click += new System.EventHandler(this.btnExportMapillary_Click);
            // 
            // btnExportGpx
            // 
            this.btnExportGpx.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnExportGpx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportGpx.AutoSize = false;
            this.btnExportGpx.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExportGpx.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExportGpx.Depth = 0;
            this.btnExportGpx.HighEmphasis = true;
            this.btnExportGpx.Icon = null;
            this.btnExportGpx.Location = new System.Drawing.Point(4, 150);
            this.btnExportGpx.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExportGpx.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExportGpx.Name = "btnExportGpx";
            this.btnExportGpx.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnExportGpx.Size = new System.Drawing.Size(194, 36);
            this.btnExportGpx.TabIndex = 3;
            this.btnExportGpx.Text = "&GPX Export";
            this.btnExportGpx.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExportGpx.UseAccentColor = true;
            this.btnExportGpx.UseVisualStyleBackColor = true;
            this.btnExportGpx.Click += new System.EventHandler(this.btnExportGpx_Click);
            // 
            // btnExport
            // 
            this.btnExport.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.AutoSize = false;
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExport.Depth = 0;
            this.btnExport.HighEmphasis = true;
            this.btnExport.Icon = null;
            this.btnExport.Location = new System.Drawing.Point(4, 54);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExport.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExport.Name = "btnExport";
            this.btnExport.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnExport.Size = new System.Drawing.Size(194, 36);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "&Export Selected Drive(s)";
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
            this.btnScan.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.btnScan.Depth = 0;
            this.btnScan.HighEmphasis = true;
            this.btnScan.Icon = null;
            this.btnScan.Location = new System.Drawing.Point(558, 2);
            this.btnScan.Margin = new System.Windows.Forms.Padding(2);
            this.btnScan.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnScan.Name = "btnScan";
            this.btnScan.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnScan.Size = new System.Drawing.Size(177, 36);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan For OP Devices";
            this.btnScan.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnScan.UseAccentColor = false;
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtExportFolder
            // 
            this.txtExportFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportFolder.AnimateReadOnly = false;
            this.txtExportFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExportFolder.Depth = 0;
            this.txtExportFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtExportFolder.Hint = "Export Folder";
            this.txtExportFolder.LeadingIcon = null;
            this.txtExportFolder.Location = new System.Drawing.Point(6, 6);
            this.txtExportFolder.MaxLength = 50;
            this.txtExportFolder.MouseState = MaterialSkin.MouseState.OUT;
            this.txtExportFolder.Multiline = false;
            this.txtExportFolder.Name = "txtExportFolder";
            this.txtExportFolder.Size = new System.Drawing.Size(1002, 50);
            this.txtExportFolder.TabIndex = 0;
            this.txtExportFolder.Text = "C:\\Openpilot";
            this.txtExportFolder.TrailingIcon = null;
            this.txtExportFolder.DoubleClick += new System.EventHandler(this.txtExportFolder_DoubleClick);
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
            this.adbConnected.Location = new System.Drawing.Point(783, 2);
            this.adbConnected.Margin = new System.Windows.Forms.Padding(2);
            this.adbConnected.MouseState = MaterialSkin.MouseState.HOVER;
            this.adbConnected.Name = "adbConnected";
            this.adbConnected.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.adbConnected.Size = new System.Drawing.Size(40, 36);
            this.adbConnected.TabIndex = 3;
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
            this.ilTabs.Images.SetKeyName(11, "outline_console_black_24dp.png");
            this.ilTabs.Images.SetKeyName(12, "outline_games_white_24dp.png");
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
            this.themeButton.Location = new System.Drawing.Point(827, 2);
            this.themeButton.Margin = new System.Windows.Forms.Padding(2);
            this.themeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.themeButton.Name = "themeButton";
            this.themeButton.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.themeButton.Size = new System.Drawing.Size(40, 36);
            this.themeButton.TabIndex = 4;
            this.themeButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.themeButton.UseAccentColor = false;
            this.themeButton.UseVisualStyleBackColor = false;
            this.themeButton.Click += new System.EventHandler(this.themeButton_Click);
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tpExport);
            this.tcSettings.Controls.Add(this.tpRemote);
            this.tcSettings.Controls.Add(this.tpSettings);
            this.tcSettings.Controls.Add(this.tpLogFile);
            this.tcSettings.Controls.Add(this.tpExplore);
            this.tcSettings.Controls.Add(this.tpFingerprint);
            this.tcSettings.Controls.Add(this.tpSSH);
            this.tcSettings.Controls.Add(this.tpFork);
            this.tcSettings.Controls.Add(this.tpFlash);
            this.tcSettings.Controls.Add(this.tpShell);
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
            this.tcSettings.Size = new System.Drawing.Size(1110, 537);
            this.tcSettings.TabIndex = 1;
            this.tcSettings.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcSettings_Selected);
            // 
            // tpExport
            // 
            this.tpExport.BackColor = System.Drawing.Color.White;
            this.tpExport.Controls.Add(this.tlpTasks);
            this.tpExport.Controls.Add(this.groupBox3);
            this.tpExport.Controls.Add(this.groupBox2);
            this.tpExport.Controls.Add(this.panel2);
            this.tpExport.Controls.Add(this.pbPreview);
            this.tpExport.Controls.Add(this.vlcVideoPlayer);
            this.tpExport.Controls.Add(this.txtExportFolder);
            this.tpExport.Controls.Add(this.lbDrives);
            this.tpExport.Controls.Add(this.btnBrowse);
            this.tpExport.ImageKey = "outline_file_download_white_24dp.png";
            this.tpExport.Location = new System.Drawing.Point(4, 31);
            this.tpExport.Name = "tpExport";
            this.tpExport.Padding = new System.Windows.Forms.Padding(3);
            this.tpExport.Size = new System.Drawing.Size(1102, 502);
            this.tpExport.TabIndex = 0;
            this.tpExport.Text = "Export";
            // 
            // tlpTasks
            // 
            this.tlpTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTasks.AutoScroll = true;
            this.tlpTasks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpTasks.ColumnCount = 1;
            this.tlpTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTasks.Location = new System.Drawing.Point(908, 239);
            this.tlpTasks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpTasks.Name = "tlpTasks";
            this.tlpTasks.RowCount = 1;
            this.tlpTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTasks.Size = new System.Drawing.Size(187, 257);
            this.tlpTasks.TabIndex = 16;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvDriveInfo);
            this.groupBox3.Location = new System.Drawing.Point(908, 123);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 110);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Drive Info";
            // 
            // dgvDriveInfo
            // 
            this.dgvDriveInfo.AllowUserToAddRows = false;
            this.dgvDriveInfo.AllowUserToDeleteRows = false;
            this.dgvDriveInfo.AllowUserToResizeRows = false;
            this.dgvDriveInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDriveInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDriveInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvDriveInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDriveInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDriveInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Custom;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDriveInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDriveInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDriveInfo.ColumnHeadersVisible = false;
            this.dgvDriveInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProperty,
            this.colValue});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDriveInfo.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDriveInfo.Depth = 0;
            this.dgvDriveInfo.EnableHeadersVisualStyles = false;
            this.dgvDriveInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dgvDriveInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvDriveInfo.Location = new System.Drawing.Point(6, 22);
            this.dgvDriveInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.dgvDriveInfo.Name = "dgvDriveInfo";
            this.dgvDriveInfo.ReadOnly = true;
            this.dgvDriveInfo.RowHeadersVisible = false;
            this.dgvDriveInfo.RowTemplate.Height = 25;
            this.dgvDriveInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDriveInfo.ShowCellToolTips = false;
            this.dgvDriveInfo.Size = new System.Drawing.Size(175, 78);
            this.dgvDriveInfo.TabIndex = 0;
            // 
            // colProperty
            // 
            this.colProperty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProperty.DataPropertyName = "Key";
            this.colProperty.HeaderText = "Property";
            this.colProperty.Name = "colProperty";
            this.colProperty.ReadOnly = true;
            this.colProperty.Width = 5;
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colValue.DataPropertyName = "Value";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colValue.DefaultCellStyle = dataGridViewCellStyle12;
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbFrontCamera);
            this.groupBox2.Controls.Add(this.cbDriverCamera);
            this.groupBox2.Controls.Add(this.cbWideCamera);
            this.groupBox2.Location = new System.Drawing.Point(217, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(878, 55);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export Camera";
            // 
            // cbFrontCamera
            // 
            this.cbFrontCamera.AutoSize = true;
            this.cbFrontCamera.Checked = true;
            this.cbFrontCamera.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFrontCamera.Depth = 0;
            this.cbFrontCamera.Location = new System.Drawing.Point(3, 15);
            this.cbFrontCamera.Margin = new System.Windows.Forms.Padding(0);
            this.cbFrontCamera.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbFrontCamera.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbFrontCamera.Name = "cbFrontCamera";
            this.cbFrontCamera.ReadOnly = false;
            this.cbFrontCamera.Ripple = true;
            this.cbFrontCamera.Size = new System.Drawing.Size(72, 37);
            this.cbFrontCamera.TabIndex = 0;
            this.cbFrontCamera.Text = "Front";
            this.cbFrontCamera.UseVisualStyleBackColor = true;
            // 
            // cbDriverCamera
            // 
            this.cbDriverCamera.AutoSize = true;
            this.cbDriverCamera.Depth = 0;
            this.cbDriverCamera.Location = new System.Drawing.Point(145, 15);
            this.cbDriverCamera.Margin = new System.Windows.Forms.Padding(0);
            this.cbDriverCamera.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbDriverCamera.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbDriverCamera.Name = "cbDriverCamera";
            this.cbDriverCamera.ReadOnly = false;
            this.cbDriverCamera.Ripple = true;
            this.cbDriverCamera.Size = new System.Drawing.Size(76, 37);
            this.cbDriverCamera.TabIndex = 2;
            this.cbDriverCamera.Text = "Driver";
            this.cbDriverCamera.UseVisualStyleBackColor = true;
            // 
            // cbWideCamera
            // 
            this.cbWideCamera.AutoSize = true;
            this.cbWideCamera.Depth = 0;
            this.cbWideCamera.Location = new System.Drawing.Point(75, 15);
            this.cbWideCamera.Margin = new System.Windows.Forms.Padding(0);
            this.cbWideCamera.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbWideCamera.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbWideCamera.Name = "cbWideCamera";
            this.cbWideCamera.ReadOnly = false;
            this.cbWideCamera.Ripple = true;
            this.cbWideCamera.Size = new System.Drawing.Size(70, 37);
            this.cbWideCamera.TabIndex = 1;
            this.cbWideCamera.Text = "Wide";
            this.cbWideCamera.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOsmUpload);
            this.panel2.Controls.Add(this.btnDeleteDrives);
            this.panel2.Controls.Add(this.btnRefreshVideos);
            this.panel2.Controls.Add(this.btnExportMapillary);
            this.panel2.Controls.Add(this.btnExportGpx);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Location = new System.Drawing.Point(6, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 434);
            this.panel2.TabIndex = 2;
            // 
            // btnOsmUpload
            // 
            this.btnOsmUpload.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnOsmUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOsmUpload.AutoSize = false;
            this.btnOsmUpload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOsmUpload.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOsmUpload.Depth = 0;
            this.btnOsmUpload.HighEmphasis = true;
            this.btnOsmUpload.Icon = null;
            this.btnOsmUpload.Location = new System.Drawing.Point(4, 198);
            this.btnOsmUpload.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOsmUpload.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOsmUpload.Name = "btnOsmUpload";
            this.btnOsmUpload.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnOsmUpload.Size = new System.Drawing.Size(194, 36);
            this.btnOsmUpload.TabIndex = 4;
            this.btnOsmUpload.Text = "Upload GPS to &OSM";
            this.btnOsmUpload.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOsmUpload.UseAccentColor = true;
            this.btnOsmUpload.UseVisualStyleBackColor = true;
            this.btnOsmUpload.Click += new System.EventHandler(this.btnOsmUpload_Click);
            // 
            // btnDeleteDrives
            // 
            this.btnDeleteDrives.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnDeleteDrives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDrives.AutoSize = false;
            this.btnDeleteDrives.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteDrives.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeleteDrives.Depth = 0;
            this.btnDeleteDrives.HighEmphasis = true;
            this.btnDeleteDrives.Icon = null;
            this.btnDeleteDrives.Location = new System.Drawing.Point(4, 102);
            this.btnDeleteDrives.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteDrives.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteDrives.Name = "btnDeleteDrives";
            this.btnDeleteDrives.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnDeleteDrives.Size = new System.Drawing.Size(194, 36);
            this.btnDeleteDrives.TabIndex = 2;
            this.btnDeleteDrives.Text = "&Delete Selected Drive(s)";
            this.btnDeleteDrives.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeleteDrives.UseAccentColor = true;
            this.btnDeleteDrives.UseVisualStyleBackColor = true;
            this.btnDeleteDrives.Click += new System.EventHandler(this.btnDeleteDrives_Click);
            // 
            // vlcVideoPlayer
            // 
            this.vlcVideoPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlcVideoPlayer.Location = new System.Drawing.Point(367, 123);
            this.vlcVideoPlayer.Name = "vlcVideoPlayer";
            this.vlcVideoPlayer.Size = new System.Drawing.Size(533, 373);
            this.vlcVideoPlayer.TabIndex = 5;
            // 
            // tpRemote
            // 
            this.tpRemote.BackColor = System.Drawing.Color.White;
            this.tpRemote.Controls.Add(this.btnUpdate);
            this.tpRemote.Controls.Add(this.materialButton1);
            this.tpRemote.Controls.Add(this.btnCloseSettings);
            this.tpRemote.Controls.Add(this.btnFlashPanda);
            this.tpRemote.Controls.Add(this.btnOpenSettings);
            this.tpRemote.Controls.Add(this.btnShutdown);
            this.tpRemote.Controls.Add(this.btnReboot);
            this.tpRemote.ImageKey = "outline_games_white_24dp.png";
            this.tpRemote.Location = new System.Drawing.Point(4, 31);
            this.tpRemote.Name = "tpRemote";
            this.tpRemote.Padding = new System.Windows.Forms.Padding(3);
            this.tpRemote.Size = new System.Drawing.Size(1102, 502);
            this.tpRemote.TabIndex = 11;
            this.tpRemote.Text = "Remote";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.AutoSize = false;
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUpdate.Depth = 0;
            this.btnUpdate.HighEmphasis = true;
            this.btnUpdate.Icon = null;
            this.btnUpdate.Location = new System.Drawing.Point(392, 89);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnUpdate.Size = new System.Drawing.Size(307, 36);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "Reinstall Openpilot";
            this.btnUpdate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUpdate.UseAccentColor = true;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.materialButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(392, 377);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.materialButton1.Size = new System.Drawing.Size(307, 36);
            this.materialButton1.TabIndex = 36;
            this.materialButton1.Text = "Install Emu";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = true;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click_1);
            // 
            // btnCloseSettings
            // 
            this.btnCloseSettings.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnCloseSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCloseSettings.AutoSize = false;
            this.btnCloseSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCloseSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCloseSettings.Depth = 0;
            this.btnCloseSettings.HighEmphasis = true;
            this.btnCloseSettings.Icon = null;
            this.btnCloseSettings.Location = new System.Drawing.Point(392, 281);
            this.btnCloseSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCloseSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCloseSettings.Name = "btnCloseSettings";
            this.btnCloseSettings.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnCloseSettings.Size = new System.Drawing.Size(307, 36);
            this.btnCloseSettings.TabIndex = 34;
            this.btnCloseSettings.Text = "Close Settings";
            this.btnCloseSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCloseSettings.UseAccentColor = true;
            this.btnCloseSettings.UseVisualStyleBackColor = true;
            this.btnCloseSettings.Click += new System.EventHandler(this.btnCloseSettings_Click);
            // 
            // btnFlashPanda
            // 
            this.btnFlashPanda.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnFlashPanda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFlashPanda.AutoSize = false;
            this.btnFlashPanda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFlashPanda.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnFlashPanda.Depth = 0;
            this.btnFlashPanda.HighEmphasis = true;
            this.btnFlashPanda.Icon = null;
            this.btnFlashPanda.Location = new System.Drawing.Point(392, 329);
            this.btnFlashPanda.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFlashPanda.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFlashPanda.Name = "btnFlashPanda";
            this.btnFlashPanda.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnFlashPanda.Size = new System.Drawing.Size(307, 36);
            this.btnFlashPanda.TabIndex = 35;
            this.btnFlashPanda.Text = "Flash Panda";
            this.btnFlashPanda.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnFlashPanda.UseAccentColor = true;
            this.btnFlashPanda.UseVisualStyleBackColor = true;
            this.btnFlashPanda.Click += new System.EventHandler(this.btnFlashPanda_Click);
            // 
            // btnOpenSettings
            // 
            this.btnOpenSettings.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnOpenSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOpenSettings.AutoSize = false;
            this.btnOpenSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOpenSettings.Depth = 0;
            this.btnOpenSettings.HighEmphasis = true;
            this.btnOpenSettings.Icon = null;
            this.btnOpenSettings.Location = new System.Drawing.Point(392, 233);
            this.btnOpenSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOpenSettings.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenSettings.Name = "btnOpenSettings";
            this.btnOpenSettings.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnOpenSettings.Size = new System.Drawing.Size(307, 36);
            this.btnOpenSettings.TabIndex = 33;
            this.btnOpenSettings.Text = "Open Settings";
            this.btnOpenSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOpenSettings.UseAccentColor = true;
            this.btnOpenSettings.UseVisualStyleBackColor = true;
            this.btnOpenSettings.Click += new System.EventHandler(this.btnOpenSettings_Click);
            // 
            // btnShutdown
            // 
            this.btnShutdown.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnShutdown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShutdown.AutoSize = false;
            this.btnShutdown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShutdown.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnShutdown.Depth = 0;
            this.btnShutdown.HighEmphasis = true;
            this.btnShutdown.Icon = null;
            this.btnShutdown.Location = new System.Drawing.Point(392, 185);
            this.btnShutdown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnShutdown.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnShutdown.Size = new System.Drawing.Size(307, 36);
            this.btnShutdown.TabIndex = 32;
            this.btnShutdown.Text = "shutdown";
            this.btnShutdown.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnShutdown.UseAccentColor = true;
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnReboot
            // 
            this.btnReboot.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnReboot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReboot.AutoSize = false;
            this.btnReboot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReboot.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReboot.Depth = 0;
            this.btnReboot.HighEmphasis = true;
            this.btnReboot.Icon = null;
            this.btnReboot.Location = new System.Drawing.Point(392, 137);
            this.btnReboot.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReboot.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnReboot.Size = new System.Drawing.Size(307, 36);
            this.btnReboot.TabIndex = 31;
            this.btnReboot.Text = "reboot";
            this.btnReboot.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReboot.UseAccentColor = true;
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // tpSettings
            // 
            this.tpSettings.BackColor = System.Drawing.Color.White;
            this.tpSettings.Controls.Add(this.groupBox1);
            this.tpSettings.ImageKey = "outline_settings_white_24dp.png";
            this.tpSettings.Location = new System.Drawing.Point(4, 31);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1102, 502);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.cbCombineSegments);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drive Exporter";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOsmTest);
            this.groupBox4.Controls.Add(this.txtOsmPassword);
            this.groupBox4.Controls.Add(this.txtOsmUsername);
            this.groupBox4.Location = new System.Drawing.Point(6, 59);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(467, 243);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Openstreetmap API";
            // 
            // btnOsmTest
            // 
            this.btnOsmTest.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnOsmTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOsmTest.AutoSize = false;
            this.btnOsmTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOsmTest.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOsmTest.Depth = 0;
            this.btnOsmTest.HighEmphasis = true;
            this.btnOsmTest.Icon = null;
            this.btnOsmTest.Location = new System.Drawing.Point(7, 135);
            this.btnOsmTest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOsmTest.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOsmTest.Name = "btnOsmTest";
            this.btnOsmTest.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnOsmTest.Size = new System.Drawing.Size(453, 36);
            this.btnOsmTest.TabIndex = 2;
            this.btnOsmTest.Text = "&Test";
            this.btnOsmTest.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOsmTest.UseAccentColor = true;
            this.btnOsmTest.UseVisualStyleBackColor = true;
            this.btnOsmTest.Click += new System.EventHandler(this.btnOsmTest_Click);
            // 
            // txtOsmPassword
            // 
            this.txtOsmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOsmPassword.AnimateReadOnly = false;
            this.txtOsmPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtOsmPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtOsmPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtOsmPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOsmPassword.Depth = 0;
            this.txtOsmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtOsmPassword.HideSelection = true;
            this.txtOsmPassword.Hint = "Password";
            this.txtOsmPassword.LeadingIcon = null;
            this.txtOsmPassword.Location = new System.Drawing.Point(6, 78);
            this.txtOsmPassword.MaxLength = 50;
            this.txtOsmPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtOsmPassword.Name = "txtOsmPassword";
            this.txtOsmPassword.PasswordChar = '●';
            this.txtOsmPassword.PrefixSuffixText = null;
            this.txtOsmPassword.ReadOnly = false;
            this.txtOsmPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOsmPassword.SelectedText = "";
            this.txtOsmPassword.SelectionLength = 0;
            this.txtOsmPassword.SelectionStart = 0;
            this.txtOsmPassword.ShortcutsEnabled = true;
            this.txtOsmPassword.Size = new System.Drawing.Size(455, 48);
            this.txtOsmPassword.TabIndex = 1;
            this.txtOsmPassword.TabStop = false;
            this.txtOsmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOsmPassword.TrailingIcon = null;
            this.txtOsmPassword.UseSystemPasswordChar = true;
            // 
            // txtOsmUsername
            // 
            this.txtOsmUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOsmUsername.AnimateReadOnly = false;
            this.txtOsmUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtOsmUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtOsmUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtOsmUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtOsmUsername.Depth = 0;
            this.txtOsmUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtOsmUsername.HideSelection = true;
            this.txtOsmUsername.Hint = "Username";
            this.txtOsmUsername.LeadingIcon = null;
            this.txtOsmUsername.Location = new System.Drawing.Point(6, 22);
            this.txtOsmUsername.MaxLength = 50;
            this.txtOsmUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtOsmUsername.Name = "txtOsmUsername";
            this.txtOsmUsername.PasswordChar = '\0';
            this.txtOsmUsername.PrefixSuffixText = null;
            this.txtOsmUsername.ReadOnly = false;
            this.txtOsmUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtOsmUsername.SelectedText = "";
            this.txtOsmUsername.SelectionLength = 0;
            this.txtOsmUsername.SelectionStart = 0;
            this.txtOsmUsername.ShortcutsEnabled = true;
            this.txtOsmUsername.Size = new System.Drawing.Size(455, 48);
            this.txtOsmUsername.TabIndex = 0;
            this.txtOsmUsername.TabStop = false;
            this.txtOsmUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtOsmUsername.TrailingIcon = null;
            this.txtOsmUsername.UseSystemPasswordChar = false;
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
            this.cbCombineSegments.ReadOnly = false;
            this.cbCombineSegments.Ripple = true;
            this.cbCombineSegments.Size = new System.Drawing.Size(173, 37);
            this.cbCombineSegments.TabIndex = 0;
            this.cbCombineSegments.Text = "Combine Segments";
            this.cbCombineSegments.UseVisualStyleBackColor = true;
            this.cbCombineSegments.CheckedChanged += new System.EventHandler(this.cbCombineSegments_CheckedChanged);
            // 
            // tpLogFile
            // 
            this.tpLogFile.BackColor = System.Drawing.Color.White;
            this.tpLogFile.Controls.Add(this.txtLog);
            this.tpLogFile.ImageKey = "outline_description_white_24dp.png";
            this.tpLogFile.Location = new System.Drawing.Point(4, 31);
            this.tpLogFile.Name = "tpLogFile";
            this.tpLogFile.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogFile.Size = new System.Drawing.Size(1102, 502);
            this.tpLogFile.TabIndex = 2;
            this.tpLogFile.Text = "Log";
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
            this.txtLog.Size = new System.Drawing.Size(1096, 496);
            this.txtLog.TabIndex = 2;
            this.txtLog.Text = "";
            // 
            // tpExplore
            // 
            this.tpExplore.BackColor = System.Drawing.Color.White;
            this.tpExplore.Controls.Add(this.panel1);
            this.tpExplore.ImageKey = "outline_folder_open_white_24dp.png";
            this.tpExplore.Location = new System.Drawing.Point(4, 31);
            this.tpExplore.Name = "tpExplore";
            this.tpExplore.Padding = new System.Windows.Forms.Padding(3);
            this.tpExplore.Size = new System.Drawing.Size(1102, 502);
            this.tpExplore.TabIndex = 3;
            this.tpExplore.Text = "Explorer";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 496);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.Controls.Add(this.tlpExplorerTasks, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1096, 496);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tlpExplorerTasks
            // 
            this.tlpExplorerTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpExplorerTasks.AutoScroll = true;
            this.tlpExplorerTasks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpExplorerTasks.ColumnCount = 1;
            this.tlpExplorerTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpExplorerTasks.Location = new System.Drawing.Point(900, 3);
            this.tlpExplorerTasks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpExplorerTasks.Name = "tlpExplorerTasks";
            this.tlpExplorerTasks.RowCount = 1;
            this.tlpExplorerTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpExplorerTasks.Size = new System.Drawing.Size(192, 490);
            this.tlpExplorerTasks.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtWorkingDirectory);
            this.panel3.Controls.Add(this.dgvExplorer);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(890, 490);
            this.panel3.TabIndex = 0;
            // 
            // txtWorkingDirectory
            // 
            this.txtWorkingDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkingDirectory.AnimateReadOnly = false;
            this.txtWorkingDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWorkingDirectory.Depth = 0;
            this.txtWorkingDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtWorkingDirectory.Hint = "Working Directory";
            this.txtWorkingDirectory.LeadingIcon = null;
            this.txtWorkingDirectory.Location = new System.Drawing.Point(3, 3);
            this.txtWorkingDirectory.MaxLength = 50;
            this.txtWorkingDirectory.MouseState = MaterialSkin.MouseState.OUT;
            this.txtWorkingDirectory.Multiline = false;
            this.txtWorkingDirectory.Name = "txtWorkingDirectory";
            this.txtWorkingDirectory.Size = new System.Drawing.Size(884, 50);
            this.txtWorkingDirectory.TabIndex = 0;
            this.txtWorkingDirectory.Text = "Current Directory";
            this.txtWorkingDirectory.TrailingIcon = null;
            // 
            // dgvExplorer
            // 
            this.dgvExplorer.AllowDrop = true;
            this.dgvExplorer.AllowUserToAddRows = false;
            this.dgvExplorer.AllowUserToDeleteRows = false;
            this.dgvExplorer.AllowUserToOrderColumns = true;
            this.dgvExplorer.AllowUserToResizeRows = false;
            this.dgvExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExplorer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvExplorer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExplorer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvExplorer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Custom;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExplorer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvExplorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExplorer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colSize,
            this.colType,
            this.colChanged});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExplorer.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvExplorer.Depth = 0;
            this.dgvExplorer.EnableHeadersVisualStyles = false;
            this.dgvExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvExplorer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvExplorer.Location = new System.Drawing.Point(3, 59);
            this.dgvExplorer.MouseState = MaterialSkin.MouseState.HOVER;
            this.dgvExplorer.Name = "dgvExplorer";
            this.dgvExplorer.ReadOnly = true;
            this.dgvExplorer.RowHeadersVisible = false;
            this.dgvExplorer.RowTemplate.Height = 25;
            this.dgvExplorer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExplorer.ShowCellToolTips = false;
            this.dgvExplorer.Size = new System.Drawing.Size(884, 428);
            this.dgvExplorer.TabIndex = 1;
            this.dgvExplorer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExplorer_CellDoubleClick);
            this.dgvExplorer.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvExplorer_CellFormatting);
            this.dgvExplorer.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvExplorer_DragDrop);
            this.dgvExplorer.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvExplorer_DragEnter);
            this.dgvExplorer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvExplorer_KeyDown);
            this.dgvExplorer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvExplorer_KeyPress);
            this.dgvExplorer.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvExplorer_PreviewKeyDown);
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
            this.colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSize.DataPropertyName = "Attributes.Size";
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colType.DataPropertyName = "Attributes.IsDirectory";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 123;
            // 
            // colChanged
            // 
            this.colChanged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colChanged.DataPropertyName = "LastWriteTimeUTC";
            this.colChanged.HeaderText = "Changed";
            this.colChanged.Name = "colChanged";
            this.colChanged.ReadOnly = true;
            this.colChanged.Width = 163;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AnimateReadOnly = false;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Depth = 0;
            this.txtSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.Hint = "Search";
            this.txtSearch.LeadingIcon = null;
            this.txtSearch.Location = new System.Drawing.Point(678, 3);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(209, 50);
            this.txtSearch.TabIndex = 28;
            this.txtSearch.Text = "";
            this.txtSearch.TrailingIcon = null;
            this.txtSearch.Visible = false;
            // 
            // tpFingerprint
            // 
            this.tpFingerprint.BackColor = System.Drawing.Color.White;
            this.tpFingerprint.Controls.Add(this.txtFingerprint);
            this.tpFingerprint.ImageKey = "outline_fingerprint_white_24dp.png";
            this.tpFingerprint.Location = new System.Drawing.Point(4, 31);
            this.tpFingerprint.Name = "tpFingerprint";
            this.tpFingerprint.Padding = new System.Windows.Forms.Padding(3);
            this.tpFingerprint.Size = new System.Drawing.Size(1102, 502);
            this.tpFingerprint.TabIndex = 4;
            this.tpFingerprint.Text = "Fingerprint";
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
            this.txtFingerprint.Size = new System.Drawing.Size(1096, 496);
            this.txtFingerprint.TabIndex = 3;
            this.txtFingerprint.Text = "";
            // 
            // tpSSH
            // 
            this.tpSSH.BackColor = System.Drawing.Color.White;
            this.tpSSH.Controls.Add(this.ucSshWizard);
            this.tpSSH.ImageKey = "outline_ssh_black_24dp.png";
            this.tpSSH.Location = new System.Drawing.Point(4, 31);
            this.tpSSH.Name = "tpSSH";
            this.tpSSH.Padding = new System.Windows.Forms.Padding(3);
            this.tpSSH.Size = new System.Drawing.Size(1102, 502);
            this.tpSSH.TabIndex = 5;
            this.tpSSH.Text = "SSH Wizard";
            // 
            // ucSshWizard
            // 
            this.ucSshWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSshWizard.Location = new System.Drawing.Point(3, 3);
            this.ucSshWizard.Name = "ucSshWizard";
            this.ucSshWizard.Size = new System.Drawing.Size(1096, 496);
            this.ucSshWizard.TabIndex = 1;
            this.ucSshWizard.WizardCompleted += new System.EventHandler(this.ucSshWizard_WizardCompleted);
            // 
            // tpFork
            // 
            this.tpFork.BackColor = System.Drawing.Color.White;
            this.tpFork.Controls.Add(this.txtForkBranch);
            this.tpFork.Controls.Add(this.txtForkUsername);
            this.tpFork.Controls.Add(this.btnInstallFork);
            this.tpFork.ImageKey = "git_fork_black.png";
            this.tpFork.Location = new System.Drawing.Point(4, 31);
            this.tpFork.Name = "tpFork";
            this.tpFork.Size = new System.Drawing.Size(1102, 502);
            this.tpFork.TabIndex = 9;
            this.tpFork.Text = "Fork Installer";
            // 
            // txtForkBranch
            // 
            this.txtForkBranch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtForkBranch.AnimateReadOnly = false;
            this.txtForkBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtForkBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtForkBranch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtForkBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtForkBranch.Depth = 0;
            this.txtForkBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtForkBranch.HideSelection = true;
            this.txtForkBranch.Hint = "Branch Name";
            this.txtForkBranch.LeadingIcon = null;
            this.txtForkBranch.Location = new System.Drawing.Point(375, 232);
            this.txtForkBranch.MaxLength = 50;
            this.txtForkBranch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtForkBranch.Name = "txtForkBranch";
            this.txtForkBranch.PasswordChar = '\0';
            this.txtForkBranch.PrefixSuffixText = null;
            this.txtForkBranch.ReadOnly = false;
            this.txtForkBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtForkBranch.SelectedText = "";
            this.txtForkBranch.SelectionLength = 0;
            this.txtForkBranch.SelectionStart = 0;
            this.txtForkBranch.ShortcutsEnabled = true;
            this.txtForkBranch.Size = new System.Drawing.Size(341, 48);
            this.txtForkBranch.TabIndex = 33;
            this.txtForkBranch.TabStop = false;
            this.txtForkBranch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtForkBranch.TrailingIcon = null;
            this.txtForkBranch.UseSystemPasswordChar = false;
            // 
            // txtForkUsername
            // 
            this.txtForkUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtForkUsername.AnimateReadOnly = false;
            this.txtForkUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtForkUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtForkUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtForkUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtForkUsername.Depth = 0;
            this.txtForkUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtForkUsername.HideSelection = true;
            this.txtForkUsername.Hint = "Fork Username";
            this.txtForkUsername.LeadingIcon = null;
            this.txtForkUsername.Location = new System.Drawing.Point(375, 176);
            this.txtForkUsername.MaxLength = 50;
            this.txtForkUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtForkUsername.Name = "txtForkUsername";
            this.txtForkUsername.PasswordChar = '\0';
            this.txtForkUsername.PrefixSuffixText = null;
            this.txtForkUsername.ReadOnly = false;
            this.txtForkUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtForkUsername.SelectedText = "";
            this.txtForkUsername.SelectionLength = 0;
            this.txtForkUsername.SelectionStart = 0;
            this.txtForkUsername.ShortcutsEnabled = true;
            this.txtForkUsername.Size = new System.Drawing.Size(341, 48);
            this.txtForkUsername.TabIndex = 32;
            this.txtForkUsername.TabStop = false;
            this.txtForkUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtForkUsername.TrailingIcon = null;
            this.txtForkUsername.UseSystemPasswordChar = false;
            this.txtForkUsername.Leave += new System.EventHandler(this.txtForkUsername_Leave);
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
            this.btnInstallFork.Location = new System.Drawing.Point(375, 291);
            this.btnInstallFork.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnInstallFork.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnInstallFork.Name = "btnInstallFork";
            this.btnInstallFork.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnInstallFork.Size = new System.Drawing.Size(341, 36);
            this.btnInstallFork.TabIndex = 34;
            this.btnInstallFork.Text = "&Install";
            this.btnInstallFork.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnInstallFork.UseAccentColor = true;
            this.btnInstallFork.UseVisualStyleBackColor = true;
            this.btnInstallFork.Click += new System.EventHandler(this.btnInstallFork_Click);
            // 
            // tpFlash
            // 
            this.tpFlash.BackColor = System.Drawing.Color.White;
            this.tpFlash.ImageKey = "outline_flash_on_white_24dp.png";
            this.tpFlash.Location = new System.Drawing.Point(4, 31);
            this.tpFlash.Name = "tpFlash";
            this.tpFlash.Padding = new System.Windows.Forms.Padding(3);
            this.tpFlash.Size = new System.Drawing.Size(1102, 502);
            this.tpFlash.TabIndex = 6;
            this.tpFlash.Text = "Flash Wizard";
            // 
            // tpShell
            // 
            this.tpShell.BackColor = System.Drawing.Color.White;
            this.tpShell.Controls.Add(this.tableLayoutPanel1);
            this.tpShell.ImageKey = "outline_console_black_24dp.png";
            this.tpShell.Location = new System.Drawing.Point(4, 31);
            this.tpShell.Name = "tpShell";
            this.tpShell.Padding = new System.Windows.Forms.Padding(3);
            this.tpShell.Size = new System.Drawing.Size(1102, 502);
            this.tpShell.TabIndex = 10;
            this.tpShell.Text = "Terminal";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1096, 496);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnTmuxEndScroll);
            this.panel4.Controls.Add(this.btnTmuxScroll);
            this.panel4.Controls.Add(this.btnTmux);
            this.panel4.Controls.Add(this.btnExitTmux);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(895, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(198, 490);
            this.panel4.TabIndex = 0;
            // 
            // btnTmuxEndScroll
            // 
            this.btnTmuxEndScroll.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnTmuxEndScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTmuxEndScroll.AutoSize = false;
            this.btnTmuxEndScroll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTmuxEndScroll.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTmuxEndScroll.Depth = 0;
            this.btnTmuxEndScroll.HighEmphasis = true;
            this.btnTmuxEndScroll.Icon = null;
            this.btnTmuxEndScroll.Location = new System.Drawing.Point(0, 150);
            this.btnTmuxEndScroll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTmuxEndScroll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTmuxEndScroll.Name = "btnTmuxEndScroll";
            this.btnTmuxEndScroll.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnTmuxEndScroll.Size = new System.Drawing.Size(194, 36);
            this.btnTmuxEndScroll.TabIndex = 28;
            this.btnTmuxEndScroll.Text = "TMUX End SCROLL";
            this.btnTmuxEndScroll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTmuxEndScroll.UseAccentColor = true;
            this.btnTmuxEndScroll.UseVisualStyleBackColor = true;
            this.btnTmuxEndScroll.Click += new System.EventHandler(this.btnTmuxEndScroll_Click);
            // 
            // btnTmuxScroll
            // 
            this.btnTmuxScroll.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnTmuxScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTmuxScroll.AutoSize = false;
            this.btnTmuxScroll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTmuxScroll.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTmuxScroll.Depth = 0;
            this.btnTmuxScroll.HighEmphasis = true;
            this.btnTmuxScroll.Icon = null;
            this.btnTmuxScroll.Location = new System.Drawing.Point(0, 102);
            this.btnTmuxScroll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTmuxScroll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTmuxScroll.Name = "btnTmuxScroll";
            this.btnTmuxScroll.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnTmuxScroll.Size = new System.Drawing.Size(194, 36);
            this.btnTmuxScroll.TabIndex = 27;
            this.btnTmuxScroll.Text = "TMUX Start SCROLL";
            this.btnTmuxScroll.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTmuxScroll.UseAccentColor = true;
            this.btnTmuxScroll.UseVisualStyleBackColor = true;
            this.btnTmuxScroll.Click += new System.EventHandler(this.btnTmuxScroll_Click);
            // 
            // btnTmux
            // 
            this.btnTmux.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnTmux.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTmux.AutoSize = false;
            this.btnTmux.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTmux.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTmux.Depth = 0;
            this.btnTmux.HighEmphasis = true;
            this.btnTmux.Icon = null;
            this.btnTmux.Location = new System.Drawing.Point(1, 6);
            this.btnTmux.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTmux.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTmux.Name = "btnTmux";
            this.btnTmux.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnTmux.Size = new System.Drawing.Size(196, 36);
            this.btnTmux.TabIndex = 25;
            this.btnTmux.Text = "Start TMUX";
            this.btnTmux.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTmux.UseAccentColor = true;
            this.btnTmux.UseVisualStyleBackColor = true;
            this.btnTmux.Click += new System.EventHandler(this.btnTmux_Click);
            // 
            // btnExitTmux
            // 
            this.btnExitTmux.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnExitTmux.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitTmux.AutoSize = false;
            this.btnExitTmux.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExitTmux.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExitTmux.Depth = 0;
            this.btnExitTmux.HighEmphasis = true;
            this.btnExitTmux.Icon = null;
            this.btnExitTmux.Location = new System.Drawing.Point(1, 54);
            this.btnExitTmux.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExitTmux.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExitTmux.Name = "btnExitTmux";
            this.btnExitTmux.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnExitTmux.Size = new System.Drawing.Size(194, 36);
            this.btnExitTmux.TabIndex = 26;
            this.btnExitTmux.Text = "Exit Tmux";
            this.btnExitTmux.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExitTmux.UseAccentColor = true;
            this.btnExitTmux.UseVisualStyleBackColor = true;
            this.btnExitTmux.Click += new System.EventHandler(this.btnExitTmux_Click);
            // 
            // tpDonate
            // 
            this.tpDonate.BackColor = System.Drawing.Color.White;
            this.tpDonate.Controls.Add(this.label1);
            this.tpDonate.Controls.Add(this.btnPaypal);
            this.tpDonate.Controls.Add(this.btnKofi);
            this.tpDonate.Controls.Add(this.btnBuyMeCoffee);
            this.tpDonate.ImageKey = "outline_favorite_white_24dp.png";
            this.tpDonate.Location = new System.Drawing.Point(4, 31);
            this.tpDonate.Name = "tpDonate";
            this.tpDonate.Padding = new System.Windows.Forms.Padding(3);
            this.tpDonate.Size = new System.Drawing.Size(1102, 502);
            this.tpDonate.TabIndex = 8;
            this.tpDonate.Text = "Donate";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1078, 109);
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
            this.btnPaypal.Location = new System.Drawing.Point(507, 233);
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
            this.btnKofi.Location = new System.Drawing.Point(513, 185);
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
            this.btnBuyMeCoffee.Location = new System.Drawing.Point(473, 281);
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
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.flpColours);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1102, 502);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "tabPage1";
            // 
            // flpColours
            // 
            this.flpColours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpColours.Location = new System.Drawing.Point(3, 3);
            this.flpColours.Name = "flpColours";
            this.flpColours.Size = new System.Drawing.Size(1096, 496);
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
            this.themePanel.Controls.Add(this.btnScan);
            this.themePanel.Controls.Add(this.cmbDevices);
            this.themePanel.Controls.Add(this.lblActiveDevice);
            this.themePanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.themePanel.Location = new System.Drawing.Point(244, 24);
            this.themePanel.Name = "themePanel";
            this.themePanel.Size = new System.Drawing.Size(869, 40);
            this.themePanel.TabIndex = 0;
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
            this.wifiConnected.Location = new System.Drawing.Point(739, 2);
            this.wifiConnected.Margin = new System.Windows.Forms.Padding(2);
            this.wifiConnected.MouseState = MaterialSkin.MouseState.HOVER;
            this.wifiConnected.Name = "wifiConnected";
            this.wifiConnected.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.wifiConnected.Size = new System.Drawing.Size(40, 36);
            this.wifiConnected.TabIndex = 2;
            this.wifiConnected.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.wifiConnected.UseAccentColor = false;
            this.wifiConnected.UseVisualStyleBackColor = true;
            // 
            // cmbDevices
            // 
            this.cmbDevices.AutoResize = false;
            this.cmbDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbDevices.Depth = 0;
            this.cmbDevices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbDevices.DropDownHeight = 118;
            this.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevices.DropDownWidth = 121;
            this.cmbDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbDevices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Hint = "Openpilot Device";
            this.cmbDevices.IntegralHeight = false;
            this.cmbDevices.ItemHeight = 29;
            this.cmbDevices.Location = new System.Drawing.Point(287, 3);
            this.cmbDevices.MaxDropDownItems = 4;
            this.cmbDevices.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(266, 35);
            this.cmbDevices.StartIndex = 0;
            this.cmbDevices.TabIndex = 0;
            this.cmbDevices.UseTallSize = false;
            this.cmbDevices.SelectedIndexChanged += new System.EventHandler(this.cmbDevices_SelectedIndexChanged);
            // 
            // lblActiveDevice
            // 
            this.lblActiveDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblActiveDevice.ForeColor = System.Drawing.Color.White;
            this.lblActiveDevice.Location = new System.Drawing.Point(124, 0);
            this.lblActiveDevice.Name = "lblActiveDevice";
            this.lblActiveDevice.Size = new System.Drawing.Size(157, 37);
            this.lblActiveDevice.TabIndex = 35;
            this.lblActiveDevice.Text = "ACTIVE DEVICE:";
            this.lblActiveDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OpenpilotToolkitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 604);
            this.Controls.Add(this.tcSettings);
            this.Controls.Add(this.themePanel);
            this.DrawerAutoHide = false;
            this.DrawerBackgroundWithAccent = true;
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.tcSettings;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1116, 604);
            this.Name = "OpenpilotToolkitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OPENPILOT TOOLKIT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportDrivesForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OpenpilotToolkitForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.tcSettings.ResumeLayout(false);
            this.tpExport.ResumeLayout(false);
            this.tpExport.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriveInfo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tpRemote.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tpLogFile.ResumeLayout(false);
            this.tpExplore.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExplorer)).EndInit();
            this.tpFingerprint.ResumeLayout(false);
            this.tpSSH.ResumeLayout(false);
            this.tpFork.ResumeLayout(false);
            this.tpShell.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tpDonate.ResumeLayout(false);
            this.tpDonate.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.themePanel.ResumeLayout(false);
            this.themePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDrives;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.FolderBrowserDialog fbdExportFolder;
        private MaterialButton btnBrowse;
        private MaterialButton btnRefreshVideos;
        private MaterialButton btnExportMapillary;
        private MaterialButton btnExportGpx;
        private MaterialButton btnExport;
        private MaterialButton btnScan;
        private MaterialSkin.Controls.MaterialTextBox txtExportFolder;
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
        private ucSshWizard ucSshWizard;
        private MaterialTextBox txtWorkingDirectory;
        private MaterialTextBox txtSearch;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flpColours;
        private Controls.MaterialSkinDataGridView dgvExplorer;
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
        private MaterialTextBox2 txtForkBranch;
        private MaterialTextBox2 txtForkUsername;
        private MaterialButton btnInstallFork;
        private System.Windows.Forms.TabPage tpShell;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tpRemote;
        private MaterialButton btnFlashPanda;
        private MaterialButton btnCloseSettings;
        private MaterialButton btnOpenSettings;
        private MaterialButton btnShutdown;
        private MaterialButton btnReboot;
        private MaterialComboBox cmbDevices;
        private System.Windows.Forms.Label lblActiveDevice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialCheckbox cbFrontCamera;
        private MaterialCheckbox cbDriverCamera;
        private MaterialCheckbox cbWideCamera;
        private MaterialButton materialButton1;
        private MaterialButton btnUpdate;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.MaterialSkinDataGridView dgvDriveInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private MaterialButton btnDeleteDrives;
        private System.Windows.Forms.GroupBox groupBox4;
        private MaterialTextBox2 txtOsmPassword;
        private MaterialTextBox2 txtOsmUsername;
        private MaterialButton btnOsmUpload;
        private MaterialButton btnOsmTest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tlpExplorerTasks;
        private System.Windows.Forms.Panel panel4;
        private MaterialButton btnTmux;
        private MaterialButton btnExitTmux;
        private MaterialButton btnTmuxScroll;
        private MaterialButton btnTmuxEndScroll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChanged;
    }
}

