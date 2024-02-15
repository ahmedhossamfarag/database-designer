using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	internal class StackPanel : Panel
	{
		public StackPanel() {
			Layout += StackPanel_Layout;
		}

		private void StackPanel_Layout(object sender, LayoutEventArgs e)
		{
			Point center = new Point(Width / 2, Height / 2);
			foreach(Control control in Controls)
			{
				control.Location = new System.Drawing.Point(
					center.X - (control.Width / 2),
					center.Y - (control.Height / 2)
					);
			}
		}
	}
}
