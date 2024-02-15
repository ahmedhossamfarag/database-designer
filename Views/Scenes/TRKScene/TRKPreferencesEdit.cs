using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.TRKScene
{
	internal class TRKPreferencesEdit : OkCancelForm
	{
		public Base.SizePanel TRKSize;

		public TRKPreferencesEdit()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.TRKSize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(81, 173);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(190, 173);
			// 
			// TRKSize
			// 
			this.TRKSize.Font = new System.Drawing.Font("Tahoma", 12F);
			this.TRKSize.Location = new System.Drawing.Point(13, 13);
			this.TRKSize.MaxSize = new System.Drawing.Size(2000, 2000);
			this.TRKSize.Name = "TRKSize";
			this.TRKSize.PrefSize = new System.Drawing.Size(1200, 800);
			this.TRKSize.Size = new System.Drawing.Size(252, 128);
			this.TRKSize.TabIndex = 0;
			// 
			// TRKPreferencesEdit
			// 
			this.ClientSize = new System.Drawing.Size(282, 225);
			this.Controls.Add(this.TRKSize);
			this.Name = "TRKPreferencesEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.TRKSize, 0);
			this.ResumeLayout(false);

		}
	}
}
