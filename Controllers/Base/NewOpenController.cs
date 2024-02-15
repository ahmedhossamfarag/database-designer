using DatabaseDesigner.Controllers.SaveRead;
using DatabaseDesigner.Models;
using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes.Scene3;
using DatabaseDesigner.Views.Scenes.TEScene;
using DatabaseDesigner.Views.Scenes.Scene5;
using DatabaseDesigner.Views.Scenes.Scene6;
using DatabaseDesigner.Views.Scenes.SQLScene;
using DatabaseDesigner.Views.Scenes.TRKScene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers.Base
{
	internal class NewOpenController
	{
		public static Designer designer;

		public static void NewIFD()
		{
			FDPreferencesEdit edit = new FDPreferencesEdit();
			if (edit.ShowDialog() == DialogResult.OK)
			{
				FDScene s = new FDScene();
				s.FlowDiagramView.SetPreferences(edit.Get());
				designer?.AddScene(s);
			}
		}

		public static void OpenIFD()
		{
			FDScene sc = FDRead.Read();
			if(sc != null)
			{
                designer?.AddScene(sc);
            }
		}
		
		public static void NewEER()
		{
			ERPreferencesEdit edit = new ERPreferencesEdit();
			if (edit.ShowDialog() == DialogResult.OK)
			{
				ERScene s = new ERScene();
				s.ERDiagramView1.SetPreferences(edit.Get());
				designer?.AddScene(s);
			}
		}

		public static void OpenEER()
		{
			ERScene sc = ERRead.Read();
            if (sc != null)
            {
                designer?.AddScene(sc);
            }
        }

		public static void NewTRK()
		{
			TRKPreferencesEdit edit = new TRKPreferencesEdit();
			if(edit.ShowDialog() == DialogResult.OK)
			{
				TRKScene sc = new TRKScene();
				sc.TPanel.Size = edit.TRKSize.PrefSize;
				designer?.AddScene(sc);
			}
		}

		public static void OpenTRK()
		{
			TRKScene sc = TRKRead.Read();
            if (sc != null)
            {
                designer?.AddScene(sc);
            }
        }

		public static void OpenDB()
		{
			TEScene db = DBRead.Read();
			if(db != null)
			{
				designer.AddScene(db);
			}
		}

		public static void NewSQL(Database d)
		{
			IEnumerable<FDScene> fDScenes = Session.Scenes.TakeWhile(s => s is FDScene).Cast<FDScene>();
			SQLScene sc = null;
			if (!fDScenes.Any())
				sc = new SQLScene(null, d);
			else
			{
				SQLPreferencesEdit edit = new SQLPreferencesEdit();
				edit.FDSelect.Items.AddRange(fDScenes.ToArray());
				if(edit.ShowDialog() == DialogResult.OK)
				{
					if (edit.FDSelect.SelectedIndex < 0)
						sc = new SQLScene(null, d);
					else
						sc = new SQLScene(((FDScene)edit.FDSelect.SelectedItem).FlowDiagramView.GetFlowDiagram(), d);
				}
			}
			if (sc != null)
				designer.AddScene(sc);
		}
	}
}
