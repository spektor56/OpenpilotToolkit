using System.Drawing;
using System.Windows.Forms;

namespace OpenpilotToolkit.Controls
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            KeyPreview = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            DoubleBuffered = true;
            TransparencyKey = Color.FromArgb(27, 27, 27);
            BackColor = Color.FromArgb(27, 27, 27);
            FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            AutoScaleMode = AutoScaleMode.None;
        }

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
    }
}
