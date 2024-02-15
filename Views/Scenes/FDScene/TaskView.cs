using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Controllers.FDControl;
using DatabaseDesigner.Controllers;
using DatabaseDesigner.Models.Preference;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class TaskView : CirText, IControllable
	{
		public Task Task { get; set; }
		public FDVController FDVController => Task.FlowDiagram.Controller;
		public IItemController Controller { get => Task.Controller; } 

		public Dictionary<Task, ArrowShape> Lines = new Dictionary<Task, ArrowShape>();

		public TaskView(Task task)
		{
			Task = task;


			var x = task.FlowDiagram.Preferences;
            Size = x.TSize;
            SetColors(x);

            task.NameChanged = n => Text = n;
			MouseClick += TaskView_MouseClick;
			MouseDown += TaskView_MouseDown;
			MouseUp += TaskView_MouseUp;
		}

        public void Set(FDPreferences x, Point move, float dScale)
        {
			SetColors(x);
			FactorBounds(x.TSize, dScale, move);
        }

		private void SetColors(FDPreferences x)
		{
            SelectPen.Color = x.TSelectColor;
            SelectFill.Color = x.TSelectColor;
            DrawPen.Color = x.TColor;
            FillColor.Color = x.TColor;
            Fill = x.Fill;
            ForeColor = x.TTextColor;
        }

        private void TaskView_MouseUp(object sender, MouseEventArgs e)
		{
			FDVController.MouseListner.MouseUp?.Invoke(sender, e);
		}

		private void TaskView_MouseDown(object sender, MouseEventArgs e)
		{
			FDVController.MouseListner.MouseDown?.Invoke(sender, e);
		}

		private void TaskView_MouseClick(object sender, MouseEventArgs e)
		{
			FDVController.MouseListner.MouseClick?.Invoke(sender, e);
		}

		public override string ToString() => Task.Name;
	}
}
