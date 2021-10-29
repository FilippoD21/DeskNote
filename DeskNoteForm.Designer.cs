namespace DeskNote
{
    partial class DeskNote
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeskNote));
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.CommandPanel = new System.Windows.Forms.Panel();
            this.NewBox = new System.Windows.Forms.PictureBox();
            this.DeleteBox = new System.Windows.Forms.PictureBox();
            this.MenuBox = new System.Windows.Forms.PictureBox();
            this.Note = new System.Windows.Forms.TextBox();
            this.HeaderPanel.SuspendLayout();
            this.CommandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.CommandPanel);
            this.HeaderPanel.Controls.Add(this.MenuBox);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(5, 5);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(240, 18);
            this.HeaderPanel.TabIndex = 5;
            // 
            // CommandPanel
            // 
            this.CommandPanel.Controls.Add(this.NewBox);
            this.CommandPanel.Controls.Add(this.DeleteBox);
            this.CommandPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CommandPanel.Location = new System.Drawing.Point(191, 0);
            this.CommandPanel.Name = "CommandPanel";
            this.CommandPanel.Size = new System.Drawing.Size(33, 18);
            this.CommandPanel.TabIndex = 3;
            this.CommandPanel.Visible = false;
            // 
            // NewBox
            // 
            this.NewBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.NewBox.Image = global::DeskNote.Properties.Resources.new_thin;
            this.NewBox.Location = new System.Drawing.Point(1, 0);
            this.NewBox.Margin = new System.Windows.Forms.Padding(2);
            this.NewBox.Name = "NewBox";
            this.NewBox.Size = new System.Drawing.Size(16, 18);
            this.NewBox.TabIndex = 4;
            this.NewBox.TabStop = false;
            this.NewBox.Click += new System.EventHandler(this.NewBox_Click);
            this.NewBox.MouseLeave += new System.EventHandler(this.CmdBox_MouseLeave);
            this.NewBox.MouseHover += new System.EventHandler(this.CmdBox_MouseHover);
            // 
            // DeleteBox
            // 
            this.DeleteBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeleteBox.Image = global::DeskNote.Properties.Resources.delete_thin;
            this.DeleteBox.Location = new System.Drawing.Point(17, 0);
            this.DeleteBox.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteBox.Name = "DeleteBox";
            this.DeleteBox.Size = new System.Drawing.Size(16, 18);
            this.DeleteBox.TabIndex = 3;
            this.DeleteBox.TabStop = false;
            this.DeleteBox.Click += new System.EventHandler(this.DeleteBox_Click);
            this.DeleteBox.MouseLeave += new System.EventHandler(this.CmdBox_MouseLeave);
            this.DeleteBox.MouseHover += new System.EventHandler(this.CmdBox_MouseHover);
            // 
            // MenuBox
            // 
            this.MenuBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.MenuBox.Image = global::DeskNote.Properties.Resources.menu_thin;
            this.MenuBox.Location = new System.Drawing.Point(224, 0);
            this.MenuBox.Margin = new System.Windows.Forms.Padding(2);
            this.MenuBox.Name = "MenuBox";
            this.MenuBox.Size = new System.Drawing.Size(16, 18);
            this.MenuBox.TabIndex = 2;
            this.MenuBox.TabStop = false;
            this.MenuBox.MouseLeave += new System.EventHandler(this.MenuBox_MouseLeave);
            this.MenuBox.MouseHover += new System.EventHandler(this.MenuBox_MouseHover);
            // 
            // Note
            // 
            this.Note.BackColor = System.Drawing.Color.LemonChiffon;
            this.Note.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Note.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note.Location = new System.Drawing.Point(5, 23);
            this.Note.Multiline = true;
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(240, 222);
            this.Note.TabIndex = 6;
            this.Note.TextChanged += new System.EventHandler(this.Note_TextChanged);
            // 
            // DeskNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.ControlBox = false;
            this.Controls.Add(this.Note);
            this.Controls.Add(this.HeaderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeskNote";
            this.Opacity = 0.25D;
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desktop Note";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeskNote_FormClosing);
            this.Load += new System.EventHandler(this.DeskNote_Load);
            this.Shown += new System.EventHandler(this.DeskNote_Shown);
            this.GotFocus += new System.EventHandler(this.Note_GotFocus);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DeskNote_MouseDoubleClick);
            this.Move += new System.EventHandler(this.DeskNote_Move);
            this.Resize += new System.EventHandler(this.DeskNote_Resize);
            this.HeaderPanel.ResumeLayout(false);
            this.CommandPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeleteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Note_TextChanged1(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.TextBox Note;
        private System.Windows.Forms.PictureBox MenuBox;
        private System.Windows.Forms.Panel CommandPanel;
        private System.Windows.Forms.PictureBox DeleteBox;
        private System.Windows.Forms.PictureBox NewBox;
    }
}

