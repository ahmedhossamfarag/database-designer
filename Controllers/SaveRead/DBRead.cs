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
using DatabaseDesigner.Models.Base;
using DatabaseDesigner.Controllers.Base;

namespace DatabaseDesigner.Controllers.SaveRead
{
	internal class DBRead
	{
		
		public static TEScene Read()
		{
			OpenFileDialog dialog = new OpenFileDialog() { Filter = "Text files |*.txt" };
			if (dialog.ShowDialog() == DialogResult.OK)
			{

				StreamReader reader = new StreamReader(File.Open(dialog.FileName, FileMode.Open, FileAccess.Read));
				Database database = new Database();
				Read(reader, database);
				reader.Close();
				return new TEScene(database) { File = dialog.FileName};
			}
			return null;
		}


		public static void Read(StreamReader reader, Database database)
		{
			List<(Property P, string T, string K)> ForgienKeys = new List<(Property P, string T, string K)>();
			int n = int.Parse(reader.ReadLine());
			for (int i = 0; i < n; i++)
				ReadTable(reader, database, ForgienKeys);
			SetForgienKeys(database, ForgienKeys);
		}

		private static void ReadTable(StreamReader reader, Database database, List<(Property P, string T, string K)> forgienKeys)
		{
			string[] s = reader.ReadLine().Split(',');
			Table t = new Table()
			{
				Name = s[0],
				Weak = bool.Parse(s[1])
			};
			int n = int.Parse(s[2]);
			for (int i = 0; i < n; i++)
				ReadProperty(reader, t, forgienKeys);
			database.Tables.Add(t);
		}

		private static void ReadProperty(StreamReader reader, Table t, List<(Property P, string T, string K)> forgienKeys)
		{
			string[] s = reader.ReadLine().Split(',');
			Property p = new Property()
			{
				Table = t,
				Name = s[0],
				Key = bool.Parse(s[1]),
				Nullable = bool.Parse(s[2]),
				Unique = bool.Parse(s[3]),
				Default = s[4],
				DataType = (DataType)int.Parse(s[5]),
				Length = int.Parse(s[6]),
			};
			if (s[7].Any())
                forgienKeys.Add((p, s[7], s[8]));
            t.Attributes.Add(p);
			if (p.Key)
				t.Keys.Add(p);
		}
	
		private static void SetForgienKeys(Database database, List<(Property P, string T, string K)> ForgienKeys)
		{
			foreach((Property P, string T, string K) in ForgienKeys)
			{
				if (T != "")
				{
					Table t = database.FindTable(T);
					P.ForgienKey = t.Attributes.Find(a => a.Name == K);
					P.ForgienKey.LinkedTypes.Add(P);
					if (P.Name == $"{t.Name}_{P.ForgienKey.Name}")
					{
						PropertyNameObserver nameObserver = new PropertyNameObserver()
						{ ObserveProperty = P.ForgienKey, ChangeProperty = P, Pre = $"{t.Name}_" };
						P.ForgienKey.NameChanged += nameObserver.ChangeName;
						P.NameChanged += nameObserver.RemoveObserver;
					}else if (P.Name == $"{t.Name}2_{P.ForgienKey.Name}")
					{
						PropertyNameObserver nameObserver = new PropertyNameObserver()
						{ ObserveProperty = P.ForgienKey, ChangeProperty = P, Pre = $"{t.Name}2_" };
                        P.ForgienKey.NameChanged += nameObserver.ChangeName;
                        P.NameChanged += nameObserver.RemoveObserver;
                    }
				}
			}
		}
	}
}
