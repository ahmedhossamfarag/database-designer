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
	internal abstract class Shape : TransparentPanel
	{

		public Pen DrawPen { get; set; } = new Pen(Color.Black, 2);

		public Pen SelectPen { get; set; } = new Pen(Color.Blue, 2);

		private bool fill;
		public bool Fill {
			get => fill;
			set
			{
				if(fill != value)
				{
					fill = value;
					FillChanged?.Invoke();
				}
			}
		}

		public SolidBrush FillColor { get; set; } = new SolidBrush(Color.Blue);

		public SolidBrush SelectFill { get; set; } = new SolidBrush(Color.SkyBlue);
		
		public event Action FillChanged;

		private bool selected;
		
		public bool Selected { get { return selected; } set { if (value != selected) { selected = value; SelectedChanged?.Invoke(); } } }

		public Pen Pen { get => selected ? SelectPen : DrawPen; }

		public SolidBrush Brush { get => !Fill ? new SolidBrush(BackColor) : (selected ? SelectFill : FillColor); }

		
		public event Action SelectedChanged;

		public Point Center
		{
			get => new Point(Location.X + (Width / 2), Location.Y + (Height / 2));
			set 
			{
				Location = new Point(value.X - (Width / 2), value.Y - (Height / 2));
			}
		}

		public Rectangle Rectangle
		{
			get
			{
				int ds = (int)Pen.Width;
				return new Rectangle(ds, ds, Width - (3 * ds), Height - (3 * ds));
			}
		}

		public Shape()
		{
			SelectedChanged += Shape_SelectedChanged;
		}

		private void Shape_SelectedChanged() => Redraw();

		public override void PaintContent(Graphics g)
		{
			FillBackground(g);
			if(!Fill)
				DrawBorders(g);
		}

		public void FactorBounds(Size size, double factor, Point move)
		{
			var center = Center;
			var width = (int)(size.Width * factor);
			var height = (int)(size.Height * factor);
			Bounds = new Rectangle(center.X - width / 2 + move.X,
				center.Y - height / 2 + move.Y, width, height); ;
		}

		public virtual void FillBackground(Graphics g) { }

		public virtual void DrawBorders(Graphics g) { }

		//
		//
	}
}
