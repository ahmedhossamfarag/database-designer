using DatabaseDesigner.Models.EER;
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
using DatabaseDesigner.Models;
using DatabaseDesigner.Views.Scenes.TEScene;
using DatabaseDesigner.Views.Scenes.Scene3;
using Attribute = DatabaseDesigner.Models.EER.Attribute;
using DatabaseDesigner.Models.Preference;
using DatabaseDesigner.Views.Scenes.Scene1;

namespace DatabaseDesigner.Controllers.SaveRead
{
	internal static class ERSave
	{

		public static void Save(ERScene sc)
		{
			var View = sc.ERDiagramView1;
			ERDiagram E = new ERDiagram(View);
			if (sc.File == null)
			{
				SaveFileDialog dialog = new SaveFileDialog()
				{
					FileName = "EER Diagram.txt",
					DefaultExt = "txt",
					AddExtension = true
				};
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					sc.File = dialog.FileName;
				}
				else
				{
					return;
				}
			}
			StreamWriter writer = new StreamWriter(File.Open(sc.File, FileMode.OpenOrCreate, FileAccess.Write));
			WritePreferences(writer, View.Preferences);
			Write(writer, E);
			writer.Dispose();
			writer.Close();
		}

		public static void Write(StreamWriter writer, ERDiagram diagram)
		{
			writer.Write(diagram.Entities.Count);
			writer.WriteLine();
			foreach(Entity e in diagram.Entities)
			{
				WriteEntity(writer, e);
				writer.WriteLine();
			}
			writer.Write(diagram.Relations.Count);
			writer.WriteLine();
			foreach(Relation e in diagram.Relations)
			{
				WriteRelation(writer, e);
				writer.WriteLine();
			}
			writer.Write(diagram.Branches.Count);
			writer.WriteLine();
			foreach(Branch e in diagram.Branches)
			{
				WriteBranch(writer, e);
				writer.WriteLine();
			}
			writer.Write(diagram.Unions.Count);
			writer.WriteLine();
			foreach(Union e in diagram.Unions)
			{
				WriteUnion(writer, e);
				writer.WriteLine();
			}

		}

		public static void WritePreferences(StreamWriter writer, ERPreferences p)
		{
			writer.Write($"{p.DiagramSize.Width},{p.DiagramSize.Height},{p.Fill},{p.Scale}");
			writer.WriteLine();
			writer.Write($"{p.ESize.Width},{p.ESize.Height},{p.EColor.ToArgb()},{p.ETextColor.ToArgb()},{p.ESelectColor.ToArgb()},{p.ELineColor.ToArgb()}");
			writer.WriteLine();
			writer.Write($"{p.ASize.Width},{p.ASize.Height},{p.AColor.ToArgb()},{p.ATextColor.ToArgb()},{p.ASelectColor.ToArgb()},{p.ALineColor.ToArgb()}");
			writer.WriteLine();
			writer.Write($"{p.RSize.Width},{p.RSize.Height},{p.RColor.ToArgb()},{p.RTextColor.ToArgb()},{p.RSelectColor.ToArgb()},{p.RLineColor.ToArgb()}");
			writer.WriteLine();
			writer.Write($"{p.BSize.Width},{p.BSize.Height},{p.BColor.ToArgb()},{p.BTextColor.ToArgb()},{p.BSelectColor.ToArgb()},{p.BLineColor.ToArgb()}");
			writer.WriteLine();
			writer.Write($"{p.USize.Width},{p.USize.Height},{p.UColor.ToArgb()},{p.UTextColor.ToArgb()},{p.USelectColor.ToArgb()},{p.ULineColor.ToArgb()}");
			writer.WriteLine();

		}
		public static void WriteEntity(StreamWriter writer, Entity e)
		{
			writer.Write($"{e.Name},{e.Weak},{e.View.Center.X},{e.View.Center.Y},{e.Attributes.Count}");
			foreach (Attribute a in e.Attributes)
			{
				writer.WriteLine();
				WriteArribute(writer, a);
			}
		}
		public static void WriteArribute(StreamWriter writer, Attribute a)
		{
			writer.Write($"{a.Name},{a.Key},{a.Multiple},{a.Drived},{a.View.Center.X},{a.View.Center.Y},{a.Attributes.Count}");
			foreach (Attribute at in a.Attributes)
			{
				writer.WriteLine();
				WriteArribute(writer, at);
			}
		}
		public static void WriteRelation(StreamWriter writer, Relation r)
		{
			writer.Write($"{r.Name},{r.Weak},{r.View.Center.X},{r.View.Center.Y},{r.Attributes.Count},{r.Entities.Count},{string.Join(",",r.Entities.ConvertAll(e => e.ToString()))}");
			foreach (Attribute a in r.Attributes)
			{
				writer.WriteLine();
				WriteArribute(writer, a);
			}
		}
		public static void WriteBranch(StreamWriter writer, Branch b)
		{
			writer.Write($"{b.Super},{b.Overlap},{b.Must},{b.View.Center.X},{b.View.Center.Y},{b.Subs.Count},{string.Join(",",b.Subs.ConvertAll(s => s.Name))}");
		}
		public static void WriteUnion(StreamWriter writer, Union u)
		{
			writer.Write($"{u.Sub},{u.View.Center.X},{u.View.Center.Y},{u.Supers.Count},{string.Join(",", u.Supers.ConvertAll(s => s.Name))}");
		}


	}
}
