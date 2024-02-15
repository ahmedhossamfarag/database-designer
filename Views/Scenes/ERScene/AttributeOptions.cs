using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Views.Scenes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = DatabaseDesigner.Models.EER.Attribute;
namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class AttributeOptions : OptionsPanel
	{
		public Attribute Attribute;

		public AttributeView View
		{
			set
			{
				if (value != null)
				{
					if (value.Attribute != Attribute)
					{
						Attribute?.Controller.SetSelect(false);
						Attribute = value.Attribute;
						Visible = true;
						Attribute.Controller.SetSelect(true);
					}
				}
				else
				{
					Attribute?.Controller.SetSelect(false);
					Attribute = null;
					Visible = false;
				}
			}
		}

		public AttributeOptions()
		{
			Add.Text = "+ SubAttr";
		}


		public override void Delete_Click(object sender, EventArgs e)
		{
			InfoDialog dialog = new InfoDialog("Are You Sure ?")
			{
				OnOk = () =>
				{
					Attribute.Controller.Delete();
					View = null;
				}
			};
			dialog.Show();
		}

		public override void Edit_Click(object sender, EventArgs e)
		{
			Attribute.Controller.Edit();
		}

		public override void Add_Click(object sender, EventArgs e)
		{
			Attribute.Controller.AddAttribute();
		}
	}
}
