using DatabaseDesigner.Views.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes
{
	public class Scene : Panel
	{

		private string file;
		public string File
		{
			get => file;
			set
			{
				file = value;
				if(scenePanel != null)
					scenePanel.sceneTitle.Text = this.ToString();
				if (sceneLabel != null)
					sceneLabel.Text = this.ToString();
			}
		}

		public ScenePanel scenePanel;
		public SceneLabel sceneLabel;

		public Scene()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Scene
			// 
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Font = new System.Drawing.Font("Arial", 12F);
			//this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			//this.KeyPreview = true;
			this.Name = "Scene";
			//this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Scene_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Scene_KeyPress);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Scene_KeyUp);
			this.ResumeLayout(false);
			this.Dock = DockStyle.Fill;
		}


		public virtual void SetMenu(Designer d) { }

		public virtual void Save() { }

		public virtual void SaveAs()
		{
			string f = File;
			File = null;
			Save();
			if(f != null)
				File = f;
		}

		public virtual void Print() { }

		public virtual void Undo() { }

		public virtual void Redo() { }

		public virtual void CreateERTables() { }

		public virtual void CreateTRKScene() { }

		public virtual void CreateSQLFile() { }

		public virtual void CreatePHPFile() { }

        public virtual void CreateCsharpFile() { }


        public virtual void Scene_KeyPress(object sender, KeyPressEventArgs e) { }

		public virtual void Scene_KeyDown(object sender, KeyEventArgs e) { }

		public virtual void Scene_KeyUp(object sender, KeyEventArgs e) { }

		public override string ToString() => File != null ? File.Substring(File.LastIndexOfAny(new char[] { '/', '\\' }) + 1) : Name;

    }
}
