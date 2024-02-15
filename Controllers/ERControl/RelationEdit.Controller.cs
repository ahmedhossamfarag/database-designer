using DatabaseDesigner.Models.EER;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	struct ESeries
	{
		public Entity Entity;
		public CheckBox Many;
		public Panel Panel;
	}
	internal partial class RelationEdit
	{
		public List<RelationView> Relations { get; set; }
		
		public List<ESeries> Entities { get; set; } = new List<ESeries>();

		public List<EntityView> AvailableEntities {
			set
			{
				EBox.Items.AddRange(value.ToArray());
			}
		}

		public void AddEntity(object sender, EventArgs ev)
		{
			if (EBox.SelectedIndex < 0) return;
			EntityView e = (EntityView)EBox.SelectedItem;
			AddEntity(e.Entity, false);
		}


		public void AddEntity(Entity e, bool many)
		{
			
			Panel EPanel;
			CheckBox EMany;
			Label EName;
			Button Delete;
			EPanel = new System.Windows.Forms.Panel();
			EMany = new System.Windows.Forms.CheckBox();
			EName = new System.Windows.Forms.Label();
			Delete = new Button(); 
			var es = new ESeries()
			{
				Entity = e,
				Many = EMany,
				Panel = EPanel
			};
			// 
			// EPanel
			// 
			EPanel.Controls.Add(EMany);
			EPanel.Controls.Add(EName);
			EPanel.Controls.Add(Delete);
			EPanel.Location = new System.Drawing.Point(3, 3);
			EPanel.Name = "EPanel";
			EPanel.Size = new System.Drawing.Size(338, 49);
			EPanel.TabIndex = 7;
			//
			//Delete
			//
			Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			Delete.Location = new System.Drawing.Point(4, 15);
			Delete.Name = "AddButton";
			Delete.Size = new System.Drawing.Size(17, 17);
			Delete.TabIndex = 5;
			Delete.UseVisualStyleBackColor = true;
			Delete.Click += (s, ev) => Remove(es);
			Delete.Paint += Paint_Delete;
			// 
			// EMany
			// 
			EMany.AutoSize = true;
			EMany.Checked = many;
			EMany.Location = new System.Drawing.Point(255, 17);
			EMany.Name = "EMany";
			EMany.Size = new System.Drawing.Size(80, 17);
			EMany.TabIndex = 2;
			EMany.Text = "Many";
			EMany.UseVisualStyleBackColor = true;
			// 
			// EName
			// 
			EName.AutoSize = true;
			EName.Location = new System.Drawing.Point(60, 17);
			EName.Name = "EName";
			EName.Size = new System.Drawing.Size(42, 17);
			EName.TabIndex = 1;
			EName.Text = e.Name;

			EContainer.Controls.Add(EPanel);
			Entities.Add(es);

			if (Entities.Count(en => en.Entity == e) > 1)
			{
				EBox.Items.Remove(e.View);
				EBox.SelectedIndex = -1;
				EBox.Text = "";
			}
		}
		private void Paint_Delete(object sender, PaintEventArgs e)
		{
			Button b = (Button)sender;
			Pen pen = new Pen(Color.Black);
			e.Graphics.DrawLine(pen, 0, 0, b.Width, b.Height);
			e.Graphics.DrawLine(pen, 0, b.Height, b.Width, 0);
		}

		private void Remove(ESeries e)
		{
			Entities.Remove(e);
			EContainer.Controls.Remove(e.Panel);
			if(!EBox.Items.Contains(e.Entity.View))
				EBox.Items.Add(e.Entity.View);
		}
		public void Update(Relation r)
		{
			//
			//Check Name
			if (string.IsNullOrWhiteSpace(NameBox.Text) ||
				NameBox.Text.Any(c => !(char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '_')))
				throw new InvalidOperationException("Invalid Relation Name");

			if (NameBox.Text != r.Name)
			{
				if (Relations.Any(e => e.Name== NameBox.Text &&
				e.Relation.Entities.ConvertAll(re => re.Entity)
				.Intersect(this.Entities.ConvertAll(es => es.Entity))
				.Count() > 1))
					throw new InvalidOperationException("Invalid Relation Name");

			}
			//
			//Update
			r.Name = NameBox.Text;

			new List<RelationEntity>(r.Entities).ForEach(e => r.Entities.Remove(e));

			foreach (ESeries s in Entities)
			{
				r.Entities.Add(new RelationEntity(s.Entity, s.Many.Checked));
			}

			r.Weak = WeakCheck.Checked;//|| r.Entities.Any(e => e.Entity.Weak);
			//
			//
			Close();
		}

		public void Set(Relation r)
		{
			NameBox.Text = r.Name;
			r.Entities.ForEach(e => AddEntity(e.Entity, e.Many));
			WeakCheck.Checked = r.Weak;
		}

		public List<(string name, Entity E1, Entity E2)> RelationExpand(Relation r)
		{
			List<(string name, Entity E1, Entity E2)> values = new List<(string name, Entity T1, Entity T2)>();
			if (r.Entities.Count > 1)
				for (int i = 0; i < r.Entities.Count; i++)
				{
					for (int j = i + 1; j < r.Entities.Count; j++)
					{
						values.Add((r.Name, r.Entities[i].Entity, r.Entities[j].Entity));

					}
				}

			return values;
		}

	}
}
