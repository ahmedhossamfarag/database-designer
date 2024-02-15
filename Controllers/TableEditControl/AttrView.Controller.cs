using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.TEScene
{
	internal partial class AttrView
	{
		private void AttrView_MouseClick(object sender, MouseEventArgs e)
		{
			PropertyEdit edit = new PropertyEdit();
			edit.Set(Property);
			edit.Cancelbutton.Visible = false;
			edit.OnOk = () =>
			{
				edit.Update(Property);
				//AttName.Text = Property.Name;
				//AttType.Text = Property.DataType.ToString();
			};
			edit.Show();
		}

		private void AttMover_Paint(object sender, PaintEventArgs e)
		{
			for (int y = 0; y < AttMover.Height + 20; y += 5)
			{
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, y, 20, y - 20);
			}
		}



		private void AttMover_MouseMove(object sender, MouseEventArgs e)
		{
			if (PrevPoint != default)
			{
				int dy = e.Y - PrevPoint.Y;
				int y = (Attributes.Count - 1) * 40;
				Location = new Point(0, Math.Max(Math.Min(y, Location.Y + dy), 0));
				if (Location.Y >= (Index + 1) * Step)
				{

					Attributes[Index + 1].View.Index = Index;
					Index_++;

				}
				else if (Location.Y <= (Index - 1) * Step)
				{

					Attributes[Index - 1].View.Index = Index;
					Index_--;

				}
			}
		}

		private void AttMover_MouseUp(object sender, MouseEventArgs e)
		{
			PrevPoint = default;
			Index = Index_;
			AttMover.Cursor = Cursors.Default;
			BorderStyle = BorderStyle.None;
		}

		private void AttMover_MouseDown(object sender, MouseEventArgs e)
		{
			PrevPoint = e.Location;
			Parent.Controls.SetChildIndex(this, 0);
			AttMover.Cursor = Cursors.NoMoveVert;
			BorderStyle = BorderStyle.FixedSingle;
		}

	}
}
