using System.Windows.Forms;

namespace OpenpilotToolkit.Controls
{
    public partial class ucTaskProgress : UserControl
    {
        private string _routeName;
        public ucTaskProgress(string routeName, int segments)
        {
            InitializeComponent();
            materialProgressBar1.Maximum = segments;
            _routeName = routeName;
            lblPercent.Text = string.Concat(_routeName," ", 0, "%");
        }

        public int Progress
        {
            get { return materialProgressBar1.Value; }
            set
            {
                materialProgressBar1.Value = value;
                lblPercent.Text = string.Concat(_routeName, " ", (int)(((double)value / (double)materialProgressBar1.Maximum)*100), "%");
            }
        }
    }
}
