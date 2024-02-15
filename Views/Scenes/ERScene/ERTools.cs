using System.Drawing;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class ERTools : FlowLayoutPanel
	{
		public Button Ent { get; }
		public Button Rel { get; }
		public Button Free { get; }

		private readonly Pen Pen = new Pen(Color.Black);

		public ERTools()
		{
			FlowDirection = FlowDirection.TopDown;
			Width = 60;
			Height = 160;
			Size size = new Size(50, 50);
			//
			//Ent
			Ent = new Button()
			{
				Size = size
			};
			Ent.Paint += EntPaint;
			//
			//Rel
			Rel = new Button()
			{
				Size = size
			};
			Rel.Paint += RelPaint;
			//
			//Free
			Free = new Button()
			{
				Size = size
			};
			//
			//
			Controls.Add(Free);
			Controls.Add(Ent);
			Controls.Add(Rel);
		}

		private void EntPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(Pen, 10, 10, 30, 30);
		}
		private void RelPaint(object sender, PaintEventArgs e)
		{
			Point[] points = {new Point(10,25), new Point(25, 10),
								new Point(40, 25), new Point(25, 40)};
			e.Graphics.DrawPolygon(Pen, points);
		}
		

	}
}
