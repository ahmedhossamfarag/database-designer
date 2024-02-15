using DatabaseDesigner.Controllers;
using DatabaseDesigner.Controllers.Base;
using DatabaseDesigner.Controllers.SaveRead;
using DatabaseDesigner.Models;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Base;
using DatabaseDesigner.Views.Scenes.Scene1;
using DatabaseDesigner.Views.Scenes.Scene2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner
{
	public partial class Designer : Form
	{
		public Scene Scene { get; set; }

		private string fail_message = "Failed to run operation";
		public Designer()
		{
			InitializeComponent();
			NewOpenController.designer = this;
		}

		
		private void Form1_Load(object sender, EventArgs e)
		{
			SceneContainer.Controls.Add(new MScene());
		}

		public void AddScene(Scene scene)
		{
			SceneContainer.Controls.Add(scene);
			scene.scenePanel = new ScenePanel(scene) { OnSelect = SelectScene, OnClose = RemoveScene };
			scene.sceneLabel = new SceneLabel(scene) { OnDClick = ShowScene };
			SceneTitleContainer.Controls.Add(scene.scenePanel);
			SScenes.Controls.Add(scene.sceneLabel);
			SelectScene(scene);
			Session.Scenes.Add(scene);
		}

		public void ShowScene(Scene scene)
		{
			if (scene.Parent == null)
			{
				SceneTitleContainer.Controls.Add(scene.scenePanel);
				SceneContainer.Controls.Add(scene);
			}
			SelectScene(scene);
		}

		public void SelectScene(Scene scene)
		{
			if (scene == Scene) return;
			if(Scene != null)
			{
				Scene.scenePanel.Margin = new Padding(0, 5, 0, 0);
			}
			scene.BringToFront();
			scene.scenePanel.Margin = new Padding(0);
			Scene = scene;
			scene.SetMenu(this);
		}

		public void RemoveScene(Scene scene)
		{
			InfoDialog dialog = new InfoDialog("Are you sure ?");
			dialog.OnOk += () =>
			{
				SceneContainer.Controls.Remove(scene);
				SceneTitleContainer.Controls.Remove(scene.scenePanel);
				Scene = null;
				if (SceneContainer.Controls.Count > 1)
				{
					SelectScene((Scene)SceneContainer.Controls[0]);
				}
				else
				{
					printToolStripMenuItem.Enabled = false;
					editToolStripMenuItem.Enabled = false;
					createToolStripMenuItem.Enabled = false;
				}
			};
			dialog.Show();
			
		}

		private void NewIFDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				NewOpenController.NewIFD();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}

		private void NewEERDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				NewOpenController.NewEER();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}

		private void NewTRFKToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				NewOpenController.NewTRK();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}

		private void OpenIFDtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				NewOpenController.OpenIFD();
			}
			catch (Exception)
			{
				InfoDialog.Of("Can't Open File !");
			}
		}

		private void OpenEERDtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			try
			{
				NewOpenController.OpenEER();
			}
			catch (Exception)
			{
				InfoDialog.Of("Can't Open File !");
			}
		}

		private void OpenTRFKDtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				NewOpenController.OpenTRK();

			}
			catch (Exception)
			{
				InfoDialog.Of("Can't Open File !");
			}
		}

		private void OpenDBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				NewOpenController.OpenDB();

			}
			catch (Exception)
			{
				InfoDialog.Of("Can't Open File !");
			}
		}
		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Scene?.Save();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Scene?.SaveAs();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}

		private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Scene?.Print();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Scene?.Undo();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}

		private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Scene?.Redo();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}

		private void EERTablesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Scene?.CreateERTables();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}


		private void tRKSceneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Scene?.CreateTRKScene();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}
		private void SQLFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Scene?.CreateSQLFile();
			}
			catch (Exception)
			{

				InfoDialog.Of(fail_message);
			}
		}

		private void PHPFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Scene?.CreatePHPFile();
			}
			catch (Exception)
			{
				
				InfoDialog.Of(fail_message);
			}
		}


        private void csharpFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Scene?.CreateCsharpFile();
            }
            catch (Exception)
            {

                InfoDialog.Of(fail_message);
            }
        }

        private void ScenesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SessionScenes.Visible = !SessionScenes.Visible;
			scenesToolStripMenuItem.Text = SessionScenes.Visible ? "Hide Scenes Window" : "Show Scenes Window";
		}

		private void Designer_KeyDown(object sender, KeyEventArgs e)
		{
			Scene?.Scene_KeyDown(sender, e);
		}

		private void Designer_KeyPress(object sender, KeyPressEventArgs e)
		{
			Scene?.Scene_KeyPress(sender, e);
		}

		private void Designer_KeyUp(object sender, KeyEventArgs e)
		{
			Scene?.Scene_KeyUp(sender, e);
		}

    }
}

