using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal partial class RelationEdit : OkCancelForm
	{
		private System.Windows.Forms.ComboBox EBox;
		private System.Windows.Forms.FlowLayoutPanel EContainer;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.CheckBox WeakCheck;
		public System.Windows.Forms.TextBox NameBox;

		public RelationEdit()
		{
			InitializeComponent();
			NameBox.Select();
		}

		private void InitializeComponent()
		{
			this.EBox = new System.Windows.Forms.ComboBox();
			this.EContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.AddButton = new System.Windows.Forms.Button();
			this.WeakCheck = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// DeleteButton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(185, 409);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(280, 409);
			// 
			// EBox
			// 
			this.EBox.Location = new System.Drawing.Point(12, 92);
			this.EBox.Name = "EBox";
			this.EBox.Size = new System.Drawing.Size(308, 31);
			this.EBox.TabIndex = 12;
			// 
			// EContainer
			// 
			this.EContainer.Location = new System.Drawing.Point(12, 148);
			this.EContainer.Name = "EContainer";
			this.EContainer.Size = new System.Drawing.Size(345, 225);
			this.EContainer.TabIndex = 11;
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(12, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(348, 30);
			this.NameBox.TabIndex = 10;
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(326, 89);
			this.AddButton.Name = "AddButton";
			this.AddButton.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.AddButton.Size = new System.Drawing.Size(34, 31);
			this.AddButton.TabIndex = 20;
			this.AddButton.Text = "A";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddEntity);
			// 
			// WeakCheck
			// 
			this.WeakCheck.AutoSize = true;
			this.WeakCheck.Location = new System.Drawing.Point(13, 49);
			this.WeakCheck.Name = "WeakCheck";
			this.WeakCheck.Size = new System.Drawing.Size(83, 27);
			this.WeakCheck.TabIndex = 21;
			this.WeakCheck.Text = "Weak";
			this.WeakCheck.UseVisualStyleBackColor = true;
			// 
			// RelationEdit
			// 
			this.ClientSize = new System.Drawing.Size(372, 461);
			this.Controls.Add(this.WeakCheck);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.EBox);
			this.Controls.Add(this.EContainer);
			this.Controls.Add(this.NameBox);
			this.Name = "RelationEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.NameBox, 0);
			this.Controls.SetChildIndex(this.EContainer, 0);
			this.Controls.SetChildIndex(this.EBox, 0);
			this.Controls.SetChildIndex(this.AddButton, 0);
			this.Controls.SetChildIndex(this.WeakCheck, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

	}
}
