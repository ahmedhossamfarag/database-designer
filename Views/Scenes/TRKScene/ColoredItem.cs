using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal class ColoredItem : Panel
	{

		public System.Windows.Forms.Panel IColor;
		public System.Windows.Forms.Label ILabel;

		public ColoredItem()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.ILabel = new System.Windows.Forms.Label();
			this.IColor = new System.Windows.Forms.Panel();
			// 
			// 
			// 
			this.Controls.Add(this.IColor);
			this.Controls.Add(this.ILabel);
			this.Size = new System.Drawing.Size(200, 30);
			this.TabIndex = 0;
			this.DoubleClick += ColoredItem_DoubleClick;
			this.MouseEnter += ColoredItem_MouseEnter;
			this.MouseLeave += ColoredItem_MouseLeave;
			// 
			// ILabel
			// 
			this.ILabel.Font = new System.Drawing.Font("Arial", 12F);
			this.ILabel.Location = new System.Drawing.Point(0, 0);
			this.ILabel.Name = "ILabel";
			this.ILabel.Size = new System.Drawing.Size(50, 30);
			this.ILabel.TabIndex = 0;
			this.ILabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ILabel.DoubleClick += ColoredItem_DoubleClick;
			this.ILabel.MouseEnter += ColoredItem_MouseEnter;
			this.ILabel.MouseLeave += ColoredItem_MouseLeave;

			// 
			// IColor
			// 
			this.IColor.Location = new System.Drawing.Point(50, 12);
			this.IColor.Name = "IColor";
			this.IColor.Size = new System.Drawing.Size(130, 5);
			this.IColor.TabIndex = 1;
			this.IColor.DoubleClick += ColoredItem_DoubleClick;
			this.IColor.MouseEnter += ColoredItem_MouseEnter;
			this.IColor.MouseLeave += ColoredItem_MouseLeave;

		}

		private void ColoredItem_MouseLeave(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.None;
		}

		private void ColoredItem_MouseEnter(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.FixedSingle;
		}

		public virtual void ColoredItem_DoubleClick(object sender, EventArgs e)
		{
			
		}
	}
}
