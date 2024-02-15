using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using DatabaseDesigner.Controllers;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class RelationView : RhText, IControllable
	{
		public Relation Relation { get; }
		public IItemController Controller => Relation.Controller;

		public Dictionary<RelationEntity, Line> Lines = new Dictionary<RelationEntity, Line>();

		public RelationView(Relation relation)
		{
			Relation = relation;

			var x = relation.ERDiagram.Preferences;
			Size = x.RSize;
			SelectPen.Color = x.RSelectColor;
			SelectFill.Color = x.RSelectColor;
			DrawPen.Color = x.RColor;
			FillColor.Color = x.RColor;
			Fill = x.Fill;
			ForeColor = x.RTextColor;


			relation.NameChanged = n => Text = n;
			relation.WeakChanged = w => Redraw();
			MouseClick += RelationView_MouseClick;
			MouseDown += RelationView_MouseDown;
			MouseUp += RelationView_MouseUp;
		}

		private void RelationView_MouseUp(object sender, MouseEventArgs e)
		{
			Relation.ERDiagram.Controller.MouseListner.MouseUp?.Invoke(sender, e);
		}

		private void RelationView_MouseDown(object sender, MouseEventArgs e)
		{
			Relation.ERDiagram.Controller.MouseListner.MouseDown?.Invoke(sender, e);
		}

		private void RelationView_MouseClick(object sender, MouseEventArgs e)
		{
			Relation.ERDiagram.Controller.MouseListner.MouseClick?.Invoke(sender, e);
		}

		public override void DrawBorders(Graphics g)
		{
			base.DrawBorders(g);
			if (Relation.Weak)
			{
				int w1 = Width / 10, w2 = Width * 9 / 10;
				int h1 = Height / 10, h2 = Height * 9 / 10;
				Point[] points =
				{
					new Point(w1, Height / 2), new Point(Width / 2, h1),
					new Point(w2, Height / 2), new Point(Width / 2, h2)
				};
				g.DrawPolygon(Pen, points);
			}
		}

		public override string ToString() => Relation.Name;
	}
}
