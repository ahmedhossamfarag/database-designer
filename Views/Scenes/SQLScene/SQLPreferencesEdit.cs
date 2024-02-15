using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.SQLScene
{
	internal class SQLPreferencesEdit : OkCancelForm
	{
		public System.Windows.Forms.ComboBox FDSelect;

		public SQLPreferencesEdit()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.FDSelect = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(81, 65);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(190, 65);
			// 
			// FDSelect
			// 
			this.FDSelect.Location = new System.Drawing.Point(13, 13);
			this.FDSelect.Name = "FDSelect";
			this.FDSelect.Size = new System.Drawing.Size(257, 31);
			this.FDSelect.TabIndex = 6;
			// 
			// SQLPreferencesEdit
			// 
			this.ClientSize = new System.Drawing.Size(282, 117);
			this.Controls.Add(this.FDSelect);
			this.Name = "SQLPreferencesEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.FDSelect, 0);
			this.ResumeLayout(false);

		}
	}
}
