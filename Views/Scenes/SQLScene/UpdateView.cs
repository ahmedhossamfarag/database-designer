using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.SQL;
using DatabaseDesigner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene5
{
	internal class UpdateView : OkCancelForm
	{
		private System.Windows.Forms.FlowLayoutPanel PBox;
		private System.Windows.Forms.TextBox WhereBox;
		private System.Windows.Forms.Label Where;
		private System.Windows.Forms.ComboBox TBox;
		private List<(Property P, CheckBox C)> Values;

		public Database Database
		{
			set
			{
				TBox.Items.AddRange(value.Tables.ToArray());
			}
		}

		public UpdateView()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			this.PBox = new System.Windows.Forms.FlowLayoutPanel();
			this.TBox = new System.Windows.Forms.ComboBox();
			this.WhereBox = new System.Windows.Forms.TextBox();
			this.Where = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(228, 494);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(323, 494);
			// 
			// PBox
			// 
			this.PBox.AutoScroll = true;
			this.PBox.Location = new System.Drawing.Point(16, 67);
			this.PBox.Name = "PBox";
			this.PBox.Size = new System.Drawing.Size(385, 256);
			this.PBox.TabIndex = 12;
			// 
			// TBox
			// 
			this.TBox.Location = new System.Drawing.Point(12, 12);
			this.TBox.Name = "TBox";
			this.TBox.Size = new System.Drawing.Size(389, 31);
			this.TBox.TabIndex = 11;
			this.TBox.SelectedIndexChanged += new System.EventHandler(this.TBox_SelectedIndexChanged);
			// 
			// WhereBox
			// 
			this.WhereBox.Location = new System.Drawing.Point(16, 394);
			this.WhereBox.Multiline = true;
			this.WhereBox.Name = "WhereBox";
			this.WhereBox.Size = new System.Drawing.Size(385, 78);
			this.WhereBox.TabIndex = 14;
			// 
			// Where
			// 
			this.Where.AutoSize = true;
			this.Where.Location = new System.Drawing.Point(12, 351);
			this.Where.Name = "Where";
			this.Where.Size = new System.Drawing.Size(68, 23);
			this.Where.TabIndex = 13;
			this.Where.Text = "Where";
			// 
			// UpdateView
			// 
			this.ClientSize = new System.Drawing.Size(415, 546);
			this.Controls.Add(this.WhereBox);
			this.Controls.Add(this.Where);
			this.Controls.Add(this.PBox);
			this.Controls.Add(this.TBox);
			this.Name = "UpdateView";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.TBox, 0);
			this.Controls.SetChildIndex(this.PBox, 0);
			this.Controls.SetChildIndex(this.Where, 0);
			this.Controls.SetChildIndex(this.WhereBox, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void TBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Table t = (Table)TBox.SelectedItem;
			PBox.Controls.Clear();
			Values = new List<(Property P, CheckBox C)>();
			foreach (Property p in t.Attributes)
			{
				CheckBox c = new CheckBox()
				{
					Text = p.Name,
					Width = 200
				};
				Values.Add((p, c));
				PBox.Controls.Add(c);
			}
		}

		public Update Get()
		{
			if (TBox.SelectedIndex < 0)
				return null;
			Update u = new Update()
			{
				Table = (Table)TBox.SelectedItem
			};
			Values.ForEach(x =>
			{
				if (x.C.Checked)
					u.Properities.Add(x.P);
			});
			if (u.Properities.Any())
				return u;
			return null;
		}
	}
}
