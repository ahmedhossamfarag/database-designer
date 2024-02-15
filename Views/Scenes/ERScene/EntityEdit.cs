using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal partial class EntityEdit : OkCancelForm
	{
		private System.Windows.Forms.CheckBox WeakCheck;
		public System.Windows.Forms.TextBox NameBox;
		public EntityEdit()
		{
			InitializeComponent();
			NameBox.Select();
		}
		private void InitializeComponent()
		{
			this.WeakCheck = new System.Windows.Forms.CheckBox();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// WeakCheck
			// 
			this.WeakCheck.Location = new System.Drawing.Point(13, 67);
			this.WeakCheck.Name = "WeakCheck";
			this.WeakCheck.Size = new System.Drawing.Size(257, 34);
			this.WeakCheck.TabIndex = 7;
			this.WeakCheck.Text = "Weak";
			this.WeakCheck.UseVisualStyleBackColor = true;
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(12, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(258, 30);
			this.NameBox.TabIndex = 6;
			// 
			// EntityEdit
			// 
			this.ClientSize = new System.Drawing.Size(282, 253);
			this.Controls.Add(this.WeakCheck);
			this.Controls.Add(this.NameBox);
			this.Name = "EntityEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.NameBox, 0);
			this.Controls.SetChildIndex(this.WeakCheck, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
