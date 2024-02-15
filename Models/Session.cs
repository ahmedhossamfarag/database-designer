using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models.SQL;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene1;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes.Scene3;
using DatabaseDesigner.Views.Scenes.TEScene;
using DatabaseDesigner.Views.Scenes.Scene5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models
{
	internal class Session
	{

		public static List<Scene> Scenes = new List<Scene>();

		public static List<Models.Database.Database> Databases = new List<Models.Database.Database>();


	}
}
