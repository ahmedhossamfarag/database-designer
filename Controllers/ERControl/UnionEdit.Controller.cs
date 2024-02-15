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
	internal partial class UnionEdit
	{
		public List<EntityView> Entities
		{
			set
			{
				SuperBox.Items.AddRange(value.ToArray());
			}
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			if (SuperBox.SelectedIndex < 0) return;
			EntityView entity = (EntityView)SuperBox.SelectedItem;
			if (EnPanel.Controls.Cast<SubEView>().Any(t => t.Entity == entity.Entity)) return;
			AddSub(entity.Entity);
		}

		private void AddSub(Entity e)
		{
			SubEView v = new SubEView(e);
			v.Delete.Click += (s, ev) => Remove(v);
			EnPanel.Controls.Add(v);
			SuperBox.Items.Remove(e.View);
		}

		private void Remove(SubEView p)
		{
			EnPanel.Controls.Remove(p);
			SuperBox.Items.Add(p.Entity.View);
		}


		public void Set(Union b)
		{
			b.Supers.ForEach(AddSub);
			SuperBox.Items.Remove(b.Sub.View);
		}

		public void Update(Union b)
		{
			IEnumerable<SubEView> sups = EnPanel.Controls.Cast<SubEView>();
			foreach (Entity e in new List<Entity>(b.Supers))
				if (!sups.Any(s => s.Entity == e))
					b.Supers.Remove(e);

			foreach (SubEView s in sups)
				if (!b.Supers.Any(e => s.Entity == e))
					b.Supers.Add(s.Entity);
			
			Close();
		}
	}
}
