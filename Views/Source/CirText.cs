using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	internal class CirText : ShapeText
	{
		public override void DrawBorders(Graphics g)
		{
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			g.DrawEllipse(Pen, Rectangle);
		}

		public override void FillBackground(Graphics g)
		{
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			g.FillEllipse(Brush, 0, 0, Width, Height);

		}
	}
}
