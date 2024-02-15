using DatabaseDesigner.Controllers.FDControl;
using DatabaseDesigner.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseDesigner.Controllers.ERControl;
using DatabaseDesigner.Models.Preference;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class ERDiagramView : Diagram
	{
		public List<EntityView> Entities { get; } = new List<EntityView>();
		public List<AttributeView> Attributes { get; } = new List<AttributeView>();
		public List<RelationView> Relations { get; } = new List<RelationView>();
		public List<BranchView> Branches { get; } = new List<BranchView>();
		public List<UnionView> Unions { get; } = new List<UnionView>();

		public ERController Controller { get; set; }

		public ERPreferences Preferences { get; private set; }

		public override DiagramController DiagramController => Controller;

		public ERDiagramView()
		{
			MouseClick += ERDiagramView_MouseClick;
			MouseDown += ERDiagramView_MouseDown;
			MouseUp += ERDiagramView_MouseUp;
		}

		public void SetPreferences(ERPreferences preferences)
		{
			Preferences = preferences;
			Size = preferences.DiagramSize;
			DScale = (float)Math.Pow(1.1, preferences.Scale);
			Controller.ScaleToolView.Value = 100 + (10 * preferences.Scale);

		}

		private void ERDiagramView_MouseUp(object sender, MouseEventArgs e)
		{
			Controller.MouseListner.MouseUp?.Invoke(sender, e);
		}

		private void ERDiagramView_MouseDown(object sender, MouseEventArgs e)
		{
			Controller.MouseListner.MouseDown?.Invoke(sender, e);
		}

		private void ERDiagramView_MouseClick(object sender, MouseEventArgs e)
		{
			Controller.MouseListner.MouseClick?.Invoke(sender, e);
		}
	}
}
