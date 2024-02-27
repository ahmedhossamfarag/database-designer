using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.TRK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class TableEdit : IEdit<TableView, TableState>
	{
		public TRKScene Scene { get; set; }
		public TableView View { get; set; }


		public void CreateView()
		{
			TableView view = new TableView() {Scene = Scene };
			view.Location = new System.Drawing.Point((Scene.TPanel.Width - view.Width) / 2, (Scene.TPanel.Height - view.Height) / 2);
			view.Set(GetState());
			view.Add();
			Scene.Record.Add((view.Remove, view.Add));
		}


		public void Set(TableView view)
		{
			TName.Text = view.TName.Text;
			TBackColor.BackColor = view.TName.BackColor;
			TForColor.BackColor = view.TName.ForeColor;
			PBackColor.BackColor = view.PBox.BackColor;
			PForColor.BackColor = view.PBox.ForeColor;
		}

		public TableState GetState()
		{
			return new TableState()
			{
				Name = TName.Text,
				TBackColor = TBackColor.BackColor,
				TForColor = TForColor.BackColor,
				PBackColor = PBackColor.BackColor,
				PForColor = PForColor.BackColor
			};
		}

		public void Valid()
		{
			//
			//
			//Name
			if (string.IsNullOrWhiteSpace(TName.Text) ||
					TName.Text.Any(c => !(char.IsLetterOrDigit(c) || c == '_')))

				throw new InvalidOperationException("Invalid Name!");
			if (View != null && View.TName.Text != TName.Text && Scene.TableViews.Any(t => t.TName.Text == TName.Text))
				throw new InvalidOperationException("Invalid Name!");

		}
	}
}
