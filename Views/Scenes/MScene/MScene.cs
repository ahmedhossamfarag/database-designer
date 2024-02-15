using DatabaseDesigner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene1
{
	internal class MScene : Scene
	{
		private PipeLine PipeLine;

		public MScene()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.PipeLine = new DatabaseDesigner.Views.Scenes.Scene1.PipeLine();
			this.SuspendLayout();
			// 
			// PipeLine
			// 
			this.PipeLine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PipeLine.Location = new System.Drawing.Point(0, 0);
			this.PipeLine.Name = "PipeLine";
			this.PipeLine.Size = new System.Drawing.Size(800, 600);
			this.PipeLine.TabIndex = 1;
			this.PipeLine.Paint += new System.Windows.Forms.PaintEventHandler(this.PipeLine_Paint);
			// 
			// Scene1
			// 
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.PipeLine);
			this.Name = "Scene1";
			this.ResumeLayout(false);

		}

		private void PipeLine_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			PipeLine.PaintComponent(e);
		}
	}
}
