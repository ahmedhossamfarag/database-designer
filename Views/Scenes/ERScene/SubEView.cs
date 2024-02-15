using DatabaseDesigner.Models.EER;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class SubEView : Panel
	{

		public Button Delete;
		public Entity Entity;

		public SubEView(Entity e)
		{
			this.Entity = e;
			InitializeComponent(e);
		}

		private void InitializeComponent(Entity entity)
		{
			Delete = new Button();
			System.Windows.Forms.Label EName = new System.Windows.Forms.Label();
			// 
			// Taskthis
			// 
			this.Controls.Add(EName);
			this.Controls.Add(Delete);
			this.Name = "this";
			this.Size = new System.Drawing.Size(385, 49);
			this.TabIndex = 0;
			//
			//Delete
			//
			Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			Delete.Location = new System.Drawing.Point(4, 15);
			Delete.Name = "AddButton";
			Delete.Size = new System.Drawing.Size(17, 17);
			Delete.TabIndex = 5;
			Delete.UseVisualStyleBackColor = true;
			Delete.Paint += Paint_Delete;
			// 
			// EName
			// 
			EName.AutoSize = true;
			EName.Location = new System.Drawing.Point(60, 17);
			EName.Name = "EName";
			EName.Text = entity.Name;
			EName.Size = new System.Drawing.Size(42, 17);
			EName.TabIndex = 0;


		}

		private void Paint_Delete(object sender, PaintEventArgs e)
		{
			Button b = (Button)sender;
			Pen pen = new Pen(Color.Black);
			e.Graphics.DrawLine(pen, 0, 0, b.Width, b.Height);
			e.Graphics.DrawLine(pen, 0, b.Height, b.Width, 0);
		}


	}
}
