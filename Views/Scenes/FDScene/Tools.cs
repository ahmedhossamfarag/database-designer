using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class Tools : FlowLayoutPanel
	{
		public Button Circle { get; }
		public Button Rec { get; }
		public Button Free { get; }
		public Tools()
		{
			FlowDirection = FlowDirection.TopDown;
			Width = 60;
			Height = 250;

			//
			//	Free
			//
			Free = new Button()
			{
				Width = 50,
				Height = 50,
				Cursor = Cursors.Hand
			};
			Controls.Add(Free);

			//
			//	Circle
			//
			Pen P = new Pen(Color.Black);
			Circle = new Button()
			{
				Width = 50,
				Height = 50,
				Cursor = Cursors.Hand
			};
			Circle.Paint += (s, e) =>
			{
				e.Graphics.DrawEllipse(P, 10, 10, 30, 30);
			};
			Controls.Add(Circle);

			//
			//	Rec
			//
			Rec = new Button()
			{
				Width = 50,
				Height = 50,
				Cursor = Cursors.Hand
			};
			Rec.Paint += (s, e) =>
			{
				e.Graphics.DrawRectangle(P, 10, 10, 30, 30);
			};
			Controls.Add(Rec);
		}
	}
}
