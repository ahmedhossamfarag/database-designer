using DatabaseDesigner.Controllers;
using DatabaseDesigner.Controllers.FDControl;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models.Preference;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class FlowDiagramView : Diagram
	{
		public List<TaskView> Tasks { get; } = new List<TaskView>();

		public List<IOScreenView> IOScreens { get; } = new List<IOScreenView>();

		public DatabaseView Database { get; set; }
		public FDVController Controller { get; set; }

		public override DiagramController DiagramController => Controller;

		public FDPreferences Preferences { get; set; }

		public FlowDiagramView()
		{
			MouseClick += FlowDiagramView_MouseClick;
			MouseDown += FlowDiagramView_MouseDown;
			MouseUp += FlowDiagramView_MouseUp;
            ControlAdded += FlowDiagramView_ControlAdded;
		}

        private void FlowDiagramView_ControlAdded(object sender, ControlEventArgs e)
        {
			Database.SendToBack();
        }

        public void SetPreferences(FDPreferences preferences)
		{
			Preferences = preferences;
			Size = preferences.DiagramSize;
			DScale = (float)Math.Pow(1.1, preferences.Scale);
			Controller.ScaleToolView.Value = 100 + (10 * preferences.Scale);
			Database = new DatabaseView(this);
			Controls.Add(Database);
		}

		private void FlowDiagramView_MouseUp(object sender, MouseEventArgs e)
		{
			Controller.MouseListner.MouseUp?.Invoke(sender, e);
		}

		private void FlowDiagramView_MouseDown(object sender, MouseEventArgs e)
		{
			Controller.MouseListner.MouseDown?.Invoke(sender, e);
		}

		private void FlowDiagramView_MouseClick(object sender, MouseEventArgs e)
		{
			Controller.MouseListner.MouseClick?.Invoke(sender, e);
		}

		public FlowDiagram GetFlowDiagram()
		{
			return new FlowDiagram()
			{
				Tasks = Tasks.ConvertAll(t => t.Task),
				IOScreens = IOScreens.ConvertAll(i => i.IOScreen),
			};
		}

	}
}
