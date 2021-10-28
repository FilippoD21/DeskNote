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

namespace DeskNote
{
    public partial class DeskNote : Form
    {

        string NoteFile;
        bool AllowSave = false;
        private TitleBarTextBox TitleBar;

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public DeskNote(string filename)
        {
            InitializeComponent();
            this.Width = Properties.Settings.Default.Width;
            this.Height = Properties.Settings.Default.Height;
            this.TitleBar = new TitleBarTextBox(this.Handle);
            this.TitleBar.AcceptsReturn = true;
            this.TitleBar.BackColor = Color.LemonChiffon;
            this.TitleBar.BorderStyle = BorderStyle.None;
            this.TitleBar.Dock = DockStyle.Fill;
            this.TitleBar.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.TitleBar.Location = new Point(0, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new Size(this.Width-2, 16);
            this.TitleBar.TabIndex = 0;
            this.TitleBar.Leave += new EventHandler(this.TitleBar_Leave);
            this.TitleBar.KeyUp += new KeyEventHandler(this.TitleBar_KeyUp);
            this.TitleBar.Dragging += new EventHandler(TitleBar_Dragging);
            this.TitleBar.TextChanged += new EventHandler(Note_TextChanged);
            this.HeaderPanel.Controls.Add(this.TitleBar);
            NoteFile = filename;
        }

        void TitleBar_Dragging(object sender, EventArgs e)
        {
            TitleBar.HandleMouseMove();
        }


        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on non-client area of the form
            const int WM_NCHITTEST = 0x0084;
            const int HTCLIENT = 0x01;
            IntPtr HTTOPLEFT = (IntPtr)13;
            IntPtr HTTOP = (IntPtr)12;
            IntPtr HTTOPRIGHT = (IntPtr)14;
            IntPtr HTLEFT = (IntPtr)10;
            IntPtr HTCAPTION = (IntPtr)2;
            IntPtr HTRIGHT = (IntPtr)11;
            IntPtr HTBOTTOMLEFT = (IntPtr)16;
            IntPtr HTBOTTOM = (IntPtr)15;
            IntPtr HTBOTTOMRIGHT = (IntPtr)17;

            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);

                    if ((int)m.Result == HTCLIENT)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = HTTOPLEFT;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = HTTOP;
                            else
                                m.Result = HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = HTLEFT;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = HTCAPTION;
                            else
                                m.Result = HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = HTBOTTOMLEFT;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = HTBOTTOM;
                            else
                                m.Result = HTBOTTOMRIGHT;
                        }
                    }
                    return;
                case WM_NCLBUTTONDBLCLK:
                    TitleBar.Text = this.Text;
                    TitleBar.Visible = true;
                    TitleBar.Focus();
                    m.Result = IntPtr.Zero;
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        private void LoadFile()
        {
            try
            {
                string[] lines = File.ReadAllText(NoteFile).Split(new[] { Environment.NewLine }, 2, StringSplitOptions.None);
                string[] headerTxt = lines[0].Split(';');
                int left = this.Left;
                int.TryParse(headerTxt[0], out left);
                int top = this.Top;
                int.TryParse(headerTxt[1], out top);
                int width = this.Width;
                int.TryParse(headerTxt[2], out width);
                int height = this.Height;
                int.TryParse(headerTxt[3], out height);
                this.Text = headerTxt[4];
                TitleBar.Text = headerTxt[4];
                Note.Text = lines[1];
                Note.Select(Note.Text.Length, 0);
                this.SetDesktopBounds(left, top, width, height);
            }
            catch (Exception fParseEx)
            {
                MessageBox.Show(Properties.Messages.ReadingNoteError + "\n" + fParseEx.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewFile();
            }

        }

        private void NewFile()
        {
            try
            {
                string title = "DeskNote " + DateTime.Now;
                File.WriteAllText(NoteFile, "0;0;0;0;" + title + Environment.NewLine);
                this.Text = title;
                this.TitleBar.Text = title;
                SetForegroundWindow(this.Handle);
            }
            catch (Exception fileEx)
            {
                MessageBox.Show(Properties.Messages.CreatingNoteError + "\n" + fileEx.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SaveFile()
        {
            if (AllowSave)
            {
                if (this.Left > 0 && this.Top > 0 && this.Width > 0 && this.Height > 0)
                {
                    try
                    {
                        File.WriteAllText(NoteFile,
                            this.Left + ";" + this.Top + ";" + this.Width + ";" + this.Height + ";" + this.TitleBar.Text + Environment.NewLine +
                            Note.Text);
                    }
                    catch (Exception fileEx)
                    {
                        MessageBox.Show(Properties.Messages.SavingNoteError + "\n" + fileEx.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TitleBar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Note.Focus();
            }

        }

        private void TitleBar_Leave(object sender, EventArgs e)
        {
            this.Text = TitleBar.Text;
            SaveFile();
        }

        private void Note_GotFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Note.Text))
                Note.Select(Note.TextLength - 1, 0);
        }

        private void Note_TextChanged(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void DeskNote_Resize(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void DeskNote_Move(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void DeskNote_Load(object sender, EventArgs e)
        {
            this.Opacity = Properties.Settings.Default.Opacity;
            Color backColor = ColorTranslator.FromHtml(Properties.Settings.Default.BackColor);
            this.BackColor = backColor;
            Note.BackColor = backColor;
            HeaderPanel.BackColor = backColor;
            TitleBar.BackColor = backColor;
            //TitleBar.BackColor = AlternateColor(Note.BackColor);
            AllowSave = true;
            if (File.Exists(NoteFile))
                LoadFile();
            else
                NewFile();
        }

        private Color AlternateColor (Color color, int val = 10)
        {
            try
            {
                return Color.FromArgb(color.R + val, color.G + val, color.B + val);
            }
            catch (Exception colorEx)
            {
                return Color.FromArgb(color.R - val, color.G - val, color.B - val);
            }
        }

        private void DeskNote_Shown(object sender, EventArgs e)
        {
            Note.Focus();
        }

        private void DeskNote_MouseDoubleClick(object sender, System.EventArgs e)
        {
            MessageBox.Show("Double Click", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void deleteBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeskNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = DeskNote_Delete();
            }
        }

        private bool DeskNote_Delete()
        {
            bool canc_state = true;
            DialogResult dr = MessageBox.Show(Properties.Messages.DeleteNote, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    File.Delete(NoteFile);
                    canc_state = false;
                }
                catch (Exception fileEx)
                {
                    MessageBox.Show(fileEx.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return canc_state;
        }
    }
}
