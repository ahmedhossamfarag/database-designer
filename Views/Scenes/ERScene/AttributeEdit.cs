using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal partial class AttributeEdit : OkCancelForm
	{
		private System.Windows.Forms.CheckBox KeyCheck;
		private System.Windows.Forms.CheckBox DrivedCheck;
		private System.Windows.Forms.CheckBox MultCheck;
		public System.Windows.Forms.TextBox NameBox;
		public AttributeEdit()
		{
			InitializeComponent();
			NameBox.Select();

		}
		private void InitializeComponent()
		{
			this.KeyCheck = new System.Windows.Forms.CheckBox();
			this.DrivedCheck = new System.Windows.Forms.CheckBox();
			this.MultCheck = new System.Windows.Forms.CheckBox();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// DeleteButton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(228, 280);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(323, 280);
			// 
			// KeyCheck
			// 
			this.KeyCheck.Location = new System.Drawing.Point(12, 203);
			this.KeyCheck.Name = "KeyCheck";
			this.KeyCheck.Size = new System.Drawing.Size(377, 45);
			this.KeyCheck.TabIndex = 26;
			this.KeyCheck.Text = "Key";
			this.KeyCheck.UseVisualStyleBackColor = true;
			this.KeyCheck.CheckedChanged += new System.EventHandler(this.KeyCheck_CheckedChanged);
			// 
			// DrivedCheck
			// 
			this.DrivedCheck.Location = new System.Drawing.Point(12, 136);
			this.DrivedCheck.Name = "DrivedCheck";
			this.DrivedCheck.Size = new System.Drawing.Size(377, 39);
			this.DrivedCheck.TabIndex = 23;
			this.DrivedCheck.Text = "Drived";
			this.DrivedCheck.UseVisualStyleBackColor = true;
			this.DrivedCheck.CheckedChanged += new System.EventHandler(this.DrivedCheck_CheckedChanged);
			// 
			// MultCheck
			// 
			this.MultCheck.Location = new System.Drawing.Point(12, 73);
			this.MultCheck.Name = "MultCheck";
			this.MultCheck.Size = new System.Drawing.Size(377, 39);
			this.MultCheck.TabIndex = 22;
			this.MultCheck.Text = "Multiple";
			this.MultCheck.UseVisualStyleBackColor = true;
			this.MultCheck.CheckedChanged += new System.EventHandler(this.MultCheck_CheckedChanged);
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(12, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(385, 30);
			this.NameBox.TabIndex = 18;
			// 
			// AttributeEdit
			// 
			this.ClientSize = new System.Drawing.Size(415, 332);
			this.Controls.Add(this.KeyCheck);
			this.Controls.Add(this.DrivedCheck);
			this.Controls.Add(this.MultCheck);
			this.Controls.Add(this.NameBox);
			this.Name = "AttributeEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.NameBox, 0);
			this.Controls.SetChildIndex(this.MultCheck, 0);
			this.Controls.SetChildIndex(this.DrivedCheck, 0);
			this.Controls.SetChildIndex(this.KeyCheck, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#region Controls Events
		
		private void KeyCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (KeyCheck.Checked)
			{
				MultCheck.Checked = false;
				DrivedCheck.Checked = false;
			}
		}
		private void MultCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (MultCheck.Checked)
				KeyCheck.Checked = false;
		}

		private void DrivedCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (DrivedCheck.Checked)
				KeyCheck.Checked = false;
		}

		#endregion
	}
}
