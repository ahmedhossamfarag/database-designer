using DatabaseDesigner.Models.TRK;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class RelationView : IStateful<(Color, ManyMode)>
	{
		public TRKScene Scene { get; set; }
		public RItemView RItemView;
		public void Add()
		{
			Scene.TPanel.Controls.Add(this);
			table1.Move += Table_Move;
			table2.Move += Table_Move;
			table1.Relations.Add(table2, this);
			if(table1 != table2)
				table2.Relations.Add(table1, this);
			Scene.FKRContainer.Controls.Add(RItemView);
			Scene.RViews.Add(this);
		}

		private void Table_Move(object sender, EventArgs e) => Align();

		public (Color, ManyMode) CreateState() => (Pen.Color, Many);

		public void Delete()
		{
			int n = Scene.FKRContainer.Controls.IndexOf(RItemView);
			Remove();
			Action un = () => { Add(); Scene.FKRContainer.Controls.SetChildIndex(RItemView, n); };
			Scene.Record.Add((un, Remove));
		}

		public void Remove()
		{
			Scene.TPanel.Controls.Remove(this);
			table1.Move -= Table_Move;
			table2.Move -= Table_Move;
			table1.Relations.Remove(table2);
			table2.Relations.Remove(table1);
			Scene.FKRContainer.Controls.Remove(RItemView); ;
			Scene.RViews.Remove(this);
		}

		public void Set((Color, ManyMode) state)
		{
			Pen.Color = state.Item1;
			Many = state.Item2;
			RItemView.IColor.BackColor = state.Item1;
			if(Parent != null)
				Redraw();
		}

		public void Update((Color, ManyMode) state)
		{
			if(state.Item1 != Pen.Color || state.Item2 != Many)
			{
				(Color, ManyMode) s = CreateState();
				Action un = () => Set(s);
				Action re = () => Set(state);
				re();
				Scene.Record.Add((un, re));
			}
		}
	}
}
