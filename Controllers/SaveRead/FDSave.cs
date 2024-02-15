using DatabaseDesigner.Models;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models.Preference;
using DatabaseDesigner.Models.SQL;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DatabaseDesigner.Controllers.SaveRead
{
	internal static class FDSave
	{

		public static void Save(FDScene scene)
		{
			var flowDiagramView = scene.FlowDiagramView;
			try
			{
				FlowDiagram F = new FlowDiagram()
				{
					Tasks = flowDiagramView.Tasks.ConvertAll(t => t.Task),
					IOScreens = flowDiagramView.IOScreens.ConvertAll(i => i.IOScreen)
				};
				if(scene.File == null)
				{
					SaveFileDialog dialog = new SaveFileDialog()
					{
						FileName = "Information Flow Diagram.txt",
						DefaultExt = "txt",
						AddExtension = true
					};
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						scene.File = dialog.FileName;
					}
					else
						return;
				}
				
				StreamWriter writer = new StreamWriter(File.Open(scene.File,FileMode.OpenOrCreate, FileAccess.Write, FileShare.None));
				WritePreferences(writer, flowDiagramView.Preferences);
				Write(writer, F);
				writer.Close();
			}
			catch (InvalidOperationException e)
			{
				new InfoDialog() { Text = e.Message }.Show();
			}
			
		}

		public static void Write(StreamWriter writer, FlowDiagram diagram)
		{
			IEnumerable<Task> tasks = diagram.Tasks.TakeWhile(t => t.Parent == null);
			writer.Write($"{tasks.Count()}");
			writer.WriteLine();
			foreach(Task task in tasks)
			{
				WriteTask(writer, task);
				writer.WriteLine();
			}

			writer.Write($"{diagram.IOScreens.Count}");
			writer.WriteLine();
			foreach(IOScreen io in diagram.IOScreens)
			{
				WriteIOScreen(writer, io);
				writer.WriteLine();
			}

		}

		public static void WritePreferences(StreamWriter writer, FDPreferences p)
		{
			writer.Write($"{p.DiagramSize.Width},{p.DiagramSize.Height},{p.Fill},{p.Scale}");
			writer.WriteLine();
			writer.Write($"{p.DBSize.Width},{p.DBSize.Height},{p.DBColor.ToArgb()},{p.DBTextColor.ToArgb()}");
			writer.WriteLine();
			writer.Write($"{p.TSize.Width},{p.TSize.Height},{p.TColor.ToArgb()},{p.TTextColor.ToArgb()},{p.TSelectColor.ToArgb()},{p.TArrowColor.ToArgb()}");
			writer.WriteLine();
			writer.Write($"{p.IOSize.Width},{p.IOSize.Height},{p.IOColor.ToArgb()},{p.IOTextColor.ToArgb()},{p.IOSelectColor.ToArgb()},{p.IOArrowColor.ToArgb()}");
			writer.WriteLine();
		}

		public static void WriteTask(StreamWriter writer, Task task)
		{
			writer.Write($"{task.Name},{task.In},{task.Out},{task.View.Center.X},{task.View.Center.Y},{task.SubTasks.Count}");
			foreach(Task t in task.SubTasks)
			{
				writer.WriteLine();
				WriteTask(writer, t);
			}
		}

		public static void WriteIOScreen(StreamWriter writer, IOScreen io)
		{
			writer.Write($"{io.Name},{io.View.Center.X},{io.View.Center.Y},{io.Tasks.Count},{string.Join(",",io.Tasks.ConvertAll(t => t.ToString()).ToArray())}");
		}

	}
}
