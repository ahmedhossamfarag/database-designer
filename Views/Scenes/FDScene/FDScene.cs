using DatabaseDesigner.Controllers.Base;
using DatabaseDesigner.Controllers.FDControl;
using DatabaseDesigner.Controllers.SaveRead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class FDScene : Scene
	{
		public Tools ToolsView;
		public TaskOptions TaskOptions1;
		public IOScreenOptions IOScreenOptions1;
		public ScaleTool ScaleToolView;
		private Source.StackPanel actionsStack;
		public FlowDiagramView FlowDiagramView;

		public FDSceneController Controller { get; set; }
		public FDScene()
		{
			InitializeComponent();
			Controller = new FDSceneController(this);
		}
		private void InitializeComponent()
		{
			this.FlowDiagramView = new DatabaseDesigner.Views.Scenes.Scene2.FlowDiagramView();
			this.ToolsView = new DatabaseDesigner.Views.Scenes.Scene2.Tools();
			this.TaskOptions1 = new DatabaseDesigner.Views.Scenes.Scene2.TaskOptions();
			this.IOScreenOptions1 = new DatabaseDesigner.Views.Scenes.Scene2.IOScreenOptions();
			this.ScaleToolView = new DatabaseDesigner.Views.Scenes.Scene2.ScaleTool();
			this.actionsStack = new DatabaseDesigner.Views.Source.StackPanel();
			this.actionsStack.SuspendLayout();
			this.SuspendLayout();
			// 
			// FlowDiagramView
			// 
			this.FlowDiagramView.BackColor = System.Drawing.Color.White;
			this.FlowDiagramView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FlowDiagramView.Controller = null;
			this.FlowDiagramView.Database = null;
			this.FlowDiagramView.DScale = 1F;
			this.FlowDiagramView.Location = new System.Drawing.Point(0, 0);
			this.FlowDiagramView.Name = "FlowDiagramView";
			this.FlowDiagramView.Size = new System.Drawing.Size(800, 600);
			this.FlowDiagramView.TabIndex = 1;
			// 
			// ToolsView
			// 
			this.ToolsView.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.ToolsView.BackColor = System.Drawing.Color.White;
			this.ToolsView.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.ToolsView.Location = new System.Drawing.Point(698, 185);
			this.ToolsView.Name = "ToolsView";
			this.ToolsView.Size = new System.Drawing.Size(60, 175);
			this.ToolsView.TabIndex = 1;
			// 
			// TaskOptions1
			// 
			this.TaskOptions1.AutoSize = true;
			this.TaskOptions1.Location = new System.Drawing.Point(274, 1);
			this.TaskOptions1.Margin = new System.Windows.Forms.Padding(0);
			this.TaskOptions1.Name = "TaskOptions1";
			this.TaskOptions1.Size = new System.Drawing.Size(252, 33);
			this.TaskOptions1.TabIndex = 3;
			this.TaskOptions1.Task = null;
			this.TaskOptions1.Visible = false;
			// 
			// IOScreenOptions1
			// 
			this.IOScreenOptions1.AutoSize = true;
			this.IOScreenOptions1.Location = new System.Drawing.Point(277, 1);
			this.IOScreenOptions1.Margin = new System.Windows.Forms.Padding(0);
			this.IOScreenOptions1.Name = "IOScreenOptions1";
			this.IOScreenOptions1.Size = new System.Drawing.Size(246, 33);
			this.IOScreenOptions1.TabIndex = 3;
			this.IOScreenOptions1.Visible = false;
			// 
			// ScaleToolView
			// 
			this.ScaleToolView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ScaleToolView.BackColor = System.Drawing.Color.White;
			this.ScaleToolView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ScaleToolView.Location = new System.Drawing.Point(618, 34);
			this.ScaleToolView.Movable = false;
			this.ScaleToolView.Name = "ScaleToolView";
			this.ScaleToolView.Size = new System.Drawing.Size(140, 20);
			this.ScaleToolView.TabIndex = 4;
			this.ScaleToolView.Value = 100;
			// 
			// actionsStack
			// 
			this.actionsStack.Controls.Add(this.IOScreenOptions1);
			this.actionsStack.Controls.Add(this.TaskOptions1);
			this.actionsStack.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.actionsStack.Location = new System.Drawing.Point(0, 565);
			this.actionsStack.Name = "actionsStack";
			this.actionsStack.Size = new System.Drawing.Size(800, 35);
			this.actionsStack.TabIndex = 0;
			// 
			// FDScene
			// 
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.ScaleToolView);
			this.Controls.Add(this.ToolsView);
			this.Controls.Add(this.actionsStack);
			this.Controls.Add(this.FlowDiagramView);
			this.Name = "FDScene";
			this.actionsStack.ResumeLayout(false);
			this.actionsStack.PerformLayout();
			this.ResumeLayout(false);

		}
	
		 public override void Scene_KeyDown(object sender, KeyEventArgs e)
		{
			Controller.KeyDown(e);
		}


		public override void Scene_KeyUp(object sender, KeyEventArgs e)
		{
			Controller.KeyUp(e);
		}

		public override void SetMenu(Designer d)
		{
			d.printToolStripMenuItem.Enabled = true;
			d.editToolStripMenuItem.Enabled = false;
			d.createToolStripMenuItem.Enabled = false;
		}

		public override void Save()
		{
			FDSave.Save(this);
		}

		public override void Print()
		{
			PrintBMP.Print(FlowDiagramView);
		}
		 
	}
}
