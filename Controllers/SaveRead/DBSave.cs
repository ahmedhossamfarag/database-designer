using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseDesigner.Views.Scenes.TEScene;

namespace DatabaseDesigner.Controllers.SaveRead
{
	internal static class DBSave
	{

		public static void Save(TEScene scene)
		{
			if(scene.File == null)
			{
				SaveFileDialog dialog = new SaveFileDialog()
				{
					FileName = "Database Tables.txt",
					DefaultExt = "txt",
					AddExtension = true
				};
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					scene.File = dialog.FileName;
				}
				else
				{
					return;
				}
			}
			StreamWriter writer = new StreamWriter(File.Open(scene.File, FileMode.OpenOrCreate, FileAccess.Write));
			Write(writer, scene.Database);
			writer.Close();

		}

		public static void Write(StreamWriter writer, Database database)
		{
			writer.Write(database.Tables.Count);
			writer.WriteLine();
			foreach(Table t in database.Tables)
			{
				WriteTable(writer, t);
				writer.WriteLine();
			}

		}

		public static void WriteTable(StreamWriter writer, Table t)
		{
			writer.Write($"{t.Name},{t.Weak},{t.Attributes.Count}");
			foreach(Property p in t.Attributes)
			{
				writer.WriteLine();
				WriteProperty(writer, p);
			}
		}

        public static void WriteProperty(StreamWriter writer, Property p)
		{
			writer.Write($"{p.Name},{p.Key},{p.Nullable},{p.Unique},{p.Default},{(int)p.DataType},{p.Length},{(p.ForgienKey == null ? "," : $"{p.ForgienKey.Table.Name},{p.ForgienKey.Name}")}");
		}

	}
}
