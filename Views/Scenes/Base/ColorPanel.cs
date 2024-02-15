using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Base
{
	internal class ColorPanel : Panel
	{

		private Label ColorLabel;
		private Panel ColorBox;


		public string PrefName
		{
			get => ColorLabel.Text;
			set => ColorLabel.Text = value;
		}

		public Color PrefColor
		{
			get => ColorBox.BackColor;
			set => ColorBox.BackColor = value;
		}

		public ColorPanel()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.ColorLabel = new Label();
			this.ColorBox = new Panel();
			// 
			// this
			// 
			this.Controls.Add(this.ColorBox);
			this.Controls.Add(this.ColorLabel);
			this.Font = new Font("Tahoma", 12F);
			this.Size = new Size(200, 32);
			this.TabIndex = 0;
			// 
			// ColorLabel
			// 
			this.ColorLabel.Location = new Point(0, 0);
			this.ColorLabel.Name = "ColorLabel";
			this.ColorLabel.Size = new Size(150, 32);
			this.ColorLabel.TabIndex = 0;
			this.ColorLabel.Text = "Color";
			this.ColorLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// ColorBox
			// 
			this.ColorBox.Location = new Point(174, 6);
			this.ColorBox.Name = "ColorBox";
			this.ColorBox.Size = new Size(20, 20);
			this.ColorBox.TabIndex = 1;
			this.ColorBox.Cursor = Cursors.Hand;
			this.ColorBox.Click += ColorBox_Click;
			this.ColorBox.Anchor = System.Windows.Forms.AnchorStyles.Right;

		}

		private void ColorBox_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog() { Color = ColorBox.BackColor };
			if (dialog.ShowDialog() == DialogResult.OK)
				ColorBox.BackColor = dialog.Color;
		}
	}
}
