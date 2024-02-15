using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class RelationEdit : OkCancelForm
	{
		private System.Windows.Forms.GroupBox MGroup;
		private System.Windows.Forms.RadioButton C1N;
		private System.Windows.Forms.RadioButton CNM;
		private System.Windows.Forms.RadioButton CN1;
		private System.Windows.Forms.Label Clabel1;
		private System.Windows.Forms.Panel Color;
		public Button Delete;
		private System.Windows.Forms.RadioButton C11;


		public RelationEdit()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.MGroup = new System.Windows.Forms.GroupBox();
			this.C1N = new System.Windows.Forms.RadioButton();
			this.CNM = new System.Windows.Forms.RadioButton();
			this.CN1 = new System.Windows.Forms.RadioButton();
			this.C11 = new System.Windows.Forms.RadioButton();
			this.Clabel1 = new System.Windows.Forms.Label();
			this.Color = new System.Windows.Forms.Panel();
			this.Delete = new System.Windows.Forms.Button();
			this.MGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(138, 201);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(247, 201);
			// 
			// MGroup
			// 
			this.MGroup.Controls.Add(this.C1N);
			this.MGroup.Controls.Add(this.CNM);
			this.MGroup.Controls.Add(this.CN1);
			this.MGroup.Controls.Add(this.C11);
			this.MGroup.Location = new System.Drawing.Point(12, 13);
			this.MGroup.Name = "MGroup";
			this.MGroup.Size = new System.Drawing.Size(318, 46);
			this.MGroup.TabIndex = 6;
			this.MGroup.TabStop = false;
			// 
			// C1N
			// 
			this.C1N.AutoSize = true;
			this.C1N.Location = new System.Drawing.Point(78, 11);
			this.C1N.Name = "C1N";
			this.C1N.Size = new System.Drawing.Size(62, 27);
			this.C1N.TabIndex = 3;
			this.C1N.Text = "1-N";
			this.C1N.UseVisualStyleBackColor = true;
			// 
			// CNM
			// 
			this.CNM.AutoSize = true;
			this.CNM.Location = new System.Drawing.Point(242, 11);
			this.CNM.Name = "CNM";
			this.CNM.Size = new System.Drawing.Size(68, 27);
			this.CNM.TabIndex = 2;
			this.CNM.Text = "N-M";
			this.CNM.UseVisualStyleBackColor = true;
			// 
			// CN1
			// 
			this.CN1.AutoSize = true;
			this.CN1.Location = new System.Drawing.Point(163, 11);
			this.CN1.Name = "CN1";
			this.CN1.Size = new System.Drawing.Size(62, 27);
			this.CN1.TabIndex = 1;
			this.CN1.Text = "N-1";
			this.CN1.UseVisualStyleBackColor = true;
			// 
			// C11
			// 
			this.C11.AutoSize = true;
			this.C11.Checked = true;
			this.C11.Location = new System.Drawing.Point(0, 11);
			this.C11.Name = "C11";
			this.C11.Size = new System.Drawing.Size(60, 27);
			this.C11.TabIndex = 0;
			this.C11.TabStop = true;
			this.C11.Text = "1-1";
			this.C11.UseVisualStyleBackColor = true;
			// 
			// Clabel1
			// 
			this.Clabel1.AutoSize = true;
			this.Clabel1.Location = new System.Drawing.Point(8, 117);
			this.Clabel1.Name = "Clabel1";
			this.Clabel1.Size = new System.Drawing.Size(57, 23);
			this.Clabel1.TabIndex = 7;
			this.Clabel1.Text = "Color";
			// 
			// Color
			// 
			this.Color.BackColor = System.Drawing.Color.Black;
			this.Color.Location = new System.Drawing.Point(302, 120);
			this.Color.Name = "Color";
			this.Color.Size = new System.Drawing.Size(20, 20);
			this.Color.TabIndex = 8;
			this.Color.Click += new System.EventHandler(this.Color_Click);
			// 
			// Delete
			// 
			this.Delete.Location = new System.Drawing.Point(27, 201);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(94, 40);
			this.Delete.TabIndex = 9;
			this.Delete.Text = "Delete";
			this.Delete.UseVisualStyleBackColor = true;
			this.Delete.Visible = false;
			this.Delete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// RelationEdit
			// 
			this.ClientSize = new System.Drawing.Size(339, 253);
			this.Controls.Add(this.Delete);
			this.Controls.Add(this.Color);
			this.Controls.Add(this.Clabel1);
			this.Controls.Add(this.MGroup);
			this.Name = "RelationEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.MGroup, 0);
			this.Controls.SetChildIndex(this.Clabel1, 0);
			this.Controls.SetChildIndex(this.Color, 0);
			this.Controls.SetChildIndex(this.Delete, 0);
			this.MGroup.ResumeLayout(false);
			this.MGroup.PerformLayout();
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
