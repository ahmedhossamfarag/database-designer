using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Source
{
	internal class ArrowShape : Arrow
	{
		public Shape Shape1 { get; set; }
		public Shape Shape2 { get; set; }

		public ArrowShape(Shape s1, Shape s2) : base(FromStart(s1, s2), FromEnd(s1, s2))
		{
			(Shape1, Shape2) = (s1, s2);
			void e(object s, EventArgs ev) { Start = FromStart(s1, s2); End = FromEnd(s1, s2); }
			s1.Move += e;
			s2.Move += e;
			s1.Resize += e;
			s2.Resize += e;
			s1.Removed += p => p.Controls.Remove(this);
			s2.Removed += p => p.Controls.Remove(this);
		}

		private static Point FromStart(Shape s1, Shape s2)
		{
			int dx = s2.Center.X - s1.Center.X;
			int dy = s2.Center.Y - s1.Center.Y;
			int l = (int)Math.Sqrt((dx * dx) + (dy * dy));
			dx = (int)((double)dx * Math.Min(s1.Width, s1.Height) / 2 / l);
			dy = (int)((double)dy * Math.Min(s1.Width, s1.Height) / 2 / l);
			return new Point(s1.Center.X + dx, s1.Center.Y + dy);
		}
		private static Point FromEnd(Shape s1, Shape s2)
		{

			int dx = s1.Center.X - s2.Center.X;
			int dy = s1.Center.Y - s2.Center.Y;
			int l = (int)Math.Sqrt((dx * dx) + (dy * dy));
			dx = (int)((double)dx * Math.Min(s2.Width, s2.Height) / 2 / l);
			dy = (int)((double)dy * Math.Min(s2.Width, s2.Height) / 2 / l);
			return new Point(s2.Center.X + dx, s2.Center.Y + dy);
		}

	}
}
