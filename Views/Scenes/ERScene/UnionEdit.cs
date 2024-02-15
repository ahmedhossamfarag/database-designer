using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal partial class UnionEdit : OkCancelForm
	{
		private System.Windows.Forms.ComboBox SuperBox;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.FlowLayoutPanel EnPanel;
		public UnionEdit()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuperBox = new System.Windows.Forms.ComboBox();
			this.EnPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.AddButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DeleteButton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(110, 322);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(205, 322);
			// 
			// SuperBox
			// 
			this.SuperBox.Location = new System.Drawing.Point(12, 12);
			this.SuperBox.Name = "SuperBox";
			this.SuperBox.Size = new System.Drawing.Size(231, 31);
			this.SuperBox.TabIndex = 19;
			// 
			// EnPanel
			// 
			this.EnPanel.Font = new System.Drawing.Font("Arial", 12F);
			this.EnPanel.Location = new System.Drawing.Point(12, 60);
			this.EnPanel.Name = "EnPanel";
			this.EnPanel.Size = new System.Drawing.Size(273, 238);
			this.EnPanel.TabIndex = 18;
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(252, 9);
			this.AddButton.Name = "AddButton";
			this.AddButton.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.AddButton.Size = new System.Drawing.Size(34, 31);
			this.AddButton.TabIndex = 21;
			this.AddButton.Text = "A";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// UnionEdit
			// 
			this.ClientSize = new System.Drawing.Size(297, 374);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.SuperBox);
			this.Controls.Add(this.EnPanel);
			this.Name = "UnionEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.EnPanel, 0);
			this.Controls.SetChildIndex(this.SuperBox, 0);
			this.Controls.SetChildIndex(this.AddButton, 0);
			this.ResumeLayout(false);

		}


	}
}
