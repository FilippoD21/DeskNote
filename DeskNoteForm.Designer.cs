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
            this.deleteBox = new System.Windows.Forms.PictureBox();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.Note = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.deleteBox)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteBox
            // 
            this.deleteBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.deleteBox.Image = global::DeskNote.Properties.Resources.del;
            this.deleteBox.Location = new System.Drawing.Point(224, 0);
            this.deleteBox.Margin = new System.Windows.Forms.Padding(2);
            this.deleteBox.Name = "deleteBox";
            this.deleteBox.Size = new System.Drawing.Size(16, 18);
            this.deleteBox.TabIndex = 0;
            this.deleteBox.TabStop = false;
            this.deleteBox.Click += new System.EventHandler(this.deleteBox_Click);
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.deleteBox);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(5, 5);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(240, 18);
            this.HeaderPanel.TabIndex = 5;
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
            this.Load += new System.EventHandler(this.DeskNote_Load);
            this.Shown += new System.EventHandler(this.DeskNote_Shown);
            this.GotFocus += new System.EventHandler(this.Note_GotFocus);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DeskNote_MouseDoubleClick);
            this.Move += new System.EventHandler(this.DeskNote_Move);
            this.Resize += new System.EventHandler(this.DeskNote_Resize);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeskNote_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.deleteBox)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox deleteBox;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.TextBox Note;
    }
}

