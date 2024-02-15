using DatabaseDesigner.Controllers;
using DatabaseDesigner.Controllers.SaveRead;
using DatabaseDesigner.Models;
using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene5
{
	internal class SQLScene : Scene
	{
		private Panel TasksContainer;
		private readonly List<TaskView> Tasks = new List<TaskView>();

		public Database Database { get; set; }


		public SQLScene(FlowDiagram flowDiagram = null, Database database = null)
		{
			InitializeComponent();
			if (flowDiagram != null)
			{
				IEnumerable<Task> tasks = flowDiagram.Tasks.Where(t => !t.SubTasks.Any());
				int h = 0;
				foreach (Task t in tasks)
				{
					TaskView view = new TaskView
					{
						Task = t,
						Location = new System.Drawing.Point(0, h),
						Database = database
					};
					Tasks.Add(view);
					TasksContainer.Controls.Add(view);
					h += view.Height + 10;
				}
				TasksContainer.Height = h;
			}
			else
			{
				TaskView view = new TaskView
				{
					Task = null,
					Database = database
				};
				Tasks.Add(view);
				TasksContainer.Controls.Add(view);
			}
			Database = database;
		}
		private void InitializeComponent()
		{
			this.TasksContainer = new Panel();
			// 
			// TasksContainer
			// 
			this.TasksContainer.Dock = DockStyle.Fill;
			this.TasksContainer.Location = new System.Drawing.Point(0, 0);
			this.TasksContainer.Name = "TasksContainer";
			this.TasksContainer.Size = new System.Drawing.Size(800, 600);
			this.TasksContainer.TabIndex = 0;
			this.TasksContainer.AutoScroll = true;
			// 
			// Scene5
			// 
			this.Controls.Add(this.TasksContainer);
			this.Name = "SQL Scene";

		}



		public override void SetMenu(Designer d)
		{
			d.printToolStripMenuItem.Enabled = false;
			d.editToolStripMenuItem.Enabled = false;
			d.createToolStripMenuItem.Enabled = true;
			d.eERTablesToolStripMenuItem.Enabled = false;
			d.tRKSceneToolStripMenuItem.Enabled = false;
			d.sQLFileToolStripMenuItem.Enabled = false;
			d.pHPFileToolStripMenuItem.Enabled = true;
            d.csharpFileToolStripMenuItem.Enabled = true;
        }

		public override void Save()
		{
			var SQL = new List<SQLOperation>();
			Tasks.ForEach(t => SQL.AddRange(t.SQL));
			SQLSave.WriteSQL(SQL);
		}

		public override void CreatePHPFile()
		{
			var SQL = new List<SQLOperation>();
			Tasks.ForEach(t => SQL.AddRange(t.SQL));
			PHP.Write(SQL);
		}

        public override void CreateCsharpFile()
        {
			var sqllist = new List<SQLOperation>();
			Tasks.ForEach((t) => sqllist.AddRange(t.SQL));
			CSharp.CreateCSharp(sqllist);
        }
    }
}
