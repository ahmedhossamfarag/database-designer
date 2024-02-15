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
using DatabaseDesigner.Models.IFD;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class UnionView : CirText, IControllable
	{
		public Union Union { get; }

		public IItemController Controller => Union.Controller;

		public Dictionary<Entity, Line> Lines = new Dictionary<Entity, Line>();

		public UnionView(Union union)
		{
			Union = union;

			var x = union.ERDiagram.Preferences;
			Size = x.USize;
			SelectPen.Color = x.USelectColor;
			SelectFill.Color = x.USelectColor;
			DrawPen.Color = x.UColor;
			FillColor.Color = x.UColor;
			Fill = x.Fill;
			ForeColor = x.UTextColor;


			Text = "U";
			MouseClick += UnionView_MouseClick;
			MouseDown += UnionView_MouseDown;
			MouseUp += UnionView_MouseUp;
		}

		private void UnionView_MouseUp(object sender, MouseEventArgs e)
		{
			Union.ERDiagram.Controller.MouseListner.MouseUp?.Invoke(sender, e);
		}

		private void UnionView_MouseDown(object sender, MouseEventArgs e)
		{
			Union.ERDiagram.Controller.MouseListner.MouseDown?.Invoke(sender, e);
		}

		private void UnionView_MouseClick(object sender, MouseEventArgs e)
		{
			Union.ERDiagram.Controller.MouseListner.MouseClick?.Invoke(sender, e);
		}
	}
}
