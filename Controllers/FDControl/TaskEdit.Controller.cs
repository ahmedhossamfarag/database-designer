using DatabaseDesigner.Models.IFD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal partial class TaskEdit
	{
		public void Set(Task task)
		{
			NameBox.Text = task.Name;
			InCheck.Checked = task.In;
			OutCheck.Checked = task.Out;
			OkButton.Select();
		}


		public void Update(Task task)

		{
			//
			//Check Name
			if (string.IsNullOrWhiteSpace(NameBox.Text))
				throw new InvalidOperationException("Invalid Name");
			if (NameBox.Text != task.Name &&
				task.FlowDiagram.Tasks.Any(t => t.Task.Name == NameBox.Text))
				throw new InvalidOperationException("Invalid Name");
			//
			//Parent
			if (task.Parent != null)
			{
				if (InCheck.Checked & !task.Parent.In || OutCheck.Checked & !task.Parent.Out)
					throw new InvalidOperationException("Invalid In/Out");
			}
			//
			//Update
			task.Name = NameBox.Text;
			task.In = InCheck.Checked;
			task.Out = OutCheck.Checked;
			//
			//
			Close();
		}
	}
}
