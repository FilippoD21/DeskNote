using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace DeskNote
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int NEWNOTE_HOTKEY_ID = 1;
        const int POPUP_HOTKEY_ID = 2;

        string AppFolder;
        Size desktopArea = SystemInformation.WorkingArea.Size;
        SettingsForm SettingsFrm;
        List<DeskNote> DeskNotes;

        public MainForm()
        {
            InitializeComponent();
            DeskNotes = new List<DeskNote>();

            // Alt = 1, Ctrl = 2, Shift = 4, Win = 8
            // Register New note shortcut
            int modKey = 0;
            modKey += Properties.Settings.Default.AltKey ? 1 : 0;
            modKey += Properties.Settings.Default.CtrlKey ? 2 : 0;
            modKey += Properties.Settings.Default.ShiftKey ? 4 : 0;
            modKey += Properties.Settings.Default.WinKey ? 8 : 0;
            int key = Properties.Settings.Default.Key;
            RegisterHotKey(this.Handle, NEWNOTE_HOTKEY_ID, modKey, key);

            // Register Pop up notes shortcut
            modKey = 0;
            modKey += Properties.Settings.Default.AltPopKey ? 1 : 0;
            modKey += Properties.Settings.Default.CtrlPopKey ? 2 : 0;
            modKey += Properties.Settings.Default.ShiftPopKey ? 4 : 0;
            modKey += Properties.Settings.Default.WinPopKey ? 8 : 0;
            key = Properties.Settings.Default.KeyPop;
            RegisterHotKey(this.Handle, POPUP_HOTKEY_ID, modKey, key);

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                switch (m.WParam.ToInt32())
                {
                    case NEWNOTE_HOTKEY_ID: 
                        NewNote(); 
                        break;
                    case POPUP_HOTKEY_ID: 
                        PopUpNotes(); 
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            AppFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Properties.Settings.Default.AppName);

            if (Directory.Exists(AppFolder))
            {
                notifyIcon1.Text = Properties.Settings.Default.AppName;
                notifyIcon1.BalloonTipTitle = Properties.Settings.Default.AppName;
                notifyIcon1.BalloonTipText = Properties.Messages.AppDescription;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(AppFolder);
                }
                catch (Exception dirEx)
                {
                    MessageBox.Show(dirEx.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Exit();
                }
            }
            foreach (string note in Directory.GetFiles(AppFolder, "DeskNote_*.dat"))
            {
                LoadNote(note);
            }
        }

        private void LoadNote(string filename)
        {
            DeskNote Note = new DeskNote(this, filename);
            Note.Show();
            DeskNotes.Add(Note);
        }

        public void NewNote()
        {
            DeskNote Note = new DeskNote(this, Path.Combine(AppFolder, "DeskNote_" + DateTime.Now.ToString("yyyyMMddhhmmssffff") + ".dat"));
            Note.Show();
            DeskNotes.Add(Note);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    PopUpNotes();
                    break;
                case MouseButtons.Right:
                    //contextMenuStrip1.Items["minimizeToolStripMenuItem"].Enabled = WindowState == FormWindowState.Normal;
                    //contextMenuStrip1.Items["restoreToolStripMenuItem"].Enabled = WindowState == FormWindowState.Minimized;
                    contextMenuStrip1.Show(Cursor.Position);
                    break;
            }
        }

        private void ResizeWin()
        {
            Width = Width <= desktopArea.Width ? Width : desktopArea.Width;
            Height = Height <= desktopArea.Height ? Height : desktopArea.Height;
            SetDesktopLocation(Decimal.ToInt32(Math.Round((decimal)(desktopArea.Width - Width) / 2, 0)), 0);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        private void OpenSettingsForm()
        {
            if (SettingsFrm == null)
            {
                SettingsFrm = new SettingsForm();
                SettingsFrm.FormClosed += new FormClosedEventHandler(SettingsFrm_Closed);
                SettingsFrm.Show();
            }
            else SettingsFrm.Activate();
        }

        private void SettingsFrm_Closed(object sender, FormClosedEventArgs e)
        {
            SettingsFrm = null;
        }

        private void ProgInfo()
        {
            string programInfo =
                Properties.Settings.Default.AppName + "\n" +
                Properties.Messages.AppDescription + "\n\n" +
                "Rel. " + Properties.Settings.Default.Release + "\n\n" +
                Properties.Messages.Copyright + "\n" +
                Properties.Messages.License;
            MessageBox.Show(programInfo, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Exit()
        {
            notifyIcon1.Visible = false;
            Environment.Exit(0);
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Hide();
                this.WindowState = FormWindowState.Minimized;
            }

        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgInfo();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NewNote();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void popUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopUpNotes();
        }

        private void NewNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewNote();
        }

        private void PopUpNotes()
        {
            this.Activate();
            foreach (DeskNote Note in DeskNotes)
            {
                Note.WindowState = FormWindowState.Normal;
                Note.Focus();
            }
                
        }

        private void contextMenuStrip1_MouseEnter(object sender, EventArgs e)
        {
            contextMenuStrip1.Show();
            contextMenuStrip1.Focus();
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
        }
    }
}
