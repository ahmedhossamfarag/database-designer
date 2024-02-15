using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Views.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class BranchOptions : OptionsPanel
	{
		public Branch Branch;

		public BranchView View
		{
			set
			{
				if (value != null)
				{
					if (value.Branch != Branch)
					{
						Branch?.Controller.SetSelect(false);
						Branch = value.Branch;
						Visible = true;
						Branch.Controller.SetSelect(true);
					}
				}
				else
				{
					Branch?.Controller.SetSelect(false);
					Branch = null;
					Visible = false;
				}
			}
		}

		public BranchOptions()
		{
			Add.Text = "+ Sub";
		}


		public override void Delete_Click(object sender, EventArgs e)
		{
			InfoDialog dialog = new InfoDialog("Are You Sure ?")
			{
				OnOk = () =>
				{
					Branch.Controller.Delete();
					View = null;
				}
			};
			dialog.Show();
		}

		public override void Edit_Click(object sender, EventArgs e)
		{
			Branch.Controller.Edit();
		}

		public override void Add_Click(object sender, EventArgs e)
		{
			Branch.Controller.AddEntity();
		}
	}
}
