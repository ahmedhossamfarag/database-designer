using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers.FDControl
{
	internal class FDSceneController : SceneController
	{

		public FDSceneController(FDScene scene)
		{
			Diagram = scene.FlowDiagramView;
			scene.FlowDiagramView.Controller = new FDVController(scene);
		}

	}
}
