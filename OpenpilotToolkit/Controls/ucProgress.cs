using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenpilotToolkit.Controls
{
    public partial class ucProgress : UserControl
    {
        private string _fileName;
        public ucProgress(string fileName)
        {
            InitializeComponent();
            materialProgressBar1.Maximum = 100;
            _fileName = fileName;
            lblPercent.Text = string.Concat(0, "%", " ", _fileName);
        }

        public int Progress
        {
            get { return materialProgressBar1.Value; }
            set
            {
                materialProgressBar1.Value = value;
                lblPercent.Text = string.Concat((int)(((double)value / (double)materialProgressBar1.Maximum) * 100), "%", " ", _fileName);
            }
        }
    }
}
