using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Models;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes.Scene3;
using DatabaseDesigner.Views.Scenes.TEScene;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

namespace DatabaseDesigner.Controllers.ERControl
{
	internal partial class ERSceneController : SceneController
	{
		public ERSceneController(ERScene scene)
		{
			Diagram = scene.ERDiagramView1;
			scene.ERDiagramView1.Controller = new ERController(scene);
		}
	}
}
