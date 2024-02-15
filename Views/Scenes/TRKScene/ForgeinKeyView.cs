using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class ForgeinKeyView : Baziar
	{
		public readonly PropertyView property1, property2;

		public ForgeinKeyView(PropertyView property1, PropertyView property2)
		{
			this.property1 = property1;
			this.property2 = property2;
			FKItemView = new FKItemView(this);
			Align();
		}

        public override void PaintContent(Graphics g)
        {
            base.PaintContent(g); 
			Point p = new Point(End.X - Location.X, End.Y - Location.Y);
            Point[] points = { p, new Point(p.X + 10, p.Y + 10), new Point(p.X + 10, p.Y - 10) };
            g.FillPolygon(new SolidBrush(Pen.Color), points);
            Point[] points2 = { p, new Point(p.X - 10, p.Y + 10), new Point(p.X - 10, p.Y - 10) };
            g.FillPolygon(new SolidBrush(Pen.Color), points2);
        }

		public void Align()
		{
			PropertyView v1, v2;
			if (property1.AbsoluteLocation.Y > property2.AbsoluteLocation.Y)
			{
				v1 = property1; v2 = property2;
			}
			else
			{
				v1 = property2; v2 = property1;
			}
			Point p1 = v1.AbsoluteLocation, p2 = v2.AbsoluteLocation;
			if (p2.X - p1.X > v1.Width)
			{
				p1.X += v1.Width;
				Mode = BaziarMode.Z;
			}
			else if (p1.X - p2.X > v1.Width)
			{
				p2.X += v2.Width;
				Mode = BaziarMode.Z;
			}
			else if (p1.X > p2.X)
			{
				p1.X += v1.Width;
				p2.X += v2.Width;
				Mode = BaziarMode.UR;
			}
			else
			{
				Mode = BaziarMode.UL;
			}
			p1.Y += v1.Height / 2;
			p2.Y += v2.Height / 2;
			
			if (v1 == property1)
			{
				Start = p1;
				End = p2;
			}
			else
			{
				Start = p2;
				End = p1;
			}
		}
	}
}
