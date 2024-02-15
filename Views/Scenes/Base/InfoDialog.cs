using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes
{
	internal class InfoDialog : OkCancelForm
	{
		public Label Content;
		public override string Text
		{
			set
			{
				Content.Text = value;
			}
		}

		public string Negative { set { Cancelbutton.Text = value; } }

		public InfoDialog()
		{
			InitializeComponent();
		}

		public InfoDialog(string txt) : this()
		{
			Text = txt;
		}

		private void InitializeComponent()
		{
			this.Content = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(312, 72);
			this.Cancelbutton.Visible = false;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(407, 72);
			// 
			// Content
			// 
			this.Content.AutoSize = true;
			this.Content.Font = new System.Drawing.Font("Tahoma", 12F);
			this.Content.Location = new System.Drawing.Point(12, 9);
			this.Content.Name = "Content";
			this.Content.Size = new System.Drawing.Size(80, 24);
			this.Content.TabIndex = 6;
			this.Content.Text = "Content";
			// 
			// InfoDialog
			// 
			this.ClientSize = new System.Drawing.Size(499, 124);
			this.Controls.Add(this.Content);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "InfoDialog";
			this.TopMost = true;
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.Content, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		public static DialogResult Of(object txt)
		{
			return new InfoDialog(txt.ToString()).ShowDialog();
		}

	}
}
