using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	public enum BaziarMode
	{
		Z,
		N,
		UR,
		UL
	}

	public enum ManyMode
	{	
		None,
		N,
		N1,
		NN
	}

	internal class Baziar : TransparentPanel
	{
		Point st, end;

		public Point Start { get { return st; } set { if (value != st) { st = value; PointChanged(); } } }
		public Point End { get { return end; } set { if (value != end) { end = value; PointChanged(); } } }

		event Action PointChanged;

		public Pen Pen { get; set; } = new Pen(Color.Black, 2);



		BaziarMode mode = BaziarMode.Z;
		public BaziarMode Mode
		{
			get => mode;
			set
			{
				if(value != mode)
				{
					mode = value;
					PointChanged();
				}
			}
		}



		ManyMode many = ManyMode.None; 
		public ManyMode Many
		{
			get => many;
			set
			{
				if (value != many)
				{
					many = value;
					Redraw();
				}
			}
		}


		public Baziar()
		{
			PointChanged += Baziar_PointChanged;
		}

		private void Baziar_PointChanged()
		{
			Line_PointChanged();
			Redraw();
		}

		public override void PaintContent(Graphics g)
		{
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			Point p1, p2, p3, p4;
			p1 = new Point(st.X - Location.X, st.Y - Location.Y);
			p4 = new Point(end.X - Location.X, end.Y - Location.Y);
			switch (mode)
			{
				case BaziarMode.Z: {
						p2 = new Point(p4.X, p1.Y);
						p3 = new Point(p1.X, p4.Y);
						break; 
					}
				case BaziarMode.N: {
						p3 = new Point(p4.X, p1.Y);
						p2 = new Point(p1.X, p4.Y);
						break; 
					}
				case BaziarMode.UR: {
						p2 = new Point(p1.X + 200, p1.Y);
						p3 = new Point(p4.X + 200, p4.Y);
						break; 
					}
				default: {
						p2 = new Point(p1.X - 200, p1.Y);
						p3 = new Point(p4.X - 200, p4.Y);
						break; 
					}
				
			}
			g.DrawBezier(Pen, p1, p2, p3, p4);
			switch (many)
			{
				case ManyMode.N:
					{
						if (mode == BaziarMode.N)
							p4.X += 10;
						else
							p4.Y += 10;
						g.DrawBezier(Pen, p1, p2, p3, p4);
						if (mode == BaziarMode.N)
							p4.X -= 20;
						else
							p4.Y -= 20;
						g.DrawBezier(Pen, p1, p2, p3, p4);
						break;
					}
				case ManyMode.N1:
					{
						if (mode == BaziarMode.N)
							p1.X += 10;
						else
							p1.Y += 10;
						g.DrawBezier(Pen, p1, p2, p3, p4);
						if (mode == BaziarMode.N)
							p1.X -= 20;
						else
							p1.Y -= 20;
						g.DrawBezier(Pen, p1, p2, p3, p4);
						break;
					}
				case ManyMode.NN:
					{
						if (mode == BaziarMode.N)
						{
							p4.X += 10;
							p1.X -= 10;
						}
						else
						{
							p4.Y += 10;
							p1.Y -= 10;
						}
						g.DrawBezier(Pen, p1, p2, p3, p4);
						if (mode == BaziarMode.N)
						{
							p4.X -= 20;
							p1.X += 20;
						}
						else
						{
							p4.Y -= 20;
							p1.Y += 20;
						}
						g.DrawBezier(Pen, p1, p2, p3, p4);
						break;
					}
				
			}
		}

		protected void Line_PointChanged()
		{
			Size s;
			Point p;
			switch (mode)
			{
				case BaziarMode.Z:
				case BaziarMode.N:
					{
						p = new Point(Math.Min(st.X, end.X) - 10, Math.Min(st.Y, end.Y) - 10);
						s = new Size(Math.Abs(st.X - end.X) + 25, Math.Abs(st.Y - end.Y) + 25);
						break;
					}
				case BaziarMode.UR:
					{
						p = new Point(Math.Min(st.X, end.X) - 10, Math.Min(st.Y, end.Y) - 10);
						s = new Size(Math.Abs(st.X - end.X) + 225, Math.Abs(st.Y - end.Y) + 25);
						break;
					}
				default:
					{
						p = new Point(Math.Min(st.X, end.X) - 210, Math.Min(st.Y, end.Y) - 10);
						s = new Size(Math.Abs(st.X - end.X) + 225, Math.Abs(st.Y - end.Y) + 25);
						break;
					}

			}
			Bounds = new Rectangle(p, s);
		}

	}
}
