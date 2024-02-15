using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes
{
	internal class OkCancelForm : Form
	{
		public Button Cancelbutton;
		public Button OkButton;
		public Action OnOk { get; set; }
		
		public OkCancelForm()
		{
			InitializeComponent();
			OkButton.Select();
		}
		private void InitializeComponent()
		{
			this.Cancelbutton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CancelButton
			// 
			this.Cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cancelbutton.Location = new System.Drawing.Point(81, 201);
			this.Cancelbutton.Name = "CancelButton";
			this.Cancelbutton.Size = new System.Drawing.Size(89, 40);
			this.Cancelbutton.TabIndex = 4;
			this.Cancelbutton.Text = "Cancel";
			this.Cancelbutton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkButton.Location = new System.Drawing.Point(190, 201);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 40);
			this.OkButton.TabIndex = 5;
			this.OkButton.Text = "OK";
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// OkCancelForm
			// 
			this.ClientSize = new System.Drawing.Size(282, 253);
			this.Controls.Add(this.Cancelbutton);
			this.Controls.Add(this.OkButton);
			this.Font = new System.Drawing.Font("Arial", 12F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "OkCancelForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OkDeleteForm_KeyPress);
			this.ResumeLayout(false);

		}
		private void OkButton_Click(object sender, EventArgs e)
		{
			try
			{
				OnOk?.Invoke();
				DialogResult = DialogResult.OK;
				Close();
			}
			catch(InvalidOperationException ex)
			{
				InfoDialog.Of(ex.Message);
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void OkDeleteForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ((char)Keys.Enter))
				OkButton.PerformClick();
		}

	}
}
