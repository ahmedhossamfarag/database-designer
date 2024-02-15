using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene1
{
	internal class PipeLine : Panel
	{
		readonly Pen P = new Pen(Color.FromArgb(100,255,255,255), 5);
		readonly Font F = new Font(FontFamily.GenericMonospace, 12);
		readonly string[] M = { "Analysis", "Specification", "Design", "Implementaion" };

		public PipeLine()
		{
			Resize += (s, e) => Refresh();
		}

		public void PaintComponent(PaintEventArgs e)
		{
			int w = Math.Min(Width / 4, 300);
			int dx = Width / 4;
			int y = Height / 2;
			int dy = y / 2;
			int xi = dx / 2;
			for (int i = 1; i < M.Length; i++)
			{
				e.Graphics.DrawLine(P, xi, y - dy, xi + dx, y + dy);
				xi += dx;
				dy *= -1;
			}
			dy = y / 2;
			xi = dx / 2;

			foreach (string m in M)
			{
				Rectangle r = new Rectangle(xi - (w / 2), y - dy - (w / 2), w, w);
				e.Graphics.FillEllipse(new SolidBrush(BackColor), r);
				e.Graphics.DrawEllipse(P, r);
				Label l = new Label()
				{
					Text = m,
					ForeColor = Color.FromArgb(100, 0, 0, 255),
					Font = F,
				};
				Size s = l.GetPreferredSize(Size);
				int xl = xi - (s.Width / 2);
				int yl = y - dy - (s.Height / 2);
				e.Graphics.DrawString(m, F, new SolidBrush(l.ForeColor), new PointF(xl, yl));
				xi += dx;
				dy *= -1;
			}
			
		}
	}
}
