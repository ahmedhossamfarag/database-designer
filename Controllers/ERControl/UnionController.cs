using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene3;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers.ERControl
{
	internal class UnionController : IItemController
	{
		private readonly Union Union;
		private UnionView View => Union.View;
		public UnionController(Union union)
		{
			Union = union;
			union.Supers.ItemAdded += Supers_ItemAdded;
			union.Supers.ItemRemoved += Supers_ItemRemoved;
		}

		private void Supers_ItemRemoved(Entity obj)
		{
			Union.ERDiagram.Controller.RemoveLine(Union.View.Lines[obj]);
			Union.View.Lines.Remove(obj);
			Union.Sub.Parents.Remove(obj);
		}

		private void Supers_ItemAdded(Entity obj)
		{
			Line l = new LineShape(Union.View, obj.View);
			l.Pen.Color = Union.ERDiagram.Preferences.ULineColor;
			Union.ERDiagram.Controller.AddLine(l);
			Union.View.Lines.Add(obj, l);
			Union.Sub.Parents.Add(obj);
			obj.View.Removed += p => Union.Supers.Remove(obj);
		}

		public void AddEntity()
		{
			EntityPicker picker = new EntityPicker() { Text = "Pick Entity", Entities = Union.ERDiagram.Entities.SkipWhile(e => Union.Sub == e.Entity || Union.Supers.Any(t => t == e.Entity)) };
			picker.OnOk = () =>
			{
				Union.Supers.Add(picker.Selected);
			};
			picker.ShowDialog();
		}

		public void Delete()
		{
			Union.ERDiagram.Controller.RemoveUnion(Union);
			Union.Sub.HasUnion = false;
		}

		public void Edit()
		{
			UnionEdit edit = new UnionEdit() { Text = "Edit Union", Entities = Union.ERDiagram.Entities };
			edit.Set(Union);
			edit.OnOk = () =>
			{
				edit.Update(Union);
			};
			edit.ShowDialog();
		}

		public void Move(int x, int y)
		{
			View.Location = new Point(View.Location.X + x, View.Location.Y + y);
		}

		public void SetSelect(bool flg) => View.Selected = flg;

		
	}
}
