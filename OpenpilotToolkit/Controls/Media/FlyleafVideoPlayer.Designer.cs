namespace OpenpilotToolkit.Controls.Media
{
    partial class FlyleafVideoPlayer
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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel2 = new System.Windows.Forms.Panel();
            flyleafHost1 = new FlyleafLib.Controls.WinForms.FlyleafHost();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            btnPreviousSegment = new MaterialSkin.Controls.MaterialButton();
            timeScale = new MaterialSkin.Controls.MaterialSlider();
            lblSegment = new System.Windows.Forms.Label();
            btnNextSegment = new MaterialSkin.Controls.MaterialButton();
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(463, 350);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(flyleafHost1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(457, 299);
            panel2.TabIndex = 69;
            // 
            // flyleafHost1
            // 
            flyleafHost1.AllowDrop = true;
            flyleafHost1.BackColor = System.Drawing.Color.Black;
            flyleafHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            flyleafHost1.DragMove = false;
            flyleafHost1.IsFullScreen = false;
            flyleafHost1.KeyBindings = true;
            flyleafHost1.Location = new System.Drawing.Point(0, 0);
            flyleafHost1.Name = "flyleafHost1";
            flyleafHost1.OpenOnDrop = false;
            flyleafHost1.PanMoveOnCtrl = true;
            flyleafHost1.PanRotateOnShiftWheel = false;
            flyleafHost1.PanZoomOnCtrlWheel = true;
            flyleafHost1.Player = null;
            flyleafHost1.Size = new System.Drawing.Size(457, 299);
            flyleafHost1.SwapDragEnterOnShift = false;
            flyleafHost1.SwapOnDrop = false;
            flyleafHost1.TabIndex = 2;
            flyleafHost1.ToggleFullScreenOnDoubleClick = false;
            flyleafHost1.Click += flyleafHost1_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel2.Controls.Add(btnPreviousSegment, 0, 0);
            tableLayoutPanel2.Controls.Add(timeScale, 1, 0);
            tableLayoutPanel2.Controls.Add(lblSegment, 2, 0);
            tableLayoutPanel2.Controls.Add(btnNextSegment, 4, 0);
            tableLayoutPanel2.Controls.Add(materialComboBox1, 3, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 308);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(457, 39);
            tableLayoutPanel2.TabIndex = 70;
            // 
            // btnPreviousSegment
            // 
            btnPreviousSegment.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnPreviousSegment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnPreviousSegment.AutoSize = false;
            btnPreviousSegment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnPreviousSegment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnPreviousSegment.Depth = 0;
            btnPreviousSegment.HighEmphasis = true;
            btnPreviousSegment.Icon = null;
            btnPreviousSegment.Location = new System.Drawing.Point(4, 6);
            btnPreviousSegment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnPreviousSegment.MouseState = MaterialSkin.MouseState.HOVER;
            btnPreviousSegment.Name = "btnPreviousSegment";
            btnPreviousSegment.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnPreviousSegment.Size = new System.Drawing.Size(32, 27);
            btnPreviousSegment.TabIndex = 67;
            btnPreviousSegment.Text = "<";
            btnPreviousSegment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnPreviousSegment.UseAccentColor = true;
            btnPreviousSegment.UseVisualStyleBackColor = true;
            btnPreviousSegment.Click += btnPreviousSegment_Click;
            // 
            // timeScale
            // 
            timeScale.Depth = 0;
            timeScale.Dock = System.Windows.Forms.DockStyle.Fill;
            timeScale.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            timeScale.Location = new System.Drawing.Point(43, 3);
            timeScale.MouseState = MaterialSkin.MouseState.HOVER;
            timeScale.Name = "timeScale";
            timeScale.RangeMax = 100000;
            timeScale.ShowText = false;
            timeScale.ShowValue = false;
            timeScale.Size = new System.Drawing.Size(231, 40);
            timeScale.TabIndex = 66;
            timeScale.Text = "";
            timeScale.UseAccentColor = true;
            timeScale.Value = 0;
            timeScale.onValueChanged += timeScale_onValueChanged;
            // 
            // lblSegment
            // 
            lblSegment.AutoSize = true;
            lblSegment.Dock = System.Windows.Forms.DockStyle.Fill;
            lblSegment.Location = new System.Drawing.Point(280, 0);
            lblSegment.Name = "lblSegment";
            lblSegment.Size = new System.Drawing.Size(34, 39);
            lblSegment.TabIndex = 69;
            lblSegment.Text = "0";
            lblSegment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextSegment
            // 
            btnNextSegment.AccentTextColor = System.Drawing.Color.FromArgb(255, 64, 129);
            btnNextSegment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnNextSegment.AutoSize = false;
            btnNextSegment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnNextSegment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNextSegment.Depth = 0;
            btnNextSegment.HighEmphasis = true;
            btnNextSegment.Icon = null;
            btnNextSegment.Location = new System.Drawing.Point(421, 6);
            btnNextSegment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btnNextSegment.MouseState = MaterialSkin.MouseState.HOVER;
            btnNextSegment.Name = "btnNextSegment";
            btnNextSegment.NoAccentTextColor = System.Drawing.Color.FromArgb(63, 81, 181);
            btnNextSegment.Size = new System.Drawing.Size(32, 27);
            btnNextSegment.TabIndex = 68;
            btnNextSegment.Text = ">";
            btnNextSegment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNextSegment.UseAccentColor = true;
            btnNextSegment.UseVisualStyleBackColor = true;
            btnNextSegment.Click += btnNextSegment_Click;
            // 
            // materialComboBox1
            // 
            materialComboBox1.AutoResize = false;
            materialComboBox1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            materialComboBox1.Depth = 0;
            materialComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            materialComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            materialComboBox1.DropDownHeight = 118;
            materialComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            materialComboBox1.DropDownWidth = 121;
            materialComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            materialComboBox1.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            materialComboBox1.FormattingEnabled = true;
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 29;
            materialComboBox1.Items.AddRange(new object[] { "Front", "Driver", "Wide" });
            materialComboBox1.Location = new System.Drawing.Point(320, 3);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new System.Drawing.Size(94, 35);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 70;
            materialComboBox1.UseTallSize = false;
            materialComboBox1.SelectedIndexChanged += materialComboBox1_SelectedIndexChanged;
            materialComboBox1.SelectedValueChanged += materialComboBox1_SelectedValueChanged;
            // 
            // FlyleafVideoPlayer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "FlyleafVideoPlayer";
            Size = new System.Drawing.Size(463, 350);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        public FlyleafLib.Controls.WinForms.FlyleafHost flyleafHost1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialButton btnPreviousSegment;
        private MaterialSkin.Controls.MaterialSlider timeScale;
        private MaterialSkin.Controls.MaterialButton btnNextSegment;
        private System.Windows.Forms.Label lblSegment;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
    }
}
