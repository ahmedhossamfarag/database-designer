using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.TEScene;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace DatabaseDesigner.Controllers.Base
{
	internal static class PrintBMP
	{
		public static void Print(Panel p)
		{
			SaveFileDialog dialog = new SaveFileDialog()
			{
				FileName = "bitmap.bmp",
				DefaultExt = "bmp",
				AddExtension = true
			};
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				Bitmap m = new Bitmap(p.Width, p.Height);
				var g = Graphics.FromImage(m);
				g.Clear(Color.White);
				for (int i = p.Controls.Count - 1; i >= 0; i--)
				{
					Control c = p.Controls[i];
					Bitmap b = new Bitmap(c.Width, c.Height);
					c.DrawToBitmap(b, new Rectangle(new Point(), c.Size));
					g.DrawImage(b, new Rectangle(c.Location, c.Size));

				}
				m.Save(dialog.FileName);

			}
		}
	}
}
