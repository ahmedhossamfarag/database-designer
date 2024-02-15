using DatabaseDesigner.Views.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers
{
	internal class SceneController
	{
		public Diagram Diagram;

		public void KeyDown(KeyEventArgs k)
		{
			switch (k.KeyCode)
			{
				case Keys.ControlKey: { Diagram.DiagramController.Control = true;  Diagram.DiagramController.SetControlMode(); break; }
				case Keys.Delete: { Diagram.DiagramController.Delete(); break; }
				case Keys.Escape: { Diagram.DiagramController.SetDefault(); break; }
				case Keys.F2: { Diagram.DiagramController.SetPreferences(); break; }
			}
		}

		public void KeyUp(KeyEventArgs k)
		{
			switch (k.KeyCode)
			{
				case Keys.ControlKey: { Diagram.DiagramController.Control = false; Diagram.DiagramController.CheckControlMode(); break; }
				case Keys.Left: { Diagram.DiagramController.Move(-20, 0); break; }
				case Keys.Right: { Diagram.DiagramController.Move(20, 0); break; }
				case Keys.Up: { Diagram.DiagramController.Move(0, -20); break; }
				case Keys.Down: { Diagram.DiagramController.Move(0, 20); break; }
				case Keys.Enter: { Diagram.DiagramController.Edit(); break; }

			}
		}
	}
}
