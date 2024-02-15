using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Models.Preference;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes.Scene3;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers.SaveRead
{
	internal static class ERRead
	{
		
		public static ERScene Read()
		{
			OpenFileDialog dialog = new OpenFileDialog() { Filter = "Text files |*.txt" };
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				ERScene sc = new ERScene();
				StreamReader reader = new StreamReader(File.Open(dialog.FileName, FileMode.Open, FileAccess.Read));
				Read(reader, sc.ERDiagramView1);
				reader.Dispose();
				reader.Close();
				sc.File = dialog.FileName;
				return sc;
			}
			return null;
		}

		public static void Read(StreamReader reader, ERDiagramView view)
		{
			ReadPreferences(reader, view);
			
			int n = int.Parse(reader.ReadLine());
			for (int i = 0; i < n; i++)
				ReadEntity(reader, view);
			n = int.Parse(reader.ReadLine());
			for (int i = 0; i < n; i++)
				ReadRelation(reader, view);
			n = int.Parse(reader.ReadLine());
			for (int i = 0; i < n; i++)
				ReadBranch(reader, view);
			n = int.Parse(reader.ReadLine());
			for (int i = 0; i < n; i++)
				ReadUnion(reader, view);

		}

		public static void ReadPreferences(StreamReader reader, ERDiagramView view)
		{
			string[] s1 = reader.ReadLine().Split(',');
			string[] s2 = reader.ReadLine().Split(',');
			string[] s3 = reader.ReadLine().Split(',');
			string[] s4 = reader.ReadLine().Split(',');
			string[] s5 = reader.ReadLine().Split(',');
			string[] s6 = reader.ReadLine().Split(',');

			ERPreferences p = new ERPreferences()
			{
				DiagramSize = new Size(int.Parse(s1[0]), int.Parse(s1[1])),
				Fill = bool.Parse(s1[2]),
				Scale = int.Parse(s1[3]),
				ESize = new Size(int.Parse(s2[0]), int.Parse(s2[1])),
				EColor = Color.FromArgb(int.Parse(s2[2])),
				ETextColor = Color.FromArgb(int.Parse(s2[3])),
				ESelectColor = Color.FromArgb(int.Parse(s2[4])),
				ELineColor = Color.FromArgb(int.Parse(s2[5])),
				ASize = new Size(int.Parse(s3[0]), int.Parse(s3[1])),
				AColor = Color.FromArgb(int.Parse(s3[2])),
				ATextColor = Color.FromArgb(int.Parse(s3[3])),
				ASelectColor = Color.FromArgb(int.Parse(s3[4])),
				ALineColor = Color.FromArgb(int.Parse(s3[5])),
				RSize = new Size(int.Parse(s4[0]), int.Parse(s4[1])),
				RColor = Color.FromArgb(int.Parse(s4[2])),
				RTextColor = Color.FromArgb(int.Parse(s4[3])),
				RSelectColor = Color.FromArgb(int.Parse(s4[4])),
				RLineColor = Color.FromArgb(int.Parse(s4[5])),
				BSize = new Size(int.Parse(s5[0]), int.Parse(s5[1])),
				BColor = Color.FromArgb(int.Parse(s5[2])),
				BTextColor = Color.FromArgb(int.Parse(s5[3])),
				BSelectColor = Color.FromArgb(int.Parse(s5[4])),
				BLineColor = Color.FromArgb(int.Parse(s5[5])),
				USize = new Size(int.Parse(s6[0]), int.Parse(s6[1])),
				UColor = Color.FromArgb(int.Parse(s6[2])),
				UTextColor = Color.FromArgb(int.Parse(s6[3])),
				USelectColor = Color.FromArgb(int.Parse(s6[4])),
				ULineColor = Color.FromArgb(int.Parse(s6[5])),

			};
			view.SetPreferences(p);
		}
		public static void ReadEntity(StreamReader reader, ERDiagramView view)
		{
			string[] s = reader.ReadLine().Split(',');
			Entity e = new Entity(view)
			{
				Name = s[0],
				Weak = bool.Parse(s[1])
			};
			e.View.Center = new Point(int.Parse(s[2]), int.Parse(s[3]));
			view.Controller.AddEntity(e);
			int nAtt = int.Parse(s[4]);
			for (int i = 0; i < nAtt; i++)
				ReadArribute(reader, e, view);
		}
		public static void ReadArribute(StreamReader reader, HasAttributes sup, ERDiagramView view)
		{
			string[] s = reader.ReadLine().Split(',');
			Attribute a = new Attribute(view)
			{
				Name = s[0],
				Super = sup,
				Key = bool.Parse(s[1]),
				Multiple = bool.Parse(s[2]),
				Drived = bool.Parse(s[3]),
			};
			a.View.Center = new Point(int.Parse(s[4]), int.Parse(s[5]));
			view.Controller.AddAttribute(a);
			int nAtt = int.Parse(s[6]);
			for (int i = 0; i < nAtt; i++)
				ReadArribute(reader, a, view);
			sup.Attributes.Add(a);
		}
		public static void ReadRelation(StreamReader reader, ERDiagramView view)
		{
			string[] s = reader.ReadLine().Split(',');
			Relation r = new Relation(view)
			{
				Name = s[0],
				Weak = bool.Parse(s[1]),
			};
			r.View.Center = new Point(int.Parse(s[2]), int.Parse(s[3]));
			view.Controller.AddRelation(r);
			int n = int.Parse(s[5]);
			int m = 6 + (2 * n);
			for (int i = 6; i < m; i+=2)
			{
				r.Entities.Add(new RelationEntity(view.Entities.Find(e => e.Entity.Name == s[i]).Entity, bool.Parse(s[i+1])));
			}
			int nAtt = int.Parse(s[4]);
			for (int i = 0; i < nAtt; i++)
				ReadArribute(reader, r, view);
		}
		public static void ReadBranch(StreamReader reader, ERDiagramView view)
		{
			string[] s = reader.ReadLine().Split(',');
			Branch b = new Branch(view)
			{
				Super = view.Entities.Find(e => e.Entity.Name == s[0]).Entity,
				Overlap = bool.Parse(s[1]),
				Must = bool.Parse(s[2])
			};
			b.View.Center = new Point(int.Parse(s[3]), int.Parse(s[4]));
			view.Controller.AddBranch(b);
			view.Controller.AddLine(b.Super.Controller.CreateBranchLine(b));
			int n = int.Parse(s[5]);
			int m = 6 + n;
			for (int i = 6; i < m; i ++)
			{
				b.Subs.Add(view.Entities.Find(e => e.Entity.Name == s[i]).Entity);
			}
		}
		public static void ReadUnion(StreamReader reader, ERDiagramView view)
		{
			string[] s = reader.ReadLine().Split(',');
			Union u = new Union(view)
			{
				Sub = view.Entities.Find(e => e.Entity.Name == s[0]).Entity
			};
			u.View.Center = new Point(int.Parse(s[1]), int.Parse(s[2]));
			view.Controller.AddUnion(u);
			view.Controller.AddLine(u.Sub.Controller.CreateUnionLine(u));
			int n = int.Parse(s[3]);
			int m = 4 + n;
			for (int i = 4; i < m; i++)
			{
				u.Supers.Add(view.Entities.Find(e => e.Entity.Name == s[i]).Entity);
			}
		}



	}
}
