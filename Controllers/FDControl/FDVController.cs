using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DatabaseDesigner.Views.Scenes.Base;
using System.ComponentModel.Design;
using DatabaseDesigner.Models.Preference;
using DatabaseDesigner.Controllers.ERControl;
using DatabaseDesigner.Models.Database;
using System.Threading.Tasks;

namespace DatabaseDesigner.Controllers.FDControl
{
	internal partial class FDVController : DiagramController
	{
		public FDScene Scene;

		public FlowDiagramView View;

		public TaskOptions TaskOptions => Scene.TaskOptions1;

		public IOScreenOptions IOScreenOptions => Scene.IOScreenOptions1;

		
		public FDVController(FDScene scene) : base(scene.FlowDiagramView, scene.ScaleToolView)
		{
			Scene = scene;
			View = scene.FlowDiagramView;
			Tools = scene.ToolsView;
			scene.ToolsView.Free.Click += Free_Click;
			scene.ToolsView.Circle.Click += Circle_Click;
			scene.ToolsView.Rec.Click += Rec_Click;
			scene.ScaleToolView.ZoomIn.Click += ZoomIn_Click;
			scene.ScaleToolView.ZoomOut.Click += ZoomOut_Click;
			SetDefaultMouseListner();
		}

		private void ZoomOut_Click(object sender, EventArgs e) => View.Preferences.Scale--;

		private void ZoomIn_Click(object sender, EventArgs e) => View.Preferences.Scale++;

		private void Rec_Click(object sender, EventArgs e) => OnClick = NewIoScreen;

		private void Circle_Click(object sender, EventArgs e) => OnClick = NewTask;

		private void Free_Click(object sender, EventArgs e) => SetDefault();

		
		public override void ChangeMode()
		{
			base.ChangeMode();
			TaskOptions.View = null;
			IOScreenOptions.View = null;
			Scene.ToolsView.Free.Select();
		}

		public override void DefaultMouseClick(object s, MouseEventArgs e)
		{
			
			if(s is TaskView tv)
			{
				TaskOptions.Location = PointToScene(tv.Center);
				TaskOptions.View = tv;
				IOScreenOptions.View = null;
			}
			else if(s is IOScreenView io)
			{
				IOScreenOptions.Location = PointToScene(io.Center);
				IOScreenOptions.View = io;
				TaskOptions.View = null;
			}
			else
			{
				TaskOptions.View = null;
				IOScreenOptions.View = null;
				if (s == View)
					OnClick?.Invoke(e.Location);
			}
		}

        public override void SetPreferences()
        {
            FDPreferencesEdit edit = new FDPreferencesEdit();
			edit.Set(View.Preferences);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                UpdatePreferences(edit.Get());
            }
        }

        private void UpdatePreferences(FDPreferences preferences)
        {
            preferences.Scale = View.Preferences.Scale;
			View.Preferences = preferences;
			var size = View.Size;
            View.Size = preferences.DiagramSize;
			var move = new Point((View.Width - size.Width) / 2, (View.Height - size.Height) / 2);
            foreach (var control in View.Controls)
            {
                if(control is ArrowShape arrow)
				{
					if(arrow.Shape1 is IOScreenView)
                    {
						arrow.Pen.Color = preferences.IOArrowColor;
                    }
                    else
					{
                        arrow.Pen.Color = preferences.TArrowColor;
                    }
					arrow.Refresh();
				}
            }
            View.Database.Set(View, move, View.DScale);
            View.Tasks.ForEach(t => t.Set(preferences, move, View.DScale));
            View.IOScreens.ForEach(io => io.Set(preferences, move, View.DScale));
        }
    }

}
