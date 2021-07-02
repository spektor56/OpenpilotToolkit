using System;
using System.Windows.Forms;

namespace OpenpilotToolkit.Controls.Wizards
{
    public partial class ucWizard : UserControl
    {

        public ucWizard()
        {
            InitializeComponent();

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
          
                
            

           
                materialTabControl1.SelectedIndex =
                    Math.Min(materialTabControl1.TabCount, materialTabControl1.SelectedIndex + 1);
            
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex =
                Math.Max(0, materialTabControl1.SelectedIndex - 1);
        }
    }
}
