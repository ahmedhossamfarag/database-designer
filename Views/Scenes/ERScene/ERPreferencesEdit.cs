using DatabaseDesigner.Models.Preference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class ERPreferencesEdit : OkCancelForm
	{
		private System.Windows.Forms.TabPage rTab;
		private Base.ColorPanel RLine;
		private Base.ColorPanel RSelect;
		private Base.ColorPanel RTxtColor;
		private Base.ColorPanel RColor;
		private Base.SizePanel RSize;
		private System.Windows.Forms.TabPage aTab;
		private Base.ColorPanel ALine;
		private Base.ColorPanel ASelect;
		private Base.ColorPanel ATxtColor;
		private Base.ColorPanel AColor;
		private Base.SizePanel ASize;
		private System.Windows.Forms.TabPage eTab;
		private Base.ColorPanel ELine;
		private Base.ColorPanel ESelect;
		private Base.ColorPanel ETxtColor;
		private Base.ColorPanel EColor;
		private Base.SizePanel ESize;
		private System.Windows.Forms.TabPage dTab;
		private System.Windows.Forms.CheckBox DFill;
		private Base.SizePanel DSize;
		private System.Windows.Forms.TabPage bTab;
		private Base.ColorPanel BLine;
		private Base.ColorPanel BSelect;
		private Base.ColorPanel BTxtColor;
		private Base.ColorPanel BColor;
		private Base.SizePanel BSize;
		private System.Windows.Forms.TabPage uTab;
		private Base.ColorPanel ULine;
		private Base.ColorPanel USelect;
		private Base.ColorPanel UTxtColor;
		private Base.ColorPanel UColor;
		private Base.SizePanel USize;
		private System.Windows.Forms.TabControl tabControl;


		public ERPreferencesEdit()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.rTab = new System.Windows.Forms.TabPage();
			this.RLine = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.RSelect = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.RTxtColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.RColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.RSize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.aTab = new System.Windows.Forms.TabPage();
			this.ALine = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.ASelect = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.ATxtColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.AColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.ASize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.eTab = new System.Windows.Forms.TabPage();
			this.ELine = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.ESelect = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.ETxtColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.EColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.ESize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.dTab = new System.Windows.Forms.TabPage();
			this.DFill = new System.Windows.Forms.CheckBox();
			this.DSize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.bTab = new System.Windows.Forms.TabPage();
			this.BLine = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.BSelect = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.BTxtColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.BColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.BSize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.uTab = new System.Windows.Forms.TabPage();
			this.ULine = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.USelect = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.UTxtColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.UColor = new DatabaseDesigner.Views.Scenes.Base.ColorPanel();
			this.USize = new DatabaseDesigner.Views.Scenes.Base.SizePanel();
			this.rTab.SuspendLayout();
			this.aTab.SuspendLayout();
			this.eTab.SuspendLayout();
			this.dTab.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.bTab.SuspendLayout();
			this.uTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// Cancelbutton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(301, 485);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(410, 485);
			// 
			// rTab
			// 
			this.rTab.BackColor = System.Drawing.SystemColors.Control;
			this.rTab.Controls.Add(this.RLine);
			this.rTab.Controls.Add(this.RSelect);
			this.rTab.Controls.Add(this.RTxtColor);
			this.rTab.Controls.Add(this.RColor);
			this.rTab.Controls.Add(this.RSize);
			this.rTab.Location = new System.Drawing.Point(4, 32);
			this.rTab.Name = "rTab";
			this.rTab.Padding = new System.Windows.Forms.Padding(3);
			this.rTab.Size = new System.Drawing.Size(492, 368);
			this.rTab.TabIndex = 7;
			this.rTab.Text = "Relation View";
			// 
			// RLine
			// 
			this.RLine.Font = new System.Drawing.Font("Tahoma", 12F);
			this.RLine.Location = new System.Drawing.Point(10, 330);
			this.RLine.Name = "RLine";
			this.RLine.PrefColor = System.Drawing.Color.Black;
			this.RLine.PrefName = "Line Color";
			this.RLine.Size = new System.Drawing.Size(469, 32);
			this.RLine.TabIndex = 6;
			// 
			// RSelect
			// 
			this.RSelect.Font = new System.Drawing.Font("Tahoma", 12F);
			this.RSelect.Location = new System.Drawing.Point(10, 280);
			this.RSelect.Name = "RSelect";
			this.RSelect.PrefColor = System.Drawing.Color.Blue;
			this.RSelect.PrefName = "Select Color";
			this.RSelect.Size = new System.Drawing.Size(469, 32);
			this.RSelect.TabIndex = 5;
			// 
			// RTxtColor
			// 
			this.RTxtColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.RTxtColor.Location = new System.Drawing.Point(10, 225);
			this.RTxtColor.Name = "RTxtColor";
			this.RTxtColor.PrefColor = System.Drawing.Color.Black;
			this.RTxtColor.PrefName = "Text Color";
			this.RTxtColor.Size = new System.Drawing.Size(469, 32);
			this.RTxtColor.TabIndex = 4;
			// 
			// RColor
			// 
			this.RColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.RColor.Location = new System.Drawing.Point(10, 170);
			this.RColor.Name = "RColor";
			this.RColor.PrefColor = System.Drawing.Color.Black;
			this.RColor.PrefName = "Color";
			this.RColor.Size = new System.Drawing.Size(469, 32);
			this.RColor.TabIndex = 2;
			// 
			// RSize
			// 
			this.RSize.Font = new System.Drawing.Font("Tahoma", 12F);
			this.RSize.Location = new System.Drawing.Point(10, 20);
			this.RSize.MaxSize = new System.Drawing.Size(200, 200);
			this.RSize.Name = "RSize";
			this.RSize.PrefSize = new System.Drawing.Size(100, 100);
			this.RSize.Size = new System.Drawing.Size(469, 128);
			this.RSize.TabIndex = 3;
			// 
			// aTab
			// 
			this.aTab.BackColor = System.Drawing.SystemColors.Control;
			this.aTab.Controls.Add(this.ALine);
			this.aTab.Controls.Add(this.ASelect);
			this.aTab.Controls.Add(this.ATxtColor);
			this.aTab.Controls.Add(this.AColor);
			this.aTab.Controls.Add(this.ASize);
			this.aTab.Location = new System.Drawing.Point(4, 32);
			this.aTab.Name = "aTab";
			this.aTab.Padding = new System.Windows.Forms.Padding(3);
			this.aTab.Size = new System.Drawing.Size(492, 368);
			this.aTab.TabIndex = 3;
			this.aTab.Text = "Attribute View";
			// 
			// ALine
			// 
			this.ALine.Font = new System.Drawing.Font("Tahoma", 12F);
			this.ALine.Location = new System.Drawing.Point(10, 330);
			this.ALine.Name = "ALine";
			this.ALine.PrefColor = System.Drawing.Color.Black;
			this.ALine.PrefName = "Line Color";
			this.ALine.Size = new System.Drawing.Size(469, 32);
			this.ALine.TabIndex = 6;
			// 
			// ASelect
			// 
			this.ASelect.Font = new System.Drawing.Font("Tahoma", 12F);
			this.ASelect.Location = new System.Drawing.Point(10, 280);
			this.ASelect.Name = "ASelect";
			this.ASelect.PrefColor = System.Drawing.Color.Blue;
			this.ASelect.PrefName = "Select Color";
			this.ASelect.Size = new System.Drawing.Size(469, 32);
			this.ASelect.TabIndex = 5;
			// 
			// ATxtColor
			// 
			this.ATxtColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.ATxtColor.Location = new System.Drawing.Point(10, 225);
			this.ATxtColor.Name = "ATxtColor";
			this.ATxtColor.PrefColor = System.Drawing.Color.Black;
			this.ATxtColor.PrefName = "Text Color";
			this.ATxtColor.Size = new System.Drawing.Size(469, 32);
			this.ATxtColor.TabIndex = 4;
			// 
			// AColor
			// 
			this.AColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.AColor.Location = new System.Drawing.Point(10, 170);
			this.AColor.Name = "AColor";
			this.AColor.PrefColor = System.Drawing.Color.Black;
			this.AColor.PrefName = "Color";
			this.AColor.Size = new System.Drawing.Size(469, 32);
			this.AColor.TabIndex = 2;
			// 
			// ASize
			// 
			this.ASize.Font = new System.Drawing.Font("Tahoma", 12F);
			this.ASize.Location = new System.Drawing.Point(10, 20);
			this.ASize.MaxSize = new System.Drawing.Size(200, 200);
			this.ASize.Name = "ASize";
			this.ASize.PrefSize = new System.Drawing.Size(80, 60);
			this.ASize.Size = new System.Drawing.Size(469, 128);
			this.ASize.TabIndex = 3;
			// 
			// eTab
			// 
			this.eTab.BackColor = System.Drawing.SystemColors.Control;
			this.eTab.Controls.Add(this.ELine);
			this.eTab.Controls.Add(this.ESelect);
			this.eTab.Controls.Add(this.ETxtColor);
			this.eTab.Controls.Add(this.EColor);
			this.eTab.Controls.Add(this.ESize);
			this.eTab.Location = new System.Drawing.Point(4, 32);
			this.eTab.Name = "eTab";
			this.eTab.Padding = new System.Windows.Forms.Padding(3);
			this.eTab.Size = new System.Drawing.Size(492, 368);
			this.eTab.TabIndex = 2;
			this.eTab.Text = "Entity View";
			// 
			// ELine
			// 
			this.ELine.Font = new System.Drawing.Font("Tahoma", 12F);
			this.ELine.Location = new System.Drawing.Point(10, 330);
			this.ELine.Name = "ELine";
			this.ELine.PrefColor = System.Drawing.Color.Black;
			this.ELine.PrefName = "Line Color";
			this.ELine.Size = new System.Drawing.Size(469, 32);
			this.ELine.TabIndex = 6;
			// 
			// ESelect
			// 
			this.ESelect.Font = new System.Drawing.Font("Tahoma", 12F);
			this.ESelect.Location = new System.Drawing.Point(10, 280);
			this.ESelect.Name = "ESelect";
			this.ESelect.PrefColor = System.Drawing.Color.Blue;
			this.ESelect.PrefName = "Select Color";
			this.ESelect.Size = new System.Drawing.Size(469, 32);
			this.ESelect.TabIndex = 5;
			// 
			// ETxtColor
			// 
			this.ETxtColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.ETxtColor.Location = new System.Drawing.Point(10, 225);
			this.ETxtColor.Name = "ETxtColor";
			this.ETxtColor.PrefColor = System.Drawing.Color.Black;
			this.ETxtColor.PrefName = "Text Color";
			this.ETxtColor.Size = new System.Drawing.Size(469, 32);
			this.ETxtColor.TabIndex = 4;
			// 
			// EColor
			// 
			this.EColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.EColor.Location = new System.Drawing.Point(10, 170);
			this.EColor.Name = "EColor";
			this.EColor.PrefColor = System.Drawing.Color.Black;
			this.EColor.PrefName = "Color";
			this.EColor.Size = new System.Drawing.Size(469, 32);
			this.EColor.TabIndex = 2;
			// 
			// ESize
			// 
			this.ESize.Font = new System.Drawing.Font("Tahoma", 12F);
			this.ESize.Location = new System.Drawing.Point(10, 20);
			this.ESize.MaxSize = new System.Drawing.Size(200, 200);
			this.ESize.Name = "ESize";
			this.ESize.PrefSize = new System.Drawing.Size(100, 50);
			this.ESize.Size = new System.Drawing.Size(469, 128);
			this.ESize.TabIndex = 3;
			// 
			// dTab
			// 
			this.dTab.BackColor = System.Drawing.SystemColors.Control;
			this.dTab.Controls.Add(this.DFill);
			this.dTab.Controls.Add(this.DSize);
			this.dTab.Location = new System.Drawing.Point(4, 32);
			this.dTab.Name = "dTab";
			this.dTab.Padding = new System.Windows.Forms.Padding(3);
			this.dTab.Size = new System.Drawing.Size(492, 368);
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
			// tabControl
			// 
			this.tabControl.Controls.Add(this.dTab);
			this.tabControl.Controls.Add(this.eTab);
			this.tabControl.Controls.Add(this.aTab);
			this.tabControl.Controls.Add(this.rTab);
			this.tabControl.Controls.Add(this.bTab);
			this.tabControl.Controls.Add(this.uTab);
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(500, 404);
			this.tabControl.TabIndex = 7;
			// 
			// bTab
			// 
			this.bTab.BackColor = System.Drawing.SystemColors.Control;
			this.bTab.Controls.Add(this.BLine);
			this.bTab.Controls.Add(this.BSelect);
			this.bTab.Controls.Add(this.BTxtColor);
			this.bTab.Controls.Add(this.BColor);
			this.bTab.Controls.Add(this.BSize);
			this.bTab.Location = new System.Drawing.Point(4, 32);
			this.bTab.Name = "bTab";
			this.bTab.Padding = new System.Windows.Forms.Padding(3);
			this.bTab.Size = new System.Drawing.Size(492, 368);
			this.bTab.TabIndex = 8;
			this.bTab.Text = "Branch View";
			// 
			// BLine
			// 
			this.BLine.Font = new System.Drawing.Font("Tahoma", 12F);
			this.BLine.Location = new System.Drawing.Point(10, 330);
			this.BLine.Name = "BLine";
			this.BLine.PrefColor = System.Drawing.Color.Black;
			this.BLine.PrefName = "Line Color";
			this.BLine.Size = new System.Drawing.Size(469, 32);
			this.BLine.TabIndex = 6;
			// 
			// BSelect
			// 
			this.BSelect.Font = new System.Drawing.Font("Tahoma", 12F);
			this.BSelect.Location = new System.Drawing.Point(10, 280);
			this.BSelect.Name = "BSelect";
			this.BSelect.PrefColor = System.Drawing.Color.Blue;
			this.BSelect.PrefName = "Select Color";
			this.BSelect.Size = new System.Drawing.Size(469, 32);
			this.BSelect.TabIndex = 5;
			// 
			// BTxtColor
			// 
			this.BTxtColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.BTxtColor.Location = new System.Drawing.Point(9, 225);
			this.BTxtColor.Name = "BTxtColor";
			this.BTxtColor.PrefColor = System.Drawing.Color.Black;
			this.BTxtColor.PrefName = "Text Color";
			this.BTxtColor.Size = new System.Drawing.Size(469, 32);
			this.BTxtColor.TabIndex = 4;
			// 
			// BColor
			// 
			this.BColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.BColor.Location = new System.Drawing.Point(10, 170);
			this.BColor.Name = "BColor";
			this.BColor.PrefColor = System.Drawing.Color.Black;
			this.BColor.PrefName = "Color";
			this.BColor.Size = new System.Drawing.Size(469, 32);
			this.BColor.TabIndex = 2;
			// 
			// BSize
			// 
			this.BSize.Font = new System.Drawing.Font("Tahoma", 12F);
			this.BSize.Location = new System.Drawing.Point(10, 20);
			this.BSize.MaxSize = new System.Drawing.Size(50, 50);
			this.BSize.Name = "BSize";
			this.BSize.PrefSize = new System.Drawing.Size(30, 30);
			this.BSize.Size = new System.Drawing.Size(469, 128);
			this.BSize.TabIndex = 3;
			// 
			// uTab
			// 
			this.uTab.BackColor = System.Drawing.SystemColors.Control;
			this.uTab.Controls.Add(this.ULine);
			this.uTab.Controls.Add(this.USelect);
			this.uTab.Controls.Add(this.UTxtColor);
			this.uTab.Controls.Add(this.UColor);
			this.uTab.Controls.Add(this.USize);
			this.uTab.Location = new System.Drawing.Point(4, 32);
			this.uTab.Name = "uTab";
			this.uTab.Padding = new System.Windows.Forms.Padding(3);
			this.uTab.Size = new System.Drawing.Size(492, 368);
			this.uTab.TabIndex = 9;
			this.uTab.Text = "Union View";
			// 
			// ULine
			// 
			this.ULine.Font = new System.Drawing.Font("Tahoma", 12F);
			this.ULine.Location = new System.Drawing.Point(10, 330);
			this.ULine.Name = "ULine";
			this.ULine.PrefColor = System.Drawing.Color.Black;
			this.ULine.PrefName = "Line Color";
			this.ULine.Size = new System.Drawing.Size(469, 32);
			this.ULine.TabIndex = 6;
			// 
			// USelect
			// 
			this.USelect.Font = new System.Drawing.Font("Tahoma", 12F);
			this.USelect.Location = new System.Drawing.Point(10, 280);
			this.USelect.Name = "USelect";
			this.USelect.PrefColor = System.Drawing.Color.Blue;
			this.USelect.PrefName = "Select Color";
			this.USelect.Size = new System.Drawing.Size(469, 32);
			this.USelect.TabIndex = 5;
			// 
			// UTxtColor
			// 
			this.UTxtColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.UTxtColor.Location = new System.Drawing.Point(10, 225);
			this.UTxtColor.Name = "UTxtColor";
			this.UTxtColor.PrefColor = System.Drawing.Color.Black;
			this.UTxtColor.PrefName = "Text Color";
			this.UTxtColor.Size = new System.Drawing.Size(469, 32);
			this.UTxtColor.TabIndex = 4;
			// 
			// UColor
			// 
			this.UColor.Font = new System.Drawing.Font("Tahoma", 12F);
			this.UColor.Location = new System.Drawing.Point(10, 170);
			this.UColor.Name = "UColor";
			this.UColor.PrefColor = System.Drawing.Color.Black;
			this.UColor.PrefName = "Color";
			this.UColor.Size = new System.Drawing.Size(469, 32);
			this.UColor.TabIndex = 2;
			// 
			// USize
			// 
			this.USize.Font = new System.Drawing.Font("Tahoma", 12F);
			this.USize.Location = new System.Drawing.Point(10, 20);
			this.USize.MaxSize = new System.Drawing.Size(50, 50);
			this.USize.Name = "USize";
			this.USize.PrefSize = new System.Drawing.Size(30, 30);
			this.USize.Size = new System.Drawing.Size(469, 128);
			this.USize.TabIndex = 3;
			// 
			// ERPreferencesEdit
			// 
			this.ClientSize = new System.Drawing.Size(502, 537);
			this.Controls.Add(this.tabControl);
			this.Name = "ERPreferencesEdit";
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.rTab.ResumeLayout(false);
			this.aTab.ResumeLayout(false);
			this.eTab.ResumeLayout(false);
			this.dTab.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.bTab.ResumeLayout(false);
			this.uTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		public ERPreferences Get()
		{
			return new ERPreferences()
			{
				DiagramSize = DSize.PrefSize,
				Fill = DFill.Checked,
				ESize = ESize.PrefSize,
				EColor = EColor.PrefColor,
				ETextColor = ETxtColor.PrefColor,
				ESelectColor = ESelect.PrefColor,
				ELineColor = ELine.PrefColor,
				ASize = ASize.PrefSize,
				AColor = AColor.PrefColor,
				ATextColor = ATxtColor.PrefColor,
				ASelectColor = ASelect.PrefColor,
				ALineColor = ALine.PrefColor,
				RSize = RSize.PrefSize,
				RColor = RColor.PrefColor,
				RTextColor = RTxtColor.PrefColor,
				RSelectColor = RSelect.PrefColor,
				RLineColor = RLine.PrefColor,
				BSize = BSize.PrefSize,
				BColor = BColor.PrefColor,
				BTextColor = BTxtColor.PrefColor,
				BSelectColor = BSelect.PrefColor,
				BLineColor = BLine.PrefColor,
				USize = USize.PrefSize,
				UColor = UColor.PrefColor,
				UTextColor = UTxtColor.PrefColor,
				USelectColor = USelect.PrefColor,
				ULineColor = ULine.PrefColor,

			};
		}
	}
}
