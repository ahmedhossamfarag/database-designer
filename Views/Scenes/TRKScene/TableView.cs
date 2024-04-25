using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.TRK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class TableView : Panel 
	{
		public Panel Mover;
		public Label TName;
		public Button AddProperty;
		public FlowLayoutPanel PBox;

		private bool move;
		private Point pastLo;
		private Point pastP;

		public TableView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.Mover = new Panel();
			this.PBox = new FlowLayoutPanel();
			this.AddProperty = new Button();
			this.TName = new Label();
			// 
			// TableView
			// 
			this.BackColor = Color.White;
			this.Controls.Add(this.Mover);
			this.Controls.Add(this.PBox);
			this.Controls.Add(this.AddProperty);
			this.Controls.Add(this.TName);
			this.Location = new Point(227, 58);
			this.Name = "TableView";
			this.Size = new Size(200, 75);
			this.TabIndex = 0;
			//
			// Mover
			//
			Mover.Size = new Size(200, 10);
			Mover.BackColor = Color.FromArgb(206, 206, 206);
			Mover.Cursor = Cursors.Hand;
			Mover.MouseDown += Mover_MouseDown;
			Mover.MouseMove += Mover_MouseMove;
			Mover.MouseUp += Mover_MouseUp;
			// 
			// PBox
			// 
			this.PBox.Location = new Point(0, 45);
			this.PBox.Name = "PBox";
			this.PBox.Size = new Size(200, 0);
			this.PBox.TabIndex = 2;
			this.PBox.ControlAdded += PBox_ControlAdded;
			this.PBox.ControlRemoved += PBox_ControlRemoved;
            this.PBox.ForeColorChanged += PBox_ForeColorChanged;
            this.PBox.BackColorChanged += PBox_BackColorChanged;
			// 
			// AddProperty
			// 
			this.AddProperty.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
			this.AddProperty.FlatAppearance.BorderSize = 0;
			this.AddProperty.FlatStyle = FlatStyle.Flat;
			this.AddProperty.Location = new Point(0, 45);
			this.AddProperty.Name = "AddProperty";
			this.AddProperty.Size = new Size(200, 30);
			this.AddProperty.TabIndex = 1;
			this.AddProperty.Cursor = Cursors.Hand;
			this.AddProperty.Text = "+ Property";
			this.AddProperty.TextAlign = ContentAlignment.MiddleLeft;
			this.AddProperty.UseVisualStyleBackColor = true;
			AddProperty.Click += AddProperty_Click;
			// 
			// TName
			// 
			this.TName.Location = new Point(0, 10);
			this.TName.Name = "TName";
			this.TName.Padding = new Padding(10, 0, 0, 0);
			this.TName.Size = new Size(200, 35);
			this.TName.TabIndex = 0;
			this.TName.Font = new Font("Arial", 14);
			this.TName.TextAlign = ContentAlignment.MiddleLeft;
			this.TName.Click += TName_Click;
			this.TName.DoubleClick += TName_DoubleClick;

		}

        private void PBox_ForeColorChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.PBox.Controls)
			{
                c.ForeColor = this.PBox.ForeColor;
				c.Refresh();
            }
        }

        private void PBox_BackColorChanged(object sender, EventArgs e)
        {
            foreach(Control c in this.PBox.Controls)
				c.BackColor = this.PBox.BackColor;
        }

        private void TName_Click(object sender, EventArgs e)
		{
			Scene.TableClick(this);
		}

		private void PBox_ControlRemoved(object sender, ControlEventArgs e)
		{
			PBox.Height -= 30;
			this.Height -= 30;
		}

		private void PBox_ControlAdded(object sender, ControlEventArgs e)
		{
			PBox.Height += 30;
			this.Height += 30;
		}

		private void Mover_MouseUp(object sender, MouseEventArgs e)
		{
			move = false;
			Mover.Cursor = Cursors.Hand;
			Point l = Location;
			Action un = () => Location = pastLo, re = () => Location = l;
			Scene.Record.Add((un, re));
		}

		private void Mover_MouseMove(object sender, MouseEventArgs e)
		{
			if (!move) return;
			int dx = e.X - pastP.X, dy = e.Y - pastP.Y;
			Point p = new Point(Location.X + dx, Location.Y + dy);
			Location = new Point(Math.Max(0, Math.Min(p.X, Parent.Width - Width)),
							Math.Max(0, Math.Min(p.Y, Parent.Height - Height)));
		}

		private void Mover_MouseDown(object sender, MouseEventArgs e)
		{
			move = true;
			Mover.Cursor = Cursors.NoMove2D;
			pastP = e.Location;
			pastLo = Location;
		}
	}
}
