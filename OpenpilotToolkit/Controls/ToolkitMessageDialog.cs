using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MaterialSkin;
using MaterialSkin.Controls;

namespace OpenpilotToolkit.Controls
{
    public partial class ToolkitMessageDialog : MaterialForm
    {
        private OverlayForm _overlayForm;
        public ToolkitMessageDialog(string text, MessageBoxButtons buttons, ContainerControl parent)
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
            if (buttons != MessageBoxButtons.YesNo)
            {
                flowLayoutPanel1.Controls.Remove(btnYes);
                flowLayoutPanel1.Controls.Remove(btnNo);
            }
            if (buttons != MessageBoxButtons.OK)
            {
                flowLayoutPanel1.Controls.Remove(btnOk);
            }

            if (flowLayoutPanel1.Controls.Count > 0)
            {
                var button = (MaterialButton)flowLayoutPanel1.Controls[0];
                this.AcceptButton = button;
            }

            label1.Text = text;
        }


        public static DialogResult ShowDialog(string text, ContainerControl parent = null, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            
            return new ToolkitMessageDialog(text, buttons, parent).ShowDialog(parent);

            
        }

        private void ToolkitMessageDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void ToolkitMessageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_overlayForm != null)
            {
                _overlayForm.Close();
            }
        }

        private void ToolkitMessageDialog_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void ToolkitMessageDialog_Shown(object sender, EventArgs e)
        {
            Opacity = 100;
        }
    }
}
