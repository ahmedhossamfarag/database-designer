using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	internal class Arrow : TransparentPanel
	{
		protected Point st, end;

		protected LineMode mode;
		public Point Start { get { return st; } set { if (value != st) { st = value; PointChanged?.Invoke(); } } }
		public Point End { get { return end; } set { if (value != end) { end = value; PointChanged?.Invoke(); } } }

		public Pen Pen { get; set; } = new Pen(Color.White, 2);

		public event Action PointChanged;

		private bool atS, atE;

		public event Action AtStartChanged;
		public event Action AtEndChanged;

		public bool AtStart
		{
			set
			{
				if(value != atS)
				{
					atS = value;
					AtStartChanged?.Invoke();
				}
			}
		}

		public bool AtEnd
		{
			set
			{
				if(value != atE)
				{
					atE = value;
					AtEndChanged?.Invoke();
				}
			}
		}

		public Arrow(Point s, Point e)
		{
			st = s;
			end = e;
			PointChanged += Line_PointChanged;
			Line_PointChanged();
			AtStartChanged += Refresh;
			AtEndChanged += Refresh;
		}

		protected override void TransparentPanel_Resize(object sender, EventArgs e)
		{
			Refresh();
			base.TransparentPanel_Resize(sender, e);
		}
		public Arrow(int xi, int yi, int xf, int yf) : this(new Point(xi, yi), new Point(xf, yf)) { }

		public Arrow() : this(0, 0, 100, 100) { AtStart = true; AtEnd = true; }

		public override void PaintContent(Graphics g)
		{
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			
			Point p1 = new Point(Start.X - Location.X, Start.Y - Location.Y);
			Point p2 = new Point(End.X - Location.X, End.Y - Location.Y);
			g.DrawLine(Pen, p1, p2);
			double dx = p2.X - p1.X;
			double dy = p2.Y - p1.Y;
			double th = Math.Atan(dy / dx) * 180 / Math.PI;
			if (dx < 0)
				th += 180;
			float f = 5 * Pen.Width;
			PointF[] points = new PointF[] { new PointF(), new PointF(f, f), new PointF(f, -f) };
			if (atS)
			{
				g.TranslateTransform(p1.X, p1.Y);
				g.RotateTransform((float)th);
				g.FillPolygon(Pen.Brush, points);
                g.RotateTransform(-(float)th);
                g.TranslateTransform(-p1.X, -p1.Y);
            }
			if (atE)
			{
				g.TranslateTransform(p2.X, p2.Y);
				g.RotateTransform((float)(th + 180));
				g.FillPolygon(Pen.Brush, points);
                g.RotateTransform(-(float)(th + 180));
                g.TranslateTransform(-p2.X, -p2.Y);
            }
		}

		protected void Line_PointChanged()
		{
			Size s;
			Point p;
			if (st.X == end.X)
			{
				mode = LineMode.Vertical;
				s = new Size((int)(10 * Pen.Width), Math.Abs(st.Y - end.Y));
				p = new Point((int)(st.X - (5 * Pen.Width)), Math.Min(st.Y, end.Y));
			}
			else if (st.Y == end.Y)
			{
				mode = LineMode.Horizontal;
				s = new Size(Math.Abs(st.X - end.X), (int)(10 * Pen.Width));
				p = new Point(Math.Min(st.X, end.X), (int)(st.Y - (5 * Pen.Width)));
			}
			else
			{
				if ((double)(end.Y - st.Y) / (end.X - st.X) > 0)
					mode = LineMode.Positive;
				else
					mode = LineMode.Negative;
				s = new Size(Math.Abs(st.X - end.X) + (int)(10 * Pen.Width), Math.Abs(st.Y - end.Y) + (int)(10 * Pen.Width));
				p = new Point(Math.Min(st.X, end.X) - (int)(5 * Pen.Width), Math.Min(st.Y, end.Y) - (int)(5 * Pen.Width));
			}
			Bounds = new Rectangle(p, s);

		}
	}
}
