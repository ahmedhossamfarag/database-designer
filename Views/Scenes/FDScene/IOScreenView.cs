using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using DatabaseDesigner.Controllers.FDControl;
using DatabaseDesigner.Controllers;
using DatabaseDesigner.Models.Preference;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class IOScreenView : RecText, IControllable
	{
		public IOScreen IOScreen { get; set; }

		public FDVController FDVController => IOScreen.FlowDiagram.Controller;

		public IItemController Controller { get => IOScreen.Controller; }

		public IOScreenView(IOScreen iO)
		{
			IOScreen = iO;

			var x = iO.FlowDiagram.Preferences;
            Size = x.IOSize;
			SetColors(x);

            iO.NameChanged = n => Text = n;
			MouseClick += IOScreenView_MouseClick;
			MouseDown += IOScreenView_MouseDown;
			MouseUp += IOScreenView_MouseUp;
		}

        public void Set(FDPreferences x, Point move, float dScale)
        {
			SetColors(x);
			FactorBounds(x.IOSize, dScale, move);
        }

		private void SetColors(FDPreferences x)
		{
            SelectPen.Color = x.IOSelectColor;
            SelectFill.Color = x.IOSelectColor;
            DrawPen.Color = x.IOColor;
            FillColor.Color = x.IOColor;
            Fill = x.Fill;
            ForeColor = x.IOTextColor;
        }

        private void IOScreenView_MouseUp(object sender, MouseEventArgs e)
		{
			FDVController.MouseListner.MouseUp?.Invoke(sender, e);
		}

		private void IOScreenView_MouseDown(object sender, MouseEventArgs e)
		{
			FDVController.MouseListner.MouseDown?.Invoke(sender, e);
		}

		private void IOScreenView_MouseClick(object sender, MouseEventArgs e)
		{
			FDVController.MouseListner.MouseClick?.Invoke(sender, e);
		}

		public override string ToString() => IOScreen.Name;
	}
}
