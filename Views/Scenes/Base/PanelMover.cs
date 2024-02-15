using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Base
{
	internal class PanelMover : Panel
	{
		Point p;
		bool m;
		public PanelMover()
		{
			Cursor = Cursors.Hand;
			Dock = DockStyle.Top;
			Height = 10;
			MouseDown += PanelMover_MouseDown;
			MouseMove += PanelMover_MouseMove;
			MouseUp += PanelMover_MouseUp;
		}

		private void PanelMover_MouseUp(object sender, MouseEventArgs e)
		{
			m = false;
			Cursor = Cursors.Hand;
		}

		private void PanelMover_MouseMove(object sender, MouseEventArgs e)
		{
			if (m)
			{
				int dx = e.X - p.X, dy = e.Y - p.Y;
				Point l = new Point(Parent.Location.X + dx, Parent.Location.Y + dy);
				Point x = new Point(Parent.Parent.Width - Parent.Width, Parent.Parent.Height - Parent.Height);
				Parent.Location = new Point(Math.Max(0, Math.Min(l.X, x.X)), Math.Max(0, Math.Min(l.Y, x.Y)));
			}
		}

		private void PanelMover_MouseDown(object sender, MouseEventArgs e)
		{
			p = e.Location;
			m = true;
			Cursor = Cursors.NoMove2D;
		}
	}
}
