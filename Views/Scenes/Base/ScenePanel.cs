using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Base
{
	public class ScenePanel  : Panel
	{

		private System.Windows.Forms.Button sceneClose;
		public System.Windows.Forms.Label sceneTitle;

		public Scene scene;
		public Action<Scene> OnSelect;
		public Action<Scene> OnClose;
		public ScenePanel(Scene scene)
		{
			this.scene = scene;
			InitializeComponent();
			sceneTitle.Text = scene.ToString();
		}

		private void InitializeComponent()
		{
			this.sceneClose = new System.Windows.Forms.Button();
			this.sceneTitle = new System.Windows.Forms.Label();
			// 
			// this
			// 
			this.BackColor = System.Drawing.Color.White;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.sceneTitle);
			this.Controls.Add(this.sceneClose);
			this.Name = "panel1";
			this.Size = new System.Drawing.Size(200, 100);
			this.TabIndex = 0;
			
			// 
			// sceneClose
			// 
			this.sceneClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.sceneClose.FlatAppearance.BorderSize = 0;
			this.sceneClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.sceneClose.Font = new System.Drawing.Font("Tahoma", 8F);
			this.sceneClose.ForeColor = System.Drawing.Color.Red;
			this.sceneClose.Location = new System.Drawing.Point(175, 0);
			this.sceneClose.Name = "sceneClose";
			this.sceneClose.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
			this.sceneClose.Size = new System.Drawing.Size(25, 20);
			this.sceneClose.TabIndex = 0;
			this.sceneClose.Text = "X";
			this.sceneClose.UseVisualStyleBackColor = false;
			this.sceneClose.Click += SceneClose_Click;
			this.sceneClose.MouseEnter += SceneClose_MouseEL;
			this.sceneClose.MouseLeave += SceneClose_MouseEL;
			// 
			// sceneTitle
			// 
			this.sceneTitle.Location = new System.Drawing.Point(5, 0);
			this.sceneTitle.Name = "sceneTitle";
			this.sceneTitle.Size = new System.Drawing.Size(170, 23);
			this.sceneTitle.TabIndex = 1;
			this.sceneTitle.Text = "SceneTitle";
			this.sceneTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.sceneTitle.Click += SceneTitle_Click;

		}

		private void SceneClose_MouseEL(object sender, EventArgs e)
		{
			(sceneClose.BackColor, sceneClose.ForeColor) = (sceneClose.ForeColor, sceneClose.BackColor);
		}

		private void SceneTitle_Click(object sender, EventArgs e)
		{
			OnSelect?.Invoke(scene);
		}

		private void SceneClose_Click(object sender, EventArgs e)
		{
			OnClose?.Invoke(scene);
		}
	}
}
