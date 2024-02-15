using DatabaseDesigner.Models.IFD;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class TaskItemView : Panel
	{
		public Button Delete;
		public Label TaskName;
		public CheckBox TaskIn;
		public CheckBox TaskOut;
		public Task Task;
		public TaskItemView(IOTask t)
		{
			InitializeComponent(t);
			Task = t.Task;
		}

		private void InitializeComponent(IOTask t)
		{
			Delete = new Button();
			TaskName = new System.Windows.Forms.Label();
			TaskIn = new System.Windows.Forms.CheckBox();
			TaskOut = new System.Windows.Forms.CheckBox();
			// 
			// this
			// 
			this.Controls.Add(TaskOut);
			this.Controls.Add(TaskIn);
			this.Controls.Add(TaskName);
			this.Controls.Add(Delete);
			this.Name = "this";
			this.Size = new System.Drawing.Size(385, 49);
			this.TabIndex = 0;
			//
			//Delete
			//
			Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			Delete.Location = new System.Drawing.Point(4, 15);
			Delete.Name = "AddButton";
			Delete.Size = new System.Drawing.Size(17, 17);
			Delete.TabIndex = 5;
			Delete.UseVisualStyleBackColor = true;
			Delete.Paint += Paint_Delete;
			// 
			// TaskName
			// 
			TaskName.AutoSize = true;
			TaskName.Location = new System.Drawing.Point(60, 17);
			TaskName.Name = "TaskName";
			TaskName.Text = t.Task.Name;
			TaskName.Size = new System.Drawing.Size(42, 17);
			TaskName.TabIndex = 0;
			// 
			// TaskIn
			// 
			TaskIn.AutoSize = true;
			TaskIn.Location = new System.Drawing.Point(271, 16);
			TaskIn.Name = "TaskIn";
			TaskIn.Checked = t.In;
			TaskIn.Size = new System.Drawing.Size(42, 21);
			TaskIn.TabIndex = 1;
			TaskIn.Text = "In";
			TaskIn.UseVisualStyleBackColor = true;
			// 
			// TaskOut
			// 
			TaskOut.AutoSize = true;
			TaskOut.Location = new System.Drawing.Point(319, 16);
			TaskOut.Name = "TaskOut";
			TaskOut.Checked = t.Out;
			TaskOut.Size = new System.Drawing.Size(53, 21);
			TaskOut.TabIndex = 2;
			TaskOut.Text = "Out";
			TaskOut.UseVisualStyleBackColor = true;

		}

		private void Paint_Delete(object sender, PaintEventArgs e)
		{
			Button b = (Button)sender;
			Pen pen = new Pen(Color.Black);
			e.Graphics.DrawLine(pen, 0, 0, b.Width, b.Height);
			e.Graphics.DrawLine(pen, 0, b.Height, b.Width, 0);
		}

		public IOTask Get()
		{
			return new IOTask(Task, TaskIn.Checked, TaskOut.Checked);
		}
	}
}
