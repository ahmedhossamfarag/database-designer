using DatabaseDesigner.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene5
{
	internal class SelectXView : OkCancelForm
	{
		private System.Windows.Forms.GroupBox XGroup;
		private System.Windows.Forms.RadioButton Except;
		private System.Windows.Forms.RadioButton Intersect;
		private System.Windows.Forms.RadioButton Union;
		private System.Windows.Forms.ComboBox SBox2;
		private System.Windows.Forms.ComboBox SBox1;
		private IEnumerable<Select> List;
		public IEnumerable<Select> Selects
		{
			set
			{
				List = value;
				SBox1.Items.AddRange(value.ToArray());
				SBox2.Items.AddRange(value.ToArray());
			}
		}


		public SelectXView()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.XGroup = new System.Windows.Forms.GroupBox();
			this.Except = new System.Windows.Forms.RadioButton();
			this.Intersect = new System.Windows.Forms.RadioButton();
			this.Union = new System.Windows.Forms.RadioButton();
			this.SBox2 = new System.Windows.Forms.ComboBox();
			this.SBox1 = new System.Windows.Forms.ComboBox();
			this.XGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(276, 207);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(371, 207);
			// 
			// XGroup
			// 
			this.XGroup.Controls.Add(this.Except);
			this.XGroup.Controls.Add(this.Intersect);
			this.XGroup.Controls.Add(this.Union);
			this.XGroup.Location = new System.Drawing.Point(12, 61);
			this.XGroup.Name = "XGroup";
			this.XGroup.Size = new System.Drawing.Size(436, 48);
			this.XGroup.TabIndex = 9;
			this.XGroup.TabStop = false;
			// 
			// Except
			// 
			this.Except.AutoSize = true;
			this.Except.Location = new System.Drawing.Point(277, 21);
			this.Except.Name = "Except";
			this.Except.Size = new System.Drawing.Size(91, 27);
			this.Except.TabIndex = 2;
			this.Except.Text = "Except";
			this.Except.UseVisualStyleBackColor = true;
			// 
			// Intersect
			// 
			this.Intersect.AutoSize = true;
			this.Intersect.Location = new System.Drawing.Point(138, 21);
			this.Intersect.Name = "Intersect";
			this.Intersect.Size = new System.Drawing.Size(108, 27);
			this.Intersect.TabIndex = 1;
			this.Intersect.Text = "Intersect";
			this.Intersect.UseVisualStyleBackColor = true;
			// 
			// Union
			// 
			this.Union.AutoSize = true;
			this.Union.Checked = true;
			this.Union.Location = new System.Drawing.Point(7, 21);
			this.Union.Name = "Union";
			this.Union.Size = new System.Drawing.Size(79, 27);
			this.Union.TabIndex = 0;
			this.Union.TabStop = true;
			this.Union.Text = "Union";
			this.Union.UseVisualStyleBackColor = true;
			// 
			// SBox2
			// 
			this.SBox2.Location = new System.Drawing.Point(12, 138);
			this.SBox2.Name = "SBox2";
			this.SBox2.Size = new System.Drawing.Size(436, 31);
			this.SBox2.TabIndex = 8;
			// 
			// SBox1
			// 
			this.SBox1.Location = new System.Drawing.Point(12, 12);
			this.SBox1.Name = "SBox1";
			this.SBox1.Size = new System.Drawing.Size(436, 31);
			this.SBox1.TabIndex = 7;
			// 
			// SelectXView
			// 
			this.ClientSize = new System.Drawing.Size(463, 259);
			this.Controls.Add(this.XGroup);
			this.Controls.Add(this.SBox2);
			this.Controls.Add(this.SBox1);
			this.Name = "SelectXView";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.SBox1, 0);
			this.Controls.SetChildIndex(this.SBox2, 0);
			this.Controls.SetChildIndex(this.XGroup, 0);
			this.XGroup.ResumeLayout(false);
			this.XGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		public SelectX Get()
		{
			if (SBox1.SelectedIndex < 0 || SBox2.SelectedIndex < 0 || SBox1.SelectedIndex == SBox2.SelectedIndex)
				return null;
			XType t = XType.UNION;
			if (Intersect.Checked)
				t = XType.INTERSECT;
			else if (Except.Checked)
				t = XType.EXCEPT;
			return new SelectX()
			{
				Select1 = List.ElementAt(SBox1.SelectedIndex),
				Select2 = List.ElementAt(SBox2.SelectedIndex),
				Type = t
			};
		}
	}
}
