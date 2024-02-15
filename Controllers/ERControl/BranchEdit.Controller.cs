using DatabaseDesigner.Models.EER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal partial class BranchEdit
	{
		public List<EntityView> Entities
		{
			set
			{
				SubBox.Items.AddRange(value.ToArray());
			}
		}

		public void AddButton_Click(object sender, EventArgs e)
		{
			if (SubBox.SelectedIndex < 0) return;
			EntityView entity = (EntityView)SubBox.SelectedItem;
			if (EnPanel.Controls.Cast<SubEView>().Any(t => t.Entity == entity.Entity)) return;
			AddSub(entity.Entity);
		}

		private void AddSub(Entity e)
		{
			SubEView v = new SubEView(e);
			v.Delete.Click += (s, ev) => Remove(v);
			EnPanel.Controls.Add(v);
			SubBox.Items.Remove(e.View);
		}

		private void Remove(SubEView en)
		{
			EnPanel.Controls.Remove(en);
			SubBox.Items.Add(en.Entity.View);
		}

		public void Set(Branch b)
		{
			b.Subs.ForEach(AddSub);
			SubBox.Items.Remove(b.Super.View);
			OverlapCheck.Checked = b.Overlap;
			MustCheck.Checked = b.Must;
		}

		public void Update(Branch b)
		{//
			//Update
			b.Overlap = OverlapCheck.Checked;
			b.Must = MustCheck.Checked;
			IEnumerable<SubEView> sups = EnPanel.Controls.Cast<SubEView>();
			foreach (Entity e in new List<Entity>(b.Subs))
				if (!sups.Any(s => s.Entity == e))
				{
					b.Subs.Remove(e);
				}
			foreach (SubEView s in sups)
				if (!b.Subs.Any(e => s.Entity == e))
				{
					b.Subs.Add(s.Entity);
				}

			//
			//
			Close();
		}
	}
}
