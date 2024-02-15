using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	internal class RecText : ShapeText
	{
		public override void FillBackground(Graphics g)
		{
			g.FillRectangle(Brush, 0, 0, Width, Height);
		}

		public override void DrawBorders(Graphics g)
		{
			g.DrawRectangle(Pen, Rectangle);
		}

	}
}
