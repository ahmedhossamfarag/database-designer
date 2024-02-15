using DatabaseDesigner.Views.Scenes.Scene3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal class RItemView : ColoredItem
	{
		RelationView view;

		public RItemView(RelationView view)
		{
			this.view = view;
			ILabel.Text = "R";
			IColor.BackColor = view.Pen.Color;
		}

		public override void ColoredItem_DoubleClick(object sender, EventArgs e)
		{
			RelationEdit edit = new RelationEdit();
			edit.Set(view);
			edit.Delete.Visible = true;
			DialogResult r = edit.ShowDialog();
			if (r == DialogResult.OK)
			{
				view.Update(edit.GetState());
			}
			else if(r == DialogResult.No)
			{
				view.Delete();
			}
		}
	}
}
