using DatabaseDesigner.Controllers.FDControl;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models.Preference;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers.SaveRead
{
	internal static class FDRead
	{

		public static FDScene Read()
		{
			OpenFileDialog dialog = new OpenFileDialog() { Filter = "Text files |*.txt" };
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				FDScene sc = new FDScene();
				StreamReader reader = new StreamReader(File.Open(dialog.FileName, FileMode.Open, FileAccess.Read));
				Read(reader, sc.FlowDiagramView);
				reader.Close();
				sc.File = dialog.FileName;
				return sc;
			}
			return null;
		}

		public static void Read(StreamReader reader, FlowDiagramView diagram)
		{
			ReadPreferences(reader, diagram);
			string nTasks = reader.ReadLine();
			int n = int.Parse(nTasks);
			for (int i = 0; i < n; i++)
				ReadTask(reader, diagram);

			string nIO = reader.ReadLine();
			n = int.Parse(nIO);
			for (int i = 0; i < n; i++)
				ReadIOScreen(reader, diagram);

		}

		public static void ReadPreferences(StreamReader reader, FlowDiagramView v)
		{
			
			string[] s1 = reader.ReadLine().Split(',');
			string[] s2 = reader.ReadLine().Split(',');
			string[] s3 = reader.ReadLine().Split(',');
			string[] s4 = reader.ReadLine().Split(',');

			FDPreferences p = new FDPreferences()
			{
				DiagramSize = new Size(int.Parse(s1[0]), int.Parse(s1[1])),
				Fill = bool.Parse(s1[2]),
				Scale = int.Parse(s1[3]),
				DBSize = new Size(int.Parse(s2[0]), int.Parse(s2[1])),
				DBColor = Color.FromArgb(int.Parse(s2[2])),
				DBTextColor = Color.FromArgb(int.Parse(s2[3])),
				TSize = new Size(int.Parse(s3[0]), int.Parse(s3[1])),
				TColor = Color.FromArgb(int.Parse(s3[2])),
				TTextColor = Color.FromArgb(int.Parse(s3[3])),
				TSelectColor = Color.FromArgb(int.Parse(s3[4])),
				TArrowColor = Color.FromArgb(int.Parse(s3[5])),
				IOSize = new Size(int.Parse(s4[0]), int.Parse(s4[1])),
				IOColor = Color.FromArgb(int.Parse(s4[2])),
				IOTextColor = Color.FromArgb(int.Parse(s4[3])),
				IOSelectColor = Color.FromArgb(int.Parse(s4[4])),
				IOArrowColor = Color.FromArgb(int.Parse(s4[5])),

			};
			v.SetPreferences(p);
		}


		public static void ReadTask(StreamReader reader, FlowDiagramView diagram , Task parent = null)
		{
			string[] s = reader.ReadLine().Split(',');
			Task task = new Task(diagram)
			{
				Name = s[0],
				In = bool.Parse(s[1]),
				Out = bool.Parse(s[2]),
				Parent = parent
			};
			task.View.Center = new System.Drawing.Point(int.Parse(s[3]), int.Parse(s[4]));
			diagram.Controller.AddTask(task);
			if (parent == null)
			{
				diagram.Controller.AddArrow(TaskController.CreateArrow(task));
			}
			parent?.SubTasks.Add(task);
			int n = int.Parse(s[5]);
			for(int i = 0; i < n; i++)
			{
				ReadTask(reader, diagram, task);
			}
		}

		
		public static void ReadIOScreen(StreamReader reader, FlowDiagramView diagram)
		{
			string[] s = reader.ReadLine().Split(',');
			IOScreen io = new IOScreen(diagram)
			{
				Name = s[0]
			};
			io.View.Center = new System.Drawing.Point(int.Parse(s[1]), int.Parse(s[2]));
			diagram.Controller.AddIOScreen(io); 
			int n = int.Parse(s[3]);
			int m = 4 + (3 * n);
			for(int i = 4; i < m; i+=3)
			{
				IOTask iOTask = new IOTask()
				{
					Task = diagram.Tasks.Find(t => t.Task.Name == s[i]).Task,
					In = bool.Parse(s[i+1]),
					Out = bool.Parse(s[i+2])
				};
				io.Tasks.Add(iOTask);
			}
		}

	}
}
