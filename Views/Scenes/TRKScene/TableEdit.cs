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
	internal partial class TableEdit  : OkCancelForm
	{
		public GroupBox TGroup;
		public Panel TForColor;
		public Label TFCLabel;
		public Label TBCLabel;
		public Panel TBackColor;
		public GroupBox PGroup;
		public Panel PForColor;
		public Label PFCLabel;
		public Label PBCLabel;
		public Panel PBackColor;
		public Button Delete;
		public TextBox TName;


		

		public TableEdit()
		{
			InitializeComponent();
			TName.Select();
			OnOk = Valid;
		}



		private void InitializeComponent()
		{
			this.TName = new TextBox();
			this.TGroup = new GroupBox();
			this.TForColor = new Panel();
			this.TFCLabel = new Label();
			this.TBCLabel = new Label();
			this.TBackColor = new Panel();
			this.PGroup = new GroupBox();
			this.PForColor = new Panel();
			this.PFCLabel = new Label();
			this.PBCLabel = new Label();
			this.PBackColor = new Panel();
			this.Delete = new Button();
			this.TGroup.SuspendLayout();
			this.PGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(100, 301);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(195, 300);
			// 
			// TName
			// 
			this.TName.Location = new System.Drawing.Point(13, 13);
			this.TName.Name = "TName";
			this.TName.Size = new System.Drawing.Size(257, 30);
			this.TName.TabIndex = 6;
			// 
			// TGroup
			// 
			this.TGroup.Controls.Add(this.TForColor);
			this.TGroup.Controls.Add(this.TFCLabel);
			this.TGroup.Controls.Add(this.TBCLabel);
			this.TGroup.Controls.Add(this.TBackColor);
			this.TGroup.Location = new System.Drawing.Point(13, 59);
			this.TGroup.Name = "TGroup";
			this.TGroup.Size = new System.Drawing.Size(257, 100);
			this.TGroup.TabIndex = 11;
			this.TGroup.TabStop = false;
			this.TGroup.Text = "Table Name";
			// 
			// TForColor
			// 
			this.TForColor.BackColor = System.Drawing.Color.White;
			this.TForColor.Location = new System.Drawing.Point(237, 70);
			this.TForColor.Name = "TForColor";
			this.TForColor.Size = new System.Drawing.Size(20, 20);
			this.TForColor.TabIndex = 14;
			this.TForColor.Click += new System.EventHandler(this.ChooseColor_Click);
			// 
			// TFCLabel
			// 
			this.TFCLabel.AutoSize = true;
			this.TFCLabel.Location = new System.Drawing.Point(0, 70);
			this.TFCLabel.Name = "TFCLabel";
			this.TFCLabel.Size = new System.Drawing.Size(87, 23);
			this.TFCLabel.TabIndex = 13;
			this.TFCLabel.Text = "ForColor";
			// 
			// TBCLabel
			// 
			this.TBCLabel.AutoSize = true;
			this.TBCLabel.Location = new System.Drawing.Point(0, 30);
			this.TBCLabel.Name = "TBCLabel";
			this.TBCLabel.Size = new System.Drawing.Size(101, 23);
			this.TBCLabel.TabIndex = 12;
			this.TBCLabel.Text = "BackColor";
			// 
			// TBackColor
			// 
			this.TBackColor.BackColor = System.Drawing.Color.Blue;
			this.TBackColor.Location = new System.Drawing.Point(237, 30);
			this.TBackColor.Name = "TBackColor";
			this.TBackColor.Size = new System.Drawing.Size(20, 20);
			this.TBackColor.TabIndex = 11;
			this.TBackColor.Click += new System.EventHandler(this.ChooseColor_Click);
			// 
			// PGroup
			// 
			this.PGroup.Controls.Add(this.PForColor);
			this.PGroup.Controls.Add(this.PFCLabel);
			this.PGroup.Controls.Add(this.PBCLabel);
			this.PGroup.Controls.Add(this.PBackColor);
			this.PGroup.Location = new System.Drawing.Point(13, 175);
			this.PGroup.Name = "PGroup";
			this.PGroup.Size = new System.Drawing.Size(257, 100);
			this.PGroup.TabIndex = 12;
			this.PGroup.TabStop = false;
			this.PGroup.Text = "Properties";
			// 
			// PForColor
			// 
			this.PForColor.BackColor = System.Drawing.Color.DodgerBlue;
			this.PForColor.Location = new System.Drawing.Point(237, 70);
			this.PForColor.Name = "PForColor";
			this.PForColor.Size = new System.Drawing.Size(20, 20);
			this.PForColor.TabIndex = 14;
			this.PForColor.Click += new System.EventHandler(this.ChooseColor_Click);
			// 
			// PFCLabel
			// 
			this.PFCLabel.AutoSize = true;
			this.PFCLabel.Location = new System.Drawing.Point(0, 70);
			this.PFCLabel.Name = "PFCLabel";
			this.PFCLabel.Size = new System.Drawing.Size(87, 23);
			this.PFCLabel.TabIndex = 13;
			this.PFCLabel.Text = "ForColor";
			// 
			// PBCLabel
			// 
			this.PBCLabel.AutoSize = true;
			this.PBCLabel.Location = new System.Drawing.Point(0, 30);
			this.PBCLabel.Name = "PBCLabel";
			this.PBCLabel.Size = new System.Drawing.Size(101, 23);
			this.PBCLabel.TabIndex = 12;
			this.PBCLabel.Text = "BackColor";
			// 
			// PBackColor
			// 
			this.PBackColor.BackColor = System.Drawing.Color.White;
			this.PBackColor.Location = new System.Drawing.Point(237, 30);
			this.PBackColor.Name = "PBackColor";
			this.PBackColor.Size = new System.Drawing.Size(20, 20);
			this.PBackColor.TabIndex = 11;
			this.PBackColor.Click += new System.EventHandler(this.ChooseColor_Click);
			// 
			// Delete
			// 
			this.Delete.Location = new System.Drawing.Point(7, 300);
			this.Delete.Name = "Delete";
			this.Delete.Size = new System.Drawing.Size(87, 41);
			this.Delete.TabIndex = 13;
			this.Delete.Text = "Delete";
			this.Delete.UseVisualStyleBackColor = true;
			this.Delete.Visible = false;
			this.Delete.Click += new System.EventHandler(this.Delete_Click);
			// 
			// TableEdit
			// 
			this.ClientSize = new System.Drawing.Size(282, 353);
			this.Controls.Add(this.Delete);
			this.Controls.Add(this.PGroup);
			this.Controls.Add(this.TGroup);
			this.Controls.Add(this.TName);
			this.Name = "TableEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.TName, 0);
			this.Controls.SetChildIndex(this.TGroup, 0);
			this.Controls.SetChildIndex(this.PGroup, 0);
			this.Controls.SetChildIndex(this.Delete, 0);
			this.TGroup.ResumeLayout(false);
			this.TGroup.PerformLayout();
			this.PGroup.ResumeLayout(false);
			this.PGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void ChooseColor_Click(object sender, EventArgs e)
		{
			Control c = (Control)sender;
			ColorDialog dialog = new ColorDialog()
			{
				Color = c.BackColor
			};
			if (dialog.ShowDialog() == DialogResult.OK)
				c.BackColor = dialog.Color;
		}

		private void Delete_Click(object sender, EventArgs e)
		{
			if(InfoDialog.Of("Are You Sure?") == DialogResult.OK)
			{
				DialogResult = DialogResult.No;
				Close();
			}
		}
	}
}
