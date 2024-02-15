using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Views.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class TaskOptions : OptionsPanel
	{
		public Task Task { get; set; }

		public TaskView View {
			set {
				if(value != null)
				{
					if (value.Task != Task)
					{
						Task?.Controller.SetSelect(false);
						Task = value.Task;
						Task?.Controller.SetSelect(true);
						Visible = true;
					}
				}
				else
				{
					Task?.Controller.SetSelect(false);
					Task = null;
					Visible = false;
				}
			} 
		}

		public TaskOptions()
		{
			Add.Text = "+ SubTask";
		}

		public override void Add_Click(object sender, EventArgs e)
		{
			Task.Controller.AddSubTask();
			View = null;
		}

		public override  void Edit_Click(object sender, EventArgs e)
		{
			Task.Controller.Edit();
		}

		public override void Delete_Click(object sender, EventArgs e)
		{
			InfoDialog dialog = new InfoDialog("Are You Sure ?")
			{
				OnOk = () =>
			{
				Task.Controller.Delete();
				View = null;
			}
			};
			dialog.Show();
		}
	}
}
