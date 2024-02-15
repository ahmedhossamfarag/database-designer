using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.TEScene
{
    internal partial  class TableEdit : OkCancelForm
    {
        private System.Windows.Forms.TextBox NameBox;

        public TableEdit()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.NameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(206, 53);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(315, 53);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(20, 12);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(370, 30);
            this.NameBox.TabIndex = 14;
            // 
            // TableEdit
            // 
            this.ClientSize = new System.Drawing.Size(407, 105);
            this.Controls.Add(this.NameBox);
            this.Name = "TableEdit";
            this.Controls.SetChildIndex(this.OkButton, 0);
            this.Controls.SetChildIndex(this.Cancelbutton, 0);
            this.Controls.SetChildIndex(this.NameBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
