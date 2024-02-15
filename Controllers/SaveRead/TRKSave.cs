using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models.TRK;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene6;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers.SaveRead
{
	internal class TRKSave
	{
		public static void Save(TRKScene scene)
		{
			if (scene.File == null)
			{
				SaveFileDialog dialog = new SaveFileDialog()
				{
					FileName = "TRFK Diagram.txt",
					DefaultExt = "txt",
					AddExtension = true
				};
				if (dialog.ShowDialog() == DialogResult.OK)
					scene.File = dialog.FileName;
				else
					return;
			}
			StreamWriter writer = new StreamWriter(File.Open(scene.File, FileMode.OpenOrCreate, FileAccess.Write));
			Write(scene, writer);
			writer.Close();

		}


		public static void Write(TRKScene s, StreamWriter writer)
		{
			writer.Write($"{s.TPanel.Width},{s.TPanel.Height}");
			writer.WriteLine();
			
			
			writer.Write(s.TableViews.Count);
			writer.WriteLine();
			foreach(TableView t in s.TableViews)
			{
				WriteTable(t, writer);
				writer.WriteLine();
			}
			
			writer.Write(s.RViews.Count);
			writer.WriteLine();
			foreach(RelationView r in s.RViews)
			{
				WriteRelation(r, writer);
				writer.WriteLine();
			}
			
			writer.Write(s.FKViews.Count);
			writer.WriteLine();
			foreach(ForgeinKeyView k in s.FKViews)
			{
				WriteForgeinKey(k, writer);
				writer.WriteLine();
			}
		}

		public static void WriteTable(TableView t, StreamWriter writer)
		{
			TableState s = t.CreateState();
			IEnumerable<PropertyView> ps = t.Properties;
			writer.Write($"{s.Name},{t.Location.X},{t.Location.Y},{s.TBackColor.ToArgb()},{s.TForColor.ToArgb()},{s.PBackColor.ToArgb()},{s.PForColor.ToArgb()},{ps.Count()}");
			foreach(PropertyView p in ps)
			{
				writer.WriteLine();
				WriteProperty(p, writer);
			}
		}

		private static void WriteProperty(PropertyView p, StreamWriter writer)
		{
			PropertyState s = p.Property;
			writer.Write($"{s.Name},{(int)s.DataType},{s.Length},{s.Key},{s.Unique},{s.Nullable},{s.Default}");
		}

		public static void WriteRelation(RelationView r, StreamWriter writer)
		{
			writer.Write($"{r.table1.TName.Text},{r.table2.TName.Text},{(int)r.Many},{r.Pen.Color.ToArgb()}");
		}

		public static void WriteForgeinKey(ForgeinKeyView k, StreamWriter writer)
		{
			writer.Write($"{k.property1.TableView.TName.Text},{k.property1.Property.Name},{k.property2.TableView.TName.Text},{k.property2.Property.Name},{k.Pen.Color.ToArgb()}");
		}
	}
}
