using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class ScaleTool : Panel
	{
		public Button ZoomIn { get; }
		public Button ZoomOut { get; }
		public Label L { get; }
		public Button MoveEnable { get; }

		public Button Center { get; }

		private readonly int max = 130, min = 70;
		private int value_ = 100;
		public int Value { 
			get => value_;
			set {
				value_ = value;
				ZoomIn.Visible = value < max;
				ZoomOut.Visible = value > min;
				L.Text = value.ToString();
			} 
		}

		private bool movable;
		public bool Movable { get => movable; set { movable = value; MoveEnable.BackColor = movable ? Color.SkyBlue : Color.White; } }

		public ScaleTool()
		{
			Size = new System.Drawing.Size(140, 20);
			BackColor = Color.White;

			//
			//	ZoomIn
			//

			ZoomIn = new Button()
			{
				Size = new System.Drawing.Size(20, 20),
				Cursor = Cursors.Hand,
				FlatStyle = FlatStyle.Flat,
				TabStop = false
			};
			ZoomIn.FlatAppearance.BorderSize = 0;
			ZoomIn.Paint += PaintPlus;


			//
			//	L
			//

			L = new Label()
			{
				Text = "100",
				Size = new System.Drawing.Size(60, 20),
				Location = new Point(20, 0),
				TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
				Font = new System.Drawing.Font(System.Drawing.FontFamily.GenericMonospace, 10)
			};

			//
			//	ZoomOut
			//

			ZoomOut = new Button()
			{
				Size = new System.Drawing.Size(20, 20),
				Location = new Point(80, 0),
				Cursor = Cursors.Hand,
				FlatStyle = FlatStyle.Flat,
				TabStop = false
			};
			ZoomOut.FlatAppearance.BorderSize = 0;
			ZoomOut.Paint += PaintMinus;

			//
			//	MoveEnable
			//
			MoveEnable = new Button()
			{
				Size = new System.Drawing.Size(20, 20),
				Location = new Point(100, 0),
				Cursor = Cursors.Hand,
				FlatStyle = FlatStyle.Flat,
				TabStop = false
			};
			MoveEnable.FlatAppearance.BorderSize = 0;
			MoveEnable.Paint += Move_Paint;
			MoveEnable.Click += Move_Click;
			//
			//	Center
			//
			Center = new Button()
			{
				Size = new System.Drawing.Size(20, 20),
				Location = new Point(120, 0),
				Cursor = Cursors.Hand,
				FlatStyle = FlatStyle.Flat,
				TabStop = false
			};
			Center.FlatAppearance.BorderSize = 0;
			Center.Paint += Center_Paint;
			//
			// Zoom Click
			//

			ZoomIn.Click += (s, e) =>
			{
				Value += 10;
			};
			ZoomOut.Click += (s, e) =>
			{
				Value -= 10;
			};

			//
			//	Controls Add
			//

			Controls.Add(ZoomOut);
			Controls.Add(L);
			Controls.Add(ZoomIn);
			Controls.Add(MoveEnable);
			Controls.Add(Center);
		}

		private void Center_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(new Pen(Color.Black), 5, 5, 10, 10);
		}

		private void Move_Click(object sender, EventArgs e)
		{
			Movable = !Movable;
		}

		private void Move_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawLine(new Pen(Color.Black), 3, 10, 17, 10);
			e.Graphics.DrawLine(new Pen(Color.Black), 10, 3, 10, 17);

			e.Graphics.DrawLine(new Pen(Color.Black), 3, 10, 5, 8);
			e.Graphics.DrawLine(new Pen(Color.Black), 3, 10, 5, 12);
			e.Graphics.DrawLine(new Pen(Color.Black), 17, 10, 15, 8);
			e.Graphics.DrawLine(new Pen(Color.Black), 17, 10, 15, 12);
		}

		private void PaintMinus(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawLine(new Pen(Color.Black), 3, 10, 17, 10);
		}

		private void PaintPlus(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawLine(new Pen(Color.Black), 3, 10, 17, 10);
			e.Graphics.DrawLine(new Pen(Color.Black), 10, 3, 10, 17);
		}
	}
}
