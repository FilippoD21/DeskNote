using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DeskNote
{
    public partial class SettingsForm : Form
    {
        private int KeyNew;
        private int KeyPop;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // New Note shortcut
            CtrlChk.Checked = Properties.Settings.Default.CtrlKey;
            AltChk.Checked = Properties.Settings.Default.AltKey;
            ShiftChk.Checked = Properties.Settings.Default.ShiftKey;
            WinChk.Checked = Properties.Settings.Default.WinKey;
            KeyNew = Properties.Settings.Default.Key;
            KeyTxt.Text = ((Keys)KeyNew).ToString();

            // Pop up Notes shortcut
            CtrlPopChk.Checked = Properties.Settings.Default.CtrlPopKey;
            AltPopChk.Checked = Properties.Settings.Default.AltPopKey;
            ShiftPopChk.Checked = Properties.Settings.Default.ShiftPopKey;
            WinPopChk.Checked = Properties.Settings.Default.WinPopKey;
            KeyPop = Properties.Settings.Default.KeyPop;
            KeyPopTxt.Text = ((Keys)KeyPop).ToString();

            // initial size
            WidthTxt.Text = Properties.Settings.Default.Width.ToString();
            HeightTxt.Text = Properties.Settings.Default.Height.ToString();

            ColorValueTxt.Text = Properties.Settings.Default.BackColor;
            ColorBox.BackColor = ColorTranslator.FromHtml(ColorValueTxt.Text);
            OpacityTxt.Text = Convert.ToInt16(Properties.Settings.Default.Opacity * 100d).ToString();
            OpacityBar.Value = Convert.ToInt16(Properties.Settings.Default.Opacity * 100d);
        }

        private void ColorBox_Click(object sender, EventArgs e)
        {
            DialogResult res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                ColorBox.BackColor = colorDialog1.Color;
                ColorValueTxt.Text = ColorTranslator.ToHtml(colorDialog1.Color);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // New Note shortcut
            Properties.Settings.Default.CtrlKey = CtrlChk.Checked;
            Properties.Settings.Default.AltKey = AltChk.Checked;
            Properties.Settings.Default.ShiftKey = ShiftChk.Checked;
            Properties.Settings.Default.WinKey = WinChk.Checked;
            Properties.Settings.Default.Key = KeyNew;

            // Pop up notes shortcut
            Properties.Settings.Default.CtrlPopKey = CtrlPopChk.Checked;
            Properties.Settings.Default.AltPopKey = AltPopChk.Checked;
            Properties.Settings.Default.ShiftPopKey = ShiftPopChk.Checked;
            Properties.Settings.Default.WinPopKey = WinPopChk.Checked;
            Properties.Settings.Default.KeyPop = KeyPop;

            // inital size
            int w = Properties.Settings.Default.Width;
            int.TryParse(WidthTxt.Text, out w);
            Properties.Settings.Default.Width = w;
            int h = Properties.Settings.Default.Height;
            int.TryParse(WidthTxt.Text, out h);
            Properties.Settings.Default.Width = h;

            int opc = Convert.ToInt16(Properties.Settings.Default.Opacity * 100d);
            int.TryParse(OpacityTxt.Text, out opc);
            Properties.Settings.Default.Opacity = opc / 100d;

            try
            {
                ColorTranslator.FromHtml(ColorValueTxt.Text);
                Properties.Settings.Default.BackColor = ColorValueTxt.Text.ToUpper();
            }
            catch
            {
                ColorValueTxt.Text = ColorTranslator.ToHtml(ColorBox.BackColor);
                Properties.Settings.Default.BackColor = ColorValueTxt.Text.ToUpper();
            }

            Properties.Settings.Default.Save();
            Hide();
            DialogResult res = MessageBox.Show(Properties.Messages.ReloadProgram, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
                Application.Restart();
            Close();
        }

        private void OpacityBar_Scroll(object sender, EventArgs e)
        {
            //MainForm.Opacity = (double)OpacityBar.Value / 100;
            OpacityTxt.Text = OpacityBar.Value.ToString();
        }

        private void ColorValueTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                ColorBox.BackColor = ColorTranslator.FromHtml(ColorValueTxt.Text);
            }
            catch
            {
                ColorValueTxt.Text = ColorTranslator.ToHtml(ColorBox.BackColor);
                MessageBox.Show(Properties.Messages.InvalidColor, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void OpacityTxt_Leave(object sender, EventArgs e)
        {
            SyncOpacityBarValue();
        }

        private void OpacityTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SyncOpacityBarValue();
        }

        private void SyncOpacityBarValue()
        {
            int val = OpacityBar.Value;
            int.TryParse(OpacityTxt.Text, out val);

            if (val >= 0 && val <= 100) OpacityBar.Value = val;
        }

        private bool IsValidKey(Keys key)
        {
            bool isValid = true;
            switch (key)
            {
                case Keys.Control:
                case Keys.ControlKey:
                case Keys.Shift:
                case Keys.ShiftKey:
                case Keys.Alt:
                case Keys.LWin:
                case Keys.RWin:
                case Keys.CapsLock:
                case Keys.Tab:
                case Keys.Escape:
                case Keys.Menu:
                    isValid = false;
                    break;
            }
            return isValid;
        }
        
        private void KeyTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsValidKey(e.KeyCode))
            {
                KeyTxt.Text = e.KeyCode.ToString();
                KeyNew = e.KeyValue;
            }
        }

        private void KeyPopTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsValidKey(e.KeyCode))
            {
                KeyPopTxt.Text = e.KeyCode.ToString();
                KeyPop = e.KeyValue;
            }
        }

        private void ValidateSaving()
        {
            int val;
            SaveBtn.Enabled =
                ((CtrlChk.Checked || AltChk.Checked || ShiftChk.Checked || WinChk.Checked) && !string.IsNullOrEmpty(KeyTxt.Text)) &&
                ((CtrlPopChk.Checked || AltPopChk.Checked || ShiftPopChk.Checked || WinPopChk.Checked) && !string.IsNullOrEmpty(KeyPopTxt.Text)) &&
                int.TryParse(WidthTxt.Text, out val) &&
                int.TryParse(HeightTxt.Text, out val);
        }

        private void WidthTxt_TextChanged(object sender, EventArgs e)
        {
            ValidateSaving();
            int val;
            if (!int.TryParse(WidthTxt.Text, out val))
                MessageBox.Show(Properties.Messages.InvalidValue, Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void HeightTxt_TextChanged(object sender, EventArgs e)
        {
            ValidateSaving();
            int val;
            if (!int.TryParse(HeightTxt.Text, out val))
                MessageBox.Show(Properties.Messages.InvalidValue, Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void CtrlChk_CheckedChanged(object sender, EventArgs e)
        {
            ValidateSaving();
        }

        private void AltChk_CheckedChanged(object sender, EventArgs e)
        {
            ValidateSaving();
        }

        private void ShiftChk_CheckedChanged(object sender, EventArgs e)
        {
            ValidateSaving();
        }

        private void WinChk_CheckedChanged(object sender, EventArgs e)
        {
            ValidateSaving();
        }

        private void CtrlPopChk_CheckedChanged(object sender, EventArgs e)
        {
            ValidateSaving();
        }

        private void AltPopChk_CheckedChanged(object sender, EventArgs e)
        {
            ValidateSaving();
        }

        private void ShiftPopChk_CheckedChanged(object sender, EventArgs e)
        {
            ValidateSaving();
        }

        private void WinPopChk_CheckedChanged(object sender, EventArgs e)
        {
            ValidateSaving();
        }

        private void KeyPopTxt_TextChanged(object sender, EventArgs e)
        {
            ValidateSaving();
        }

        private void KeyTxt_TextChanged(object sender, EventArgs e)
        {
            ValidateSaving();
        }

    }
}
