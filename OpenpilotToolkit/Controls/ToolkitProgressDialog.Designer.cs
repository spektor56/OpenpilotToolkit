
namespace OpenpilotToolkit.Controls
{
    partial class ToolkitProgressDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblText = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(6, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(372, 45);
            this.lblText.TabIndex = 31;
            this.lblText.Text = "label1";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 48);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(378, 23);
            this.progressBar1.TabIndex = 32;
            // 
            // ToolkitProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 74);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblText);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "ToolkitProgressDialog";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ToolkitProgressDialog";
            this.Deactivate += new System.EventHandler(this.ToolkitProgressDialog_Deactivate);
            this.LostFocus += new System.EventHandler(this.ToolkitProgressDialog_LostFocus);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolkitProgressDialog_FormClosing);
            this.Load += new System.EventHandler(this.ToolkitProgressDialog_Load);
            this.Shown += new System.EventHandler(this.ToolkitProgressDialog_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}