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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Screen_Print {
    public partial class SelectArea : Form {
        public SelectArea() {
            InitializeComponent();
            this.Opacity = 0.5;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        /**
         * Red Overlay
         */
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.Red, Top);
            e.Graphics.FillRectangle(Brushes.Red, Left);
            e.Graphics.FillRectangle(Brushes.Red, Right);
            e.Graphics.FillRectangle(Brushes.Red, Bottom);
        }

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const int offset = 10;

        #region Selection area
        Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, offset); } }
        Rectangle Left { get { return new Rectangle(0, 0, offset, this.ClientSize.Height); } }
        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - offset, this.ClientSize.Width, offset); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - offset, 0, offset, this.ClientSize.Height); } }
        Rectangle TopLeft { get { return new Rectangle(0, 0, offset, offset); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - offset, 0, offset, offset); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - offset, offset, offset); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - offset, this.ClientSize.Height - offset, offset, offset); } }
        #endregion

        protected override void WndProc(ref Message message) {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                // Update selection area
                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();


        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panelDrag_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
