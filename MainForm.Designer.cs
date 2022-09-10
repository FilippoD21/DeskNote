namespace DeskNote
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topFromLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topFromRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightFromTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightFromBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomFromRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomFromLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftFromBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftFromTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeChkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.pinAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unpinAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ricaricaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewNoteToolStripMenuItem,
            this.toolStripSeparator2,
            this.restoreToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.popUpToolStripMenuItem,
            this.arrangeToolStripMenuItem,
            this.ricaricaToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.InfoToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.MouseLeave += new System.EventHandler(this.contextMenuStrip1_MouseLeave);
            // 
            // NewNoteToolStripMenuItem
            // 
            resources.ApplyResources(this.NewNoteToolStripMenuItem, "NewNoteToolStripMenuItem");
            this.NewNoteToolStripMenuItem.Name = "NewNoteToolStripMenuItem";
            this.NewNoteToolStripMenuItem.Click += new System.EventHandler(this.NewNoteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // restoreToolStripMenuItem
            // 
            resources.ApplyResources(this.restoreToolStripMenuItem, "restoreToolStripMenuItem");
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            resources.ApplyResources(this.minimizeToolStripMenuItem, "minimizeToolStripMenuItem");
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // popUpToolStripMenuItem
            // 
            this.popUpToolStripMenuItem.Image = global::DeskNote.Properties.Resources.popup;
            this.popUpToolStripMenuItem.Name = "popUpToolStripMenuItem";
            resources.ApplyResources(this.popUpToolStripMenuItem, "popUpToolStripMenuItem");
            this.popUpToolStripMenuItem.Click += new System.EventHandler(this.popUpToolStripMenuItem_Click);
            // 
            // arrangeToolStripMenuItem
            // 
            this.arrangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topFromLeftToolStripMenuItem,
            this.topFromRightToolStripMenuItem,
            this.rightFromTopToolStripMenuItem,
            this.rightFromBottomToolStripMenuItem,
            this.bottomFromRightToolStripMenuItem,
            this.bottomFromLeftToolStripMenuItem,
            this.leftFromBottomToolStripMenuItem,
            this.leftFromTopToolStripMenuItem,
            this.resizeChkToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.toolStripSeparator3,
            this.pinAllToolStripMenuItem,
            this.unpinAllToolStripMenuItem});
            this.arrangeToolStripMenuItem.Image = global::DeskNote.Properties.Resources.arrange;
            this.arrangeToolStripMenuItem.Name = "arrangeToolStripMenuItem";
            resources.ApplyResources(this.arrangeToolStripMenuItem, "arrangeToolStripMenuItem");
            // 
            // topFromLeftToolStripMenuItem
            // 
            this.topFromLeftToolStripMenuItem.Image = global::DeskNote.Properties.Resources.arrange_top_left;
            this.topFromLeftToolStripMenuItem.Name = "topFromLeftToolStripMenuItem";
            resources.ApplyResources(this.topFromLeftToolStripMenuItem, "topFromLeftToolStripMenuItem");
            this.topFromLeftToolStripMenuItem.Click += new System.EventHandler(this.topFromLeftToolStripMenuItem_Click);
            // 
            // topFromRightToolStripMenuItem
            // 
            this.topFromRightToolStripMenuItem.Image = global::DeskNote.Properties.Resources.arrange_top_right;
            this.topFromRightToolStripMenuItem.Name = "topFromRightToolStripMenuItem";
            resources.ApplyResources(this.topFromRightToolStripMenuItem, "topFromRightToolStripMenuItem");
            this.topFromRightToolStripMenuItem.Click += new System.EventHandler(this.topFromRightToolStripMenuItem_Click);
            // 
            // rightFromTopToolStripMenuItem
            // 
            this.rightFromTopToolStripMenuItem.Image = global::DeskNote.Properties.Resources.arrange_right_top;
            this.rightFromTopToolStripMenuItem.Name = "rightFromTopToolStripMenuItem";
            resources.ApplyResources(this.rightFromTopToolStripMenuItem, "rightFromTopToolStripMenuItem");
            this.rightFromTopToolStripMenuItem.Click += new System.EventHandler(this.rightFromTopToolStripMenuItem_Click);
            // 
            // rightFromBottomToolStripMenuItem
            // 
            this.rightFromBottomToolStripMenuItem.Image = global::DeskNote.Properties.Resources.arrange_right_bottom;
            this.rightFromBottomToolStripMenuItem.Name = "rightFromBottomToolStripMenuItem";
            resources.ApplyResources(this.rightFromBottomToolStripMenuItem, "rightFromBottomToolStripMenuItem");
            this.rightFromBottomToolStripMenuItem.Click += new System.EventHandler(this.rightFromBottomToolStripMenuItem_Click);
            // 
            // bottomFromRightToolStripMenuItem
            // 
            this.bottomFromRightToolStripMenuItem.Image = global::DeskNote.Properties.Resources.arrange_bottom_right;
            this.bottomFromRightToolStripMenuItem.Name = "bottomFromRightToolStripMenuItem";
            resources.ApplyResources(this.bottomFromRightToolStripMenuItem, "bottomFromRightToolStripMenuItem");
            this.bottomFromRightToolStripMenuItem.Click += new System.EventHandler(this.bottomFromRightToolStripMenuItem_Click);
            // 
            // bottomFromLeftToolStripMenuItem
            // 
            this.bottomFromLeftToolStripMenuItem.Image = global::DeskNote.Properties.Resources.arrange_bottom_left;
            this.bottomFromLeftToolStripMenuItem.Name = "bottomFromLeftToolStripMenuItem";
            resources.ApplyResources(this.bottomFromLeftToolStripMenuItem, "bottomFromLeftToolStripMenuItem");
            this.bottomFromLeftToolStripMenuItem.Click += new System.EventHandler(this.bottomFromLeftToolStripMenuItem_Click);
            // 
            // leftFromBottomToolStripMenuItem
            // 
            this.leftFromBottomToolStripMenuItem.Image = global::DeskNote.Properties.Resources.arrange_left_bottom;
            this.leftFromBottomToolStripMenuItem.Name = "leftFromBottomToolStripMenuItem";
            resources.ApplyResources(this.leftFromBottomToolStripMenuItem, "leftFromBottomToolStripMenuItem");
            this.leftFromBottomToolStripMenuItem.Click += new System.EventHandler(this.leftFromBottomToolStripMenuItem_Click);
            // 
            // leftFromTopToolStripMenuItem
            // 
            this.leftFromTopToolStripMenuItem.Image = global::DeskNote.Properties.Resources.arrange_left_top;
            this.leftFromTopToolStripMenuItem.Name = "leftFromTopToolStripMenuItem";
            resources.ApplyResources(this.leftFromTopToolStripMenuItem, "leftFromTopToolStripMenuItem");
            this.leftFromTopToolStripMenuItem.Click += new System.EventHandler(this.leftFromTopToolStripMenuItem_Click);
            // 
            // resizeChkToolStripMenuItem
            // 
            this.resizeChkToolStripMenuItem.CheckOnClick = true;
            this.resizeChkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1});
            this.resizeChkToolStripMenuItem.Name = "resizeChkToolStripMenuItem";
            resources.ApplyResources(this.resizeChkToolStripMenuItem, "resizeChkToolStripMenuItem");
            this.resizeChkToolStripMenuItem.Click += new System.EventHandler(this.resizeChkToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            resources.ApplyResources(this.settingsToolStripMenuItem1, "settingsToolStripMenuItem1");
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            resources.ApplyResources(this.undoToolStripMenuItem, "undoToolStripMenuItem");
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // pinAllToolStripMenuItem
            // 
            this.pinAllToolStripMenuItem.Image = global::DeskNote.Properties.Resources.pin_on_dark;
            this.pinAllToolStripMenuItem.Name = "pinAllToolStripMenuItem";
            resources.ApplyResources(this.pinAllToolStripMenuItem, "pinAllToolStripMenuItem");
            this.pinAllToolStripMenuItem.Click += new System.EventHandler(this.pinAllToolStripMenuItem_Click);
            // 
            // unpinAllToolStripMenuItem
            // 
            this.unpinAllToolStripMenuItem.Image = global::DeskNote.Properties.Resources.pin_off_dark;
            this.unpinAllToolStripMenuItem.Name = "unpinAllToolStripMenuItem";
            resources.ApplyResources(this.unpinAllToolStripMenuItem, "unpinAllToolStripMenuItem");
            this.unpinAllToolStripMenuItem.Click += new System.EventHandler(this.unpinAllToolStripMenuItem_Click);
            // 
            // ricaricaToolStripMenuItem
            // 
            this.ricaricaToolStripMenuItem.Image = global::DeskNote.Properties.Resources.reload;
            this.ricaricaToolStripMenuItem.Name = "ricaricaToolStripMenuItem";
            resources.ApplyResources(this.ricaricaToolStripMenuItem, "ricaricaToolStripMenuItem");
            this.ricaricaToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::DeskNote.Properties.Resources.gear;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.Image = global::DeskNote.Properties.Resources.info;
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            resources.ApplyResources(this.InfoToolStripMenuItem, "InfoToolStripMenuItem");
            this.InfoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem NewNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ricaricaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem popUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topFromLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topFromRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightFromTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightFromBottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomFromRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomFromLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftFromBottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftFromTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem resizeChkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pinAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unpinAllToolStripMenuItem;
    }
}