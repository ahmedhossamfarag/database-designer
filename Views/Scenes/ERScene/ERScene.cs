using DatabaseDesigner.Controllers;
using DatabaseDesigner.Controllers.Base;
using DatabaseDesigner.Controllers.ERControl;
using DatabaseDesigner.Controllers.SaveRead;
using DatabaseDesigner.Models;
using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Views.Scenes.TEScene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class ERScene : Scene
	{
		public ERTools ERTools1;
		public ERDiagramView ERDiagramView1;
		public Scene2.ScaleTool ScaleTool1;
		public EntityOptions EntityOptions1;
		public RelationOptions RelationOptions1;
		public AttributeOptions AttributeOptions1;
		public BranchOptions BranchOptions1;
		public UnionOptions UnionOptions1;
		private Source.StackPanel actionsStack;
		public ERSceneController Controller;

		
		public ERScene()
		{
			InitializeComponent();
			Controller = new ERSceneController(this);
		}

		private void InitializeComponent()
		{
			this.ERTools1 = new DatabaseDesigner.Views.Scenes.Scene3.ERTools();
			this.ERDiagramView1 = new DatabaseDesigner.Views.Scenes.Scene3.ERDiagramView();
			this.UnionOptions1 = new DatabaseDesigner.Views.Scenes.Scene3.UnionOptions();
			this.BranchOptions1 = new DatabaseDesigner.Views.Scenes.Scene3.BranchOptions();
			this.AttributeOptions1 = new DatabaseDesigner.Views.Scenes.Scene3.AttributeOptions();
			this.RelationOptions1 = new DatabaseDesigner.Views.Scenes.Scene3.RelationOptions();
			this.EntityOptions1 = new DatabaseDesigner.Views.Scenes.Scene3.EntityOptions();
			this.ScaleTool1 = new DatabaseDesigner.Views.Scenes.Scene2.ScaleTool();
			this.actionsStack = new DatabaseDesigner.Views.Source.StackPanel();
			this.actionsStack.SuspendLayout();
			this.SuspendLayout();
			// 
			// ERTools1
			// 
			this.ERTools1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.ERTools1.BackColor = System.Drawing.Color.White;
			this.ERTools1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.ERTools1.Location = new System.Drawing.Point(728, 137);
			this.ERTools1.Name = "ERTools1";
			this.ERTools1.Size = new System.Drawing.Size(60, 172);
			this.ERTools1.TabIndex = 1;
			// 
			// ERDiagramView1
			// 
			this.ERDiagramView1.BackColor = System.Drawing.Color.White;
			this.ERDiagramView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ERDiagramView1.Controller = null;
			this.ERDiagramView1.DScale = 1F;
			this.ERDiagramView1.Location = new System.Drawing.Point(0, 0);
			this.ERDiagramView1.Name = "ERDiagramView1";
			this.ERDiagramView1.Size = new System.Drawing.Size(800, 600);
			this.ERDiagramView1.TabIndex = 2;
			// 
			// UnionOptions1
			// 
			this.UnionOptions1.AutoSize = true;
			this.UnionOptions1.BackColor = System.Drawing.SystemColors.Control;
			this.UnionOptions1.Location = new System.Drawing.Point(279, -1);
			this.UnionOptions1.Margin = new System.Windows.Forms.Padding(0);
			this.UnionOptions1.Name = "UnionOptions1";
			this.UnionOptions1.Size = new System.Drawing.Size(243, 33);
			this.UnionOptions1.TabIndex = 3;
			this.UnionOptions1.Visible = false;
			// 
			// BranchOptions1
			// 
			this.BranchOptions1.AutoSize = true;
			this.BranchOptions1.BackColor = System.Drawing.SystemColors.Control;
			this.BranchOptions1.Location = new System.Drawing.Point(279, -1);
			this.BranchOptions1.Margin = new System.Windows.Forms.Padding(0);
			this.BranchOptions1.Name = "BranchOptions1";
			this.BranchOptions1.Size = new System.Drawing.Size(243, 33);
			this.BranchOptions1.TabIndex = 3;
			this.BranchOptions1.Visible = false;
			// 
			// AttributeOptions1
			// 
			this.AttributeOptions1.AutoSize = true;
			this.AttributeOptions1.BackColor = System.Drawing.SystemColors.Control;
			this.AttributeOptions1.Location = new System.Drawing.Point(277, -1);
			this.AttributeOptions1.Margin = new System.Windows.Forms.Padding(0);
			this.AttributeOptions1.Name = "AttributeOptions1";
			this.AttributeOptions1.Size = new System.Drawing.Size(247, 33);
			this.AttributeOptions1.TabIndex = 3;
			this.AttributeOptions1.Visible = false;
			// 
			// RelationOptions1
			// 
			this.RelationOptions1.AutoSize = true;
			this.RelationOptions1.BackColor = System.Drawing.SystemColors.Control;
			this.RelationOptions1.Location = new System.Drawing.Point(274, -1);
			this.RelationOptions1.Margin = new System.Windows.Forms.Padding(0);
			this.RelationOptions1.Name = "RelationOptions1";
			this.RelationOptions1.Size = new System.Drawing.Size(253, 33);
			this.RelationOptions1.TabIndex = 3;
			this.RelationOptions1.Visible = false;
			// 
			// EntityOptions1
			// 
			this.EntityOptions1.AutoSize = true;
			this.EntityOptions1.BackColor = System.Drawing.SystemColors.Control;
			this.EntityOptions1.Location = new System.Drawing.Point(198, 1);
			this.EntityOptions1.Margin = new System.Windows.Forms.Padding(0);
			this.EntityOptions1.Name = "EntityOptions1";
			this.EntityOptions1.Size = new System.Drawing.Size(405, 29);
			this.EntityOptions1.TabIndex = 1;
			this.EntityOptions1.Visible = false;
			// 
			// ScaleTool1
			// 
			this.ScaleTool1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ScaleTool1.BackColor = System.Drawing.Color.White;
			this.ScaleTool1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ScaleTool1.Location = new System.Drawing.Point(639, 48);
			this.ScaleTool1.Movable = false;
			this.ScaleTool1.Name = "ScaleTool1";
			this.ScaleTool1.Size = new System.Drawing.Size(140, 20);
			this.ScaleTool1.TabIndex = 0;
			this.ScaleTool1.Value = 100;
			// 
			// actionsStack
			// 
			this.actionsStack.Controls.Add(this.EntityOptions1);
			this.actionsStack.Controls.Add(this.AttributeOptions1);
			this.actionsStack.Controls.Add(this.RelationOptions1);
			this.actionsStack.Controls.Add(this.UnionOptions1);
			this.actionsStack.Controls.Add(this.BranchOptions1);
			this.actionsStack.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.actionsStack.Location = new System.Drawing.Point(0, 570);
			this.actionsStack.Name = "actionsStack";
			this.actionsStack.Size = new System.Drawing.Size(800, 30);
			this.actionsStack.TabIndex = 0;
			// 
			// ERScene
			// 
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.ScaleTool1);
			this.Controls.Add(this.ERTools1);
			this.Controls.Add(this.actionsStack);
			this.Controls.Add(this.ERDiagramView1);
			this.Name = "ERScene";
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
			d.createToolStripMenuItem.Enabled = true;
			d.eERTablesToolStripMenuItem.Enabled = true;
			d.tRKSceneToolStripMenuItem.Enabled = true;
			d.sQLFileToolStripMenuItem.Enabled = false;
			d.pHPFileToolStripMenuItem.Enabled = false;
			d.csharpFileToolStripMenuItem.Enabled = false;
		}

		public override void Save()
		{
			ERSave.Save(this);
		}

		public override void Print()
		{
			PrintBMP.Print(ERDiagramView1);
		}
		
		Database CreateDatabase()
		{

			ERDiagram eRDiagram = new ERDiagram(ERDiagramView1);
			try
			{
				ERDiagramView1.Controller.ValidEER(eRDiagram);
			}
			catch (InvalidOperationException ex)
			{
				InfoDialog.Of(ex.Message);
				return null;
			}
			ERAnalyser eRAnalyser = new ERAnalyser(eRDiagram);
			Session.Databases.Add(eRAnalyser.Database);
			return eRAnalyser.Database;
		}

		public override void CreateERTables()
		{
			Database database = CreateDatabase();
			if (database == null)
			{
				return;
			}
			TEScene.TEScene scene = new TEScene.TEScene(database);
			NewOpenController.designer.AddScene(scene);

		}

		public override void CreateTRKScene()
		{

			Database database = CreateDatabase();
			if (database == null)
			{
				return;
			}

			NewOpenController.NewTRK();
			var scene = (Scene6.TRKScene) NewOpenController.designer.Scene;
            scene.ReadDatabase(database);
        }

	}
}
