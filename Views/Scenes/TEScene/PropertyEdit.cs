using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.TEScene
{
	internal partial class PropertyEdit : OkCancelForm
	{
		private System.Windows.Forms.ComboBox TypeBox;
		private System.Windows.Forms.NumericUpDown LengthBox;
		private System.Windows.Forms.CheckBox NullCheck;
		private System.Windows.Forms.Label Default;
		private System.Windows.Forms.TextBox DefaultBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.CheckBox UniqueCheck;

		public PropertyEdit()
		{
			InitializeComponent();
			for (int i = 0; i < (int)DataType.Other; i++)
				TypeBox.Items.Add((DataType)i);
			TypeBox.SelectedItem = DataType.VarChar;
		}

		private void InitializeComponent()
		{
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.LengthBox = new System.Windows.Forms.NumericUpDown();
            this.UniqueCheck = new System.Windows.Forms.CheckBox();
            this.NullCheck = new System.Windows.Forms.CheckBox();
            this.Default = new System.Windows.Forms.Label();
            this.DefaultBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.LengthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(217, 352);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(312, 352);
            // 
            // TypeBox
            // 
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Location = new System.Drawing.Point(17, 58);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(370, 31);
            this.TypeBox.TabIndex = 7;
            this.TypeBox.SelectedIndexChanged += new System.EventHandler(this.TypeBox_SelectedIndexChanged);
            // 
            // LengthBox
            // 
            this.LengthBox.Location = new System.Drawing.Point(17, 111);
            this.LengthBox.Name = "LengthBox";
            this.LengthBox.Size = new System.Drawing.Size(370, 30);
            this.LengthBox.TabIndex = 8;
            // 
            // UniqueCheck
            // 
            this.UniqueCheck.AutoSize = true;
            this.UniqueCheck.Location = new System.Drawing.Point(17, 167);
            this.UniqueCheck.Name = "UniqueCheck";
            this.UniqueCheck.Size = new System.Drawing.Size(91, 27);
            this.UniqueCheck.TabIndex = 9;
            this.UniqueCheck.Text = "Unique";
            this.UniqueCheck.UseVisualStyleBackColor = true;
            this.UniqueCheck.CheckedChanged += new System.EventHandler(this.UniqueCheck_CheckedChanged);
            // 
            // NullCheck
            // 
            this.NullCheck.AutoSize = true;
            this.NullCheck.Location = new System.Drawing.Point(234, 167);
            this.NullCheck.Name = "NullCheck";
            this.NullCheck.Size = new System.Drawing.Size(100, 27);
            this.NullCheck.TabIndex = 10;
            this.NullCheck.Text = "Nullable";
            this.NullCheck.UseVisualStyleBackColor = true;
            this.NullCheck.CheckedChanged += new System.EventHandler(this.NullCheck_CheckedChanged);
            // 
            // Default
            // 
            this.Default.AutoSize = true;
            this.Default.Location = new System.Drawing.Point(13, 216);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(120, 23);
            this.Default.TabIndex = 11;
            this.Default.Text = "DefaultValue";
            // 
            // DefaultBox
            // 
            this.DefaultBox.Location = new System.Drawing.Point(17, 263);
            this.DefaultBox.Name = "DefaultBox";
            this.DefaultBox.Size = new System.Drawing.Size(370, 30);
            this.DefaultBox.TabIndex = 12;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(17, 12);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(370, 30);
            this.NameBox.TabIndex = 13;
            // 
            // PropertyEdit
            // 
            this.ClientSize = new System.Drawing.Size(404, 404);
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
            ((System.ComponentModel.ISupportInitialize)(this.LengthBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LengthBox.Enabled = TypeBox.SelectedItem.Equals(DataType.VarChar) || TypeBox.SelectedItem.Equals(DataType.Float);
		}

		private void NullCheck_CheckedChanged(object sender, EventArgs e)
		{
			DefaultBox.Enabled = !NullCheck.Checked;
		}

		private void UniqueCheck_CheckedChanged(object sender, EventArgs e)
		{
			NullCheck.Checked = false;
			NullCheck.Enabled = !UniqueCheck.Checked;
			DefaultBox.Enabled = !UniqueCheck.Checked;
		}


	}
}
