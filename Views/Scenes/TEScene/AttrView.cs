using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.TEScene
{
	internal partial class AttrView : Panel
	{
		public static int Step { get; set; } = 40;
		public Property Property { get; }
		private List<(Property Att, AttrView View)> Attributes { get; }

		private int Index_ { get; set; }

		private Point PrevPoint;

		Label AttName;
		Label AttType;
		private Panel AttMover;
		public int Index
		{
			get
			{
				return Index_;
			}
			set
			{
				Location = new Point(0, value * 40);
				Attributes[value] = (Property, this);
				Index_ = value;
			}
		}

		public AttrView(Property property, List<(Property Att, AttrView View)> attributes)
		{
			Property = property;
			Attributes = attributes;
			Index_ = attributes.Count;
			Location = new Point(0, Index_ * 40);
			Attributes.Add((Property, this));
			InitializeComponent();
			if (Property.Key)
				AttName.Font = new System.Drawing.Font("Arial", 12F, FontStyle.Underline);
			else
				AttName.Font = new System.Drawing.Font("Arial", 12F);

			AttName.Text = Property.Name;
			ViewType(Property.DataType);
			Property.DataTypeChanged += ViewType;
			Property.LengthChanged += l => ViewType(Property.DataType);
			Property.NameChanged += nm => AttName.Text = nm;
		}

		private void ViewType(DataType type)
		{
			string end = type == DataType.VarChar || type == DataType.Float ? $"({Property.Length})" : "";
            AttType.Text = type.ToString() + end;
        }


		private void InitializeComponent()
		{
			AttMover = new Panel();
			AttName = new Label();
			AttType = new Label();
			// 
			// this
			// 
			this.Controls.Add(AttMover);
			this.Controls.Add(AttType);
			this.Controls.Add(AttName);
			this.Name = "this";
			this.Size = new System.Drawing.Size(858, 36);
			this.TabIndex = 0;
			this.Cursor = Cursors.Hand;
			this.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
			| AnchorStyles.Right)));
			// 
			// AttMover
			// 
			AttMover.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
			| AnchorStyles.Right)));
			AttMover.BackColor = System.Drawing.Color.White;
			AttMover.Location = new System.Drawing.Point(835, 0);
			AttMover.Name = "AttMover";
			AttMover.Size = new System.Drawing.Size(20, 35);
			AttMover.TabIndex = 3;
			AttMover.Paint += new PaintEventHandler(AttMover_Paint);
			AttMover.MouseDown += AttMover_MouseDown;
			AttMover.MouseMove += AttMover_MouseMove;
			AttMover.MouseUp += AttMover_MouseUp;
			// 
			// AttName
			// 
			AttName.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
			| AnchorStyles.Right)));
			AttName.BackColor = System.Drawing.Color.White;
			AttName.FlatStyle = FlatStyle.Flat;
			AttName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			AttName.Location = new System.Drawing.Point(0, 0);
			AttName.Name = "AttName";
			AttName.Size = new System.Drawing.Size(734, 35);
			AttName.TabIndex = 2;
			AttName.MouseClick += AttrView_MouseClick;
			AttName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			AttName.Padding = new Padding(10, 0, 0, 0);
			//
			//AttType
			//
			AttType.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
			| AnchorStyles.Right)));
			AttType.BackColor = System.Drawing.Color.White;
			AttType.FlatStyle = FlatStyle.Flat;
			AttType.Font = new System.Drawing.Font("Arial", 12F);
			AttType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			AttType.Location = new System.Drawing.Point(734, 0);
			AttType.Name = "AttType";
			AttType.Size = new System.Drawing.Size(100, 35);
			AttType.TabIndex = 2;
			AttType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;


		}

	
	}
}
