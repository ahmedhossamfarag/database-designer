using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene5
{
	internal class OrderView : Panel
	{
		public CheckBox PName;
		private CheckBox DESC;
		private Property Property;

		public Property On
		{
			set
			{
				Property = value;
				PName.Text = value.Name;
			}
		}
		public bool Checked { get { return PName.Checked; } set { PName.Checked = value; } }

		public OrderView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.PName = new System.Windows.Forms.CheckBox();
			this.DESC = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// PName
			// 
			this.PName.AutoSize = true;
			this.PName.Location = new System.Drawing.Point(0, 0);
			this.PName.Name = "PName";
			this.PName.Size = new System.Drawing.Size(96, 27);
			this.PName.TabIndex = 0;
			this.PName.Text = "PName";
			this.PName.UseVisualStyleBackColor = true;
			this.PName.CheckedChanged += PName_CheckedChanged;
			// 
			// DESC
			// 
			this.DESC.AutoSize = true;
			this.DESC.Location = new System.Drawing.Point(380, 0);
			this.DESC.Name = "DESC";
			this.DESC.Size = new System.Drawing.Size(86, 27);
			this.DESC.TabIndex = 1;
			this.DESC.Text = "DESC";
			this.DESC.UseVisualStyleBackColor = true;
			// 
			// OrderView
			// 
			this.ClientSize = new System.Drawing.Size(510, 30);
			this.Controls.Add(this.DESC);
			this.Controls.Add(this.PName);
			this.Font = new System.Drawing.Font("Arial", 12F);
			this.Name = "OrderView";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void PName_CheckedChanged(object sender, EventArgs e)
		{
			int n = Parent.Controls.Cast<OrderView>().ToList().Count(v => v.Checked);
			if (PName.Checked)
				Parent.Controls.SetChildIndex(this, n - 1);
			else
				Parent.Controls.SetChildIndex(this, n);
		}

		public (Property P, Order D) Get()
		{
			return (Property, DESC.Checked ? Order.DESC : Order.ASC);
		}
	}
}
