using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.TRK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class TableView : IStateful<TableState>
	{
		public TRKScene Scene { get; set; }

		public Dictionary<TableView, RelationView> Relations = new Dictionary<TableView, RelationView>();
		public List<ForgeinKeyView> ForgeinKeys = new List<ForgeinKeyView>();

		public IEnumerable<PropertyView> Properties => PBox.Controls.Cast<PropertyView>();

		public List<TableView> LinkedTables;

		private bool InnerJoinTable_;

		public bool InnerJoinTable
		{
			get => InnerJoinTable_;
			set
			{
				InnerJoinTable_ = value;
				TName.Font = new Font(TName.Font, FontStyle.Italic | FontStyle.Bold);
            }
		}
		public void Add()
		{
			Scene.TableViews.Add(this);
			Scene.TPanel.Controls.Add(this);
			BringToFront();
		}

		public void Delete()
		{
			Action un = () => this.Add();
			if (Relations.Any())
			{
				RelationView[] r = Relations.Values.ToArray();
				un += () => { foreach (RelationView v in r) v.Add(); };
			}
			if (ForgeinKeys.Any())
			{
				ForgeinKeyView[] k = ForgeinKeys.ToArray();
				un += () => { foreach (ForgeinKeyView v in k) v.Add(); };
			}
			Action re = () => this.Remove();
			re();
			Scene.Record.Add((un, re));
		}

		public void Remove()
		{
			Relations.Values.ToList().ForEach(r => r.Remove());
			ForgeinKeys.ToList().ForEach(k => k.Remove());
			Scene.TPanel.Controls.Remove(this);
			Scene.TableViews.Remove(this);
		}

		public void Set(TableState state)
		{
			TName.Text = state.Name;
			TName.BackColor = state.TBackColor;
			TName.ForeColor = state.TForColor;
			AddProperty.ForeColor = state.TBackColor;
			Color m = state.TBackColor;
			Mover.BackColor = Color.FromArgb(Math.Max(m.R - 50, 0), Math.Max(m.G - 50, 0), Math.Max(m.B - 50, 0));
			PBox.ForeColor = state.PForColor;
			PBox.BackColor = state.PBackColor;
        }

		public void Update(TableState state)
		{
			TableState s = CreateState();
			if (!s.Equals(state))
			{
				Action un = () => this.Set(s);
				Action re = () => this.Set(state);
				re();
				Scene.Record.Add((un, re));
			}
		}

		public TableState CreateState()
		{
			return new TableState()
			{
				Name = TName.Text,
				TBackColor = TName.BackColor,
				TForColor = TName.ForeColor,
				PBackColor = PBox.BackColor,
				PForColor = PBox.ForeColor
			};
		}

		private void TName_DoubleClick(object sender, EventArgs e)
		{
			TableEdit edit = new TableEdit() { Scene = Scene, View = this,  Text = "Edit Table" };
			edit.Set(this);
			edit.Delete.Visible = true;
			edit.OkButton.Select();
			DialogResult r = edit.ShowDialog();
			if (r == DialogResult.OK)
			{
				this.Update(edit.GetState());
			}
			else if (r == DialogResult.No)
			{
				this.Delete();
			}
		}

		private void AddProperty_Click(object sender, EventArgs e)
		{
			PropertyState p = new PropertyState();
			PropertyView v = new PropertyView() {TableView = this ,Property = p, Scene = Scene, Text = "New Property" };
			PropertyEdit edit = new PropertyEdit() { Property = v };
			if (edit.ShowDialog() == DialogResult.OK)
			{
				if(LinkedTables == null)
				{
                    v.Set(edit.GetState());
                    v.Add();
                    Scene.Record.Add((v.Remove, v.Add));
                }
				else
				{
					AddLinkedProperty(v, edit.GetState());
				}
			}
		}

        private void AddLinkedProperty(PropertyView pv, PropertyState propertyState)
        {
            List<PropertyView> list = new List<PropertyView>
            {
                pv
            };
			pv.LinkedProperties = list;
			foreach(var t in LinkedTables)
			{
                PropertyState p = new PropertyState();
                PropertyView v = new PropertyView() { TableView = t, Property = p, Scene = Scene, Text = "New Property" };
				list.Add(v);
				v.LinkedProperties = list;
            }
            pv.Set(propertyState);
            pv.Add();
            Scene.Record.Add((pv.Remove, pv.Add));
        }

        public void ReadTable(Table table)
		{
			TName.Text = table.Name;
		}

	}
}
