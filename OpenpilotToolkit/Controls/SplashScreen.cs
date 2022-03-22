using System.Drawing;
using System.Windows.Forms;

namespace OpenpilotToolkit.Controls
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            TopMost = true;
            AutoScaleMode = AutoScaleMode.None;
        }
        /*
        private const int WS_EX_TRANSPARENT = 0x20;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        */

        private void SplashScreen_Shown(object sender, System.EventArgs e)
        {
            Opacity = 100;
        }
    }
}
