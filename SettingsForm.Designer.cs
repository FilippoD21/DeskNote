namespace DeskNote
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.CtrlChk = new System.Windows.Forms.CheckBox();
            this.AltChk = new System.Windows.Forms.CheckBox();
            this.ShiftChk = new System.Windows.Forms.CheckBox();
            this.WinChk = new System.Windows.Forms.CheckBox();
            this.KeyTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorValueTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OpacityBar = new System.Windows.Forms.TrackBar();
            this.OpacityTxt = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.KeyPopTxt = new System.Windows.Forms.TextBox();
            this.WinPopChk = new System.Windows.Forms.CheckBox();
            this.ShiftPopChk = new System.Windows.Forms.CheckBox();
            this.AltPopChk = new System.Windows.Forms.CheckBox();
            this.CtrlPopChk = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.WidthTxt = new System.Windows.Forms.TextBox();
            this.HeightTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ColorBox = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ResizeChk = new System.Windows.Forms.CheckBox();
            this.ResizeOnWTxt = new System.Windows.Forms.TextBox();
            this.ResizeOnHTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlChk
            // 
            resources.ApplyResources(this.CtrlChk, "CtrlChk");
            this.CtrlChk.Checked = true;
            this.CtrlChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CtrlChk.Name = "CtrlChk";
            this.CtrlChk.UseVisualStyleBackColor = true;
            this.CtrlChk.CheckedChanged += new System.EventHandler(this.CtrlChk_CheckedChanged);
            // 
            // AltChk
            // 
            resources.ApplyResources(this.AltChk, "AltChk");
            this.AltChk.Name = "AltChk";
            this.AltChk.UseVisualStyleBackColor = true;
            this.AltChk.CheckedChanged += new System.EventHandler(this.AltChk_CheckedChanged);
            // 
            // ShiftChk
            // 
            resources.ApplyResources(this.ShiftChk, "ShiftChk");
            this.ShiftChk.Name = "ShiftChk";
            this.ShiftChk.UseVisualStyleBackColor = true;
            this.ShiftChk.CheckedChanged += new System.EventHandler(this.ShiftChk_CheckedChanged);
            // 
            // WinChk
            // 
            resources.ApplyResources(this.WinChk, "WinChk");
            this.WinChk.Name = "WinChk";
            this.WinChk.UseVisualStyleBackColor = true;
            this.WinChk.CheckedChanged += new System.EventHandler(this.WinChk_CheckedChanged);
            // 
            // KeyTxt
            // 
            resources.ApplyResources(this.KeyTxt, "KeyTxt");
            this.KeyTxt.Name = "KeyTxt";
            this.KeyTxt.TextChanged += new System.EventHandler(this.KeyTxt_TextChanged);
            this.KeyTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyTxt_KeyUp);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ColorValueTxt
            // 
            resources.ApplyResources(this.ColorValueTxt, "ColorValueTxt");
            this.ColorValueTxt.Name = "ColorValueTxt";
            this.ColorValueTxt.Leave += new System.EventHandler(this.ColorValueTxt_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // OpacityBar
            // 
            this.OpacityBar.LargeChange = 10;
            resources.ApplyResources(this.OpacityBar, "OpacityBar");
            this.OpacityBar.Maximum = 100;
            this.OpacityBar.Name = "OpacityBar";
            this.OpacityBar.SmallChange = 5;
            this.OpacityBar.TickFrequency = 5;
            this.OpacityBar.Value = 100;
            this.OpacityBar.Scroll += new System.EventHandler(this.OpacityBar_Scroll);
            // 
            // OpacityTxt
            // 
            resources.ApplyResources(this.OpacityTxt, "OpacityTxt");
            this.OpacityTxt.Name = "OpacityTxt";
            this.OpacityTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OpacityTxt_KeyUp);
            this.OpacityTxt.Leave += new System.EventHandler(this.OpacityTxt_Leave);
            // 
            // SaveBtn
            // 
            resources.ApplyResources(this.SaveBtn, "SaveBtn");
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // KeyPopTxt
            // 
            resources.ApplyResources(this.KeyPopTxt, "KeyPopTxt");
            this.KeyPopTxt.Name = "KeyPopTxt";
            this.KeyPopTxt.TextChanged += new System.EventHandler(this.KeyPopTxt_TextChanged);
            this.KeyPopTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPopTxt_KeyUp);
            // 
            // WinPopChk
            // 
            resources.ApplyResources(this.WinPopChk, "WinPopChk");
            this.WinPopChk.Name = "WinPopChk";
            this.WinPopChk.UseVisualStyleBackColor = true;
            this.WinPopChk.CheckedChanged += new System.EventHandler(this.WinPopChk_CheckedChanged);
            // 
            // ShiftPopChk
            // 
            resources.ApplyResources(this.ShiftPopChk, "ShiftPopChk");
            this.ShiftPopChk.Checked = true;
            this.ShiftPopChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShiftPopChk.Name = "ShiftPopChk";
            this.ShiftPopChk.UseVisualStyleBackColor = true;
            this.ShiftPopChk.CheckedChanged += new System.EventHandler(this.ShiftPopChk_CheckedChanged);
            // 
            // AltPopChk
            // 
            resources.ApplyResources(this.AltPopChk, "AltPopChk");
            this.AltPopChk.Name = "AltPopChk";
            this.AltPopChk.UseVisualStyleBackColor = true;
            this.AltPopChk.CheckedChanged += new System.EventHandler(this.AltPopChk_CheckedChanged);
            // 
            // CtrlPopChk
            // 
            resources.ApplyResources(this.CtrlPopChk, "CtrlPopChk");
            this.CtrlPopChk.Checked = true;
            this.CtrlPopChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CtrlPopChk.Name = "CtrlPopChk";
            this.CtrlPopChk.UseVisualStyleBackColor = true;
            this.CtrlPopChk.CheckedChanged += new System.EventHandler(this.CtrlPopChk_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // WidthTxt
            // 
            resources.ApplyResources(this.WidthTxt, "WidthTxt");
            this.WidthTxt.Name = "WidthTxt";
            this.WidthTxt.TextChanged += new System.EventHandler(this.WidthTxt_TextChanged);
            // 
            // HeightTxt
            // 
            resources.ApplyResources(this.HeightTxt, "HeightTxt");
            this.HeightTxt.Name = "HeightTxt";
            this.HeightTxt.TextChanged += new System.EventHandler(this.HeightTxt_TextChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // ColorBox
            // 
            this.ColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ColorBox, "ColorBox");
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.TabStop = false;
            this.ColorBox.Click += new System.EventHandler(this.ColorBox_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // ResizeChk
            // 
            resources.ApplyResources(this.ResizeChk, "ResizeChk");
            this.ResizeChk.Name = "ResizeChk";
            this.ResizeChk.UseVisualStyleBackColor = true;
            // 
            // ResizeOnWTxt
            // 
            resources.ApplyResources(this.ResizeOnWTxt, "ResizeOnWTxt");
            this.ResizeOnWTxt.Name = "ResizeOnWTxt";
            this.ResizeOnWTxt.TextChanged += new System.EventHandler(this.ResizeValueTxt_TextChanged);
            // 
            // ResizeOnHTxt
            // 
            resources.ApplyResources(this.ResizeOnHTxt, "ResizeOnHTxt");
            this.ResizeOnHTxt.Name = "ResizeOnHTxt";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.SaveBtn;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ResizeOnHTxt);
            this.Controls.Add(this.ResizeOnWTxt);
            this.Controls.Add(this.ResizeChk);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.HeightTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.WidthTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.KeyPopTxt);
            this.Controls.Add(this.WinPopChk);
            this.Controls.Add(this.ShiftPopChk);
            this.Controls.Add(this.AltPopChk);
            this.Controls.Add(this.CtrlPopChk);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.ColorBox);
            this.Controls.Add(this.OpacityTxt);
            this.Controls.Add(this.OpacityBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ColorValueTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyTxt);
            this.Controls.Add(this.WinChk);
            this.Controls.Add(this.ShiftChk);
            this.Controls.Add(this.AltChk);
            this.Controls.Add(this.CtrlChk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OpacityBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox CtrlChk;
        private System.Windows.Forms.CheckBox AltChk;
        private System.Windows.Forms.CheckBox ShiftChk;
        private System.Windows.Forms.CheckBox WinChk;
        private System.Windows.Forms.TextBox KeyTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox ColorValueTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar OpacityBar;
        private System.Windows.Forms.TextBox OpacityTxt;
        private System.Windows.Forms.PictureBox ColorBox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox KeyPopTxt;
        private System.Windows.Forms.CheckBox WinPopChk;
        private System.Windows.Forms.CheckBox ShiftPopChk;
        private System.Windows.Forms.CheckBox AltPopChk;
        private System.Windows.Forms.CheckBox CtrlPopChk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox WidthTxt;
        private System.Windows.Forms.TextBox HeightTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ResizeChk;
        private System.Windows.Forms.TextBox ResizeOnWTxt;
        private System.Windows.Forms.TextBox ResizeOnHTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}