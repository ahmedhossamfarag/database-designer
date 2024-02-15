using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseDesigner.Views.Scenes.TEScene;
using System.Windows.Forms;
using System.IO;
using DatabaseDesigner.Views.Source;
using System.Drawing;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class TRKScene
	{
		public readonly List<TableView> TableViews = new List<TableView>();
		public readonly List<RelationView> RViews = new List<RelationView>();
		public readonly List<ForgeinKeyView> FKViews = new List<ForgeinKeyView>();
		private SceneMode mode = SceneMode.None;
		public ActionsRecord Record = new ActionsRecord();

		private TableView tableView;
		private PropertyView propertyView;

		private void ClearMode()
		{
			if (tableView != null)
			{
				tableView.BorderStyle = BorderStyle.None;
				tableView = null;
			}
			if (propertyView != null)
			{
				propertyView.BorderStyle = BorderStyle.None;
				propertyView = null;
			}

		}
		private void AddTable_Click(object sender, EventArgs e)
		{
			ClearMode();
			mode = SceneMode.AddTable;
			TableEdit edit = new TableEdit() { Scene = this, Text = "New Table" };
			if(edit.ShowDialog() == DialogResult.OK)
			{
				edit.CreateView();
			}
			mode = SceneMode.None;
		}

		private void AddRelation_Click(object sender, EventArgs e)
		{
			ClearMode();
			mode = SceneMode.AddRelation;
		}

		public void TableClick(TableView view)
		{
			if (mode == SceneMode.AddRelation)
			{
				if (tableView == null)
				{
					tableView =view;
					view.BorderStyle = BorderStyle.FixedSingle;
				}
				else if (tableView != view && !tableView.Relations.ContainsKey(view))
				{
					CreateRelation(tableView, view);
					tableView.BorderStyle = BorderStyle.None;
					tableView = null;
					mode = SceneMode.None;
				}

			}
		}

		private void CreateRelation(TableView tableView, TableView view)
		{
			RelationView relationView = new RelationView(tableView, view) { Scene = this};
			RelationEdit edit = new RelationEdit();
			if (edit.ShowDialog() == DialogResult.OK)
			{
				relationView.Set(edit.GetState());
				relationView.Add();
				Record.Add((relationView.Remove, relationView.Add));
			}
		}

		private void AddFKey_Click(object sender, EventArgs e)
		{
			ClearMode();
			mode = SceneMode.AddForgeinKey;
		}


		public void PropertyClick(PropertyView view)
		{
			if (mode == SceneMode.AddForgeinKey)
			{
				if (propertyView == null)
				{
					propertyView = view;
					view.BorderStyle = BorderStyle.FixedSingle;
				}
				//else if (propertyView.TableView == view.TableView)
				//{
				//	propertyView.BorderStyle = BorderStyle.None;
				//	propertyView = view;
				//	view.BorderStyle = BorderStyle.FixedSingle;
				//}
				else if(view.Property.Key)
				{
					CreateFKey(propertyView, view);
					propertyView.BorderStyle = BorderStyle.None;
					propertyView = null;
					mode = SceneMode.None;
				}

			}
		}

		private void CreateFKey(PropertyView propertyView, PropertyView view)
		{
			ForgeinKeyView fkview = new ForgeinKeyView(propertyView, view) { Scene = this};
			ForgeinKeyEdit edit = new ForgeinKeyEdit();
			if (edit.ShowDialog() == DialogResult.OK)
			{
				fkview.Set(edit.GetState());
				fkview.Add();
				Record.Add((fkview.Remove, fkview.Add));
			}
		}


		public void ReadDatabase(Database database)
		{

			int x, y, padding;
			x = y = padding = 200;

			Dictionary<Table, TableView> tableDir = new Dictionary<Table, TableView>();
			Dictionary<Property, PropertyView> propDic = new Dictionary<Property, PropertyView>();
			
			Random random = new Random();
			
			foreach (Table table in database.Tables)
			{
				TableView tableView = new TableView() { Scene = this};
				tableView.Location = new System.Drawing.Point(x, y);
				x += tableView.Width + padding;
				if(x > TPanel.Width)
				{
					x = padding;
					y += tableView.Height + padding;
				}
				tableView.ReadTable(table);
				tableDir.Add(table, tableView);
				tableView.Add();
				foreach (Property p in table.Attributes)
				{
					PropertyView v = new PropertyView() { Scene = this, TableView = tableView, };
					v.ReadProperty(p);
					v.Add();
					propDic.Add(p, v);
				}
			}
			foreach(Table table in database.Tables)
			{
				foreach(TableRalation r in table.TableRalations)
				{
					RelationView relationView = new RelationView(
						tableDir[table],
						tableDir[r.Table]
						)
					{ 
						Scene = this,
					};
					relationView.Set(
						(
						Color.FromArgb(255,random.Next(255), random.Next(255), random.Next(255)),
						(ManyMode)(int)r.RelationType
						)
					);
					relationView.Add();
				}
				foreach(Property p in table.Attributes)
				{
					if(p.ForgienKey != null)
					{
						ForgeinKeyView forgeinKeyView = new ForgeinKeyView(
							propDic[p],
							propDic[p.ForgienKey]
							)
						{
							Scene = this,
						};
						forgeinKeyView.Set(Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255)));
						forgeinKeyView.Add();
					}
				}
			}
           
        }

     }
}
