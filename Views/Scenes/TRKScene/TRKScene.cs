using DatabaseDesigner.Controllers;
using DatabaseDesigner.Controllers.Base;
using DatabaseDesigner.Controllers.SaveRead;
using DatabaseDesigner.Models;
using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.SQL;
using DatabaseDesigner.Views.Scenes.Base;
using DatabaseDesigner.Views.Scenes.TEScene;
using DatabaseDesigner.Views.Scenes.Scene5;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	enum SceneMode
	{
		AddTable,
		AddRelation,
		AddForgeinKey,
		None
	}

	internal partial class TRKScene : Scene
	{
		private Panel AddContainer;
		private Button AddFKey;
		private Button AddRelation;
		public FlowLayoutPanel FKRContainer;
		public TransparentContainer TPanel;
		private Button AddTable;

		private bool control;
		private bool move;
		private Point pastLo;
		private Point pastP;


		public TRKScene()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.AddContainer = new System.Windows.Forms.Panel();
			this.AddFKey = new System.Windows.Forms.Button();
			this.AddRelation = new System.Windows.Forms.Button();
			this.AddTable = new System.Windows.Forms.Button();
			this.FKRContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.TPanel = new DatabaseDesigner.Views.Source.TransparentContainer();
			this.AddContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// AddContainer
			// 
			this.AddContainer.Controls.Add(this.AddFKey);
			this.AddContainer.Controls.Add(this.AddRelation);
			this.AddContainer.Controls.Add(this.AddTable);
			this.AddContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.AddContainer.Location = new System.Drawing.Point(0, 565);
			this.AddContainer.Name = "AddContainer";
			this.AddContainer.Size = new System.Drawing.Size(800, 35);
			this.AddContainer.TabIndex = 1;
			// 
			// AddFKey
			// 
			this.AddFKey.FlatAppearance.BorderSize = 0;
			this.AddFKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddFKey.Location = new System.Drawing.Point(300, 0);
			this.AddFKey.Margin = new System.Windows.Forms.Padding(0);
			this.AddFKey.Name = "AddFKey";
			this.AddFKey.Size = new System.Drawing.Size(150, 35);
			this.AddFKey.TabIndex = 2;
			this.AddFKey.Text = "+ ForgienKey";
			this.AddFKey.UseVisualStyleBackColor = true;
			this.AddFKey.Click += new System.EventHandler(this.AddFKey_Click);
			// 
			// AddRelation
			// 
			this.AddRelation.FlatAppearance.BorderSize = 0;
			this.AddRelation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddRelation.Location = new System.Drawing.Point(150, 0);
			this.AddRelation.Margin = new System.Windows.Forms.Padding(0);
			this.AddRelation.Name = "AddRelation";
			this.AddRelation.Size = new System.Drawing.Size(150, 35);
			this.AddRelation.TabIndex = 1;
			this.AddRelation.Text = "+ Relation";
			this.AddRelation.UseVisualStyleBackColor = true;
			this.AddRelation.Click += new System.EventHandler(this.AddRelation_Click);
			// 
			// AddTable
			// 
			this.AddTable.FlatAppearance.BorderSize = 0;
			this.AddTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddTable.Location = new System.Drawing.Point(0, 0);
			this.AddTable.Margin = new System.Windows.Forms.Padding(0);
			this.AddTable.Name = "AddTable";
			this.AddTable.Size = new System.Drawing.Size(150, 35);
			this.AddTable.TabIndex = 0;
			this.AddTable.Text = "+ Table";
			this.AddTable.UseVisualStyleBackColor = true;
			this.AddTable.Click += new System.EventHandler(this.AddTable_Click);
			// 
			// FKRContainer
			// 
			this.FKRContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.FKRContainer.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
			this.FKRContainer.Location = new System.Drawing.Point(0, 0);
			this.FKRContainer.Name = "FKRContainer";
			this.FKRContainer.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
			this.FKRContainer.Size = new System.Drawing.Size(200, 565);
			this.FKRContainer.TabIndex = 2;
			// 
			// TPanel
			// 
			this.TPanel.BackColor = System.Drawing.Color.White;
			this.TPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TPanel.Location = new System.Drawing.Point(0, 0);
			this.TPanel.Name = "TPanel";
			this.TPanel.Size = new System.Drawing.Size(800, 600);
			this.TPanel.TabIndex = 3;
			this.TPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TPanel_MouseDown);
			this.TPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TPanel_MouseMove);
			this.TPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TPanel_MouseUp);
			// 
			// TRKScene
			// 
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.FKRContainer);
			this.Controls.Add(this.AddContainer);
			this.Controls.Add(this.TPanel);
			this.Name = "TRKScene";
			this.AddContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		private void TRKScene_Resize(object sender, EventArgs e)
		{
			Point p = TPanel.Location;
			TPanel.Location = new Point(Math.Min(FKRContainer.Width, Math.Max(p.X, Width - TPanel.Width)),
							Math.Min(0, Math.Max(p.Y, Height - TPanel.Height)));
		}

		public override void Scene_KeyDown(object sender, KeyEventArgs e)
		{

			switch (e.KeyCode)
			{
				case Keys.ControlKey: { control = true; break; }
				case Keys.Escape: { ClearMode(); break; }
			}
		}

		public override void Scene_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (control)
			{
				switch ((int)e.KeyChar)
				{
					case 26: { Record.Undo(); break; }
					case 25: { Record.Redo(); break; }
				}
			}
		}

		public override void Scene_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ControlKey)
				control = false;
		}

		private void TPanel_MouseDown(object sender, MouseEventArgs e)
		{
			move = true;
			pastP = e.Location;
			pastLo = TPanel.Location;
			TPanel.Cursor = Cursors.NoMove2D;
		}

		private void TPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (!move) return;
			int dx = e.X - pastP.X, dy = e.Y - pastP.Y;
			Point p = new Point(TPanel.Location.X + dx, TPanel.Location.Y + dy);
			TPanel.Location = new Point(Math.Min(FKRContainer.Width, Math.Max(p.X, Width - TPanel.Width)),
							Math.Min(0, Math.Max(p.Y, Height - TPanel.Height)));
		}

		private void TPanel_MouseUp(object sender, MouseEventArgs e)
		{
			move = false;
			TPanel.Cursor = Cursors.Default;
			Point l = TPanel.Location;
			Action un = () => TPanel.Location = pastLo, re = () => TPanel.Location = l;
			Record.Add((un, re));
		}

		public override void SetMenu(Designer d)
		{
			d.printToolStripMenuItem.Enabled = true;
			d.editToolStripMenuItem.Enabled = true;
			d.createToolStripMenuItem.Enabled = true;
			d.eERTablesToolStripMenuItem.Enabled = false;
			d.tRKSceneToolStripMenuItem.Enabled = false;
			d.sQLFileToolStripMenuItem.Enabled = true;
			d.pHPFileToolStripMenuItem.Enabled = false;
            d.csharpFileToolStripMenuItem.Enabled = true;
        }

		public override void Save()
		{
			TRKSave.Save(this);
		}

		public override void Print()
		{
			TableViews.ForEach(t => t.AddProperty.Visible = false);
			PrintBMP.Print(TPanel);
			TableViews.ForEach(t => t.AddProperty.Visible = true);
		}

		public override void CreateSQLFile()
		{
			TRKAnalyser tRKAnalyser = new TRKAnalyser();
			Database database = tRKAnalyser.Analyse(this);
			if(database.Tables.Any(t => !t.Keys.Any()))
			{
				InfoDialog.Of("Some Tables Has No Key");
				return;
			}
			var sql = new List<SQLOperation>();
			database.Tables.ForEach(t => sql.Add(new Create() { Table = t }));
			SQLSave.WriteSQL(sql);
			NewOpenController.NewSQL(database);
		}

        public override void CreateCsharpFile()
        {
			TRKAnalyser tRKAnalyser = new TRKAnalyser();
			Database database = tRKAnalyser.Analyse(this);
			CSharp.CreateCSharp(database);
        }

        public override void Undo()
		{
			Record.Undo();
		}

		public override void Redo()
		{
			Record.Redo();
		}
	}
}
