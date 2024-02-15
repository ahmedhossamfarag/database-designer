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
	internal class EntityView : RecText, IControllable
	{
		public Entity Entity { get; }
		public IItemController Controller => Entity.Controller;
		public EntityView(Entity entity)
		{
			Entity = entity;

			var x = entity.ERDiagram.Preferences;
			Size = x.ESize;
			SelectPen.Color = x.ESelectColor;
			SelectFill.Color = x.ESelectColor;
			DrawPen.Color = x.EColor;
			FillColor.Color = x.EColor;
			Fill = x.Fill;
			ForeColor = x.ETextColor;


			entity.NameChanged = n => Text = n;
			entity.WeakChanged = w => Redraw();
			MouseClick += EntityView_MouseClick;
			MouseDown += EntityView_MouseDown;
			MouseUp += EntityView_MouseUp;
		}

		private void EntityView_MouseUp(object sender, MouseEventArgs e)
		{
			Entity.ERDiagram.Controller.MouseListner.MouseUp?.Invoke(sender, e);
		}

		private void EntityView_MouseDown(object sender, MouseEventArgs e)
		{
			Entity.ERDiagram.Controller.MouseListner.MouseDown?.Invoke(sender, e);
		}

		private void EntityView_MouseClick(object sender, MouseEventArgs e)
		{
			Entity.ERDiagram.Controller.MouseListner.MouseClick?.Invoke(sender, e);
		}

		public override void DrawBorders(Graphics g)
		{
			base.DrawBorders(g);
			if (Entity.Weak)
				g.DrawRectangle(Pen, Width / 10, Height / 10, Width * 8 / 10, Height * 8 / 10);
		}
		public override string ToString() => Entity.Name;
	}
}
