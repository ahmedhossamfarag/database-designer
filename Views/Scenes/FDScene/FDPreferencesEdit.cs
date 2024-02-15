using DatabaseDesigner.Models.Preference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class FDPreferencesEdit : OkCancelForm
	{
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage dTab;
		private System.Windows.Forms.TabPage dbTab;
		private System.Windows.Forms.TabPage tTab;
		private Base.SizePanel DSize;
		private System.Windows.Forms.CheckBox DFill;
		private Base.ColorPanel DBTxtColor;
		private Base.ColorPanel DBColor;
		private Base.SizePanel DBSize;
		private Base.ColorPanel TTxtColor;
		private Base.ColorPanel TColor;
		private Base.SizePanel TSize;
		private Base.ColorPanel IOTxtColor;
		private Base.ColorPanel IOColor;
		private Base.SizePanel IOSize;
		private Base.ColorPanel IOSelect;
		private Base.ColorPanel TSelect;
		private Base.ColorPanel TArrow;
		private Base.ColorPanel IOArrow;
		private System.Windows.Forms.TabPage ioTab;

		public FDPreferencesEdit()
		{
			InitializeComponent();
		}


		private void InitializeComponent()
		{
			this.tabControl = new System.Windows.Forms.TabControl();
			this.dTab = new System.Windows.Forms.TabPage();
			this.DFill = new System.Windows.Forms.CheckBox();
			this.DSize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.dbTab = new System.Windows.Forms.TabPage();
			this.DBTxtColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.DBColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.DBSize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.tTab = new System.Windows.Forms.TabPage();
			this.TArrow = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.TSelect = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.TTxtColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.TColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.TSize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.ioTab = new System.Windows.Forms.TabPage();
			this.IOArrow = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.IOSelect = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.IOTxtColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.IOColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.IOSize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.tabControl.SuspendLayout();
			this.dTab.SuspendLayout();
			this.dbTab.SuspendLayout();
			this.tTab.SuspendLayout();
			this.ioTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(298, 416);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(407, 416);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.dTab);
			this.tabControl.Controls.Add(this.dbTab);
			this.tabControl.Controls.Add(this.tTab);
			this.tabControl.Controls.Add(this.ioTab);
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(500, 401);
			this.tabControl.TabIndex = 6;
			// 
			// dTab
			// 
			this.dTab.BackColor = System.Drawing.SystemColors.Control;
			this.dTab.Controls.Add(this.DFill);
			this.dTab.Controls.Add(this.DSize);
			this.dTab.Location = new System.Drawing.Point(4, 32);
			this.dTab.Name = "dTab";
			this.dTab.Padding = new System.Windows.Forms.Padding(3);
			this.dTab.Size = new System.Drawing.Size(492, 365);
			this.dTab.TabIndex = 0;
			this.dTab.Text = "Diagram";
			// 
			// DFill
			// 
			this.DFill.Location = new System.Drawing.Point(10, 170);
			this.DFill.Name = "DFill";
			this.DFill.Size = new System.Drawing.Size(469, 32);
			this.DFill.TabIndex = 1;
			this.DFill.Text = "Fill";
			this.DFill.UseVisualStyleBackColor = true;
			// 
			// DSize
			// 
			this.DSize.Font = new System.Drawing.Font("Tahoma", 12F);
			this.DSize.Location = new System.Drawing.Point(10, 20);
			this.DSize.MaxSize = new System.Drawing.Size(2000, 2000);
			this.DSize.Name = "DSize";
			this.DSize.PrefSize = new System.Drawing.Size(1200, 800);
			this.DSize.Size = new System.Drawing.Size(469, 128);
			this.DSize.TabIndex = 0;
			// 
			// dbTab
			// 
			this.dbTab.BackColor = System.Drawing.SystemColors.Control;
			this.dbTab.Controls.Add(this.DBTxtColor);
			this.dbTab.Controls.Add(this.DBColor);
			this.dbTab.Controls.Add(this.DBSize);
			this.dbTab.Location = new System.Drawing.Point(4, 32);
			this.dbTab.Name = "dbTab";
			this.dbTab.Padding = new System.Windows.Forms.Padding(3);
			this.dbTab.Size = new System.Drawing.Size(492, 365);
			this.dbTab.TabIndex = 1;
			this.dbTab.Text = "Database View";
			// 
			// DBTxtColor
			// 
			this.DBTxtColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.DBTxtColor.Location = new System.Drawing.Point(10, 225);
			this.DBTxtColor.Name = "DBTxtColor";
			this.DBTxtColor.PrefColor = System.Drawing.Color.Black;
			this.DBTxtColor.PrefName = "Text Color";
			this.DBTxtColor.Size = new System.Drawing.Size(469, 32);
			this.DBTxtColor.TabIndex = 1;
			// 
			// DBColor
			// 
			this.DBColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.DBColor.Location = new System.Drawing.Point(10, 170);
			this.DBColor.Name = "DBColor";
			this.DBColor.PrefColor = System.Drawing.Color.Black;
			this.DBColor.PrefName = "Color";
			this.DBColor.Size = new System.Drawing.Size(469, 32);
			this.DBColor.TabIndex = 0;
			// 
			// DBSize
			// 
			this.DBSize.Font = new System.Drawing.Font("Tahoma", 12F);
			this.DBSize.Location = new System.Drawing.Point(10, 20);
			this.DBSize.MaxSize = new System.Drawing.Size(300, 300);
			this.DBSize.Name = "DBSize";
			this.DBSize.PrefSize = new System.Drawing.Size(200, 200);
			this.DBSize.Size = new System.Drawing.Size(469, 128);
			this.DBSize.TabIndex = 0;
			// 
			// tTab
			// 
			this.tTab.BackColor = System.Drawing.SystemColors.Control;
			this.tTab.Controls.Add(this.TArrow);
			this.tTab.Controls.Add(this.TSelect);
			this.tTab.Controls.Add(this.TTxtColor);
			this.tTab.Controls.Add(this.TColor);
			this.tTab.Controls.Add(this.TSize);
			this.tTab.Location = new System.Drawing.Point(4, 32);
			this.tTab.Name = "tTab";
			this.tTab.Padding = new System.Windows.Forms.Padding(3);
			this.tTab.Size = new System.Drawing.Size(492, 365);
			this.tTab.TabIndex = 2;
			this.tTab.Text = "Task View";
			// 
			// TArrow
			// 
			this.TArrow.Font = new System.Drawing.Font("Tahoma", 12F);
			this.TArrow.Location = new System.Drawing.Point(10, 330);
			this.TArrow.Name = "TArrow";
			this.TArrow.PrefColor = System.Drawing.Color.Black;
			this.TArrow.PrefName = "Arrow Color";
			this.TArrow.Size = new System.Drawing.Size(469, 32);
			this.TArrow.TabIndex = 6;
			// 
			// TSelect
			// 
			this.TSelect.Font = new System.Drawing.Font("Tahoma", 12F);
			this.TSelect.Location = new System.Drawing.Point(10, 280);
			this.TSelect.Name = "TSelect";
			this.TSelect.PrefColor = System.Drawing.Color.Blue;
			this.TSelect.PrefName = "Select Color";
			this.TSelect.Size = new System.Drawing.Size(469, 32);
			this.TSelect.TabIndex = 5;
			// 
			// TTxtColor
			// 
			this.TTxtColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.TTxtColor.Location = new System.Drawing.Point(10, 225);
			this.TTxtColor.Name = "TTxtColor";
			this.TTxtColor.PrefColor = System.Drawing.Color.Black;
			this.TTxtColor.PrefName = "Text Color";
			this.TTxtColor.Size = new System.Drawing.Size(469, 32);
			this.TTxtColor.TabIndex = 4;
			// 
			// TColor
			// 
			this.TColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.TColor.Location = new System.Drawing.Point(10, 170);
			this.TColor.Name = "TColor";
			this.TColor.PrefColor = System.Drawing.Color.Black;
			this.TColor.PrefName = "Color";
			this.TColor.Size = new System.Drawing.Size(469, 32);
			this.TColor.TabIndex = 2;
			// 
			// TSize
			// 
			this.TSize.Font = new System.Drawing.Font("Tahoma", 12F);
			this.TSize.Location = new System.Drawing.Point(10, 20);
			this.TSize.MaxSize = new System.Drawing.Size(200, 200);
			this.TSize.Name = "TSize";
			this.TSize.PrefSize = new System.Drawing.Size(80, 60);
			this.TSize.Size = new System.Drawing.Size(469, 128);
			this.TSize.TabIndex = 3;
			// 
			// ioTab
			// 
			this.ioTab.BackColor = System.Drawing.SystemColors.Control;
			this.ioTab.Controls.Add(this.IOArrow);
			this.ioTab.Controls.Add(this.IOSelect);
			this.ioTab.Controls.Add(this.IOTxtColor);
			this.ioTab.Controls.Add(this.IOColor);
			this.ioTab.Controls.Add(this.IOSize);
			this.ioTab.Location = new System.Drawing.Point(4, 32);
			this.ioTab.Name = "ioTab";
			this.ioTab.Padding = new System.Windows.Forms.Padding(3);
			this.ioTab.Size = new System.Drawing.Size(492, 365);
			this.ioTab.TabIndex = 3;
			this.ioTab.Text = "IOScreeen View";
			// 
			// IOArrow
			// 
			this.IOArrow.Font = new System.Drawing.Font("Tahoma", 12F);
			this.IOArrow.Location = new System.Drawing.Point(10, 330);
			this.IOArrow.Name = "IOArrow";
			this.IOArrow.PrefColor = System.Drawing.Color.Black;
			this.IOArrow.PrefName = "Arrow Color";
			this.IOArrow.Size = new System.Drawing.Size(469, 32);
			this.IOArrow.TabIndex = 6;
			// 
			// IOSelect
			// 
			this.IOSelect.Font = new System.Drawing.Font("Tahoma", 12F);
			this.IOSelect.Location = new System.Drawing.Point(10, 280);
			this.IOSelect.Name = "IOSelect";
			this.IOSelect.PrefColor = System.Drawing.Color.Blue;
			this.IOSelect.PrefName = "Select Color";
			this.IOSelect.Size = new System.Drawing.Size(469, 32);
			this.IOSelect.TabIndex = 5;
			// 
			// IOTxtColor
			// 
			this.IOTxtColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.IOTxtColor.Location = new System.Drawing.Point(10, 225);
			this.IOTxtColor.Name = "IOTxtColor";
			this.IOTxtColor.PrefColor = System.Drawing.Color.Black;
			this.IOTxtColor.PrefName = "Text Color";
			this.IOTxtColor.Size = new System.Drawing.Size(469, 32);
			this.IOTxtColor.TabIndex = 4;
			// 
			// IOColor
			// 
			this.IOColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.IOColor.Location = new System.Drawing.Point(10, 170);
			this.IOColor.Name = "IOColor";
			this.IOColor.PrefColor = System.Drawing.Color.Black;
			this.IOColor.PrefName = "Color";
			this.IOColor.Size = new System.Drawing.Size(469, 32);
			this.IOColor.TabIndex = 2;
			// 
			// IOSize
			// 
			this.IOSize.Font = new System.Drawing.Font("Tahoma", 12F);
			this.IOSize.Location = new System.Drawing.Point(10, 20);
			this.IOSize.MaxSize = new System.Drawing.Size(300, 300);
			this.IOSize.Name = "IOSize";
			this.IOSize.PrefSize = new System.Drawing.Size(100, 100);
			this.IOSize.Size = new System.Drawing.Size(469, 128);
			this.IOSize.TabIndex = 3;
			// 
			// FDPreferencesEdit
			// 
			this.ClientSize = new System.Drawing.Size(499, 468);
			this.Controls.Add(this.tabControl);
			this.Name = "FDPreferencesEdit";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.tabControl.ResumeLayout(false);
			this.dTab.ResumeLayout(false);
			this.dbTab.ResumeLayout(false);
			this.tTab.ResumeLayout(false);
			this.ioTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	
	
		public FDPreferences Get()
		{
			return new FDPreferences()
			{
				DiagramSize = DSize.PrefSize,
				Fill = DFill.Checked,
				DBColor = DBColor.PrefColor,
				DBSize = DBSize.PrefSize,
				DBTextColor = DBTxtColor.PrefColor,
				TSize = TSize.PrefSize,
				TColor = TColor.PrefColor,
				TTextColor = TTxtColor.PrefColor,
				TSelectColor = TSelect.PrefColor,
				TArrowColor = TArrow.PrefColor,
				IOSize = IOSize.PrefSize,
				IOColor = IOColor.PrefColor,
				IOTextColor = IOTxtColor.PrefColor,
				IOSelectColor = IOSelect.PrefColor,
				IOArrowColor = IOArrow.PrefColor
			};
		}

        internal void Set(FDPreferences preferences)
        {
			DSize.PrefSize = preferences.DiagramSize;
			DFill.Checked = preferences.Fill;
			DBColor.PrefColor = preferences.DBColor;
			DBSize.PrefSize = preferences.DBSize;
			DBTxtColor .PrefColor = preferences.DBTextColor;
			TSize .PrefSize = preferences.TSize;
			TColor.PrefColor = preferences.TColor;
			TTxtColor.PrefColor = preferences.TTextColor;
			TSelect.PrefColor = preferences.TSelectColor;
			TArrow.PrefColor = preferences.TArrowColor;
			IOSize.PrefSize = preferences.IOSize;
			IOColor.PrefColor = preferences.IOColor ;
			IOTxtColor.PrefColor = preferences.IOTextColor;
			IOSelect.PrefColor = preferences.IOSelectColor;
			IOArrow.PrefColor = preferences.IOArrowColor;
        }
    }
}
