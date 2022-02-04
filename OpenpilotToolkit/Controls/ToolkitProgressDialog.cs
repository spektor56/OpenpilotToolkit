using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using OpenpilotSdk.OpenPilot.Fork;

namespace OpenpilotToolkit.Controls
{
    public partial class ToolkitProgressDialog : MaterialForm
    {
        private OverlayForm _overlayForm;

        public string ProgressText
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        public int ProgressValue
        {
            get { return progressBar1.Value; }
            set { progressBar1.Value = value; }
        }

        public int ProgressMax
        {
            get { return progressBar1.Maximum; }
            set { progressBar1.Maximum = value; }
        }

        public ToolkitProgressDialog(string text, ContainerControl parent, Progress<InstallProgress> progress = null)
        {
            Opacity = 0;
            if (parent != null)
            {
                _overlayForm = new OverlayForm(parent);
            }
            this.Icon = Properties.Resources.ic_launcher_web;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);

            InitializeComponent();
            
            progressBar1.Style = ProgressBarStyle.Marquee;
            
            lblText.Text = text;
            this.Show(parent);

            if (progress != null)
            {
                progress.ProgressChanged += ProgressOnProgressChanged;
            }
        }

        private void ToolkitProgressDialog_LostFocus(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void ProgressOnProgressChanged(object sender, InstallProgress e)
        {
            progressBar1.Style = ProgressBarStyle.Continuous;
            lblText.Text = e.ProgressText;
            progressBar1.Value = e.Progress;
        }

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
            if (_overlayForm != null)
            {
                _overlayForm.Dispose();
            }
            

            base.Dispose(disposing);
        }

        private void ToolkitProgressDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_overlayForm != null)
            {
                _overlayForm.Close();
            }

        }

        private void ToolkitProgressDialog_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void ToolkitProgressDialog_Shown(object sender, EventArgs e)
        {
            Opacity = 100;
        }

        private void ToolkitProgressDialog_Deactivate(object sender, EventArgs e)
        {
            
            this.Focus();
        }
    }
}
