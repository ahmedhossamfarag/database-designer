using DatabaseDesigner.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene5
{
	internal class WriteSQLView : OkCancelForm
	{
		private System.Windows.Forms.TextBox SQLB;
		public WriteSQLView()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.SQLB = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// DeleteButton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(493, 445);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(588, 445);
			// 
			// SQLB
			// 
			this.SQLB.Location = new System.Drawing.Point(1, -3);
			this.SQLB.Multiline = true;
			this.SQLB.Name = "SQLB";
			this.SQLB.Size = new System.Drawing.Size(677, 442);
			this.SQLB.TabIndex = 6;
			// 
			// WriteSQLView
			// 
			this.ClientSize = new System.Drawing.Size(680, 497);
			this.Controls.Add(this.SQLB);
			this.Name = "WriteSQLView";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.SQLB, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public WriteSQL Get()
		{
			if (SQLB.Text.Any())
				return new WriteSQL() { Value = SQLB.Text };
			return null;
		}
	}
}
