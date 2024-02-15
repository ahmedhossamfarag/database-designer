using DatabaseDesigner.Models.EER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class EntityPicker : OkCancelForm
	{
		private System.Windows.Forms.ComboBox EBox;

		public IEnumerable<EntityView> Entities
		{
			set
			{
				EBox.Items.AddRange(value.ToArray());
			}
		}

		public EntityPicker()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.EBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// DeleteButton
			// 
			this.Cancelbutton.Location = new System.Drawing.Point(207, 96);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(302, 96);
			// 
			// EBox
			// 
			this.EBox.Location = new System.Drawing.Point(13, 13);
			this.EBox.Name = "EBox";
			this.EBox.Size = new System.Drawing.Size(364, 31);
			this.EBox.TabIndex = 6;
			// 
			// EntityPicker
			// 
			this.ClientSize = new System.Drawing.Size(394, 148);
			this.Controls.Add(this.EBox);
			this.Name = "EntityPicker";
			this.Controls.SetChildIndex(this.OkButton, 0);
			this.Controls.SetChildIndex(this.Cancelbutton, 0);
			this.Controls.SetChildIndex(this.EBox, 0);
			this.ResumeLayout(false);

		}

		public Entity Selected
		{
			get
			{
				if (EBox.SelectedIndex < 0)
					throw new InvalidOperationException("Invalid Select");
				return ((EntityView)EBox.SelectedItem).Entity;
			}
		}
	}
}
