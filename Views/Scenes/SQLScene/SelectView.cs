using DatabaseDesigner.Models;
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
	struct TableDetail
	{
		public Table T;
		public CheckBox C;
		public List<CheckBox> I;
	}

	internal class SelectView : OkCancelForm
	{
		private FlowLayoutPanel SPBox;
		private CheckBox Count;
		private CheckBox Distinct;
		private TextBox Having;
		private Label HavingLabel;
		private ComboBox GBox;
		private Label WhereLabel;
		private TextBox Where;
		private Label GroupLabel;
		private FlowLayoutPanel OBox;
		private Label OrderLabel;
		private Label SelectLabel;
		private FlowLayoutPanel PBox;
		private FlowLayoutPanel TBox;
		private readonly List<TableDetail> Tables = new List<TableDetail>();

		public SelectView(Database Database = null)
		{
			InitializeComponent();
			Database?.Tables?.ForEach(t => {
				CheckBox c = new CheckBox() { Text = t.Name, AutoSize = true };
				TBox.Controls.Add(c);
				TableDetail detail = new TableDetail()
				{
					T = t,
					C = c,
					I = new List<CheckBox>()
				};
				Tables.Add(detail);
				c.CheckedChanged += (s, ev) => TC_CheckedChanged(c, detail);
				foreach (Property p in t.Attributes)
				{
					CheckBox cp = new CheckBox() { Text = p.Name, AutoSize = true };
					OrderView ov = new OrderView() { On = p };
					SelectItemView sv = new SelectItemView() { On = p };
					cp.CheckedChanged += (s, ev) => SelectItem_CheckChanged(p, cp, ov, sv);
					detail.I.Add(cp);
				}
			});
			GBox.Items.Add("None");
		}

		private void InitializeComponent()
		{
			this.SPBox = new System.Windows.Forms.FlowLayoutPanel();
			this.Count = new System.Windows.Forms.CheckBox();
			this.Distinct = new System.Windows.Forms.CheckBox();
			this.Having = new System.Windows.Forms.TextBox();
			this.HavingLabel = new System.Windows.Forms.Label();
			this.GBox = new System.Windows.Forms.ComboBox();
			this.WhereLabel = new System.Windows.Forms.Label();
			this.Where = new System.Windows.Forms.TextBox();
			this.GroupLabel = new System.Windows.Forms.Label();
			this.OBox = new System.Windows.Forms.FlowLayoutPanel();
			this.OrderLabel = new System.Windows.Forms.Label();
			this.SelectLabel = new System.Windows.Forms.Label();
			this.PBox = new System.Windows.Forms.FlowLayoutPanel();
			this.TBox = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(892, 601);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(987, 601);
			// 
			// SPBox
			// 
			this.SPBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SPBox.AutoScroll = true;
			this.SPBox.Location = new System.Drawing.Point(551, 338);
			this.SPBox.Name = "SPBox";
			this.SPBox.Size = new System.Drawing.Size(510, 233);
			this.SPBox.TabIndex = 30;
			this.SPBox.Visible = false;
			this.SPBox.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.SPBox_ControlAdded);
			this.SPBox.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.SPBox_ControlRemoved);
			// 
			// Count
			// 
			this.Count.AutoSize = true;
			this.Count.Enabled = false;
			this.Count.Location = new System.Drawing.Point(386, 157);
			this.Count.Name = "Count";
			this.Count.Size = new System.Drawing.Size(83, 27);
			this.Count.TabIndex = 29;
			this.Count.Text = "Count";
			this.Count.UseVisualStyleBackColor = true;
			// 
			// Distinct
			// 
			this.Distinct.AutoSize = true;
			this.Distinct.Location = new System.Drawing.Point(238, 157);
			this.Distinct.Name = "Distinct";
			this.Distinct.Size = new System.Drawing.Size(96, 27);
			this.Distinct.TabIndex = 28;
			this.Distinct.Text = "Distinct";
			this.Distinct.UseVisualStyleBackColor = true;
			this.Distinct.CheckedChanged += new System.EventHandler(this.Distinct_CheckedChanged);
			// 
			// Having
			// 
			this.Having.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Having.Enabled = false;
			this.Having.Location = new System.Drawing.Point(555, 126);
			this.Having.Name = "Having";
			this.Having.Size = new System.Drawing.Size(510, 30);
			this.Having.TabIndex = 27;
			// 
			// HavingLabel
			// 
			this.HavingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.HavingLabel.AutoSize = true;
			this.HavingLabel.Location = new System.Drawing.Point(555, 90);
			this.HavingLabel.Name = "HavingLabel";
			this.HavingLabel.Size = new System.Drawing.Size(68, 23);
			this.HavingLabel.TabIndex = 26;
			this.HavingLabel.Text = "Having";
			// 
			// GBox
			// 
			this.GBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GBox.Enabled = false;
			this.GBox.Location = new System.Drawing.Point(555, 40);
			this.GBox.Name = "GBox";
			this.GBox.Size = new System.Drawing.Size(510, 31);
			this.GBox.TabIndex = 25;
			this.GBox.SelectedIndexChanged += new System.EventHandler(this.GBox_SelectedIndexChanged);
			// 
			// WhereLabel
			// 
			this.WhereLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.WhereLabel.AutoSize = true;
			this.WhereLabel.Location = new System.Drawing.Point(12, 384);
			this.WhereLabel.Name = "WhereLabel";
			this.WhereLabel.Size = new System.Drawing.Size(68, 23);
			this.WhereLabel.TabIndex = 24;
			this.WhereLabel.Text = "Where";
			// 
			// Where
			// 
			this.Where.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Where.Location = new System.Drawing.Point(12, 425);
			this.Where.Multiline = true;
			this.Where.Name = "Where";
			this.Where.Size = new System.Drawing.Size(510, 146);
			this.Where.TabIndex = 23;
			// 
			// GroupLabel
			// 
			this.GroupLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GroupLabel.AutoSize = true;
			this.GroupLabel.Location = new System.Drawing.Point(555, 12);
			this.GroupLabel.Name = "GroupLabel";
			this.GroupLabel.Size = new System.Drawing.Size(92, 23);
			this.GroupLabel.TabIndex = 22;
			this.GroupLabel.Text = "GroupBY";
			// 
			// OBox
			// 
			this.OBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.OBox.AutoScroll = true;
			this.OBox.Location = new System.Drawing.Point(551, 210);
			this.OBox.Name = "OBox";
			this.OBox.Size = new System.Drawing.Size(510, 100);
			this.OBox.TabIndex = 21;
			// 
			// OrderLabel
			// 
			this.OrderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.OrderLabel.AutoSize = true;
			this.OrderLabel.Location = new System.Drawing.Point(551, 173);
			this.OrderLabel.Name = "OrderLabel";
			this.OrderLabel.Size = new System.Drawing.Size(91, 23);
			this.OrderLabel.TabIndex = 20;
			this.OrderLabel.Text = "Order By";
			// 
			// SelectLabel
			// 
			this.SelectLabel.AutoSize = true;
			this.SelectLabel.Location = new System.Drawing.Point(12, 156);
			this.SelectLabel.Name = "SelectLabel";
			this.SelectLabel.Size = new System.Drawing.Size(65, 23);
			this.SelectLabel.TabIndex = 19;
			this.SelectLabel.Text = "Select";
			// 
			// PBox
			// 
			this.PBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PBox.AutoScroll = true;
			this.PBox.Location = new System.Drawing.Point(12, 194);
			this.PBox.Name = "PBox";
			this.PBox.Size = new System.Drawing.Size(505, 187);
			this.PBox.TabIndex = 18;
			// 
			// TBox
			// 
			this.TBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TBox.AutoScroll = true;
			this.TBox.Location = new System.Drawing.Point(12, 12);
			this.TBox.Name = "TBox";
			this.TBox.Size = new System.Drawing.Size(505, 139);
			this.TBox.TabIndex = 17;
			// 
			// SelectView
			// 
			this.ClientSize = new System.Drawing.Size(1079, 653);
			this.Controls.Add(this.SPBox);
			this.Controls.Add(this.Count);
			this.Controls.Add(this.Distinct);
			this.Controls.Add(this.Having);
			this.Controls.Add(this.HavingLabel);
			this.Controls.Add(this.GBox);
			this.Controls.Add(this.WhereLabel);
			this.Controls.Add(this.Where);
			this.Controls.Add(this.GroupLabel);
			this.Controls.Add(this.OBox);
			this.Controls.Add(this.OrderLabel);
			this.Controls.Add(this.SelectLabel);
			this.Controls.Add(this.PBox);
			this.Controls.Add(this.TBox);
			this.Name = "SelectView";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.TBox, 0);
			this.Controls.SetChildIndex(this.PBox, 0);
			this.Controls.SetChildIndex(this.SelectLabel, 0);
			this.Controls.SetChildIndex(this.OrderLabel, 0);
			this.Controls.SetChildIndex(this.OBox, 0);
			this.Controls.SetChildIndex(this.GroupLabel, 0);
			this.Controls.SetChildIndex(this.Where, 0);
			this.Controls.SetChildIndex(this.WhereLabel, 0);
			this.Controls.SetChildIndex(this.GBox, 0);
			this.Controls.SetChildIndex(this.HavingLabel, 0);
			this.Controls.SetChildIndex(this.Having, 0);
			this.Controls.SetChildIndex(this.Distinct, 0);
			this.Controls.SetChildIndex(this.Count, 0);
			this.Controls.SetChildIndex(this.SPBox, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public Select Get()
		{
			Select s = new Select()
			{
				Distinct = Distinct.Checked,
				Count = Count.Enabled && Count.Checked,
				Where = Where.Text,
				Having = Having.Enabled ? Having.Text : string.Empty,
				GroupBy = GBox.Enabled && GBox.SelectedIndex > 0 ? (Property)GBox.SelectedItem : null
			};
			foreach (TableDetail d in Tables)
				if (d.C.Checked)
					s.Tables.Add(d.T);
			foreach (Control c in SPBox.Controls)
			{
				SelectItemView v = (SelectItemView)c;
				s.Properities.Add(v.Get());
			}
			foreach (Control c in OBox.Controls)
			{
				OrderView v = (OrderView)c;
				if (v.Checked)
				{
					(Property P, Order O) = v.Get();
					SelectProperty sp = s.Properities.Find(p => p.P == P);
					s.OrderBy.Add((sp, O));
				}
				else
					break;
			}
			return s;
		}


		#region Events
		private void TC_CheckedChanged(CheckBox c, TableDetail detail)
		{
			if (c.Checked)
			{
				PBox.Controls.AddRange(detail.I.ToArray());
			}
			else
			{
				foreach (CheckBox p in detail.I)
				{
					p.Checked = false;
					PBox.Controls.Remove(p);
				};
			}
		}

		private void SelectItem_CheckChanged(Property p, CheckBox cp, OrderView ov, SelectItemView sv)
		{
			if (cp.Checked)
			{
				OBox.Controls.Add(ov);
				GBox.Items.Add(p);
				SPBox.Controls.Add(sv);
			}
			else
			{
				OBox.Controls.Remove(ov);
				GBox.Items.Remove(p);
				SPBox.Controls.Remove(sv);
			}
		}
		private void Distinct_CheckedChanged(object sender, EventArgs e)
		{
			Count.Enabled = Distinct.Checked;
		}

		private void GBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Count.Enabled = GBox.SelectedIndex <= 0;
			SPBox.Visible = GBox.SelectedIndex > 0;
		}

		private void SPBox_ControlAdded(object sender, ControlEventArgs e)
		{
			GBox.Enabled = SPBox.Controls.Count > 1;
			Having.Enabled = SPBox.Controls.Count > 1;
			SPBox.Visible = SPBox.Controls.Count == 1 || GBox.SelectedIndex > 0;
		}

		private void SPBox_ControlRemoved(object sender, ControlEventArgs e)
		{
			GBox.Enabled = SPBox.Controls.Count > 1;
			Having.Enabled = SPBox.Controls.Count > 1;
			SPBox.Visible = SPBox.Controls.Count == 1 || GBox.SelectedIndex > 0;
		}
		#endregion
	}
}
