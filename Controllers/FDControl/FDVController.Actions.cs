using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DatabaseDesigner.Controllers.FDControl
{
	internal partial class FDVController
	{
		public void NewTask(Point p)
		{
			TaskController.New(this, p);
		}

		public void NewIoScreen(Point p)
		{
			IOScreenController.New(this, p);
		}

		public void AddTask(Task task)
		{
			View.Tasks.Add(task.View);
			View.Controls.Add(task.View);
		}

		public void AddIOScreen(IOScreen iOScreen)
		{
			View.IOScreens.Add(iOScreen.View);
			View.Controls.Add(iOScreen.View);
		}

		public void AddArrow(Arrow a)
		{
			View.Controls.Add(a);
			a.BringToFront();
		}

		public void RemoveArrow(Arrow a) {
			View.Controls.Remove(a); 
		}

		public void RemoveTask(Task task)
		{
			View.Tasks.Remove(task.View);
			View.Controls.Remove(task.View);
			SelectedShapes.Remove(task.Controller);
		}


		public void RemoveIOScreen(IOScreen iOScreen)
		{
			View.IOScreens.Remove(iOScreen.View);
			View.Controls.Remove(iOScreen.View);
			SelectedShapes.Remove(iOScreen.Controller);
		}


	}
}
