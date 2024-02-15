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
using Attribute = DatabaseDesigner.Models.EER.Attribute;

namespace DatabaseDesigner.Controllers.ERControl
{
	internal class RelationController : IItemController
	{
		private readonly Relation Relation;
		private RelationView View => Relation.View;

		public RelationController(Relation relation)
		{
			Relation = relation;
			relation.Attributes.ItemAdded += Attributes_ItemAdded;
			relation.Entities.ItemAdded += Entities_ItemAdded;
			relation.Entities.ItemRemoved += Entities_ItemRemoved;
		}

		private void Entities_ItemRemoved(RelationEntity obj)
		{
			Relation.ERDiagram.Controller.RemoveLine(Relation.View.Lines[obj]);
			Relation.View.Lines.Remove(obj);
		}

		private void Entities_ItemAdded(RelationEntity obj)
		{
			NLineShape l = new NLineShape(Relation.View, obj.Entity.View,
                Relation.Entities.Count(e => e.Entity == obj.Entity) > 1
                )
			{
				N = obj.Many,
				Pen = Relation.View.DrawPen
			};
			l.Pen.Color = Relation.ERDiagram.Preferences.RLineColor;
			obj.ManyChanged = m => l.N = m;
			Relation.ERDiagram.Controller.AddLine(l);
			Relation.View.Lines.Add(obj, l);
		}

		private void Attributes_ItemAdded(Attribute obj)
		{
			Line l = new LineShape(Relation.View, obj.View);
			l.Pen.Color = Relation.ERDiagram.Preferences.RLineColor;
			Relation.ERDiagram.Controller.AddLine(l);
		}

		internal static void New(ERController eRController, Point point)
		{
			Relation r = new Relation(eRController.View);
			RelationEdit edit = new RelationEdit() { Text = "Edit Relation", Relations = eRController.View.Relations, AvailableEntities = eRController.View.Entities };
			edit.OnOk = () =>
			{
				edit.Update(r);
				r.View.Center = point;
				eRController.AddRelation(r);
			};

			edit.ShowDialog();
		}

		public void AddAttribute()
		{
			AttributeEdit edit = new AttributeEdit() { Text = "New Attribute" };
			Attribute a = new Attribute(Relation.ERDiagram) { Super = Relation };
			edit.OnOk = () => {
				edit.Update(a);
				Relation.ERDiagram.Controller.OnClick = (p) =>
				{
					a.View.Center = p;
					Relation.ERDiagram.Controller.AddAttribute(a);
					Relation.Attributes.Add(a);
					Relation.ERDiagram.Controller.OnClick = null;
				};
			};
			edit.ShowDialog();
		}


		public void Delete()
		{
			new List<Attribute>(Relation.Attributes).ForEach(a => a.Controller.Delete());
			Relation.ERDiagram.Controller.RemoveRelation(Relation);
		}

		public void Edit()
		{
			RelationEdit edit = new RelationEdit() {Text = "Edit Relation",  Relations = Relation.ERDiagram.Relations, AvailableEntities = Relation.ERDiagram.Entities };
			edit.Set(Relation);
			edit.OnOk = () =>
			{
				edit.Update(Relation);
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
