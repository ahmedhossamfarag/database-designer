using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene1;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes.Scene3;
using DatabaseDesigner.Views.Scenes.TEScene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = DatabaseDesigner.Models.IFD.Task;
using DatabaseDesigner.Views.Scenes.Scene5;
using DatabaseDesigner.Views.Scenes.Scene6;
using System.IO;
using System.Security.AccessControl;

namespace DatabaseDesigner
{
	internal static class Program
	{
		public static Designer Form { get; set; }
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Designer());
		}
	}
}
