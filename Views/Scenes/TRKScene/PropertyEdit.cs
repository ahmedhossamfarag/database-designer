using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.TRK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class PropertyEdit : OkCancelForm
	{
		private System.Windows.Forms.TextBox DefaultBox;
		private System.Windows.Forms.Label Default;
		private System.Windows.Forms.CheckBox NullCheck;
		private System.Windows.Forms.CheckBox UniqueCheck;
		private System.Windows.Forms.NumericUpDown LengthBox;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.CheckBox KeyCheck;
		private System.Windows.Forms.ComboBox TypeBox;
		public System.Windows.Forms.Button Delete;

		public PropertyEdit()
		{
			InitializeComponent();
			for (int i = 0; i < 5; i++)
				TypeBox.Items.Add((DataType)i);
			NameBox.Select();
			OnOk = Valid;
		}

		private void InitializeComponent()
		{
			this.DefaultBox = new System.Windows.Forms.TextBox();
			this.Default = new System.Windows.Forms.Label();
			this.NullCheck = new System.Windows.Forms.CheckBox();
			this.UniqueCheck = new System.Windows.Forms.CheckBox();
			this.LengthBox = new System.Windows.Forms.NumericUpDown();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.KeyCheck = new System.Windows.Forms.CheckBox();
			this.Delete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.LengthBox)).BeginInit();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(201, 374);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(310, 374);
			// 
			// DefaultBox
			// 
			this.DefaultBox.Location = new System.Drawing.Point(16, 276);
			this.DefaultBox.Name = "DefaultBox";
			this.DefaultBox.Size = new System.Drawing.Size(370, 30);
			this.DefaultBox.TabIndex = 19;
			// 
			// Default
			// 
			this.Default.AutoSize = true;
			this.Default.Location = new System.Drawing.Point(12, 229);
			this.Default.Name = "Default";
			this.Default.Size = new System.Drawing.Size(120, 23);
			this.Default.TabIndex = 18;
			this.Default.Text = "DefaultValue";
			// 
			// NullCheck
			// 
			this.NullCheck.AutoSize = true;
			this.NullCheck.Location = new System.Drawing.Point(233, 180);
			this.NullCheck.Name = "NullCheck";
			this.NullCheck.Size = new System.Drawing.Size(100, 27);
			this.NullCheck.TabIndex = 17;
			this.NullCheck.Text = "Nullable";
			this.NullCheck.UseVisualStyleBackColor = true;
			this.NullCheck.CheckedChanged += new System.EventHandler(this.NullCheck_CheckedChanged);
			// 
			// UniqueCheck
			// 
			this.UniqueCheck.AutoSize = true;
			this.UniqueCheck.Location = new System.Drawing.Point(112, 180);
			this.UniqueCheck.Name = "UniqueCheck";
			this.UniqueCheck.Size = new System.Drawing.Size(91, 27);
			this.UniqueCheck.TabIndex = 16;
			this.UniqueCheck.Text = "Unique";
			this.UniqueCheck.UseVisualStyleBackColor = true;
			this.UniqueCheck.CheckedChanged += new System.EventHandler(this.UniqueCheck_CheckedChanged);
			// 
			// LengthBox
			// 
			this.LengthBox.Location = new System.Drawing.Point(16, 124);
			this.LengthBox.Name = "LengthBox";
			this.LengthBox.Size = new System.Drawing.Size(370, 30);
			this.LengthBox.TabIndex = 15;
			// 
			// TypeBox
			// 
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(16, 71);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(370, 31);
			this.TypeBox.TabIndex = 14;
			this.TypeBox.SelectedIndexChanged += new System.EventHandler(this.TypeBox_SelectedIndexChanged);
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(16, 13);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(370, 30);
			this.NameBox.TabIndex = 20;
			// 
			// KeyCheck
			// 
			this.KeyCheck.AutoSize = true;
			this.KeyCheck.Location = new System.Drawing.Point(16, 180);
			this.KeyCheck.Name = "KeyCheck";
			this.KeyCheck.Size = new System.Drawing.Size(66, 27);
			this.KeyCheck.TabIndex = 21;
			this.KeyCheck.Text = "Key";
			this.KeyCheck.UseVisualStyleBackColor = true;
			this.KeyCheck.CheckedChanged += new System.EventHandler(this.KeyCheck_CheckedChanged);
			// 
			// Delete
			// 
			this.Delete.Location = new System.Drawing.Point(95, 374);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(88, 40);
			this.Delete.TabIndex = 22;
			this.Delete.Text = "Delete";
			this.Delete.UseVisualStyleBackColor = true;
			this.Delete.Visible = false;
			this.Delete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// PropertyEdit
			// 
			this.ClientSize = new System.Drawing.Size(402, 426);
			this.Controls.Add(this.Delete);
			this.Controls.Add(this.KeyCheck);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.DefaultBox);
			this.Controls.Add(this.Default);
			this.Controls.Add(this.NullCheck);
			this.Controls.Add(this.UniqueCheck);
			this.Controls.Add(this.LengthBox);
			this.Controls.Add(this.TypeBox);
			this.Name = "PropertyEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.TypeBox, 0);
			this.Controls.SetChildIndex(this.LengthBox, 0);
			this.Controls.SetChildIndex(this.UniqueCheck, 0);
			this.Controls.SetChildIndex(this.NullCheck, 0);
			this.Controls.SetChildIndex(this.Default, 0);
			this.Controls.SetChildIndex(this.DefaultBox, 0);
			this.Controls.SetChildIndex(this.NameBox, 0);
			this.Controls.SetChildIndex(this.KeyCheck, 0);
			this.Controls.SetChildIndex(this.Delete, 0);
			((System.ComponentModel.ISupportInitialize)(this.LengthBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LengthBox.Enabled = TypeBox.SelectedIndex == (int)DataType.VarChar || TypeBox.SelectedIndex == (int)DataType.Float;
		}

		private void KeyCheck_CheckedChanged(object sender, EventArgs e)
		{
			if(KeyCheck.Checked)
			{
				UniqueCheck.Checked = true;
				NullCheck.Checked = false;
			}
		}

		private void UniqueCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (!UniqueCheck.Checked)
			{
				KeyCheck.Checked = false;
			}
			else
			{
				NullCheck.Checked = false;
			}
			DefaultBox.Enabled = !NullCheck.Checked && !UniqueCheck.Checked;
		}

		private void NullCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (NullCheck.Checked)
			{
				KeyCheck.Checked = false;
				UniqueCheck.Checked = false;
			}
			DefaultBox.Enabled = !NullCheck.Checked && !UniqueCheck.Checked;
		}

		private void Delete_Click(object sender, EventArgs e)
		{
			if(InfoDialog.Of("Are You Sure ?") == System.Windows.Forms.DialogResult.OK)
			{
				DialogResult = System.Windows.Forms.DialogResult.No;
				Close();
			}
		}
	}
}
