using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Models.IFD;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene2;
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
	internal class EntityController : IItemController
	{
		private readonly Entity Entity;
		private EntityView View => Entity.View;
		public EntityController(Entity entity)
		{
			Entity = entity;
			entity.Attributes.ItemAdded += Attributes_ItemAdded;
		}

		private void Attributes_ItemAdded(Attribute obj)
		{
			Line l = new LineShape(Entity.View, obj.View);
			l.Pen.Color = Entity.ERDiagram.Preferences.ELineColor;
			Entity.ERDiagram.Controller.AddLine(l);
		}

		internal static void New(ERController eRController, Point point)
		{
			Entity e = new Entity(eRController.View);
			EntityEdit edit = new EntityEdit() { Text = "New Entity"};
			edit.OnOk = () =>
			{
				edit.Update(e);
				e.View.Center = point;
				eRController.AddEntity(e);
			};

			edit.ShowDialog();
		}

		public void AddAttribute()
		{
			AttributeEdit edit = new AttributeEdit() { Text = "New Attribute" };
			Attribute a = new Attribute(Entity.ERDiagram) { Super = Entity };
			edit.OnOk = () =>{
				edit.Update(a);
				Entity.ERDiagram.Controller.OnClick = (p) =>
				{
					a.View.Center = p;
					Entity.ERDiagram.Controller.AddAttribute(a);
					Entity.Attributes.Add(a);
					Entity.ERDiagram.Controller.OnClick = null;
				};
			};
			edit.ShowDialog();
		}


		public void AddBranch()
		{
			BranchEdit edit = new BranchEdit() { Text = "New Branch", Entities = Entity.ERDiagram.Entities };
			Branch a = new Branch(Entity.ERDiagram) { Super = Entity };
			edit.Set(a);
			edit.OnOk = () => {
				Entity.ERDiagram.Controller.OnClick = (p) =>
				{
					a.View.Center = p;
					Entity.ERDiagram.Controller.AddBranch(a);
					Entity.Branches.Add(a);
					Entity.ERDiagram.Controller.AddLine(CreateBranchLine(a));
					Entity.ERDiagram.Controller.OnClick = null;
					edit.Update(a);
				};
			};
			edit.ShowDialog();
		}

		public Line CreateBranchLine(Branch b)
		{
			LineShape l = new LineShape(Entity.View, b.View);
			l.Pen.Color = Entity.ERDiagram.Preferences.BLineColor;
			l.Pen.Width = Entity.View.Pen.Width + (b.Must ? 2 : 0);
			b.MustChanged = m =>
			{
				l.Pen.Width = Entity.View.Pen.Width + (m ? 2 : 0);
				l.Redraw();
			};
			return l;
		}



		public void AddUnion()
		{
			UnionEdit edit = new UnionEdit() { Text = "New Union", Entities = Entity.ERDiagram.Entities };
			Union a = new Union(Entity.ERDiagram) { Sub = Entity };
			edit.Set(a);
			edit.OnOk = () => {
				Entity.ERDiagram.Controller.OnClick = (p) =>
				{
					a.View.Center = p;
					Entity.ERDiagram.Controller.AddUnion(a);
					Entity.HasUnion = true;
					Entity.ERDiagram.Controller.AddLine(CreateUnionLine(a));
					Entity.ERDiagram.Controller.OnClick = null;
					edit.Update(a);
				};
			};
			edit.ShowDialog();
		}


		public Line CreateUnionLine(Union u)
		{
			Line l = new LineShape(Entity.View, u.View);
			l.Pen.Color = u.ERDiagram.Preferences.ULineColor;
			l.Width += 2;
			return l;
		}

		public void Delete()
		{
			
			new List<Attribute>(Entity.Attributes).ForEach(a => a.Controller.Delete());
			new List<BranchView>(Entity.ERDiagram.Branches).ForEach(b =>
			{
				if (b.Branch.Super == Entity)
					b.Branch.Controller.Delete();
			});
			new List<UnionView>(Entity.ERDiagram.Unions).ForEach(u =>
			{
				if (u.Union.Sub == Entity)
					u.Union.Controller.Delete();
			});
			new List<RelationView>(Entity.ERDiagram.Relations).ForEach(r =>
			{
				if (r.Relation.Entities.Any(e => e.Entity == Entity))
					r.Relation.Controller.Delete();
			});
			Entity.ERDiagram.Controller.RemoveEntity(Entity);
		}

		public void Edit()
		{
			EntityEdit edit = new EntityEdit() { Text = "Edit Entity"};
			edit.Set(Entity);
			edit.OnOk = () =>
			{
				edit.Update(Entity);
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
