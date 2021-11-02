using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenpilotToolkit.Controls
{
    public partial class OverlayForm : Form
    {
        private const int DwmwaTransitionsForcedisabled = 3;
        readonly ContainerControl _parent;

        public OverlayForm(ContainerControl parent)
        {
            KeyPreview = true;
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            var parentForm = parent.FindForm();
            InitializeComponent();
            _parent = parent;
            DoubleBuffered = true;
            //TransparencyKey = Color.FromArgb(27, 27, 27);
            BackColor = Color.FromArgb(27, 27, 27);
            FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            AutoScaleMode = AutoScaleMode.None;
            Show(parent);
            parent.Focus();
            parentForm.LocationChanged += Cover_LocationChanged;
            parent.LocationChanged += Cover_LocationChanged;
            parent.VisibleChanged += Cover_LocationChanged;
            parent.ClientSizeChanged += Cover_ClientSizeChanged;
            // Disable Aero transitions, the plexiglass gets too visible
            if (Environment.OSVersion.Version.Major >= 6)
            {
                var value = 1;
                DwmSetWindowAttribute(parentForm.Handle, DwmwaTransitionsForcedisabled, ref value, 4);
            }
            Location = parent.PointToScreen(Point.Empty);
            ClientSize = parent.ClientSize;
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

        public sealed override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        private void Cover_LocationChanged(object sender, EventArgs e)
        {
            ClientSize = _parent.ClientSize;
            Location = _parent.PointToScreen(Point.Empty);
        }

        private void Cover_ClientSizeChanged(object sender, EventArgs e)
        {
            ClientSize = _parent.ClientSize;
            Location = _parent.PointToScreen(Point.Empty);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Restore owner
            Owner.LocationChanged -= Cover_LocationChanged;
            Owner.ClientSizeChanged -= Cover_ClientSizeChanged;
            if (!Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
            {
                var value = 1;
                DwmSetWindowAttribute(Owner.Handle, DwmwaTransitionsForcedisabled, ref value, 4);
            }

            base.OnFormClosing(e);
        }
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);

        private void OverlayForm_Shown(object sender, EventArgs e)
        {
            this.Opacity = 0.7;
        }
    }
}
