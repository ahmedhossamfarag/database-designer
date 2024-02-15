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
	internal class RelationOptions : OptionsPanel
	{
		public Relation Relation;

		public RelationView View
		{
			set
			{
				if (value != null)
				{
					if (value.Relation != Relation)
					{
						Relation?.Controller.SetSelect(false);
						Relation = value.Relation;
						Visible = true;
						Relation.Controller.SetSelect(true);
					}
				}
				else
				{
					Relation?.Controller.SetSelect(false);
					Relation = null;
					Visible = false;
				}
			}
		}

		public RelationOptions()
		{
			Add.Text = "+ Attribute";
		}

		public override void Add_Click(object sender, EventArgs e)
		{
			Relation.Controller.AddAttribute();
		}

		public override void Delete_Click(object sender, EventArgs e)
		{
			InfoDialog dialog = new InfoDialog("Are You Sure")
			{
				OnOk = () =>
				{
					Relation.Controller.Delete();
					View = null;
				}
			};
			dialog.Show();
		}

		public override void Edit_Click(object sender, EventArgs e)
		{
			Relation.Controller.Edit();
		}
	}
}
