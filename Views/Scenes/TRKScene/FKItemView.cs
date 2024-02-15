using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal class FKItemView : ColoredItem
	{
		ForgeinKeyView view;

		public FKItemView(ForgeinKeyView view)
		{
			this.view = view;
			this.ILabel.Text = "FK";
			this.IColor.BackColor = view.Pen.Color;
		}

		public override void ColoredItem_DoubleClick(object sender, EventArgs e)
		{
			ForgeinKeyEdit edit = new ForgeinKeyEdit();
			edit.Set(view);
			edit.Delete.Visible = true;
			DialogResult r = edit.ShowDialog();
			if (r == DialogResult.OK)
			{
				view.Update(edit.GetState());
			}
			else if (r == DialogResult.No)
			{
				view.Delete();
			}
		}
	}
}
