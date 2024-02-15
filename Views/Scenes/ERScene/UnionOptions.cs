using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Views.Scenes.Base;
using DatabaseDesigner.Views.Scenes.Scene2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class UnionOptions : OptionsPanel
	{
		public Union Union;

		public UnionView View
		{
			set
			{
				if (value != null)
				{
					if (value.Union != Union)
					{
						Union?.Controller.SetSelect(false);
						Union = value.Union;
						Visible = true;
						Union.Controller.SetSelect(true);
					}
				}
				else
				{
					Union?.Controller.SetSelect(false);
					Union = null;
					Visible = false;
				}
			}
		}

		public UnionOptions()
		{
			Add.Text = "+ Super";
		}


		public override void Delete_Click(object sender, EventArgs e)
		{
			InfoDialog dialog = new InfoDialog("Are You Sure ?")
			{
				OnOk = () =>
				{
					Union.Controller.Delete();
					View = null;
				}
			};
			dialog.Show();
		}

		public override void Edit_Click(object sender, EventArgs e)
		{
			Union.Controller.Edit();
		}

		public override void Add_Click(object sender, EventArgs e)
		{
			Union.Controller.AddEntity();
		}
	}
}
