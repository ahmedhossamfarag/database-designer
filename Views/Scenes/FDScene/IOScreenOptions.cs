using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Views.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class IOScreenOptions : OptionsPanel
	{
		public IOScreen IOScreen;

		public IOScreenView View
		{
			set
			{
				if(value != null)
				{
					if(value.IOScreen != IOScreen)
					{
						IOScreen?.Controller.SetSelect(false);
						IOScreen = value.IOScreen;
						Visible = true;
						IOScreen.Controller.SetSelect(true);
					}
				}
				else
				{
					IOScreen?.Controller.SetSelect(false);
					IOScreen = null;
					Visible = false;
				}
			}
		}

		public IOScreenOptions()
		{
			Add.Text = "+ Task IO";
		}

		
		public override void Delete_Click(object sender, EventArgs e)
		{
			InfoDialog dialog = new InfoDialog("Are You Sure ?")
			{
				OnOk = () =>
			{
				IOScreen.Controller.Delete();
				View = null;
			}
			};
			dialog.Show();
		}

		public override void Edit_Click(object sender, EventArgs e)
		{
			IOScreen.Controller.Edit();
		}

		public override void Add_Click(object sender, EventArgs e)
		{
			IOScreen.Controller.AddTaskIO();
		}
	}
}
