using System.Windows.Forms;

namespace OpenpilotToolkit.Controls
{
    public partial class ucTaskProgress : UserControl
    {
        private string _driveName;
        public ucTaskProgress(string driveName, int segments)
        {
            InitializeComponent();
            materialProgressBar1.Maximum = segments;
            _driveName = driveName;
            lblPercent.Text = string.Concat(_driveName," ", 0, "%");
        }

        public int Progress
        {
            get { return materialProgressBar1.Value; }
            set
            {
                materialProgressBar1.Value = value;
                lblPercent.Text = string.Concat(_driveName, " ", (int)(((double)value / (double)materialProgressBar1.Maximum)*100), "%");
            }
        }
    }
}
