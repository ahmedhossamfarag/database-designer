using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	public enum LineMode
	{
		Horizontal,
		Vertical,
		Positive,
		Negative
	}

	internal class Line : TransparentPanel
	{
		protected Point st, end;

		protected LineMode? mode;
		public Point Start { get { return st; } set { if (value != st) { st = value; PointChanged?.Invoke(); } } }
		public Point End { get { return end; } set { if (value != end) { end = value; PointChanged?.Invoke(); } } }

		public Pen Pen { get; set; } = new Pen(Color.White, 2);

		public event Action PointChanged;

		public virtual int Gap { get; } = 5;

		public virtual int G { get; } = 0;

		public Line(Point s, Point e)
		{
			st = s;
			end = e;
			PointChanged += Line_PointChanged;
			Line_PointChanged();
		}


        public Line(int xi, int yi, int xf, int yf) : this(new Point(xi, yi), new Point(xf, yf)) { }

		public Line() : this(0, 0, 100, 100) { }

		public virtual void Line_PointChanged()
		{
			Size s;
			Point p;
			if (st.X == end.X)
			{
				mode = LineMode.Vertical;
				s = new Size((int)(Gap * 2 * Pen.Width), Math.Abs(st.Y - end.Y));
				p = new Point((int)(st.X - (Gap * Pen.Width)), Math.Min(st.Y, end.Y));
			}
			else if (st.Y == end.Y)
			{
				mode = LineMode.Horizontal;
				s = new Size(Math.Abs(st.X - end.X), (int)(Gap * 2 * Pen.Width));
				p = new Point(Math.Min(st.X, end.X), (int)(st.Y - (Gap * Pen.Width)));
			}
			else
			{
				if ((double)(end.Y - st.Y) / (end.X - st.X) > 0)
					mode = LineMode.Positive;
				else
					mode = LineMode.Negative;
				s = new Size(Math.Abs(st.X - end.X) + 2 * G, Math.Abs(st.Y - end.Y) + 2 * G);
				p = new Point(Math.Min(st.X, end.X) - G, Math.Min(st.Y, end.Y) - G);
			}
			Bounds = new Rectangle(p, s);
		}

		public override void PaintContent(Graphics g)
		{
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			switch (mode)
			{
				case LineMode.Horizontal: { g.DrawLine(Pen, 0, Gap * Pen.Width, Width, Gap * Pen.Width); break; }
				case LineMode.Vertical: { g.DrawLine(Pen, Gap * Pen.Width, 0, Gap * Pen.Width, Height); break; }
				case LineMode.Positive: { g.DrawLine(Pen, G, G, Width - G, Height - G); break; }
				case LineMode.Negative: { g.DrawLine(Pen, G, Height - G, Width - G, G); break; }

			}
		}

		protected override void TransparentPanel_Resize(object sender, EventArgs e)
		{
			Refresh();
			base.TransparentPanel_Resize(sender, e);
		}
	}
}
