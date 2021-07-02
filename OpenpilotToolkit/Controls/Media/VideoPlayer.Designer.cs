
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
                if (vlcVideoView.MediaPlayer != null)
                {
                    vlcVideoView.MediaPlayer.Stop();
                    vlcVideoView.MediaPlayer.Dispose();
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
            this.vlcVideoView = new LibVLCSharp.WinForms.VideoView();
            this.timeScale = new MaterialSkin.Controls.MaterialSlider();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.vlcVideoView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.timeScale, 0, 1);
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
            // vlcVideoView
            // 
            this.vlcVideoView.BackColor = System.Drawing.Color.Black;
            this.vlcVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcVideoView.Location = new System.Drawing.Point(3, 3);
            this.vlcVideoView.MediaPlayer = null;
            this.vlcVideoView.Name = "vlcVideoView";
            this.vlcVideoView.Size = new System.Drawing.Size(457, 299);
            this.vlcVideoView.TabIndex = 0;
            this.vlcVideoView.Text = "videoView1";
            this.vlcVideoView.Click += new System.EventHandler(this.vlcVideoView_Click);
            // 
            // timeScale
            // 
            this.timeScale.Depth = 0;
            this.timeScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeScale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.timeScale.Location = new System.Drawing.Point(3, 308);
            this.timeScale.MouseState = MaterialSkin.MouseState.HOVER;
            this.timeScale.Name = "timeScale";
            this.timeScale.RangeMax = 100000;
            this.timeScale.ShowText = false;
            this.timeScale.ShowValue = false;
            this.timeScale.Size = new System.Drawing.Size(457, 40);
            this.timeScale.TabIndex = 66;
            this.timeScale.Text = "";
            this.timeScale.UseAccentColor = true;
            this.timeScale.Value = 0;
            this.timeScale.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.timeScale_onValueChanged);
            // 
            // VideoPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "VideoPlayer";
            this.Size = new System.Drawing.Size(463, 350);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vlcVideoView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialSlider timeScale;
        public LibVLCSharp.WinForms.VideoView vlcVideoView;
    }
}
