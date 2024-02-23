
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenpilotToolkitForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            lbDrives = new System.Windows.Forms.ListBox();
            fbdExportFolder = new System.Windows.Forms.FolderBrowserDialog();
            btnBrowse = new MaterialButton();
            btnRefreshVideos = new MaterialButton();
            btnExportMapillary = new MaterialButton();
            btnExportGpx = new MaterialButton();
            btnExport = new MaterialButton();
            btnScan = new MaterialButton();
            txtExportFolder = new MaterialTextBox();
            adbConnected = new MaterialButton();
            ilTabs = new System.Windows.Forms.ImageList(components);
            themeButton = new MaterialButton();
            tcSettings = new MaterialTabControl();
            tpExport = new System.Windows.Forms.TabPage();
            tlpTasks = new System.Windows.Forms.TableLayoutPanel();
            groupBox3 = new System.Windows.Forms.GroupBox();
            dgvDriveInfo = new Controls.MaterialSkinDataGridView();
            colProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            groupBox2 = new System.Windows.Forms.GroupBox();
            cbFrontCamera = new MaterialCheckbox();
            cbDriverCamera = new MaterialCheckbox();
            cbWideCamera = new MaterialCheckbox();
            panel2 = new System.Windows.Forms.Panel();
            btnOsmUpload = new MaterialButton();
            btnDeleteDrives = new MaterialButton();
            flyleafVideoPlayer1 = new Controls.Media.FlyleafVideoPlayer();
            tpRemote = new System.Windows.Forms.TabPage();
            btnUpdate = new MaterialButton();
            materialButton1 = new MaterialButton();
            btnCloseSettings = new MaterialButton();
            btnFlashPanda = new MaterialButton();
            btnOpenSettings = new MaterialButton();
            btnShutdown = new MaterialButton();
            btnReboot = new MaterialButton();
            tpSettings = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            btnOsmTest = new MaterialButton();
            txtOsmPassword = new MaterialTextBox2();
            txtOsmUsername = new MaterialTextBox2();
            cbCombineSegments = new MaterialCheckbox();
            tpLogFile = new System.Windows.Forms.TabPage();
            txtLog = new MaterialMultiLineTextBox();
            tpExplore = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            tlpExplorerTasks = new System.Windows.Forms.TableLayoutPanel();
            panel3 = new System.Windows.Forms.Panel();
            txtWorkingDirectory = new MaterialTextBox();
            dgvExplorer = new Controls.MaterialSkinDataGridView();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            txtSearch = new MaterialTextBox();
            tpFingerprint = new System.Windows.Forms.TabPage();
            txtFingerprint = new MaterialMultiLineTextBox();
            tpSSH = new System.Windows.Forms.TabPage();
            ucSshWizard = new ucSshWizard();
            tpFork = new System.Windows.Forms.TabPage();
            txtRepositoryName = new MaterialTextBox2();
            txtForkBranch = new MaterialTextBox2();
            txtForkUsername = new MaterialTextBox2();
            btnInstallFork = new MaterialButton();
            tpFlash = new System.Windows.Forms.TabPage();
            tpShell = new System.Windows.Forms.TabPage();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel4 = new System.Windows.Forms.Panel();
            btnTmuxEndScroll = new MaterialButton();
            btnTmuxScroll = new MaterialButton();
            btnTmux = new MaterialButton();
            btnExitTmux = new MaterialButton();
            tpDonate = new System.Windows.Forms.TabPage();
            label1 = new System.Windows.Forms.Label();
            btnPaypal = new MaterialButton();
            btnKofi = new MaterialButton();
            btnBuyMeCoffee = new MaterialButton();
            tabPage1 = new System.Windows.Forms.TabPage();
            flpColours = new System.Windows.Forms.FlowLayoutPanel();
            tabPage8 = new System.Windows.Forms.TabPage();
            themePanel = new System.Windows.Forms.FlowLayoutPanel();
            wifiConnected = new MaterialButton();
            cmbDevices = new MaterialComboBox();
            lblActiveDevice = new System.Windows.Forms.Label();
            tcSettings.SuspendLayout();
            tpExport.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDriveInfo).BeginInit();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            tpRemote.SuspendLayout();
            tpSettings.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            tpLogFile.SuspendLayout();
            tpExplore.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExplorer).BeginInit();
            tpFingerprint.SuspendLayout();
            tpSSH.SuspendLayout();
            tpFork.SuspendLayout();
            tpShell.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            tpDonate.SuspendLayout();
            tabPage1.SuspendLayout();
            themePanel.SuspendLayout();
            SuspendLayout();
            // 
            // lbDrives
            // 
            lbDrives.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lbDrives.FormattingEnabled = true;
            lbDrives.ItemHeight = 15;
            lbDrives.Location = new System.Drawing.Point(217, 123);
            lbDrives.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lbDrives.Name = "lbDrives";
            lbDrives.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            lbDrives.Size = new System.Drawing.Size(143, 364);
            lbDrives.TabIndex = 4;
            lbDrives.SelectedIndexChanged += lbDrives_SelectedIndexChanged;
            lbDrives.PreviewKeyDown += lbDrives_PreviewKeyDown;
            // 
            // btnBrowse
            // 
            btnBrowse.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnBrowse.Density = MaterialButton.MaterialButtonDensity.Default;
            btnBrowse.Depth = 0;
            btnBrowse.HighEmphasis = true;
            btnBrowse.Icon = null;
            btnBrowse.Location = new System.Drawing.Point(1006, 9);
            btnBrowse.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            btnBrowse.Name = "btnBrowse";
            btnBrowse.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnBrowse.Size = new System.Drawing.Size(89, 36);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "&Browse";
            btnBrowse.Type = MaterialButton.MaterialButtonType.Contained;
            btnBrowse.UseAccentColor = true;
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnRefreshVideos
            // 
            btnRefreshVideos.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnRefreshVideos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnRefreshVideos.AutoSize = false;
            btnRefreshVideos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnRefreshVideos.Density = MaterialButton.MaterialButtonDensity.Default;
            btnRefreshVideos.Depth = 0;
            btnRefreshVideos.HighEmphasis = true;
            btnRefreshVideos.Icon = null;
            btnRefreshVideos.Location = new System.Drawing.Point(4, 6);
            btnRefreshVideos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnRefreshVideos.MouseState = MaterialSkin.MouseState.HOVER;
            btnRefreshVideos.Name = "btnRefreshVideos";
            btnRefreshVideos.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnRefreshVideos.Size = new System.Drawing.Size(196, 36);
            btnRefreshVideos.TabIndex = 0;
            btnRefreshVideos.Text = "&Refresh Drive List";
            btnRefreshVideos.Type = MaterialButton.MaterialButtonType.Contained;
            btnRefreshVideos.UseAccentColor = true;
            btnRefreshVideos.UseVisualStyleBackColor = true;
            btnRefreshVideos.Click += btnRefreshVideos_Click;
            // 
            // btnExportMapillary
            // 
            btnExportMapillary.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnExportMapillary.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnExportMapillary.AutoSize = false;
            btnExportMapillary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnExportMapillary.Density = MaterialButton.MaterialButtonDensity.Default;
            btnExportMapillary.Depth = 0;
            btnExportMapillary.Enabled = false;
            btnExportMapillary.HighEmphasis = true;
            btnExportMapillary.Icon = null;
            btnExportMapillary.Location = new System.Drawing.Point(4, 246);
            btnExportMapillary.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnExportMapillary.MouseState = MaterialSkin.MouseState.HOVER;
            btnExportMapillary.Name = "btnExportMapillary";
            btnExportMapillary.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnExportMapillary.Size = new System.Drawing.Size(194, 36);
            btnExportMapillary.TabIndex = 5;
            btnExportMapillary.Text = "&Mapillary Export";
            btnExportMapillary.Type = MaterialButton.MaterialButtonType.Contained;
            btnExportMapillary.UseAccentColor = true;
            btnExportMapillary.UseVisualStyleBackColor = true;
            btnExportMapillary.Click += btnExportMapillary_Click;
            // 
            // btnExportGpx
            // 
            btnExportGpx.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnExportGpx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnExportGpx.AutoSize = false;
            btnExportGpx.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnExportGpx.Density = MaterialButton.MaterialButtonDensity.Default;
            btnExportGpx.Depth = 0;
            btnExportGpx.HighEmphasis = true;
            btnExportGpx.Icon = null;
            btnExportGpx.Location = new System.Drawing.Point(4, 150);
            btnExportGpx.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnExportGpx.MouseState = MaterialSkin.MouseState.HOVER;
            btnExportGpx.Name = "btnExportGpx";
            btnExportGpx.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnExportGpx.Size = new System.Drawing.Size(194, 36);
            btnExportGpx.TabIndex = 3;
            btnExportGpx.Text = "&GPX Export";
            btnExportGpx.Type = MaterialButton.MaterialButtonType.Contained;
            btnExportGpx.UseAccentColor = true;
            btnExportGpx.UseVisualStyleBackColor = true;
            btnExportGpx.Click += btnExportGpx_Click;
            // 
            // btnExport
            // 
            btnExport.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnExport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnExport.AutoSize = false;
            btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnExport.Density = MaterialButton.MaterialButtonDensity.Default;
            btnExport.Depth = 0;
            btnExport.HighEmphasis = true;
            btnExport.Icon = null;
            btnExport.Location = new System.Drawing.Point(4, 54);
            btnExport.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnExport.MouseState = MaterialSkin.MouseState.HOVER;
            btnExport.Name = "btnExport";
            btnExport.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnExport.Size = new System.Drawing.Size(194, 36);
            btnExport.TabIndex = 1;
            btnExport.Text = "&Export Selected Drive(s)";
            btnExport.Type = MaterialButton.MaterialButtonType.Contained;
            btnExport.UseAccentColor = true;
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnScan
            // 
            btnScan.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnScan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnScan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnScan.Density = MaterialButton.MaterialButtonDensity.Dense;
            btnScan.Depth = 0;
            btnScan.HighEmphasis = true;
            btnScan.Icon = null;
            btnScan.Location = new System.Drawing.Point(558, 2);
            btnScan.Margin = new System.Windows.Forms.Padding(2);
            btnScan.MouseState = MaterialSkin.MouseState.HOVER;
            btnScan.Name = "btnScan";
            btnScan.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnScan.Size = new System.Drawing.Size(177, 36);
            btnScan.TabIndex = 1;
            btnScan.Text = "Scan For OP Devices";
            btnScan.Type = MaterialButton.MaterialButtonType.Contained;
            btnScan.UseAccentColor = false;
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // txtExportFolder
            // 
            txtExportFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtExportFolder.AnimateReadOnly = false;
            txtExportFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtExportFolder.Depth = 0;
            txtExportFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            txtExportFolder.Hint = "Export Folder";
            txtExportFolder.LeadingIcon = null;
            txtExportFolder.Location = new System.Drawing.Point(6, 6);
            txtExportFolder.MaxLength = 50;
            txtExportFolder.MouseState = MaterialSkin.MouseState.OUT;
            txtExportFolder.Multiline = false;
            txtExportFolder.Name = "txtExportFolder";
            txtExportFolder.Size = new System.Drawing.Size(1002, 50);
            txtExportFolder.TabIndex = 0;
            txtExportFolder.Text = "C:\\Openpilot";
            txtExportFolder.TrailingIcon = null;
            txtExportFolder.DoubleClick += txtExportFolder_DoubleClick;
            // 
            // adbConnected
            // 
            adbConnected.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            adbConnected.AutoSize = false;
            adbConnected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            adbConnected.BackColor = System.Drawing.Color.Transparent;
            adbConnected.Density = MaterialButton.MaterialButtonDensity.Default;
            adbConnected.Depth = 0;
            adbConnected.DrawShadows = false;
            adbConnected.Enabled = false;
            adbConnected.HighEmphasis = true;
            adbConnected.Icon = Properties.Resources.outline_adb_white_24dp;
            adbConnected.ImageKey = "outline_adb_white_24dp.png";
            adbConnected.ImageList = ilTabs;
            adbConnected.Location = new System.Drawing.Point(783, 2);
            adbConnected.Margin = new System.Windows.Forms.Padding(2);
            adbConnected.MouseState = MaterialSkin.MouseState.HOVER;
            adbConnected.Name = "adbConnected";
            adbConnected.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            adbConnected.Size = new System.Drawing.Size(40, 36);
            adbConnected.TabIndex = 3;
            adbConnected.Type = MaterialButton.MaterialButtonType.Contained;
            adbConnected.UseAccentColor = false;
            adbConnected.UseVisualStyleBackColor = false;
            // 
            // ilTabs
            // 
            ilTabs.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilTabs.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilTabs.ImageStream");
            ilTabs.TransparentColor = System.Drawing.Color.Transparent;
            ilTabs.Images.SetKeyName(0, "outline_file_download_white_24dp.png");
            ilTabs.Images.SetKeyName(1, "outline_settings_white_24dp.png");
            ilTabs.Images.SetKeyName(2, "outline_description_white_24dp.png");
            ilTabs.Images.SetKeyName(3, "outline_folder_open_white_24dp.png");
            ilTabs.Images.SetKeyName(4, "outline_fingerprint_white_24dp.png");
            ilTabs.Images.SetKeyName(5, "outline_ssh_black_24dp.png");
            ilTabs.Images.SetKeyName(6, "outline_flash_on_white_24dp.png");
            ilTabs.Images.SetKeyName(7, "outline_adb_white_24dp.png");
            ilTabs.Images.SetKeyName(8, "outline_wifi_white_24dp.png");
            ilTabs.Images.SetKeyName(9, "outline_favorite_white_24dp.png");
            ilTabs.Images.SetKeyName(10, "git_fork_black.png");
            ilTabs.Images.SetKeyName(11, "outline_console_black_24dp.png");
            ilTabs.Images.SetKeyName(12, "outline_games_white_24dp.png");
            // 
            // themeButton
            // 
            themeButton.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            themeButton.AutoSize = false;
            themeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            themeButton.BackColor = System.Drawing.Color.Transparent;
            themeButton.Density = MaterialButton.MaterialButtonDensity.Default;
            themeButton.Depth = 0;
            themeButton.DrawShadows = false;
            themeButton.HighEmphasis = true;
            themeButton.Icon = Properties.Resources.light_mode_white;
            themeButton.Location = new System.Drawing.Point(827, 2);
            themeButton.Margin = new System.Windows.Forms.Padding(2);
            themeButton.MouseState = MaterialSkin.MouseState.HOVER;
            themeButton.Name = "themeButton";
            themeButton.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            themeButton.Size = new System.Drawing.Size(40, 36);
            themeButton.TabIndex = 4;
            themeButton.Type = MaterialButton.MaterialButtonType.Contained;
            themeButton.UseAccentColor = false;
            themeButton.UseVisualStyleBackColor = false;
            themeButton.Click += themeButton_Click;
            // 
            // tcSettings
            // 
            tcSettings.Controls.Add(tpExport);
            tcSettings.Controls.Add(tpRemote);
            tcSettings.Controls.Add(tpSettings);
            tcSettings.Controls.Add(tpLogFile);
            tcSettings.Controls.Add(tpExplore);
            tcSettings.Controls.Add(tpFingerprint);
            tcSettings.Controls.Add(tpSSH);
            tcSettings.Controls.Add(tpFork);
            tcSettings.Controls.Add(tpFlash);
            tcSettings.Controls.Add(tpShell);
            tcSettings.Controls.Add(tpDonate);
            tcSettings.Controls.Add(tabPage1);
            tcSettings.Depth = 0;
            tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            tcSettings.ImageList = ilTabs;
            tcSettings.Location = new System.Drawing.Point(3, 64);
            tcSettings.MouseState = MaterialSkin.MouseState.HOVER;
            tcSettings.Multiline = true;
            tcSettings.Name = "tcSettings";
            tcSettings.SelectedIndex = 0;
            tcSettings.Size = new System.Drawing.Size(1110, 537);
            tcSettings.TabIndex = 1;
            tcSettings.Selected += tcSettings_Selected;
            // 
            // tpExport
            // 
            tpExport.BackColor = System.Drawing.Color.White;
            tpExport.Controls.Add(tlpTasks);
            tpExport.Controls.Add(groupBox3);
            tpExport.Controls.Add(groupBox2);
            tpExport.Controls.Add(panel2);
            tpExport.Controls.Add(flyleafVideoPlayer1);
            tpExport.Controls.Add(txtExportFolder);
            tpExport.Controls.Add(lbDrives);
            tpExport.Controls.Add(btnBrowse);
            tpExport.ImageKey = "outline_file_download_white_24dp.png";
            tpExport.Location = new System.Drawing.Point(4, 31);
            tpExport.Name = "tpExport";
            tpExport.Padding = new System.Windows.Forms.Padding(3);
            tpExport.Size = new System.Drawing.Size(1102, 502);
            tpExport.TabIndex = 0;
            tpExport.Text = "Export";
            // 
            // tlpTasks
            // 
            tlpTasks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            tlpTasks.AutoScroll = true;
            tlpTasks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tlpTasks.ColumnCount = 1;
            tlpTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpTasks.Location = new System.Drawing.Point(908, 239);
            tlpTasks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tlpTasks.Name = "tlpTasks";
            tlpTasks.RowCount = 1;
            tlpTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpTasks.Size = new System.Drawing.Size(187, 257);
            tlpTasks.TabIndex = 16;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            groupBox3.Controls.Add(dgvDriveInfo);
            groupBox3.Location = new System.Drawing.Point(908, 123);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(187, 110);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Drive Info";
            // 
            // dgvDriveInfo
            // 
            dgvDriveInfo.AllowUserToAddRows = false;
            dgvDriveInfo.AllowUserToDeleteRows = false;
            dgvDriveInfo.AllowUserToResizeRows = false;
            dgvDriveInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvDriveInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDriveInfo.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dgvDriveInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvDriveInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDriveInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Custom;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(30, 0, 0, 0);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvDriveInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDriveInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDriveInfo.ColumnHeadersVisible = false;
            dgvDriveInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colProperty, colValue });
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(30, 0, 0, 0);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvDriveInfo.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDriveInfo.Depth = 0;
            dgvDriveInfo.EnableHeadersVisualStyles = false;
            dgvDriveInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvDriveInfo.GridColor = System.Drawing.Color.FromArgb(225, 225, 225);
            dgvDriveInfo.Location = new System.Drawing.Point(6, 22);
            dgvDriveInfo.MouseState = MaterialSkin.MouseState.HOVER;
            dgvDriveInfo.Name = "dgvDriveInfo";
            dgvDriveInfo.ReadOnly = true;
            dgvDriveInfo.RowHeadersVisible = false;
            dgvDriveInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvDriveInfo.ShowCellToolTips = false;
            dgvDriveInfo.Size = new System.Drawing.Size(175, 78);
            dgvDriveInfo.TabIndex = 0;
            // 
            // colProperty
            // 
            colProperty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            colProperty.DataPropertyName = "Key";
            colProperty.HeaderText = "Property";
            colProperty.Name = "colProperty";
            colProperty.ReadOnly = true;
            colProperty.Width = 5;
            // 
            // colValue
            // 
            colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colValue.DataPropertyName = "Value";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            colValue.DefaultCellStyle = dataGridViewCellStyle2;
            colValue.HeaderText = "Value";
            colValue.Name = "colValue";
            colValue.ReadOnly = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(cbFrontCamera);
            groupBox2.Controls.Add(cbDriverCamera);
            groupBox2.Controls.Add(cbWideCamera);
            groupBox2.Location = new System.Drawing.Point(217, 62);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(878, 55);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Export Camera";
            // 
            // cbFrontCamera
            // 
            cbFrontCamera.AutoSize = true;
            cbFrontCamera.Checked = true;
            cbFrontCamera.CheckState = System.Windows.Forms.CheckState.Checked;
            cbFrontCamera.Depth = 0;
            cbFrontCamera.Location = new System.Drawing.Point(3, 15);
            cbFrontCamera.Margin = new System.Windows.Forms.Padding(0);
            cbFrontCamera.MouseLocation = new System.Drawing.Point(-1, -1);
            cbFrontCamera.MouseState = MaterialSkin.MouseState.HOVER;
            cbFrontCamera.Name = "cbFrontCamera";
            cbFrontCamera.ReadOnly = false;
            cbFrontCamera.Ripple = true;
            cbFrontCamera.Size = new System.Drawing.Size(72, 37);
            cbFrontCamera.TabIndex = 0;
            cbFrontCamera.Text = "Front";
            cbFrontCamera.UseVisualStyleBackColor = true;
            // 
            // cbDriverCamera
            // 
            cbDriverCamera.AutoSize = true;
            cbDriverCamera.Depth = 0;
            cbDriverCamera.Location = new System.Drawing.Point(145, 15);
            cbDriverCamera.Margin = new System.Windows.Forms.Padding(0);
            cbDriverCamera.MouseLocation = new System.Drawing.Point(-1, -1);
            cbDriverCamera.MouseState = MaterialSkin.MouseState.HOVER;
            cbDriverCamera.Name = "cbDriverCamera";
            cbDriverCamera.ReadOnly = false;
            cbDriverCamera.Ripple = true;
            cbDriverCamera.Size = new System.Drawing.Size(76, 37);
            cbDriverCamera.TabIndex = 2;
            cbDriverCamera.Text = "Driver";
            cbDriverCamera.UseVisualStyleBackColor = true;
            // 
            // cbWideCamera
            // 
            cbWideCamera.AutoSize = true;
            cbWideCamera.Depth = 0;
            cbWideCamera.Location = new System.Drawing.Point(75, 15);
            cbWideCamera.Margin = new System.Windows.Forms.Padding(0);
            cbWideCamera.MouseLocation = new System.Drawing.Point(-1, -1);
            cbWideCamera.MouseState = MaterialSkin.MouseState.HOVER;
            cbWideCamera.Name = "cbWideCamera";
            cbWideCamera.ReadOnly = false;
            cbWideCamera.Ripple = true;
            cbWideCamera.Size = new System.Drawing.Size(70, 37);
            cbWideCamera.TabIndex = 1;
            cbWideCamera.Text = "Wide";
            cbWideCamera.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnOsmUpload);
            panel2.Controls.Add(btnDeleteDrives);
            panel2.Controls.Add(btnRefreshVideos);
            panel2.Controls.Add(btnExportMapillary);
            panel2.Controls.Add(btnExportGpx);
            panel2.Controls.Add(btnExport);
            panel2.Location = new System.Drawing.Point(6, 62);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(204, 434);
            panel2.TabIndex = 2;
            // 
            // btnOsmUpload
            // 
            btnOsmUpload.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnOsmUpload.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnOsmUpload.AutoSize = false;
            btnOsmUpload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnOsmUpload.Density = MaterialButton.MaterialButtonDensity.Default;
            btnOsmUpload.Depth = 0;
            btnOsmUpload.HighEmphasis = true;
            btnOsmUpload.Icon = null;
            btnOsmUpload.Location = new System.Drawing.Point(4, 198);
            btnOsmUpload.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnOsmUpload.MouseState = MaterialSkin.MouseState.HOVER;
            btnOsmUpload.Name = "btnOsmUpload";
            btnOsmUpload.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnOsmUpload.Size = new System.Drawing.Size(194, 36);
            btnOsmUpload.TabIndex = 4;
            btnOsmUpload.Text = "Upload GPS to &OSM";
            btnOsmUpload.Type = MaterialButton.MaterialButtonType.Contained;
            btnOsmUpload.UseAccentColor = true;
            btnOsmUpload.UseVisualStyleBackColor = true;
            btnOsmUpload.Click += btnOsmUpload_Click;
            // 
            // btnDeleteDrives
            // 
            btnDeleteDrives.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnDeleteDrives.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteDrives.AutoSize = false;
            btnDeleteDrives.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnDeleteDrives.Density = MaterialButton.MaterialButtonDensity.Default;
            btnDeleteDrives.Depth = 0;
            btnDeleteDrives.HighEmphasis = true;
            btnDeleteDrives.Icon = null;
            btnDeleteDrives.Location = new System.Drawing.Point(4, 102);
            btnDeleteDrives.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnDeleteDrives.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteDrives.Name = "btnDeleteDrives";
            btnDeleteDrives.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnDeleteDrives.Size = new System.Drawing.Size(194, 36);
            btnDeleteDrives.TabIndex = 2;
            btnDeleteDrives.Text = "&Delete Selected Drive(s)";
            btnDeleteDrives.Type = MaterialButton.MaterialButtonType.Contained;
            btnDeleteDrives.UseAccentColor = true;
            btnDeleteDrives.UseVisualStyleBackColor = true;
            btnDeleteDrives.Click += btnDeleteDrives_Click;
            // 
            // flyleafVideoPlayer1
            // 
            flyleafVideoPlayer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flyleafVideoPlayer1.Location = new System.Drawing.Point(368, 123);
            flyleafVideoPlayer1.Name = "flyleafVideoPlayer1";
            flyleafVideoPlayer1.Size = new System.Drawing.Size(532, 373);
            flyleafVideoPlayer1.TabIndex = 17;
            // 
            // tpRemote
            // 
            tpRemote.BackColor = System.Drawing.Color.White;
            tpRemote.Controls.Add(btnUpdate);
            tpRemote.Controls.Add(materialButton1);
            tpRemote.Controls.Add(btnCloseSettings);
            tpRemote.Controls.Add(btnFlashPanda);
            tpRemote.Controls.Add(btnOpenSettings);
            tpRemote.Controls.Add(btnShutdown);
            tpRemote.Controls.Add(btnReboot);
            tpRemote.ImageKey = "outline_games_white_24dp.png";
            tpRemote.Location = new System.Drawing.Point(4, 31);
            tpRemote.Name = "tpRemote";
            tpRemote.Padding = new System.Windows.Forms.Padding(3);
            tpRemote.Size = new System.Drawing.Size(1102, 502);
            tpRemote.TabIndex = 11;
            tpRemote.Text = "Remote";
            // 
            // btnUpdate
            // 
            btnUpdate.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnUpdate.AutoSize = false;
            btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnUpdate.Density = MaterialButton.MaterialButtonDensity.Default;
            btnUpdate.Depth = 0;
            btnUpdate.HighEmphasis = true;
            btnUpdate.Icon = null;
            btnUpdate.Location = new System.Drawing.Point(392, 89);
            btnUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnUpdate.Size = new System.Drawing.Size(307, 36);
            btnUpdate.TabIndex = 30;
            btnUpdate.Text = "Reinstall Openpilot";
            btnUpdate.Type = MaterialButton.MaterialButtonType.Contained;
            btnUpdate.UseAccentColor = true;
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // materialButton1
            // 
            materialButton1.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            materialButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new System.Drawing.Point(392, 377);
            materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            materialButton1.Size = new System.Drawing.Size(307, 36);
            materialButton1.TabIndex = 36;
            materialButton1.Text = "Install Emu";
            materialButton1.Type = MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = true;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click_1;
            // 
            // btnCloseSettings
            // 
            btnCloseSettings.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnCloseSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnCloseSettings.AutoSize = false;
            btnCloseSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnCloseSettings.Density = MaterialButton.MaterialButtonDensity.Default;
            btnCloseSettings.Depth = 0;
            btnCloseSettings.HighEmphasis = true;
            btnCloseSettings.Icon = null;
            btnCloseSettings.Location = new System.Drawing.Point(392, 281);
            btnCloseSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnCloseSettings.MouseState = MaterialSkin.MouseState.HOVER;
            btnCloseSettings.Name = "btnCloseSettings";
            btnCloseSettings.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnCloseSettings.Size = new System.Drawing.Size(307, 36);
            btnCloseSettings.TabIndex = 34;
            btnCloseSettings.Text = "Close Settings";
            btnCloseSettings.Type = MaterialButton.MaterialButtonType.Contained;
            btnCloseSettings.UseAccentColor = true;
            btnCloseSettings.UseVisualStyleBackColor = true;
            btnCloseSettings.Click += btnCloseSettings_Click;
            // 
            // btnFlashPanda
            // 
            btnFlashPanda.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnFlashPanda.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnFlashPanda.AutoSize = false;
            btnFlashPanda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnFlashPanda.Density = MaterialButton.MaterialButtonDensity.Default;
            btnFlashPanda.Depth = 0;
            btnFlashPanda.HighEmphasis = true;
            btnFlashPanda.Icon = null;
            btnFlashPanda.Location = new System.Drawing.Point(392, 329);
            btnFlashPanda.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnFlashPanda.MouseState = MaterialSkin.MouseState.HOVER;
            btnFlashPanda.Name = "btnFlashPanda";
            btnFlashPanda.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnFlashPanda.Size = new System.Drawing.Size(307, 36);
            btnFlashPanda.TabIndex = 35;
            btnFlashPanda.Text = "Flash Panda";
            btnFlashPanda.Type = MaterialButton.MaterialButtonType.Contained;
            btnFlashPanda.UseAccentColor = true;
            btnFlashPanda.UseVisualStyleBackColor = true;
            btnFlashPanda.Click += btnFlashPanda_Click;
            // 
            // btnOpenSettings
            // 
            btnOpenSettings.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnOpenSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnOpenSettings.AutoSize = false;
            btnOpenSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnOpenSettings.Density = MaterialButton.MaterialButtonDensity.Default;
            btnOpenSettings.Depth = 0;
            btnOpenSettings.HighEmphasis = true;
            btnOpenSettings.Icon = null;
            btnOpenSettings.Location = new System.Drawing.Point(392, 233);
            btnOpenSettings.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnOpenSettings.MouseState = MaterialSkin.MouseState.HOVER;
            btnOpenSettings.Name = "btnOpenSettings";
            btnOpenSettings.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnOpenSettings.Size = new System.Drawing.Size(307, 36);
            btnOpenSettings.TabIndex = 33;
            btnOpenSettings.Text = "Open Settings";
            btnOpenSettings.Type = MaterialButton.MaterialButtonType.Contained;
            btnOpenSettings.UseAccentColor = true;
            btnOpenSettings.UseVisualStyleBackColor = true;
            btnOpenSettings.Click += btnOpenSettings_Click;
            // 
            // btnShutdown
            // 
            btnShutdown.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnShutdown.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnShutdown.AutoSize = false;
            btnShutdown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnShutdown.Density = MaterialButton.MaterialButtonDensity.Default;
            btnShutdown.Depth = 0;
            btnShutdown.HighEmphasis = true;
            btnShutdown.Icon = null;
            btnShutdown.Location = new System.Drawing.Point(392, 185);
            btnShutdown.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnShutdown.MouseState = MaterialSkin.MouseState.HOVER;
            btnShutdown.Name = "btnShutdown";
            btnShutdown.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnShutdown.Size = new System.Drawing.Size(307, 36);
            btnShutdown.TabIndex = 32;
            btnShutdown.Text = "shutdown";
            btnShutdown.Type = MaterialButton.MaterialButtonType.Contained;
            btnShutdown.UseAccentColor = true;
            btnShutdown.UseVisualStyleBackColor = true;
            btnShutdown.Click += btnShutdown_Click;
            // 
            // btnReboot
            // 
            btnReboot.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnReboot.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnReboot.AutoSize = false;
            btnReboot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnReboot.Density = MaterialButton.MaterialButtonDensity.Default;
            btnReboot.Depth = 0;
            btnReboot.HighEmphasis = true;
            btnReboot.Icon = null;
            btnReboot.Location = new System.Drawing.Point(392, 137);
            btnReboot.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnReboot.MouseState = MaterialSkin.MouseState.HOVER;
            btnReboot.Name = "btnReboot";
            btnReboot.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnReboot.Size = new System.Drawing.Size(307, 36);
            btnReboot.TabIndex = 31;
            btnReboot.Text = "reboot";
            btnReboot.Type = MaterialButton.MaterialButtonType.Contained;
            btnReboot.UseAccentColor = true;
            btnReboot.UseVisualStyleBackColor = true;
            btnReboot.Click += materialButton1_Click;
            // 
            // tpSettings
            // 
            tpSettings.BackColor = System.Drawing.Color.White;
            tpSettings.Controls.Add(groupBox1);
            tpSettings.ImageKey = "outline_settings_white_24dp.png";
            tpSettings.Location = new System.Drawing.Point(4, 31);
            tpSettings.Name = "tpSettings";
            tpSettings.Padding = new System.Windows.Forms.Padding(3);
            tpSettings.Size = new System.Drawing.Size(1102, 502);
            tpSettings.TabIndex = 1;
            tpSettings.Text = "Settings";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(cbCombineSegments);
            groupBox1.Location = new System.Drawing.Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(479, 308);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Drive Exporter";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnOsmTest);
            groupBox4.Controls.Add(txtOsmPassword);
            groupBox4.Controls.Add(txtOsmUsername);
            groupBox4.Location = new System.Drawing.Point(6, 59);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(467, 243);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Openstreetmap API";
            // 
            // btnOsmTest
            // 
            btnOsmTest.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnOsmTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnOsmTest.AutoSize = false;
            btnOsmTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnOsmTest.Density = MaterialButton.MaterialButtonDensity.Default;
            btnOsmTest.Depth = 0;
            btnOsmTest.HighEmphasis = true;
            btnOsmTest.Icon = null;
            btnOsmTest.Location = new System.Drawing.Point(7, 135);
            btnOsmTest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnOsmTest.MouseState = MaterialSkin.MouseState.HOVER;
            btnOsmTest.Name = "btnOsmTest";
            btnOsmTest.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnOsmTest.Size = new System.Drawing.Size(453, 36);
            btnOsmTest.TabIndex = 2;
            btnOsmTest.Text = "&Test";
            btnOsmTest.Type = MaterialButton.MaterialButtonType.Contained;
            btnOsmTest.UseAccentColor = true;
            btnOsmTest.UseVisualStyleBackColor = true;
            btnOsmTest.Click += btnOsmTest_Click;
            // 
            // txtOsmPassword
            // 
            txtOsmPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtOsmPassword.AnimateReadOnly = false;
            txtOsmPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            txtOsmPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            txtOsmPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            txtOsmPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            txtOsmPassword.Depth = 0;
            txtOsmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtOsmPassword.HideSelection = true;
            txtOsmPassword.Hint = "Password";
            txtOsmPassword.LeadingIcon = null;
            txtOsmPassword.Location = new System.Drawing.Point(6, 78);
            txtOsmPassword.MaxLength = 50;
            txtOsmPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtOsmPassword.Name = "txtOsmPassword";
            txtOsmPassword.PasswordChar = '●';
            txtOsmPassword.PrefixSuffixText = null;
            txtOsmPassword.ReadOnly = false;
            txtOsmPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtOsmPassword.SelectedText = "";
            txtOsmPassword.SelectionLength = 0;
            txtOsmPassword.SelectionStart = 0;
            txtOsmPassword.ShortcutsEnabled = true;
            txtOsmPassword.Size = new System.Drawing.Size(455, 48);
            txtOsmPassword.TabIndex = 1;
            txtOsmPassword.TabStop = false;
            txtOsmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtOsmPassword.TrailingIcon = null;
            txtOsmPassword.UseSystemPasswordChar = true;
            // 
            // txtOsmUsername
            // 
            txtOsmUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtOsmUsername.AnimateReadOnly = false;
            txtOsmUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            txtOsmUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            txtOsmUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            txtOsmUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            txtOsmUsername.Depth = 0;
            txtOsmUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtOsmUsername.HideSelection = true;
            txtOsmUsername.Hint = "Username";
            txtOsmUsername.LeadingIcon = null;
            txtOsmUsername.Location = new System.Drawing.Point(6, 22);
            txtOsmUsername.MaxLength = 50;
            txtOsmUsername.MouseState = MaterialSkin.MouseState.OUT;
            txtOsmUsername.Name = "txtOsmUsername";
            txtOsmUsername.PasswordChar = '\0';
            txtOsmUsername.PrefixSuffixText = null;
            txtOsmUsername.ReadOnly = false;
            txtOsmUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtOsmUsername.SelectedText = "";
            txtOsmUsername.SelectionLength = 0;
            txtOsmUsername.SelectionStart = 0;
            txtOsmUsername.ShortcutsEnabled = true;
            txtOsmUsername.Size = new System.Drawing.Size(455, 48);
            txtOsmUsername.TabIndex = 0;
            txtOsmUsername.TabStop = false;
            txtOsmUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtOsmUsername.TrailingIcon = null;
            txtOsmUsername.UseSystemPasswordChar = false;
            // 
            // cbCombineSegments
            // 
            cbCombineSegments.AutoSize = true;
            cbCombineSegments.Depth = 0;
            cbCombineSegments.Location = new System.Drawing.Point(3, 19);
            cbCombineSegments.Margin = new System.Windows.Forms.Padding(0);
            cbCombineSegments.MouseLocation = new System.Drawing.Point(-1, -1);
            cbCombineSegments.MouseState = MaterialSkin.MouseState.HOVER;
            cbCombineSegments.Name = "cbCombineSegments";
            cbCombineSegments.ReadOnly = false;
            cbCombineSegments.Ripple = true;
            cbCombineSegments.Size = new System.Drawing.Size(173, 37);
            cbCombineSegments.TabIndex = 0;
            cbCombineSegments.Text = "Combine Segments";
            cbCombineSegments.UseVisualStyleBackColor = true;
            cbCombineSegments.CheckedChanged += cbCombineSegments_CheckedChanged;
            // 
            // tpLogFile
            // 
            tpLogFile.BackColor = System.Drawing.Color.White;
            tpLogFile.Controls.Add(txtLog);
            tpLogFile.ImageKey = "outline_description_white_24dp.png";
            tpLogFile.Location = new System.Drawing.Point(4, 31);
            tpLogFile.Name = "tpLogFile";
            tpLogFile.Padding = new System.Windows.Forms.Padding(3);
            tpLogFile.Size = new System.Drawing.Size(1102, 502);
            tpLogFile.TabIndex = 2;
            tpLogFile.Text = "Log";
            // 
            // txtLog
            // 
            txtLog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtLog.Depth = 0;
            txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtLog.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            txtLog.Location = new System.Drawing.Point(3, 3);
            txtLog.MouseState = MaterialSkin.MouseState.HOVER;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new System.Drawing.Size(1096, 496);
            txtLog.TabIndex = 2;
            txtLog.Text = "";
            // 
            // tpExplore
            // 
            tpExplore.BackColor = System.Drawing.Color.White;
            tpExplore.Controls.Add(panel1);
            tpExplore.ImageKey = "outline_folder_open_white_24dp.png";
            tpExplore.Location = new System.Drawing.Point(4, 31);
            tpExplore.Name = "tpExplore";
            tpExplore.Padding = new System.Windows.Forms.Padding(3);
            tpExplore.Size = new System.Drawing.Size(1102, 502);
            tpExplore.TabIndex = 3;
            tpExplore.Text = "Explorer";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1096, 496);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            tableLayoutPanel2.Controls.Add(tlpExplorerTasks, 1, 0);
            tableLayoutPanel2.Controls.Add(panel3, 0, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(1096, 496);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tlpExplorerTasks
            // 
            tlpExplorerTasks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tlpExplorerTasks.AutoScroll = true;
            tlpExplorerTasks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tlpExplorerTasks.ColumnCount = 1;
            tlpExplorerTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpExplorerTasks.Location = new System.Drawing.Point(900, 3);
            tlpExplorerTasks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tlpExplorerTasks.Name = "tlpExplorerTasks";
            tlpExplorerTasks.RowCount = 1;
            tlpExplorerTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpExplorerTasks.Size = new System.Drawing.Size(192, 490);
            tlpExplorerTasks.TabIndex = 17;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtWorkingDirectory);
            panel3.Controls.Add(dgvExplorer);
            panel3.Controls.Add(txtSearch);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(890, 490);
            panel3.TabIndex = 0;
            // 
            // txtWorkingDirectory
            // 
            txtWorkingDirectory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtWorkingDirectory.AnimateReadOnly = false;
            txtWorkingDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtWorkingDirectory.Depth = 0;
            txtWorkingDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            txtWorkingDirectory.Hint = "Working Directory";
            txtWorkingDirectory.LeadingIcon = null;
            txtWorkingDirectory.Location = new System.Drawing.Point(3, 3);
            txtWorkingDirectory.MaxLength = 50;
            txtWorkingDirectory.MouseState = MaterialSkin.MouseState.OUT;
            txtWorkingDirectory.Multiline = false;
            txtWorkingDirectory.Name = "txtWorkingDirectory";
            txtWorkingDirectory.Size = new System.Drawing.Size(884, 50);
            txtWorkingDirectory.TabIndex = 0;
            txtWorkingDirectory.Text = "Current Directory";
            txtWorkingDirectory.TrailingIcon = null;
            // 
            // dgvExplorer
            // 
            dgvExplorer.AllowDrop = true;
            dgvExplorer.AllowUserToAddRows = false;
            dgvExplorer.AllowUserToDeleteRows = false;
            dgvExplorer.AllowUserToOrderColumns = true;
            dgvExplorer.AllowUserToResizeRows = false;
            dgvExplorer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvExplorer.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dgvExplorer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvExplorer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvExplorer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Custom;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(30, 0, 0, 0);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvExplorer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvExplorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExplorer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colName, colSize, colType, colChanged });
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(153, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(30, 0, 0, 0);
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvExplorer.DefaultCellStyle = dataGridViewCellStyle5;
            dgvExplorer.Depth = 0;
            dgvExplorer.EnableHeadersVisualStyles = false;
            dgvExplorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dgvExplorer.GridColor = System.Drawing.Color.FromArgb(225, 225, 225);
            dgvExplorer.Location = new System.Drawing.Point(3, 59);
            dgvExplorer.MouseState = MaterialSkin.MouseState.HOVER;
            dgvExplorer.Name = "dgvExplorer";
            dgvExplorer.ReadOnly = true;
            dgvExplorer.RowHeadersVisible = false;
            dgvExplorer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvExplorer.ShowCellToolTips = false;
            dgvExplorer.Size = new System.Drawing.Size(884, 428);
            dgvExplorer.TabIndex = 1;
            dgvExplorer.CellDoubleClick += dgvExplorer_CellDoubleClick;
            dgvExplorer.CellFormatting += dgvExplorer_CellFormatting;
            dgvExplorer.DragDrop += dgvExplorer_DragDrop;
            dgvExplorer.DragEnter += dgvExplorer_DragEnter;
            dgvExplorer.KeyDown += dgvExplorer_KeyDown;
            dgvExplorer.KeyPress += dgvExplorer_KeyPress;
            dgvExplorer.PreviewKeyDown += dgvExplorer_PreviewKeyDown;
            // 
            // colName
            // 
            colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Name";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colSize
            // 
            colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            colSize.DataPropertyName = "Attributes.Size";
            colSize.HeaderText = "Size";
            colSize.Name = "colSize";
            colSize.ReadOnly = true;
            // 
            // colType
            // 
            colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            colType.DataPropertyName = "Attributes.IsDirectory";
            colType.HeaderText = "Type";
            colType.Name = "colType";
            colType.ReadOnly = true;
            colType.Width = 123;
            // 
            // colChanged
            // 
            colChanged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            colChanged.DataPropertyName = "LastWriteTimeUTC";
            colChanged.HeaderText = "Changed";
            colChanged.Name = "colChanged";
            colChanged.ReadOnly = true;
            colChanged.Width = 163;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtSearch.AnimateReadOnly = false;
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtSearch.Depth = 0;
            txtSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtSearch.Hint = "Search";
            txtSearch.LeadingIcon = null;
            txtSearch.Location = new System.Drawing.Point(678, 3);
            txtSearch.MaxLength = 50;
            txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            txtSearch.Multiline = false;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(209, 50);
            txtSearch.TabIndex = 28;
            txtSearch.Text = "";
            txtSearch.TrailingIcon = null;
            txtSearch.Visible = false;
            // 
            // tpFingerprint
            // 
            tpFingerprint.BackColor = System.Drawing.Color.White;
            tpFingerprint.Controls.Add(txtFingerprint);
            tpFingerprint.ImageKey = "outline_fingerprint_white_24dp.png";
            tpFingerprint.Location = new System.Drawing.Point(4, 31);
            tpFingerprint.Name = "tpFingerprint";
            tpFingerprint.Padding = new System.Windows.Forms.Padding(3);
            tpFingerprint.Size = new System.Drawing.Size(1102, 502);
            tpFingerprint.TabIndex = 4;
            tpFingerprint.Text = "Fingerprint";
            // 
            // txtFingerprint
            // 
            txtFingerprint.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtFingerprint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtFingerprint.Depth = 0;
            txtFingerprint.Dock = System.Windows.Forms.DockStyle.Fill;
            txtFingerprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtFingerprint.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            txtFingerprint.Location = new System.Drawing.Point(3, 3);
            txtFingerprint.MouseState = MaterialSkin.MouseState.HOVER;
            txtFingerprint.Name = "txtFingerprint";
            txtFingerprint.ReadOnly = true;
            txtFingerprint.Size = new System.Drawing.Size(1096, 496);
            txtFingerprint.TabIndex = 3;
            txtFingerprint.Text = "";
            // 
            // tpSSH
            // 
            tpSSH.BackColor = System.Drawing.Color.White;
            tpSSH.Controls.Add(ucSshWizard);
            tpSSH.ImageKey = "outline_ssh_black_24dp.png";
            tpSSH.Location = new System.Drawing.Point(4, 31);
            tpSSH.Name = "tpSSH";
            tpSSH.Padding = new System.Windows.Forms.Padding(3);
            tpSSH.Size = new System.Drawing.Size(1102, 502);
            tpSSH.TabIndex = 5;
            tpSSH.Text = "SSH Wizard";
            // 
            // ucSshWizard
            // 
            ucSshWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSshWizard.Location = new System.Drawing.Point(3, 3);
            ucSshWizard.Name = "ucSshWizard";
            ucSshWizard.Size = new System.Drawing.Size(1096, 496);
            ucSshWizard.TabIndex = 1;
            ucSshWizard.WizardCompleted += ucSshWizard_WizardCompleted;
            // 
            // tpFork
            // 
            tpFork.BackColor = System.Drawing.Color.White;
            tpFork.Controls.Add(txtRepositoryName);
            tpFork.Controls.Add(txtForkBranch);
            tpFork.Controls.Add(txtForkUsername);
            tpFork.Controls.Add(btnInstallFork);
            tpFork.ImageKey = "git_fork_black.png";
            tpFork.Location = new System.Drawing.Point(4, 31);
            tpFork.Name = "tpFork";
            tpFork.Size = new System.Drawing.Size(1102, 502);
            tpFork.TabIndex = 9;
            tpFork.Text = "Fork Installer";
            // 
            // txtRepositoryName
            // 
            txtRepositoryName.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtRepositoryName.AnimateReadOnly = false;
            txtRepositoryName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            txtRepositoryName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            txtRepositoryName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            txtRepositoryName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            txtRepositoryName.Depth = 0;
            txtRepositoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtRepositoryName.HideSelection = true;
            txtRepositoryName.Hint = "Repository Name";
            txtRepositoryName.LeadingIcon = null;
            txtRepositoryName.Location = new System.Drawing.Point(375, 204);
            txtRepositoryName.MaxLength = 50;
            txtRepositoryName.MouseState = MaterialSkin.MouseState.OUT;
            txtRepositoryName.Name = "txtRepositoryName";
            txtRepositoryName.PasswordChar = '\0';
            txtRepositoryName.PrefixSuffixText = null;
            txtRepositoryName.ReadOnly = false;
            txtRepositoryName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtRepositoryName.SelectedText = "";
            txtRepositoryName.SelectionLength = 0;
            txtRepositoryName.SelectionStart = 0;
            txtRepositoryName.ShortcutsEnabled = true;
            txtRepositoryName.Size = new System.Drawing.Size(341, 48);
            txtRepositoryName.TabIndex = 33;
            txtRepositoryName.TabStop = false;
            txtRepositoryName.Text = "openpilot";
            txtRepositoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtRepositoryName.TrailingIcon = null;
            txtRepositoryName.UseSystemPasswordChar = false;
            txtRepositoryName.Leave += txtForkUsername_Leave;
            // 
            // txtForkBranch
            // 
            txtForkBranch.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtForkBranch.AnimateReadOnly = false;
            txtForkBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            txtForkBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtForkBranch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            txtForkBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            txtForkBranch.Depth = 0;
            txtForkBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtForkBranch.HideSelection = true;
            txtForkBranch.Hint = "Branch Name";
            txtForkBranch.LeadingIcon = null;
            txtForkBranch.Location = new System.Drawing.Point(375, 258);
            txtForkBranch.MaxLength = 50;
            txtForkBranch.MouseState = MaterialSkin.MouseState.OUT;
            txtForkBranch.Name = "txtForkBranch";
            txtForkBranch.PasswordChar = '\0';
            txtForkBranch.PrefixSuffixText = null;
            txtForkBranch.ReadOnly = false;
            txtForkBranch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtForkBranch.SelectedText = "";
            txtForkBranch.SelectionLength = 0;
            txtForkBranch.SelectionStart = 0;
            txtForkBranch.ShortcutsEnabled = true;
            txtForkBranch.Size = new System.Drawing.Size(341, 48);
            txtForkBranch.TabIndex = 34;
            txtForkBranch.TabStop = false;
            txtForkBranch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtForkBranch.TrailingIcon = null;
            txtForkBranch.UseSystemPasswordChar = false;
            // 
            // txtForkUsername
            // 
            txtForkUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtForkUsername.AnimateReadOnly = false;
            txtForkUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            txtForkUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            txtForkUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            txtForkUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            txtForkUsername.Depth = 0;
            txtForkUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            txtForkUsername.HideSelection = true;
            txtForkUsername.Hint = "Fork Username";
            txtForkUsername.LeadingIcon = null;
            txtForkUsername.Location = new System.Drawing.Point(375, 150);
            txtForkUsername.MaxLength = 50;
            txtForkUsername.MouseState = MaterialSkin.MouseState.OUT;
            txtForkUsername.Name = "txtForkUsername";
            txtForkUsername.PasswordChar = '\0';
            txtForkUsername.PrefixSuffixText = null;
            txtForkUsername.ReadOnly = false;
            txtForkUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtForkUsername.SelectedText = "";
            txtForkUsername.SelectionLength = 0;
            txtForkUsername.SelectionStart = 0;
            txtForkUsername.ShortcutsEnabled = true;
            txtForkUsername.Size = new System.Drawing.Size(341, 48);
            txtForkUsername.TabIndex = 32;
            txtForkUsername.TabStop = false;
            txtForkUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txtForkUsername.TrailingIcon = null;
            txtForkUsername.UseSystemPasswordChar = false;
            txtForkUsername.Leave += txtForkUsername_Leave;
            // 
            // btnInstallFork
            // 
            btnInstallFork.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnInstallFork.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnInstallFork.AutoSize = false;
            btnInstallFork.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnInstallFork.Density = MaterialButton.MaterialButtonDensity.Default;
            btnInstallFork.Depth = 0;
            btnInstallFork.HighEmphasis = true;
            btnInstallFork.Icon = null;
            btnInstallFork.Location = new System.Drawing.Point(375, 317);
            btnInstallFork.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnInstallFork.MouseState = MaterialSkin.MouseState.HOVER;
            btnInstallFork.Name = "btnInstallFork";
            btnInstallFork.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnInstallFork.Size = new System.Drawing.Size(341, 36);
            btnInstallFork.TabIndex = 35;
            btnInstallFork.Text = "&Install";
            btnInstallFork.Type = MaterialButton.MaterialButtonType.Contained;
            btnInstallFork.UseAccentColor = true;
            btnInstallFork.UseVisualStyleBackColor = true;
            btnInstallFork.Click += btnInstallFork_Click;
            // 
            // tpFlash
            // 
            tpFlash.BackColor = System.Drawing.Color.White;
            tpFlash.ImageKey = "outline_flash_on_white_24dp.png";
            tpFlash.Location = new System.Drawing.Point(4, 31);
            tpFlash.Name = "tpFlash";
            tpFlash.Padding = new System.Windows.Forms.Padding(3);
            tpFlash.Size = new System.Drawing.Size(1102, 502);
            tpFlash.TabIndex = 6;
            tpFlash.Text = "Flash Wizard";
            // 
            // tpShell
            // 
            tpShell.BackColor = System.Drawing.Color.White;
            tpShell.Controls.Add(tableLayoutPanel1);
            tpShell.ImageKey = "outline_console_black_24dp.png";
            tpShell.Location = new System.Drawing.Point(4, 31);
            tpShell.Name = "tpShell";
            tpShell.Padding = new System.Windows.Forms.Padding(3);
            tpShell.Size = new System.Drawing.Size(1102, 502);
            tpShell.TabIndex = 10;
            tpShell.Text = "Terminal";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(1096, 496);
            tableLayoutPanel1.TabIndex = 31;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnTmuxEndScroll);
            panel4.Controls.Add(btnTmuxScroll);
            panel4.Controls.Add(btnTmux);
            panel4.Controls.Add(btnExitTmux);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(895, 3);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(198, 490);
            panel4.TabIndex = 0;
            // 
            // btnTmuxEndScroll
            // 
            btnTmuxEndScroll.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnTmuxEndScroll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnTmuxEndScroll.AutoSize = false;
            btnTmuxEndScroll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnTmuxEndScroll.Density = MaterialButton.MaterialButtonDensity.Default;
            btnTmuxEndScroll.Depth = 0;
            btnTmuxEndScroll.HighEmphasis = true;
            btnTmuxEndScroll.Icon = null;
            btnTmuxEndScroll.Location = new System.Drawing.Point(0, 150);
            btnTmuxEndScroll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnTmuxEndScroll.MouseState = MaterialSkin.MouseState.HOVER;
            btnTmuxEndScroll.Name = "btnTmuxEndScroll";
            btnTmuxEndScroll.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnTmuxEndScroll.Size = new System.Drawing.Size(194, 36);
            btnTmuxEndScroll.TabIndex = 28;
            btnTmuxEndScroll.Text = "TMUX End SCROLL";
            btnTmuxEndScroll.Type = MaterialButton.MaterialButtonType.Contained;
            btnTmuxEndScroll.UseAccentColor = true;
            btnTmuxEndScroll.UseVisualStyleBackColor = true;
            btnTmuxEndScroll.Click += btnTmuxEndScroll_Click;
            // 
            // btnTmuxScroll
            // 
            btnTmuxScroll.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnTmuxScroll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnTmuxScroll.AutoSize = false;
            btnTmuxScroll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnTmuxScroll.Density = MaterialButton.MaterialButtonDensity.Default;
            btnTmuxScroll.Depth = 0;
            btnTmuxScroll.HighEmphasis = true;
            btnTmuxScroll.Icon = null;
            btnTmuxScroll.Location = new System.Drawing.Point(0, 102);
            btnTmuxScroll.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnTmuxScroll.MouseState = MaterialSkin.MouseState.HOVER;
            btnTmuxScroll.Name = "btnTmuxScroll";
            btnTmuxScroll.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnTmuxScroll.Size = new System.Drawing.Size(194, 36);
            btnTmuxScroll.TabIndex = 27;
            btnTmuxScroll.Text = "TMUX Start SCROLL";
            btnTmuxScroll.Type = MaterialButton.MaterialButtonType.Contained;
            btnTmuxScroll.UseAccentColor = true;
            btnTmuxScroll.UseVisualStyleBackColor = true;
            btnTmuxScroll.Click += btnTmuxScroll_Click;
            // 
            // btnTmux
            // 
            btnTmux.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnTmux.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnTmux.AutoSize = false;
            btnTmux.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnTmux.Density = MaterialButton.MaterialButtonDensity.Default;
            btnTmux.Depth = 0;
            btnTmux.HighEmphasis = true;
            btnTmux.Icon = null;
            btnTmux.Location = new System.Drawing.Point(1, 6);
            btnTmux.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnTmux.MouseState = MaterialSkin.MouseState.HOVER;
            btnTmux.Name = "btnTmux";
            btnTmux.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnTmux.Size = new System.Drawing.Size(196, 36);
            btnTmux.TabIndex = 25;
            btnTmux.Text = "Start TMUX";
            btnTmux.Type = MaterialButton.MaterialButtonType.Contained;
            btnTmux.UseAccentColor = true;
            btnTmux.UseVisualStyleBackColor = true;
            btnTmux.Click += btnTmux_Click;
            // 
            // btnExitTmux
            // 
            btnExitTmux.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnExitTmux.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnExitTmux.AutoSize = false;
            btnExitTmux.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnExitTmux.Density = MaterialButton.MaterialButtonDensity.Default;
            btnExitTmux.Depth = 0;
            btnExitTmux.HighEmphasis = true;
            btnExitTmux.Icon = null;
            btnExitTmux.Location = new System.Drawing.Point(1, 54);
            btnExitTmux.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnExitTmux.MouseState = MaterialSkin.MouseState.HOVER;
            btnExitTmux.Name = "btnExitTmux";
            btnExitTmux.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnExitTmux.Size = new System.Drawing.Size(194, 36);
            btnExitTmux.TabIndex = 26;
            btnExitTmux.Text = "Exit Tmux";
            btnExitTmux.Type = MaterialButton.MaterialButtonType.Contained;
            btnExitTmux.UseAccentColor = true;
            btnExitTmux.UseVisualStyleBackColor = true;
            btnExitTmux.Click += btnExitTmux_Click;
            // 
            // tpDonate
            // 
            tpDonate.BackColor = System.Drawing.Color.White;
            tpDonate.Controls.Add(label1);
            tpDonate.Controls.Add(btnPaypal);
            tpDonate.Controls.Add(btnKofi);
            tpDonate.Controls.Add(btnBuyMeCoffee);
            tpDonate.ImageKey = "outline_favorite_white_24dp.png";
            tpDonate.Location = new System.Drawing.Point(4, 31);
            tpDonate.Name = "tpDonate";
            tpDonate.Padding = new System.Windows.Forms.Padding(3);
            tpDonate.Size = new System.Drawing.Size(1102, 502);
            tpDonate.TabIndex = 8;
            tpDonate.Text = "Donate";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            label1.Location = new System.Drawing.Point(6, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(1078, 109);
            label1.TabIndex = 25;
            label1.Text = "If you wish to donate to support development you can do so on the following platforms:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPaypal
            // 
            btnPaypal.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnPaypal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnPaypal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnPaypal.Density = MaterialButton.MaterialButtonDensity.Default;
            btnPaypal.Depth = 0;
            btnPaypal.HighEmphasis = true;
            btnPaypal.Icon = null;
            btnPaypal.Location = new System.Drawing.Point(507, 233);
            btnPaypal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnPaypal.MouseState = MaterialSkin.MouseState.HOVER;
            btnPaypal.Name = "btnPaypal";
            btnPaypal.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnPaypal.Size = new System.Drawing.Size(76, 36);
            btnPaypal.TabIndex = 24;
            btnPaypal.Text = "Paypal";
            btnPaypal.Type = MaterialButton.MaterialButtonType.Contained;
            btnPaypal.UseAccentColor = true;
            btnPaypal.UseVisualStyleBackColor = true;
            btnPaypal.Click += btnPaypal_Click;
            // 
            // btnKofi
            // 
            btnKofi.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnKofi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnKofi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnKofi.Density = MaterialButton.MaterialButtonDensity.Default;
            btnKofi.Depth = 0;
            btnKofi.HighEmphasis = true;
            btnKofi.Icon = null;
            btnKofi.Location = new System.Drawing.Point(513, 185);
            btnKofi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnKofi.MouseState = MaterialSkin.MouseState.HOVER;
            btnKofi.Name = "btnKofi";
            btnKofi.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnKofi.Size = new System.Drawing.Size(64, 36);
            btnKofi.TabIndex = 23;
            btnKofi.Text = "Ko-Fi";
            btnKofi.Type = MaterialButton.MaterialButtonType.Contained;
            btnKofi.UseAccentColor = true;
            btnKofi.UseVisualStyleBackColor = true;
            btnKofi.Click += btnKofi_Click;
            // 
            // btnBuyMeCoffee
            // 
            btnBuyMeCoffee.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnBuyMeCoffee.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnBuyMeCoffee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnBuyMeCoffee.Density = MaterialButton.MaterialButtonDensity.Default;
            btnBuyMeCoffee.Depth = 0;
            btnBuyMeCoffee.HighEmphasis = true;
            btnBuyMeCoffee.Icon = null;
            btnBuyMeCoffee.Location = new System.Drawing.Point(473, 281);
            btnBuyMeCoffee.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnBuyMeCoffee.MouseState = MaterialSkin.MouseState.HOVER;
            btnBuyMeCoffee.Name = "btnBuyMeCoffee";
            btnBuyMeCoffee.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnBuyMeCoffee.Size = new System.Drawing.Size(144, 36);
            btnBuyMeCoffee.TabIndex = 22;
            btnBuyMeCoffee.Text = "Buy me a coffee";
            btnBuyMeCoffee.Type = MaterialButton.MaterialButtonType.Contained;
            btnBuyMeCoffee.UseAccentColor = true;
            btnBuyMeCoffee.UseVisualStyleBackColor = true;
            btnBuyMeCoffee.Click += btnBuyMeCoffee_Click;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.Color.White;
            tabPage1.Controls.Add(flpColours);
            tabPage1.Location = new System.Drawing.Point(4, 31);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(1102, 502);
            tabPage1.TabIndex = 7;
            tabPage1.Text = "tabPage1";
            // 
            // flpColours
            // 
            flpColours.Dock = System.Windows.Forms.DockStyle.Fill;
            flpColours.Location = new System.Drawing.Point(3, 3);
            flpColours.Name = "flpColours";
            flpColours.Size = new System.Drawing.Size(1096, 496);
            flpColours.TabIndex = 0;
            // 
            // tabPage8
            // 
            tabPage8.Location = new System.Drawing.Point(0, 0);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new System.Drawing.Size(200, 100);
            tabPage8.TabIndex = 4;
            tabPage8.Text = "tabPage1";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // themePanel
            // 
            themePanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            themePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            themePanel.BackColor = System.Drawing.Color.Transparent;
            themePanel.Controls.Add(themeButton);
            themePanel.Controls.Add(adbConnected);
            themePanel.Controls.Add(wifiConnected);
            themePanel.Controls.Add(btnScan);
            themePanel.Controls.Add(cmbDevices);
            themePanel.Controls.Add(lblActiveDevice);
            themePanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            themePanel.Location = new System.Drawing.Point(244, 24);
            themePanel.Name = "themePanel";
            themePanel.Size = new System.Drawing.Size(869, 40);
            themePanel.TabIndex = 0;
            // 
            // wifiConnected
            // 
            wifiConnected.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            wifiConnected.AutoSize = false;
            wifiConnected.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            wifiConnected.BackColor = System.Drawing.Color.Red;
            wifiConnected.Density = MaterialButton.MaterialButtonDensity.Default;
            wifiConnected.Depth = 0;
            wifiConnected.DrawShadows = false;
            wifiConnected.Enabled = false;
            wifiConnected.HighEmphasis = true;
            wifiConnected.Icon = Properties.Resources.outline_wifi_black_24dp;
            wifiConnected.ImageKey = "outline_wifi_white_24dp.png";
            wifiConnected.ImageList = ilTabs;
            wifiConnected.Location = new System.Drawing.Point(739, 2);
            wifiConnected.Margin = new System.Windows.Forms.Padding(2);
            wifiConnected.MouseState = MaterialSkin.MouseState.HOVER;
            wifiConnected.Name = "wifiConnected";
            wifiConnected.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            wifiConnected.Size = new System.Drawing.Size(40, 36);
            wifiConnected.TabIndex = 2;
            wifiConnected.Type = MaterialButton.MaterialButtonType.Contained;
            wifiConnected.UseAccentColor = false;
            wifiConnected.UseVisualStyleBackColor = true;
            // 
            // cmbDevices
            // 
            cmbDevices.AutoResize = false;
            cmbDevices.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            cmbDevices.Depth = 0;
            cmbDevices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            cmbDevices.DropDownHeight = 118;
            cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDevices.DropDownWidth = 121;
            cmbDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            cmbDevices.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            cmbDevices.FormattingEnabled = true;
            cmbDevices.Hint = "Openpilot Device";
            cmbDevices.IntegralHeight = false;
            cmbDevices.ItemHeight = 29;
            cmbDevices.Location = new System.Drawing.Point(287, 3);
            cmbDevices.MaxDropDownItems = 4;
            cmbDevices.MouseState = MaterialSkin.MouseState.OUT;
            cmbDevices.Name = "cmbDevices";
            cmbDevices.Size = new System.Drawing.Size(266, 35);
            cmbDevices.StartIndex = 0;
            cmbDevices.TabIndex = 0;
            cmbDevices.UseTallSize = false;
            cmbDevices.SelectedIndexChanged += cmbDevices_SelectedIndexChanged;
            // 
            // lblActiveDevice
            // 
            lblActiveDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            lblActiveDevice.ForeColor = System.Drawing.Color.White;
            lblActiveDevice.Location = new System.Drawing.Point(124, 0);
            lblActiveDevice.Name = "lblActiveDevice";
            lblActiveDevice.Size = new System.Drawing.Size(157, 37);
            lblActiveDevice.TabIndex = 35;
            lblActiveDevice.Text = "ACTIVE DEVICE:";
            lblActiveDevice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OpenpilotToolkitForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1116, 604);
            Controls.Add(tcSettings);
            Controls.Add(themePanel);
            DrawerAutoHide = false;
            DrawerBackgroundWithAccent = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = tcSettings;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(1116, 604);
            Name = "OpenpilotToolkitForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "OPENPILOT TOOLKIT";
            FormClosing += ExportDrivesForm_FormClosing;
            FormClosed += OpenpilotToolkitForm_FormClosed;
            Load += Form1_Load;
            tcSettings.ResumeLayout(false);
            tpExport.ResumeLayout(false);
            tpExport.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDriveInfo).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel2.ResumeLayout(false);
            tpRemote.ResumeLayout(false);
            tpSettings.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            tpLogFile.ResumeLayout(false);
            tpExplore.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExplorer).EndInit();
            tpFingerprint.ResumeLayout(false);
            tpSSH.ResumeLayout(false);
            tpFork.ResumeLayout(false);
            tpShell.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tpDonate.ResumeLayout(false);
            tpDonate.PerformLayout();
            tabPage1.ResumeLayout(false);
            themePanel.ResumeLayout(false);
            themePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox lbDrives;
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
        private MaterialTextBox2 txtRepositoryName;
        private Controls.Media.FlyleafVideoPlayer flyleafVideoPlayer1;
    }
}

