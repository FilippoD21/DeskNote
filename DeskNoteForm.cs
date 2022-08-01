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
using System.Threading;
using System.Diagnostics;

namespace DeskNote
{
    public partial class DeskNote : Form
    {

        string NoteFile;
        bool AllowSave = false;
        public TitleBarTextBox TitleBar;
        private bool CmdBoxHovering = false;
        private Rectangle UndoRectangle;

        public TextBox NoteBox 
        {
            get { return Note; }
        }
        public DateTime CreationTime 
        { 
            get { return File.GetCreationTime(NoteFile); } 
        }
        public string Filename
        {
            get { return NoteFile; }
        }

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public DeskNote(MainForm owner, string filename)
        {
            InitializeComponent();
            Owner = owner;
            Width = Properties.Settings.Default.Width;
            Height = Properties.Settings.Default.Height;
            TitleBar = new TitleBarTextBox(Handle);
            TitleBar.AcceptsReturn = true;
            TitleBar.BackColor = Color.LemonChiffon;
            TitleBar.BorderStyle = BorderStyle.None;
            TitleBar.Dock = DockStyle.Fill;
            TitleBar.Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            TitleBar.Location = new Point(0, 0);
            TitleBar.Name = "TitleBar";
            TitleBar.Size = new Size(Width-2, 16);
            TitleBar.TabIndex = 0;
            TitleBar.Leave += new EventHandler(TitleBar_Leave);
            TitleBar.KeyUp += new KeyEventHandler(TitleBar_KeyUp);
            TitleBar.Dragging += new EventHandler(TitleBar_Dragging);
            TitleBar.TextChanged += new EventHandler(Note_TextChanged);
            HeaderPanel.Controls.Add(TitleBar);
            NoteFile = filename;
            UndoRectangle = new Rectangle();
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
                        Point clientPoint = PointToClient(screenPoint);
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
                    TitleBar.Text = Text;
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
                int left = Left;
                int.TryParse(headerTxt[0], out left);
                int top = Top;
                int.TryParse(headerTxt[1], out top);
                int width = Width;
                int.TryParse(headerTxt[2], out width);
                int height = Height;
                int.TryParse(headerTxt[3], out height);
                Text = headerTxt[4];
                TitleBar.Text = headerTxt[4];
                Note.Text = lines[1];
                Note.Select(Note.Text.Length, 0);
                SetDesktopBounds(left, top, width, height);
            }
            catch (Exception fParseEx)
            {
                MessageBox.Show(Properties.Messages.ReadingNoteError + "\n" + fParseEx.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewFile();
            }

        }

        private void NewFile()
        {
            try
            {
                string title = "DeskNote " + DateTime.Now;
                File.WriteAllText(NoteFile, "0;0;0;0;" + title + Environment.NewLine);
                Text = title;
                TitleBar.Text = title;
                SetForegroundWindow(Handle);
            }
            catch (Exception fileEx)
            {
                MessageBox.Show(Properties.Messages.CreatingNoteError + "\n" + fileEx.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SaveFile()
        {
            if (AllowSave)
            {
                if (Left > 0 && Top > 0 && Width > 0 && Height > 0)
                {
                    try
                    {
                        File.WriteAllText(NoteFile,
                            Left + ";" + Top + ";" + Width + ";" + Height + ";" + TitleBar.Text + Environment.NewLine +
                            Note.Text);
                    }
                    catch (Exception fileEx)
                    {
                        MessageBox.Show(Properties.Messages.SavingNoteError + "\n" + fileEx.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Text = TitleBar.Text;
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
            Opacity = Properties.Settings.Default.Opacity;
            Color backColor = ColorTranslator.FromHtml(Properties.Settings.Default.BackColor);
            BackColor = backColor;
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
            MessageBox.Show("Double Click", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void DeleteBox_Click(object sender, EventArgs e)
        {
            Close();
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
            DialogResult dr = MessageBox.Show(Properties.Messages.DeleteNote, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    canc_state = false;
                    File.Delete(NoteFile);
                    ((MainForm)Owner).DeleteNote(this);
                }
                catch (Exception fileEx)
                {
                    MessageBox.Show(fileEx.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return canc_state;
        }

        public void SaveForUndo()
        {
            UndoRectangle = new Rectangle(Location, Size);
        }

        public void Undo()
        {
            Rectangle undo = new Rectangle();
            undo = UndoRectangle;
            Location = UndoRectangle.Location;
            Size = UndoRectangle.Size;
            UndoRectangle = undo;
        }

        private void MenuBox_MouseHover(object sender, EventArgs e)
        {
            ShowCommandPanel(true);
        }

        private void MenuBox_MouseLeave(object sender, EventArgs e)
        {
            // not needed 
        }

        private void CmdBox_MouseHover(object sender, EventArgs e)
        {
            CmdBoxHovering = true;
        }

        private void CmdBox_MouseLeave(object sender, EventArgs e)
        {
            ShowCommandPanel(false);
            CmdBoxHovering = false;
        }

        private void NewBox_Click(object sender, EventArgs e)
        {
            ((MainForm)Owner).NewNote();
        }

        private void ShowCommandPanel(bool visible)
        {
            if (visible)
            {
                CommandPanel.Visible = true;
                MenuBox.Visible = false;
            }
            else
            {
                new Thread(
                    () => {
                        Thread.Sleep(500);
                        CommandPanel.Invoke((MethodInvoker)delegate {
                            if (CommandPanel.Visible)
                            {
                                if (!CmdBoxHovering)
                                {
                                    CommandPanel.Visible = false;
                                    MenuBox.Visible = true;
                                }
                            }
                        });
                    }
                ).Start();
            }
        }

    }
}
