using DatabaseDesigner.Models.IFD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal partial class IOScreenEdit
	{
		public List<TaskView> TaskViews
		{
			set
			{
				TBox.Items.AddRange(value.ToArray());
			}
		}

		public void AddTask(IOTask t)
		{
			TaskItemView v = new TaskItemView(t);
			TasksPanel.Controls.Add(v);
			TBox.Items.Remove(t.Task.View);
			v.Delete.Click += (s, e) =>
			{
				TBox.Items.Add(t.Task.View);
				TasksPanel.Controls.Remove(v);
			};
		}


		public void Set(IOScreen iO)
		{
			NameBox.Text = iO.Name;
			iO.Tasks.ForEach(AddTask);
		}

		public void Update(IOScreen iO)
		{
			//
			//Check Name
			if (string.IsNullOrWhiteSpace(NameBox.Text))
				throw new InvalidOperationException("Invalid Name");
			if (NameBox.Text != iO.Name &&
				iO.FlowDiagram.IOScreens.Any(i => i.IOScreen.Name == NameBox.Text))
				throw new InvalidOperationException("Invalid Name");
			//
			//Update
			iO.Name = NameBox.Text;
			IEnumerable<TaskItemView> taskItems = TasksPanel.Controls.Cast<TaskItemView>();
			foreach(IOTask t in new List<IOTask>(iO.Tasks))
			{
				if (!taskItems.Any(i => i.Task == t.Task))
					iO.Tasks.Remove(t);
			}
			foreach (TaskItemView v in taskItems)
			{
				IOTask iOTask = iO.Tasks.Find(i => i.Task == v.Task);
				if (iOTask != null)
				{
					iOTask.In = v.TaskIn.Checked;
					iOTask.Out = v.TaskOut.Checked;
				}
				else
				{
					iO.Tasks.Add(new IOTask(v.Task, v.TaskIn.Checked, v.TaskOut.Checked));
				}
			}
			//
			//
			Close();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			if (TBox.SelectedIndex < 0) return;
			TaskView task = (TaskView)TBox.SelectedItem;
			AddTask(new IOTask(task.Task, false, false));
		}
	}
}
