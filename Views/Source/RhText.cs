using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	internal class RhText : ShapeText
	{
		public override void DrawBorders(Graphics g)
		{
			g.DrawPolygon(Pen, GetPoints());
		}

		public override void FillBackground(Graphics g)
		{
			g.FillPolygon(Brush, GetPoints());
		}

		public Point[] GetPoints()
		{
			int w = Width / 2, h = Height / 2;
			Point[] points = {new Point(w, 0),
			new Point(Width, h), new Point(w, Height),new Point(0, h)};
			return points;
		}
	}
}
