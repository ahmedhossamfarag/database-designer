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
	internal class InsertView : OkCancelForm
	{
		private ComboBox TBox;
		public Database Database
		{
			set
			{
				TBox.Items.AddRange(value.Tables.ToArray());
			}
		}

		public InsertView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.TBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(235, 68);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(325, 68);
			// 
			// TBox
			// 
			this.TBox.Location = new System.Drawing.Point(12, 12);
			this.TBox.Name = "TBox";
			this.TBox.Size = new System.Drawing.Size(389, 31);
			this.TBox.TabIndex = 5;
			// 
			// InsertView
			// 
			this.ClientSize = new System.Drawing.Size(417, 120);
			this.Controls.Add(this.TBox);
			this.Name = "InsertView";
			this.Controls.SetChildIndex(this.TBox, 0);
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.ResumeLayout(false);

		}

		public Insert Get()
		{
			if (TBox.SelectedIndex < 0)
				return null;
			return new Insert()
			{
				Table = (Table)TBox.SelectedItem
			};
		}
	}
}
