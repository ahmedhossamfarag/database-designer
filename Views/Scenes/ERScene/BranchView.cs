using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Controllers;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class BranchView : CirText, IControllable
	{
		public Branch Branch { get; }
		public IItemController Controller => Branch.Controller;

		public Dictionary<Entity, Line> Lines = new Dictionary<Entity, Line>();

		public BranchView(Branch branch)
		{
			Branch = branch;

			var x = branch.ERDiagram.Preferences;
			Size = x.BSize;
			SelectPen.Color = x.BSelectColor;
			SelectFill.Color = x.BSelectColor;
			DrawPen.Color = x.BColor;
			FillColor.Color = x.BColor;
			Fill = x.Fill;
			ForeColor = x.BTextColor;

			Text = "d";
			branch.OverlapChanged = o => Text = o ? "o" : "d";
			MouseClick += BranchView_MouseClick;
			MouseDown += BranchView_MouseDown;
			MouseUp += BranchView_MouseUp;
		}

		private void BranchView_MouseUp(object sender, MouseEventArgs e)
		{
			Branch.ERDiagram.Controller.MouseListner.MouseUp?.Invoke(sender, e);
		}

		private void BranchView_MouseDown(object sender, MouseEventArgs e)
		{
			Branch.ERDiagram.Controller.MouseListner.MouseDown?.Invoke(sender, e);
		}

		private void BranchView_MouseClick(object sender, MouseEventArgs e)
		{
			Branch.ERDiagram.Controller.MouseListner.MouseClick?.Invoke(sender, e);
		}
	}
}
