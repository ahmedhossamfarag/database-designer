using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene5
{
	internal class SelectItemView : Panel
	{
		private Label NameBox;
		private ComboBox TypeBox;
		private Property Property;

		public Property On
		{
			set
			{
				Property = value;
				NameBox.Text = value.Name;
				if (value.DataType != DataType.Int && value.DataType != DataType.Float)
				{
					TypeBox.Items.Clear();
					TypeBox.Items.Add(SelectType.COUNT);
					TypeBox.Items.Add(SelectType.None);

				}
			}
		}
		public SelectItemView()
		{
			InitializeComponent();
			for (int i = 0; i <= (int)SelectType.None; i++)
			{
				TypeBox.Items.Add((SelectType)i);
			}
		}

		private void InitializeComponent()
		{
			this.NameBox = new System.Windows.Forms.Label();
			this.TypeBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(0, 0);
			this.NameBox.Name = "NameBox";
			this.NameBox.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.NameBox.Size = new System.Drawing.Size(250, 28);
			this.NameBox.TabIndex = 0;
			this.NameBox.Text = "Name";
			this.NameBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TypeBox
			// 
			this.TypeBox.FormattingEnabled = true;
			this.TypeBox.Location = new System.Drawing.Point(300, 0);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(210, 28);
			this.TypeBox.TabIndex = 1;
			// 
			// SelectItemView
			// 
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(510, 28);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.NameBox);
			this.Font = new System.Drawing.Font("Arial", 12F);
			this.Name = "SelectItemView";
			this.ResumeLayout(false);

		}

		public SelectProperty Get()
		{
			return new SelectProperty()
			{
				P = Property,
				T = TypeBox.SelectedIndex < 0 ? SelectType.None : (SelectType)TypeBox.SelectedIndex
			};
		}
	}
}
