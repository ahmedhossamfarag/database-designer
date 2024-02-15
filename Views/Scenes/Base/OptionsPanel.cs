using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Base
{
	internal abstract class OptionsPanel : FlowLayoutPanel
	{
		public Button Add;
		public Button Delete;
		public Button Edit;


		public OptionsPanel()
		{
			InitializeComponent();
			Visible = false;
			Add.Click += Add_Click;
			Edit.Click += Edit_Click;
			Delete.Click += Delete_Click;
		}

		public abstract void Delete_Click(object sender, EventArgs e);

		public abstract void Edit_Click(object sender, EventArgs e);

		public abstract void Add_Click(object sender, EventArgs e);

		private void InitializeComponent()
		{
			this.Add = new System.Windows.Forms.Button();
			this.Delete = new System.Windows.Forms.Button();
			this.Edit = new System.Windows.Forms.Button();
			// 
			// taskOptions
			// 
			//this.BackColor = System.Drawing.Color.White;
			this.FlowDirection = FlowDirection.LeftToRight;
			this.AutoSize = true;
			this.Controls.Add(this.Add);
			this.Controls.Add(this.Edit);
			this.Controls.Add(this.Delete);
			this.Location = new System.Drawing.Point(187, 362);
			this.Name = "taskOptions";
			//this.Size = new System.Drawing.Size(360, 40);
			this.TabIndex = 3;
			// 
			// AddSubTask
			// 
			this.Add.AutoSize = true;
			//this.Add.FlatAppearance.BorderSize = 0;
			this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			//this.Add.AutoEllipsis = true;
			this.Add.Name = "Add";
			//this.Add.Size = new System.Drawing.Size(120, 35);
			this.Add.TabIndex = 0;
			this.Add.Text = "+ Add";
			this.Add.UseVisualStyleBackColor = true;
			// 
			// Edit
			// 
			this.Edit.AutoSize = true;
			//this.Edit.FlatAppearance.BorderSize = 0;
			this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			//this.Edit.Location = new System.Drawing.Point(122, 3);
			this.Edit.Name = "Edit";
			//this.Edit.Size = new System.Drawing.Size(110, 35);
			this.Edit.TabIndex = 1;
			this.Edit.Text = "Edit";
			this.Edit.UseVisualStyleBackColor = true;
			// 
			// Delete
			// 
			this.Delete.AutoSize = true;
			//this.Delete.FlatAppearance.BorderSize = 0;
			this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			//this.Delete.Location = new System.Drawing.Point(241, 3);
			this.Delete.Name = "Delete";
			//this.Delete.Size = new System.Drawing.Size(110, 35);
			this.Delete.TabIndex = 2;
			this.Delete.Text = "Delete";
			this.Delete.UseVisualStyleBackColor = true;

		}

	}
}
