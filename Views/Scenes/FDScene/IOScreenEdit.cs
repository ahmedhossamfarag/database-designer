using DatabaseDesigner.Models.IFD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal partial class IOScreenEdit : OkCancelForm
	{
		private System.Windows.Forms.ComboBox TBox;
		private System.Windows.Forms.FlowLayoutPanel TasksPanel;
		private System.Windows.Forms.Button AddButton;
		public System.Windows.Forms.TextBox NameBox;
		
		public IOScreenEdit()
		{
			InitializeComponent();
			NameBox.Select();
		}
		private void InitializeComponent()
		{
			this.NameBox = new System.Windows.Forms.TextBox();
			this.TBox = new System.Windows.Forms.ComboBox();
			this.TasksPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.AddButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DeleteButton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(223, 388);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(318, 388);
			// 
			// NameBox
			// 
			this.NameBox.Font = new System.Drawing.Font("Arial", 12F);
			this.NameBox.Location = new System.Drawing.Point(12, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(387, 30);
			this.NameBox.TabIndex = 6;
			// 
			// TBox
			// 
			this.TBox.Location = new System.Drawing.Point(12, 62);
			this.TBox.Name = "TBox";
			this.TBox.Size = new System.Drawing.Size(347, 31);
			this.TBox.TabIndex = 8;
			// 
			// TasksPanel
			// 
			this.TasksPanel.AutoScroll = true;
			this.TasksPanel.Font = new System.Drawing.Font("Arial", 12F);
			this.TasksPanel.Location = new System.Drawing.Point(12, 110);
			this.TasksPanel.Name = "TasksPanel";
			this.TasksPanel.Size = new System.Drawing.Size(388, 238);
			this.TasksPanel.TabIndex = 7;
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(366, 59);
			this.AddButton.Name = "AddButton";
			this.AddButton.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.AddButton.Size = new System.Drawing.Size(34, 31);
			this.AddButton.TabIndex = 20;
			this.AddButton.Text = "A";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// IOScreenEdit
			// 
			this.ClientSize = new System.Drawing.Size(410, 440);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.TBox);
			this.Controls.Add(this.TasksPanel);
			this.Controls.Add(this.NameBox);
			this.Name = "IOScreenEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.NameBox, 0);
			this.Controls.SetChildIndex(this.TasksPanel, 0);
			this.Controls.SetChildIndex(this.TBox, 0);
			this.Controls.SetChildIndex(this.AddButton, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

	}
}
