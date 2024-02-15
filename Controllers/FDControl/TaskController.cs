using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DatabaseDesigner.Controllers.FDControl
{
	internal class TaskController : IItemController
	{
		public Task Task;
		public TaskView View { get => Task.View; }
		public TaskController(Task task)
		{
			Task = task;
			task.SubTasks.ItemAdded += SubTasks_ItemAdded;
			task.SubTasks.ItemRemoved += SubTasks_ItemRemoved;
		}

		private void SubTasks_ItemRemoved(Task obj)
		{

			Task.FlowDiagram.Controller.RemoveArrow(Task.View.Lines[obj]);
			Task.View.Lines.Remove(obj);
		}

		private void SubTasks_ItemAdded(Task t)
		{
			var a = CreateArrow(t);
			Task.FlowDiagram.Controller.AddArrow(a);
			Task.View.Lines.Add(t, a);
		}

		public static void New(FDVController fDV, Point p)
		{
			
			TaskEdit taskEdit = new TaskEdit() { Text = "New Task"};
			Task task = new Task(fDV.View);
			taskEdit.OnOk = () =>
			{
				taskEdit.Update(task);
				task.View.Center = p;
				fDV.AddTask(task);
				fDV.AddArrow(CreateArrow(task));
			};
			taskEdit.ShowDialog();
		}

		public static ArrowShape CreateArrow(Task task)
		{
			Shape s;
			if (task.Parent == null)
				s = task.FlowDiagram.Database;
			else
				s = task.Parent.View;
			ArrowShape arrowShape = new ArrowShape(s, task.View) { AtStart = task.In, AtEnd = task.Out};
			arrowShape.Pen.Color = task.FlowDiagram.Preferences.TArrowColor;
			task.InChanged = b => arrowShape.AtStart = b;
			task.OutChanged = b => arrowShape.AtEnd = b;
			return arrowShape;
		}

		public void AddSubTask()
		{
			TaskEdit taskEdit = new TaskEdit() { Text = "New Sub Task" };
			Task task = new Task(Task.FlowDiagram) { Parent = Task };
			taskEdit.Set(task);
			taskEdit.OnOk = () =>
			{
				taskEdit.Update(task);
				Task.FlowDiagram.Controller.OnClick = (p) =>
				{
					task.View.Center = p;
					Task.FlowDiagram.Controller.AddTask(task);
					Task.SubTasks.Add(task);
					Task.FlowDiagram.Controller.OnClick = null;
				};
			};
			taskEdit.ShowDialog();
		}

		public void Edit()
		{
			TaskEdit taskEdit = new TaskEdit() { Text = "Edit Task" };
			taskEdit.Set(Task);
			taskEdit.OnOk = () =>
			{
				taskEdit.Update(Task);
			};
			taskEdit.ShowDialog();
		}

		public void Delete()
		{
			Task.Parent?.SubTasks.Remove(Task);
			new List<Task>(Task.SubTasks).ForEach(t => t.Controller.Delete());
			Task.FlowDiagram.Controller.RemoveTask(Task);
		}

		public void Move(int x, int y)
		{
			View.Location = new Point(View.Location.X + x, View.Location.Y + y);
		}

		public void SetSelect(bool flg) => View.Selected = flg;

	}
}
