using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseDesigner.Views.Scenes.Scene5;
using DatabaseDesigner.Controllers;
using DatabaseDesigner.Models.SQL;
using DatabaseDesigner.Controllers.SaveRead;
using DatabaseDesigner.Controllers.Base;

namespace DatabaseDesigner.Views.Scenes.TEScene
{
	internal class TEScene : Scene
	{
		private Panel TablesContainer;
		private readonly List<TableView> Tables = new List<TableView>();
		public Database Database;


		public TEScene(Database database = null)
		{
			InitializeComponent();
			if (database == null) return;
			int h = 0;
			foreach (Table table in database.Tables)
			{
				TableView view = new TableView
				{
					Table = table,
					Database = database,
					Location = new System.Drawing.Point(0, h),
					Width = TablesContainer.Width - 20
				};
				Tables.Add(view);
				TablesContainer.Controls.Add(view);
				h += view.Height + 10;
			}
			Database = database;
			TablesContainer.Focus();
		}
		
		
		private void InitializeComponent()
		{
			this.TablesContainer = new Panel();
			this.SuspendLayout();
			// 
			// TablesContainer
			// 
			this.TablesContainer.AutoScroll = true;
			this.TablesContainer.Dock = DockStyle.Fill;
			this.TablesContainer.Location = new System.Drawing.Point(0, 0);
			this.TablesContainer.Name = "TablesContainer";
			this.TablesContainer.Size = new System.Drawing.Size(800, 600);
			this.TablesContainer.TabIndex = 0;
			// 
			// Scene4
			// 
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.TablesContainer);
			this.Name = "TE Scene";
			this.ResumeLayout(false);

		}

		public override void SetMenu(Designer d)
		{
			d.printToolStripMenuItem.Enabled = false;
			d.editToolStripMenuItem.Enabled = false;
			d.createToolStripMenuItem.Enabled = true;
			d.eERTablesToolStripMenuItem.Enabled = false;
			d.tRKSceneToolStripMenuItem.Enabled = false;
			d.sQLFileToolStripMenuItem.Enabled = true;
			d.pHPFileToolStripMenuItem.Enabled = false;
            d.csharpFileToolStripMenuItem.Enabled = true;
        }

		public override void Save()
		{
			Tables.ForEach(t => t.Modify());
			DBSave.Save(this);
		}

		public override void CreateSQLFile()
		{
			Tables.ForEach(t => t.Modify());
			var sql = new List<SQLOperation>();
			Database.Tables.ForEach(t => sql.Add(new Create() { Table = t }));
			SQLSave.WriteSQL(sql);
			NewOpenController.NewSQL(Database);
		}

        public override void CreateCsharpFile()
        {
			CSharp.CreateCSharp(Database);
        }
    }
}
