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

namespace OpenpilotToolkit.Controls
{
    public partial class ToolkitProgressDialog : MaterialForm
    {
        private OverlayForm _overlayForm;
        public ToolkitProgressDialog(string text, ContainerControl parent)
        {
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
            

        }

        private void ToolkitProgressDialog_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }
    }
}
