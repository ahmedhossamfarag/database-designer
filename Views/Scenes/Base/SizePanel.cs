using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Base
{
	internal class SizePanel : Panel
	{
		private NumericUpDown WBox;
		private Label WLabel;
		private NumericUpDown HBox;
		private Label HLabel;


		public Size MaxSize
		{
			get => new Size((int)WBox.Maximum, (int)HBox.Maximum);
			set
			{
				WBox.Maximum = value.Width;
				HBox.Maximum = value.Height;
			}
		}

		public Size PrefSize
		{
			get => new Size((int)WBox.Value, (int)HBox.Value);
			set
			{
				WBox.Value = value.Width;
				HBox.Value = value.Height;
			}
		}

		public SizePanel()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.WLabel = new Label();
			this.WBox = new NumericUpDown();
			this.HBox = new NumericUpDown();
			this.HLabel = new Label();
			this.SuspendLayout();
			// 
			// this
			// 
			this.Controls.Add(this.HBox);
			this.Controls.Add(this.HLabel);
			this.Controls.Add(this.WBox);
			this.Controls.Add(this.WLabel);
			this.Font = new Font("Tahoma", 12F);
			this.Size = new Size(200, 128);
			this.TabIndex = 0;
			// 
			// WLabel
			// 
			this.WLabel.ForeColor = Color.Black;
			this.WLabel.Location = new Point(0, 0);
			this.WLabel.Name = "WLabel";
			this.WLabel.Size = new Size(80, 32);
			this.WLabel.TabIndex = 0;
			this.WLabel.Text = "Width";
			this.WLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// WBox
			// 
			this.WBox.Location = new Point(0, 32);
			this.WBox.Name = "WBox";
			this.WBox.Size = new Size(200, 32);
			this.WBox.TabIndex = 1;
			this.WBox.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
			| AnchorStyles.Right)));

			// 
			// HBox
			// 
			this.HBox.Location = new Point(0, 96);
			this.HBox.Name = "HBox";
			this.HBox.Size = new Size(200, 32);
			this.HBox.TabIndex = 3;
			this.HBox.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
			| AnchorStyles.Right)));
			
			// 
			// HLabel
			// 
			this.HLabel.ForeColor = Color.Black;
			this.HLabel.Location = new Point(0, 64);
			this.HLabel.Name = "HLabel";
			this.HLabel.Size = new Size(80, 32);
			this.HLabel.TabIndex = 2;
			this.HLabel.Text = "Height";
			this.HLabel.TextAlign = ContentAlignment.MiddleLeft;
			//
			//
			//
			this.ResumeLayout();
		}
	}
}
