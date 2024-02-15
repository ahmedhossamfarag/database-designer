namespace DatabaseDesigner
{
	partial class Designer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Designer));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newIFDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newEERDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTRFKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openIFDtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openEERDtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTRFKDtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eERTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tRKSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pHPFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SceneContainer = new System.Windows.Forms.Panel();
            this.SceneTitleContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.SessionScenes = new System.Windows.Forms.Panel();
            this.SScenes = new System.Windows.Forms.FlowLayoutPanel();
            this.SMover = new DatabaseDesigner.Views.Scenes.Base.PanelMover();
            this.csharpFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SessionScenes.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.createToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1182, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newIFDToolStripMenuItem,
            this.newEERDToolStripMenuItem,
            this.newTRFKToolStripMenuItem});
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.ShowShortcutKeys = false;
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // newIFDToolStripMenuItem
            // 
            this.newIFDToolStripMenuItem.Name = "newIFDToolStripMenuItem";
            this.newIFDToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.newIFDToolStripMenuItem.Text = "New IFD";
            this.newIFDToolStripMenuItem.Click += new System.EventHandler(this.NewIFDToolStripMenuItem_Click);
            // 
            // newEERDToolStripMenuItem
            // 
            this.newEERDToolStripMenuItem.Name = "newEERDToolStripMenuItem";
            this.newEERDToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.newEERDToolStripMenuItem.Text = "New EERD";
            this.newEERDToolStripMenuItem.Click += new System.EventHandler(this.NewEERDToolStripMenuItem_Click);
            // 
            // newTRFKToolStripMenuItem
            // 
            this.newTRFKToolStripMenuItem.Name = "newTRFKToolStripMenuItem";
            this.newTRFKToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.newTRFKToolStripMenuItem.Text = "New TRFKD";
            this.newTRFKToolStripMenuItem.Click += new System.EventHandler(this.NewTRFKToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openIFDtoolStripMenuItem,
            this.openEERDtoolStripMenuItem,
            this.openTRFKDtoolStripMenuItem,
            this.openDBToolStripMenuItem});
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // openIFDtoolStripMenuItem
            // 
            this.openIFDtoolStripMenuItem.Name = "openIFDtoolStripMenuItem";
            this.openIFDtoolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.openIFDtoolStripMenuItem.Text = "Open IFD";
            this.openIFDtoolStripMenuItem.Click += new System.EventHandler(this.OpenIFDtoolStripMenuItem_Click);
            // 
            // openEERDtoolStripMenuItem
            // 
            this.openEERDtoolStripMenuItem.Name = "openEERDtoolStripMenuItem";
            this.openEERDtoolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.openEERDtoolStripMenuItem.Text = "Open EERD";
            this.openEERDtoolStripMenuItem.Click += new System.EventHandler(this.OpenEERDtoolStripMenuItem_Click);
            // 
            // openTRFKDtoolStripMenuItem
            // 
            this.openTRFKDtoolStripMenuItem.Name = "openTRFKDtoolStripMenuItem";
            this.openTRFKDtoolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.openTRFKDtoolStripMenuItem.Text = "Open TRFKD";
            this.openTRFKDtoolStripMenuItem.Click += new System.EventHandler(this.OpenTRFKDtoolStripMenuItem_Click);
            // 
            // openDBToolStripMenuItem
            // 
            this.openDBToolStripMenuItem.Name = "openDBToolStripMenuItem";
            this.openDBToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.openDBToolStripMenuItem.Text = "Open DB";
            this.openDBToolStripMenuItem.Click += new System.EventHandler(this.OpenDBToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(221, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripSeparator4});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(221, 6);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eERTablesToolStripMenuItem,
            this.tRKSceneToolStripMenuItem,
            this.sQLFileToolStripMenuItem,
            this.pHPFileToolStripMenuItem,
            this.csharpFileToolStripMenuItem});
            this.createToolStripMenuItem.Enabled = false;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.createToolStripMenuItem.Text = "&Create";
            // 
            // eERTablesToolStripMenuItem
            // 
            this.eERTablesToolStripMenuItem.Name = "eERTablesToolStripMenuItem";
            this.eERTablesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.eERTablesToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.eERTablesToolStripMenuItem.Text = "EER Tables";
            this.eERTablesToolStripMenuItem.Click += new System.EventHandler(this.EERTablesToolStripMenuItem_Click);
            // 
            // tRKSceneToolStripMenuItem
            // 
            this.tRKSceneToolStripMenuItem.Name = "tRKSceneToolStripMenuItem";
            this.tRKSceneToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.tRKSceneToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.tRKSceneToolStripMenuItem.Text = "TRK Scene";
            this.tRKSceneToolStripMenuItem.Click += new System.EventHandler(this.tRKSceneToolStripMenuItem_Click);
            // 
            // sQLFileToolStripMenuItem
            // 
            this.sQLFileToolStripMenuItem.Name = "sQLFileToolStripMenuItem";
            this.sQLFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.sQLFileToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.sQLFileToolStripMenuItem.Text = "SQL File";
            this.sQLFileToolStripMenuItem.Click += new System.EventHandler(this.SQLFileToolStripMenuItem_Click);
            // 
            // pHPFileToolStripMenuItem
            // 
            this.pHPFileToolStripMenuItem.Name = "pHPFileToolStripMenuItem";
            this.pHPFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.pHPFileToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.pHPFileToolStripMenuItem.Text = "PHP File";
            this.pHPFileToolStripMenuItem.Click += new System.EventHandler(this.PHPFileToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scenesToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // scenesToolStripMenuItem
            // 
            this.scenesToolStripMenuItem.Name = "scenesToolStripMenuItem";
            this.scenesToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.scenesToolStripMenuItem.Text = "Show Scenes Window";
            this.scenesToolStripMenuItem.Click += new System.EventHandler(this.ScenesToolStripMenuItem_Click);
            // 
            // SceneContainer
            // 
            this.SceneContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SceneContainer.Location = new System.Drawing.Point(0, 30);
            this.SceneContainer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.SceneContainer.Name = "SceneContainer";
            this.SceneContainer.Size = new System.Drawing.Size(1182, 692);
            this.SceneContainer.TabIndex = 1;
            // 
            // SceneTitleContainer
            // 
            this.SceneTitleContainer.BackColor = System.Drawing.SystemColors.Control;
            this.SceneTitleContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SceneTitleContainer.Location = new System.Drawing.Point(0, 723);
            this.SceneTitleContainer.Name = "SceneTitleContainer";
            this.SceneTitleContainer.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.SceneTitleContainer.Size = new System.Drawing.Size(1182, 30);
            this.SceneTitleContainer.TabIndex = 2;
            // 
            // SessionScenes
            // 
            this.SessionScenes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SessionScenes.Controls.Add(this.SScenes);
            this.SessionScenes.Controls.Add(this.SMover);
            this.SessionScenes.Location = new System.Drawing.Point(775, 174);
            this.SessionScenes.Name = "SessionScenes";
            this.SessionScenes.Size = new System.Drawing.Size(200, 371);
            this.SessionScenes.TabIndex = 3;
            this.SessionScenes.Visible = false;
            // 
            // SScenes
            // 
            this.SScenes.AutoScroll = true;
            this.SScenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SScenes.Location = new System.Drawing.Point(0, 10);
            this.SScenes.Margin = new System.Windows.Forms.Padding(0);
            this.SScenes.Name = "SScenes";
            this.SScenes.Size = new System.Drawing.Size(196, 357);
            this.SScenes.TabIndex = 1;
            // 
            // SMover
            // 
            this.SMover.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SMover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SMover.Dock = System.Windows.Forms.DockStyle.Top;
            this.SMover.Location = new System.Drawing.Point(0, 0);
            this.SMover.Name = "SMover";
            this.SMover.Size = new System.Drawing.Size(196, 10);
            this.SMover.TabIndex = 0;
            // 
            // csharpFileToolStripMenuItem
            // 
            this.csharpFileToolStripMenuItem.Name = "csharpFileToolStripMenuItem";
            this.csharpFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.csharpFileToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.csharpFileToolStripMenuItem.Text = "Csharp File";
            this.csharpFileToolStripMenuItem.Click += new System.EventHandler(this.csharpFileToolStripMenuItem_Click);
            // 
            // Designer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.SessionScenes);
            this.Controls.Add(this.SceneTitleContainer);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.SceneContainer);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Designer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Designer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Designer_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Designer_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Designer_KeyUp);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.SessionScenes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.MenuStrip menuStrip;
		public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		public System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		public System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		public System.Windows.Forms.ToolStripMenuItem newIFDToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem newEERDToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem newTRFKToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem openIFDtoolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem openEERDtoolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem openTRFKDtoolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem eERTablesToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem sQLFileToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem pHPFileToolStripMenuItem;
		public System.Windows.Forms.Panel SceneContainer;
		private System.Windows.Forms.FlowLayoutPanel SceneTitleContainer;
		public System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openDBToolStripMenuItem;
		private System.Windows.Forms.Panel SessionScenes;
		private System.Windows.Forms.FlowLayoutPanel SScenes;
		private Views.Scenes.Base.PanelMover SMover;
		private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scenesToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem tRKSceneToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem csharpFileToolStripMenuItem;
    }
}

