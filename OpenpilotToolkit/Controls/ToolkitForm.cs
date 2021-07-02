using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace OpenpilotToolkit.Controls
{
    public partial class ToolkitForm : MaterialForm
    {
        public ToolkitForm()
        {
            this.Icon = Properties.Resources.ic_launcher_web;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void ToolkitForm_Load(object sender, System.EventArgs e)
        {
            CenterToParent();
        }
    }
}
