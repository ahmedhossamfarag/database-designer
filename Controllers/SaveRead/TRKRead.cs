using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.TRK;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes.Scene6;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers.SaveRead
{
	internal class TRKRead
	{

		public static TRKScene Read()
		{
			OpenFileDialog dialog = new OpenFileDialog() { Filter = "Text files |*.txt" };
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				TRKScene sc = new TRKScene();
				StreamReader reader = new StreamReader(File.Open(dialog.FileName, FileMode.Open, FileAccess.Read));
				Read(reader, sc);
				reader.Close();
				sc.File = dialog.FileName;
				return sc;
			}
			return null;
		}


		public static TRKScene Read(StreamReader reader, TRKScene sc)
		{
			string[] s = reader.ReadLine().Split(',');
			sc.TPanel.Size = new Size(int.Parse(s[0]), int.Parse(s[1]));
			
			int n = int.Parse(reader.ReadLine());
			for(int i = 0; i < n; i++)
			{
				ReadTable(reader, sc);
			}
			
			n = int.Parse(reader.ReadLine());
			for(int i = 0; i < n; i++)
			{
				ReadRelation(reader, sc);
			}
			
			n = int.Parse(reader.ReadLine());
			for(int i = 0; i < n; i++)
			{
				ReadForgeinKey(reader, sc);
			}

			return sc;
		}

		public static void ReadTable(StreamReader reader, TRKScene scene)
		{
			string[] s = reader.ReadLine().Split(',');
			TableState st = new TableState() { 
				Name = s[0],
				TBackColor = Color.FromArgb(int.Parse(s[3])),
				TForColor = Color.FromArgb(int.Parse(s[4])),
				PBackColor = Color.FromArgb(int.Parse(s[5])),
				PForColor = Color.FromArgb(int.Parse(s[6]))
			};
			TableView t = new TableView()
			{
				Scene = scene,
				Location = new Point(int.Parse(s[1]), int.Parse(s[2]))
			};
			t.Set(st);
			t.Add();
			int n = int.Parse(s[7]);
			for(int i = 0; i < n; i++)
			{
				ReadProperty(reader, scene, t);
			}
		}

		private static void ReadProperty(StreamReader reader, TRKScene scene, TableView t)
		{
			string[] s = reader.ReadLine().Split(',');
			PropertyState p = new PropertyState()
			{
				Name = s[0],
				DataType = (DataType)int.Parse(s[1]),
				Length = int.Parse(s[2]),
				Key = bool.Parse(s[3]),
				Unique = bool.Parse(s[4]),
				Nullable = bool.Parse(s[5]),
				Default = s[6]
			};
			PropertyView v = new PropertyView() { Scene = scene, TableView = t };
			v.Set(p);
			v.Add();
		}

		public static void ReadRelation(StreamReader reader, TRKScene scene)
		{
			string[] s = reader.ReadLine().Split(',');
			TableView t1 = scene.TableViews.Find(t => t.TName.Text == s[0]);
			TableView t2 = scene.TableViews.Find(t => t.TName.Text == s[1]);
			RelationView r = new RelationView(t1, t2) { Scene = scene };
			r.Set((Color.FromArgb(int.Parse(s[3])), (ManyMode)int.Parse(s[2])));
			r.Add();
		}

		public static void ReadForgeinKey(StreamReader reader, TRKScene scene)
		{
			string[] s = reader.ReadLine().Split(',');
			TableView t1 = scene.TableViews.Find(t => t.TName.Text == s[0]);
			PropertyView p1 = t1.Properties.First(p => p.Property.Name == s[1]);
			TableView t2 = scene.TableViews.Find(t => t.TName.Text == s[2]);
			PropertyView p2 = t2.Properties.First(p => p.Property.Name == s[3]);
			ForgeinKeyView v = new ForgeinKeyView(p1, p2) { Scene = scene };
			v.Set(Color.FromArgb(int.Parse(s[4])));
			v.Add();
		}

	}
}
