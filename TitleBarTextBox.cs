using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace DeskNote
{
    class TitleBarTextBox : TextBox
    {
        public event EventHandler Dragging;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        IntPtr FormHandler;
        
        public TitleBarTextBox(IntPtr frmHndl)
        {
            FormHandler = frmHndl;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                if (Dragging != null)
                {
                    Cursor.Current = Cursors.Hand;
                    Dragging(null, EventArgs.Empty);
                    //Debug.Write("Strat Dragging");
                }
            }
        }

        public void HandleMouseMove()
        {
            ReleaseCapture();
            SendMessage(FormHandler, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            Cursor.Current = Cursors.Default;
            //Debug.Write("Stop Dragging");

        }
    }
}
