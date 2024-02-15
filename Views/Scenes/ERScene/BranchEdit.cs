using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal partial class BranchEdit : OkCancelForm
	{
		private System.Windows.Forms.CheckBox MustCheck;
		private System.Windows.Forms.CheckBox OverlapCheck;
		private System.Windows.Forms.ComboBox SubBox;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.FlowLayoutPanel EnPanel;
		public BranchEdit()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.MustCheck = new System.Windows.Forms.CheckBox();
			this.OverlapCheck = new System.Windows.Forms.CheckBox();
			this.SubBox = new System.Windows.Forms.ComboBox();
			this.EnPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.AddButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DeleteButton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(109, 351);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(204, 351);
			// 
			// MustCheck
			// 
			this.MustCheck.AutoSize = true;
			this.MustCheck.Location = new System.Drawing.Point(209, 12);
			this.MustCheck.Name = "MustCheck";
			this.MustCheck.Size = new System.Drawing.Size(75, 27);
			this.MustCheck.TabIndex = 18;
			this.MustCheck.Text = "Must";
			this.MustCheck.UseVisualStyleBackColor = true;
			// 
			// OverlapCheck
			// 
			this.OverlapCheck.AutoSize = true;
			this.OverlapCheck.Location = new System.Drawing.Point(12, 12);
			this.OverlapCheck.Name = "OverlapCheck";
			this.OverlapCheck.Size = new System.Drawing.Size(101, 27);
			this.OverlapCheck.TabIndex = 17;
			this.OverlapCheck.Text = "Overlap";
			this.OverlapCheck.UseVisualStyleBackColor = true;
			// 
			// SubBox
			// 
			this.SubBox.Location = new System.Drawing.Point(11, 45);
			this.SubBox.Name = "SubBox";
			this.SubBox.Size = new System.Drawing.Size(231, 31);
			this.SubBox.TabIndex = 15;
			// 
			// EnPanel
			// 
			this.EnPanel.Font = new System.Drawing.Font("Arial", 12F);
			this.EnPanel.Location = new System.Drawing.Point(11, 93);
			this.EnPanel.Name = "EnPanel";
			this.EnPanel.Size = new System.Drawing.Size(273, 238);
			this.EnPanel.TabIndex = 14;
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(250, 42);
			this.AddButton.Name = "AddButton";
			this.AddButton.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.AddButton.Size = new System.Drawing.Size(34, 31);
			this.AddButton.TabIndex = 19;
			this.AddButton.Text = "A";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// BranchEdit
			// 
			this.ClientSize = new System.Drawing.Size(296, 403);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.MustCheck);
			this.Controls.Add(this.OverlapCheck);
			this.Controls.Add(this.SubBox);
			this.Controls.Add(this.EnPanel);
			this.Name = "BranchEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.EnPanel, 0);
			this.Controls.SetChildIndex(this.SubBox, 0);
			this.Controls.SetChildIndex(this.OverlapCheck, 0);
			this.Controls.SetChildIndex(this.MustCheck, 0);
			this.Controls.SetChildIndex(this.AddButton, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

	}
}
