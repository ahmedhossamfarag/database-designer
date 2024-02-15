using DatabaseDesigner.Models.IFD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class IOScreenTask : OkCancelForm
	{
		public ComboBox TBox;
		public CheckBox InCheck;
		public CheckBox OutCheck;

		public IEnumerable<TaskView> Tasks
		{
			set
			{
				TBox.Items.AddRange(value.ToArray());
			}
		}

		public IOScreenTask()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.TBox = new System.Windows.Forms.ComboBox();
			this.InCheck = new System.Windows.Forms.CheckBox();
			this.OutCheck = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// DeleteButton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(253, 201);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(348, 201);
			// 
			// TBox
			// 
			this.TBox.Location = new System.Drawing.Point(13, 13);
			this.TBox.Name = "TBox";
			this.TBox.Size = new System.Drawing.Size(410, 31);
			this.TBox.TabIndex = 6;
			// 
			// InCheck
			// 
			this.InCheck.Location = new System.Drawing.Point(13, 63);
			this.InCheck.Name = "InCheck";
			this.InCheck.Size = new System.Drawing.Size(410, 27);
			this.InCheck.TabIndex = 7;
			this.InCheck.Text = "In";
			this.InCheck.UseVisualStyleBackColor = true;
			// 
			// OutCheck
			// 
			this.OutCheck.Location = new System.Drawing.Point(13, 114);
			this.OutCheck.Name = "OutCheck";
			this.OutCheck.Size = new System.Drawing.Size(410, 27);
			this.OutCheck.TabIndex = 8;
			this.OutCheck.Text = "Out";
			this.OutCheck.UseVisualStyleBackColor = true;
			// 
			// IOScreenTask
			// 
			this.ClientSize = new System.Drawing.Size(440, 253);
			this.Controls.Add(this.OutCheck);
			this.Controls.Add(this.InCheck);
			this.Controls.Add(this.TBox);
			this.Name = "IOScreenTask";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.TBox, 0);
			this.Controls.SetChildIndex(this.InCheck, 0);
			this.Controls.SetChildIndex(this.OutCheck, 0);
			this.ResumeLayout(false);

		}

		public void Update(IOTask iOTask)
		{
			if (TBox.SelectedIndex < 0)
				throw new InvalidOperationException("Invalid Select");
			iOTask.Task = ((TaskView)TBox.SelectedItem).Task;
			iOTask.In = InCheck.Checked;
			iOTask.Out = OutCheck.Checked;
			//
			//
			Close();
		}
	}
}
