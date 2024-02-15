using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class PropertyView : Panel
	{

		public Label PType;
		public Label PName;


		public Point AbsoluteLocation => new Point(Location.X + Parent.Location.X + Parent.Parent.Location.X,
													Location.Y + Parent.Location.Y + Parent.Parent.Location.Y);

		

		public PropertyView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.PName = new System.Windows.Forms.Label();
			this.PType = new System.Windows.Forms.Label();
			// 
			// PView
			// 
			this.Controls.Add(this.PType);
			this.Controls.Add(this.PName);
			this.Location = new System.Drawing.Point(0, 0);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "PView";
			this.Size = new System.Drawing.Size(200, 30);
			this.TabIndex = 0;
			this.DoubleClick += PView_DoubleClick;
			this.Font = new System.Drawing.Font("Arial", 12);
			this.MouseEnter += PropertyView_MouseEnter;
			this.MouseLeave += PropertyView_MouseLeave;
			this.Click += PropertyView_Click;
			// 
			// PName
			// 
			this.PName.Location = new System.Drawing.Point(0, 0);
			this.PName.Margin = new System.Windows.Forms.Padding(0);
			this.PName.Name = "PName";
			this.PName.Size = new System.Drawing.Size(100, 30);
			this.PName.TabIndex = 0;
			this.PName.Text = "Property";
			this.PName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.PName.DoubleClick += PView_DoubleClick;
			this.PName.MouseEnter += PropertyView_MouseEnter;
			this.PName.MouseLeave += PropertyView_MouseLeave;
			this.PName.Click += PropertyView_Click;
			// 
			// PType
			// 
			this.PType.Location = new System.Drawing.Point(120, 0);
			this.PType.Name = "PType";
			this.PType.Size = new System.Drawing.Size(80, 30);
			this.PType.TabIndex = 1;
			this.PType.Text = "Type";
			this.PType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.PType.DoubleClick += PView_DoubleClick;
			this.PType.MouseEnter += PropertyView_MouseEnter;
			this.PType.MouseLeave += PropertyView_MouseLeave;
			this.PType.Click += PropertyView_Click;
		}

		private void PropertyView_Click(object sender, EventArgs e)
		{
			Scene.PropertyClick(this);
		}

		private void PropertyView_MouseLeave(object sender, EventArgs e)
		{
			(ForeColor, BackColor) = (BackColor, ForeColor);
		}

		private void PropertyView_MouseEnter(object sender, EventArgs e)
		{
			(ForeColor, BackColor) = (BackColor, ForeColor);
		}

    }
}
