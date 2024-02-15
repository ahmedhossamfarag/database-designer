using DatabaseDesigner.Models.IFD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal partial class TaskEdit : OkCancelForm
	{
		private System.Windows.Forms.CheckBox OutCheck;
		private System.Windows.Forms.CheckBox InCheck;
		public System.Windows.Forms.TextBox NameBox;
		public TaskEdit()
		{
			InitializeComponent();
			NameBox.Select();
		}
		private void InitializeComponent()
		{
			this.OutCheck = new System.Windows.Forms.CheckBox();
			this.InCheck = new System.Windows.Forms.CheckBox();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// DeleteButton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(214, 168);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(309, 168);
			// 
			// OutCheck
			// 
			this.OutCheck.Location = new System.Drawing.Point(16, 121);
			this.OutCheck.Name = "OutCheck";
			this.OutCheck.Size = new System.Drawing.Size(370, 34);
			this.OutCheck.TabIndex = 7;
			this.OutCheck.Text = "OUT";
			// 
			// InCheck
			// 
			this.InCheck.Location = new System.Drawing.Point(14, 81);
			this.InCheck.Name = "InCheck";
			this.InCheck.Size = new System.Drawing.Size(370, 34);
			this.InCheck.TabIndex = 8;
			this.InCheck.Text = "IN";
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(14, 17);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(370, 30);
			this.NameBox.TabIndex = 9;
			// 
			// TaskEdit
			// 
			this.ClientSize = new System.Drawing.Size(401, 220);
			this.Controls.Add(this.OutCheck);
			this.Controls.Add(this.InCheck);
			this.Controls.Add(this.NameBox);
			this.Name = "TaskEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.NameBox, 0);
			this.Controls.SetChildIndex(this.InCheck, 0);
			this.Controls.SetChildIndex(this.OutCheck, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		
	}
}
