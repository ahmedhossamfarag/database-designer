using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class ForgeinKeyEdit : OkCancelForm
	{
		private System.Windows.Forms.Panel Color;
		public Button Delete;
		private System.Windows.Forms.Label Clabel1;

		public ForgeinKeyEdit()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.Color = new System.Windows.Forms.Panel();
			this.Clabel1 = new System.Windows.Forms.Label();
			this.Delete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(138, 70);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(247, 70);
			// 
			// Color
			// 
			this.Color.BackColor = System.Drawing.Color.Black;
			this.Color.Location = new System.Drawing.Point(306, 12);
			this.Color.Name = "Color";
			this.Color.Size = new System.Drawing.Size(20, 20);
			this.Color.TabIndex = 10;
			this.Color.Click += new System.EventHandler(this.Color_Click);
			// 
			// Clabel1
			// 
			this.Clabel1.AutoSize = true;
			this.Clabel1.Location = new System.Drawing.Point(12, 9);
			this.Clabel1.Name = "Clabel1";
			this.Clabel1.Size = new System.Drawing.Size(57, 23);
			this.Clabel1.TabIndex = 9;
			this.Clabel1.Text = "Color";
			// 
			// Delete
			// 
			this.Delete.Location = new System.Drawing.Point(28, 70);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(94, 40);
			this.Delete.TabIndex = 11;
			this.Delete.Text = "Delete";
			this.Delete.UseVisualStyleBackColor = true;
			this.Delete.Visible = false;
			this.Delete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// ForgeinKeyEdit
			// 
			this.ClientSize = new System.Drawing.Size(339, 122);
			this.Controls.Add(this.Delete);
			this.Controls.Add(this.Color);
			this.Controls.Add(this.Clabel1);
			this.Name = "ForgeinKeyEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.Clabel1, 0);
			this.Controls.SetChildIndex(this.Color, 0);
			this.Controls.SetChildIndex(this.Delete, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void Color_Click(object sender, EventArgs e)
		{
			Control c = (Control)sender;
			ColorDialog dialog = new ColorDialog()
			{
				Color = c.BackColor
			};
			if (dialog.ShowDialog() == DialogResult.OK)
				c.BackColor = dialog.Color;
		}

		private void Delete_Click(object sender, EventArgs e)
		{
			if (InfoDialog.Of("Are You Sure?") == DialogResult.OK)
			{
				DialogResult = DialogResult.No;
				Close();
			}
		}
	}
}
