
namespace OpenpilotToolkit.Controls.Media
{
    partial class VideoPlayer
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
                if (vlcVideoView1.MediaPlayer != null)
                {
                    vlcVideoView1.MediaPlayer.Stop();
                    vlcVideoView1.MediaPlayer.Dispose();
                }

                if (vlcVideoView2.MediaPlayer != null)
                {
                    vlcVideoView2.MediaPlayer.Stop();
                    vlcVideoView2.MediaPlayer.Dispose();
                }
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.vlcVideoView1 = new LibVLCSharp.WinForms.VideoView();
            this.vlcVideoView2 = new LibVLCSharp.WinForms.VideoView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPreviousSegment = new MaterialSkin.Controls.MaterialButton();
            this.timeScale = new MaterialSkin.Controls.MaterialSlider();
            this.btnNextSegment = new MaterialSkin.Controls.MaterialButton();
            this.lblSegment = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcVideoView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcVideoView2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(463, 350);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.vlcVideoView1);
            this.panel2.Controls.Add(this.vlcVideoView2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 299);
            this.panel2.TabIndex = 69;
            // 
            // vlcVideoView1
            // 
            this.vlcVideoView1.BackColor = System.Drawing.Color.Black;
            this.vlcVideoView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcVideoView1.Location = new System.Drawing.Point(0, 0);
            this.vlcVideoView1.MediaPlayer = null;
            this.vlcVideoView1.Name = "vlcVideoView1";
            this.vlcVideoView1.Size = new System.Drawing.Size(457, 299);
            this.vlcVideoView1.TabIndex = 0;
            this.vlcVideoView1.Text = "videoView1";
            this.vlcVideoView1.Click += new System.EventHandler(this.vlcVideoView_Click);
            // 
            // vlcVideoView2
            // 
            this.vlcVideoView2.BackColor = System.Drawing.Color.Black;
            this.vlcVideoView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcVideoView2.Location = new System.Drawing.Point(0, 0);
            this.vlcVideoView2.MediaPlayer = null;
            this.vlcVideoView2.Name = "vlcVideoView2";
            this.vlcVideoView2.Size = new System.Drawing.Size(457, 299);
            this.vlcVideoView2.TabIndex = 1;
            this.vlcVideoView2.Text = "videoView1";
            this.vlcVideoView2.Click += new System.EventHandler(this.vlcVideoView_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Controls.Add(this.btnPreviousSegment, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.timeScale, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnNextSegment, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSegment, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 308);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(457, 39);
            this.tableLayoutPanel2.TabIndex = 70;
            // 
            // btnPreviousSegment
            // 
            this.btnPreviousSegment.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnPreviousSegment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviousSegment.AutoSize = false;
            this.btnPreviousSegment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPreviousSegment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPreviousSegment.Depth = 0;
            this.btnPreviousSegment.HighEmphasis = true;
            this.btnPreviousSegment.Icon = null;
            this.btnPreviousSegment.Location = new System.Drawing.Point(4, 6);
            this.btnPreviousSegment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPreviousSegment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreviousSegment.Name = "btnPreviousSegment";
            this.btnPreviousSegment.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnPreviousSegment.Size = new System.Drawing.Size(32, 27);
            this.btnPreviousSegment.TabIndex = 67;
            this.btnPreviousSegment.Text = "<";
            this.btnPreviousSegment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreviousSegment.UseAccentColor = true;
            this.btnPreviousSegment.UseVisualStyleBackColor = true;
            this.btnPreviousSegment.Click += new System.EventHandler(this.btnPreviousSegment_Click);
            // 
            // timeScale
            // 
            this.timeScale.Depth = 0;
            this.timeScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeScale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.timeScale.Location = new System.Drawing.Point(43, 3);
            this.timeScale.MouseState = MaterialSkin.MouseState.HOVER;
            this.timeScale.Name = "timeScale";
            this.timeScale.RangeMax = 100000;
            this.timeScale.ShowText = false;
            this.timeScale.ShowValue = false;
            this.timeScale.Size = new System.Drawing.Size(331, 40);
            this.timeScale.TabIndex = 66;
            this.timeScale.Text = "";
            this.timeScale.UseAccentColor = true;
            this.timeScale.Value = 0;
            this.timeScale.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.timeScale_onValueChanged);
            // 
            // btnNextSegment
            // 
            this.btnNextSegment.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnNextSegment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextSegment.AutoSize = false;
            this.btnNextSegment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNextSegment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNextSegment.Depth = 0;
            this.btnNextSegment.HighEmphasis = true;
            this.btnNextSegment.Icon = null;
            this.btnNextSegment.Location = new System.Drawing.Point(421, 6);
            this.btnNextSegment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNextSegment.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNextSegment.Name = "btnNextSegment";
            this.btnNextSegment.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnNextSegment.Size = new System.Drawing.Size(32, 27);
            this.btnNextSegment.TabIndex = 68;
            this.btnNextSegment.Text = ">";
            this.btnNextSegment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNextSegment.UseAccentColor = true;
            this.btnNextSegment.UseVisualStyleBackColor = true;
            this.btnNextSegment.Click += new System.EventHandler(this.btnNextSegment_Click);
            // 
            // lblSegment
            // 
            this.lblSegment.AutoSize = true;
            this.lblSegment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSegment.Location = new System.Drawing.Point(380, 0);
            this.lblSegment.Name = "lblSegment";
            this.lblSegment.Size = new System.Drawing.Size(34, 39);
            this.lblSegment.TabIndex = 69;
            this.lblSegment.Text = "0";
            this.lblSegment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VideoPlayer";
            this.Size = new System.Drawing.Size(463, 350);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vlcVideoView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcVideoView2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialSlider timeScale;
        public LibVLCSharp.WinForms.VideoView vlcVideoView1;
        private System.Windows.Forms.Panel panel2;
        public LibVLCSharp.WinForms.VideoView vlcVideoView2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialButton btnNextSegment;
        private MaterialSkin.Controls.MaterialButton btnPreviousSegment;
        private System.Windows.Forms.Label lblSegment;
    }
}
