using DatabaseDesigner.Controllers;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes
{
	internal abstract class Diagram : TransparentContainer
	{
		public abstract DiagramController DiagramController { get; }

		public float DScale { get; set; } = 1;

		public Diagram()
		{
			ControlAdded += Diagram_ControlAdded;
		}

		private void Diagram_ControlAdded(object sender, ControlEventArgs e)
		{
			if (e.Control is ShapeText s)
			{
				Point p = s.Center;
				s.Size = new Size((int)(s.Width * DScale), (int)(s.Height * DScale));
				s.Center = p;
			}
		}

	}
}
