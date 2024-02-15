using DatabaseDesigner.Models.Preference;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene2
{
	internal class DatabaseView : CirText
	{
		public DatabaseView(FlowDiagramView view)
		{
            var x = view.Preferences;
            Size = x.DBSize;
            SetColors(x);
            Center = new Point(view.Width / 2, view.Height / 2);
            Text = "Database";
            Font = new Font("Arial", 18);
            Cursor = Cursors.Default;
        }

		public void Set(FlowDiagramView view, Point move, float dScale)
		{
            var x = view.Preferences;
            SetColors(x);
            FactorBounds(x.DBSize, dScale, move);
        }

        private void SetColors(FDPreferences x)
        {
            DrawPen.Color = x.DBColor;
            FillColor.Color = x.DBColor;
            Fill = x.Fill;
            ForeColor = x.DBTextColor;
        }

	}


}
