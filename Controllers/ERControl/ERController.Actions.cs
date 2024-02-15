using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Views.Source;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Controllers.ERControl
{
	internal partial class ERController
	{
		public void NewEntity(Point point)
		{
			EntityController.New(this, point);
		}

		public void NewRelation(Point point)
		{
			RelationController.New(this, point);
		}

		public void AddEntity(Entity entity)
		{
			View.Entities.Add(entity.View);
			View.Controls.Add(entity.View);
			entity.View.BringToFront();
		}
		public void AddAttribute(Attribute attribute)
		{
			View.Attributes.Add(attribute.View);
			View.Controls.Add(attribute.View);
			attribute.View.BringToFront();
		}
		public void AddRelation(Relation relation)
		{
			View.Relations.Add(relation.View);
			View.Controls.Add(relation.View);
			relation.View.BringToFront();
		}
		public void AddBranch(Branch branch)
		{
			View.Branches.Add(branch.View);
			View.Controls.Add(branch.View);
			branch.View.BringToFront();
		}
		public void AddUnion(Union union)
		{
			View.Unions.Add(union.View);
			View.Controls.Add(union.View);
			union.View.BringToFront();
		}

		public void RemoveEntity(Entity entity)
		{
			View.Entities.Remove(entity.View);
			View.Controls.Remove(entity.View);
			SelectedShapes.Remove(entity.Controller);
		}
		public void RemoveAttribute(Attribute attribute)
		{
			View.Attributes.Remove(attribute.View);
			View.Controls.Remove(attribute.View);
			SelectedShapes.Remove(attribute.Controller);
		}
		public void RemoveRelation(Relation relation)
		{
			View.Relations.Remove(relation.View);
			View.Controls.Remove(relation.View);
			SelectedShapes.Remove(relation.Controller);
		}
		public void RemoveBranch(Branch branch)
		{
			View.Branches.Remove(branch.View);
			View.Controls.Remove(branch.View);
			SelectedShapes.Remove(branch.Controller);
		}
		public void RemoveUnion(Union union)
		{
			View.Unions.Remove(union.View);
			View.Controls.Remove(union.View);
			SelectedShapes.Remove(union.Controller);
		}

		public void AddLine(Line l)
		{
			View.Controls.Add(l);
		}

		public void RemoveLine(Line l)
		{
			View.Controls.Remove(l);
		}

	}
}
