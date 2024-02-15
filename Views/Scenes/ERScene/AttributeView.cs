using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using Attribute = DatabaseDesigner.Models.EER.Attribute;
using DatabaseDesigner.Controllers;
using DatabaseDesigner.Models.EER;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class AttributeView : CirText, IControllable
	{
		public Attribute Attribute { get; }
		public IItemController Controller => Attribute.Controller;
		public AttributeView(Attribute attribute)
		{
			Attribute = attribute;

			var x = attribute.ERDiagram.Preferences;
			Size = x.ASize;
			SelectPen.Color = x.ASelectColor;
			SelectFill.Color = x.ASelectColor;
			DrawPen.Color = x.AColor;
			FillColor.Color = x.AColor;
			Fill = x.Fill;
			ForeColor = x.ATextColor;


			attribute.NameChanged = n => Text = n;
			void change(bool b) => Redraw();
			attribute.MultipleChanged = change;
			attribute.DrivedChanged = change;
			attribute.KeyChanged = k => Font = new Font(Font, k ? FontStyle.Underline : FontStyle.Regular);
			MouseClick += AttributeView_MouseClick;
			MouseDown += AttributeView_MouseDown;
			MouseUp += AttributeView_MouseUp;
		}

		private void AttributeView_MouseUp(object sender, MouseEventArgs e)
		{
			Attribute.ERDiagram.Controller.MouseListner.MouseUp?.Invoke(sender, e);
		}

		private void AttributeView_MouseDown(object sender, MouseEventArgs e)
		{
			Attribute.ERDiagram.Controller.MouseListner.MouseDown?.Invoke(sender, e);
		}

		private void AttributeView_MouseClick(object sender, MouseEventArgs e)
		{
			Attribute.ERDiagram.Controller.MouseListner.MouseClick?.Invoke(sender, e);
		}

		public override void DrawBorders(Graphics g)
		{
			Pen.DashPattern = Attribute.Drived ? new float[] { 10, 5 } : new float[] { 1000, 1 };
			base.DrawBorders(g);
			if (Attribute.Multiple)
			{
				g.DrawEllipse(Pen, Width / 10, Height / 10, Width * 8 / 10, Height * 8 / 10);
			}
		}

		
		public override string ToString() => Attribute.Name;
	}
}
