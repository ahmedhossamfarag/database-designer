using DatabaseDesigner.Views.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	internal class NLineShape : LineShape
	{
		private bool n;
		public bool N
		{
			get => n;
			set {
				if(value != n)
				{
					n = value;
					Redraw();
				}
			}
		}

        public bool Stop;
        public override int Gap { get; } = 50;
        public override int G { get; } = 50;

        private Point p1, p2, p3;
        
        public NLineShape(Shape s1, Shape s2, bool stp) : base(s1, s2)
		{
            Stop = stp;
		}


        private void SetPoints()
		{
            p1 = new Point(Start.X - Location.X, Start.Y - Location.Y);
            p2 = new Point(End.X - Location.X, End.Y - Location.Y);
            if (Math.Abs(p1.X - p2.X) < Gap)
            {
                if (Stop)
                {
                    p3 = new Point(p1.X + 50, (p1.Y + p2.Y) / 2);
                }
                else
                {
                    p3 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                }
            }
            else if (Math.Abs(p1.Y - p2.Y) < Gap)
            {
                if (Stop)
                {
                    p3 = new Point((p1.X + p2.X) / 2, p1.Y + 50);
                }
                else
                {
                    p3 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                }
            }
            else
            {
                if (Stop)
                {
                    p3 = new Point(p1.X, p2.Y);
                }
                else
                {
                    p3 = new Point(p2.X, p1.Y);
                }
            }
        }

        public override void PaintContent(Graphics g)
		{
			mode = null;
            SetPoints();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawBezier(Pen, p1, p3, p3, p2);
			int[] dx = { -5, -5, 5, 5 };
            if (n)
			{
				for (int i = 0; i < dx.Length / 2; i++)
				{
					Point p = new Point(p3.X  + dx[i], p3.Y + dx[i + 1]);
                    g.DrawBezier(Pen, p1, p, p, p2);
                }
			}

		}

	}
}
