using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers.FDControl
{
	internal class IOScreenController : IItemController
	{
		public IOScreen IOScreen { get; set; }

		public IOScreenView View { get => IOScreen.View; }
		public IOScreenController Controller { get => IOScreen.Controller; }

		public IOScreenController(IOScreen iOScreen)
		{
			IOScreen = iOScreen;
			iOScreen.Tasks.ItemAdded += Tasks_ItemAdded;
			iOScreen.Tasks.ItemRemoved += Tasks_ItemRemoved;
		}

		private void Tasks_ItemRemoved(IOTask o)
		{
			IOScreen.FlowDiagram.Controls.Remove(o.Arrow);
		}

		private void Tasks_ItemAdded(IOTask o)
		{
			o.Arrow = CreateArrow(o);
			IOScreen.FlowDiagram.Controller.AddArrow(o.Arrow);
			o.Task.View.Removed += p => IOScreen.Tasks.Remove(o);
		}

		public Arrow CreateArrow(IOTask iOTask)
		{
			ArrowShape a = new ArrowShape(IOScreen.View, iOTask.Task.View)
			{
				AtStart = iOTask.Out,
				AtEnd = iOTask.In,
			};
			a.Pen.Color = IOScreen.FlowDiagram.Preferences.IOArrowColor;
			iOTask.InChanged = b => a.AtEnd = b;
			iOTask.OutChanged = b => a.AtStart = b;
			return a;
		}

		public static void New(FDVController fDV, Point p)
		{
			IOScreenEdit ioEdit = new IOScreenEdit() { TaskViews = fDV.View.Tasks, Text = "New IOScreen" };
			IOScreen iOScreen = new IOScreen(fDV.View);
			ioEdit.OnOk = () =>
			{
				ioEdit.Update(iOScreen);
				iOScreen.View.Center = p;
				fDV.AddIOScreen(iOScreen);
			};
			ioEdit.ShowDialog();
		}

		public void AddTaskIO()
		{
			IOScreenTask ioEdit = new IOScreenTask() { Tasks = IOScreen.FlowDiagram.Tasks.SkipWhile(t => IOScreen.Tasks.Any(a => a.Task == t.Task)), Text = "New Task IO" };
			IOTask iOScreen = new IOTask();
			ioEdit.OnOk = () =>
			{
				ioEdit.Update(iOScreen);
				IOScreen.Tasks.Add(iOScreen);
			};
			ioEdit.ShowDialog();
		}

		public void Edit()
		{
			IOScreenEdit ioEdit = new IOScreenEdit() { TaskViews = IOScreen.FlowDiagram.Tasks, Text = "Edit IOScreen" };
			ioEdit.Set(IOScreen);
			ioEdit.OnOk = () =>
			{
				ioEdit.Update(IOScreen);
			};
			ioEdit.ShowDialog();
		}

		public void Delete()
		{
			IOScreen.FlowDiagram.Controller.RemoveIOScreen(IOScreen);
		}

		public void Move(int x, int y)
		{
			View.Location = new Point(View.Location.X + x, View.Location.Y + y);
		}

		public void SetSelect(bool flg) => View.Selected = flg;

	}
}
