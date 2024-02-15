using DatabaseDesigner.Models.SQL;
using DatabaseDesigner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseDesigner.Models.Database;

namespace DatabaseDesigner.Views.Scenes.Scene5
{
	internal class DeleteView : OkCancelForm
	{
		private ComboBox TBox;
		private Label Where;
		private TextBox WhereBox;

		public Database Database { set
			{
				TBox.Items.AddRange(value.Tables.ToArray());
			} }

		public DeleteView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.TBox = new System.Windows.Forms.ComboBox();
			this.Where = new System.Windows.Forms.Label();
			this.WhereBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(229, 201);
			this.Cancelbutton.Visible = false;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(324, 201);
			// 
			// TBox
			// 
			this.TBox.Location = new System.Drawing.Point(13, 13);
			this.TBox.Name = "TBox";
			this.TBox.Size = new System.Drawing.Size(389, 31);
			this.TBox.TabIndex = 0;
			// 
			// Where
			// 
			this.Where.AutoSize = true;
			this.Where.Location = new System.Drawing.Point(13, 62);
			this.Where.Name = "Where";
			this.Where.Size = new System.Drawing.Size(68, 23);
			this.Where.TabIndex = 1;
			this.Where.Text = "Where";
			// 
			// WhereBox
			// 
			this.WhereBox.Location = new System.Drawing.Point(17, 105);
			this.WhereBox.Multiline = true;
			this.WhereBox.Name = "WhereBox";
			this.WhereBox.Size = new System.Drawing.Size(385, 78);
			this.WhereBox.TabIndex = 2;
			// 
			// DeleteView
			// 
			this.ClientSize = new System.Drawing.Size(414, 253);
			this.Controls.Add(this.WhereBox);
			this.Controls.Add(this.Where);
			this.Controls.Add(this.TBox);
			this.Name = "DeleteView";
			this.Controls.SetChildIndex(this.TBox, 0);
			this.Controls.SetChildIndex(this.Where, 0);
			this.Controls.SetChildIndex(this.WhereBox, 0);
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public Delete Get()
		{
			if (TBox.SelectedIndex < 0)
				return null;
			return new Delete()
			{
				Table = (Table) TBox.SelectedItem,
				Where = WhereBox.Text
			};
		}
	}
}

