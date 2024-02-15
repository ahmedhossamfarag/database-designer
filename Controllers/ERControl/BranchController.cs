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
	internal class BranchController : IItemController
	{
		private readonly Branch Branch;

		private BranchView View => Branch.View;

		public BranchController(Branch branch)
		{
			Branch = branch;
			branch.Subs.ItemAdded += Subs_ItemAdded;
			branch.Subs.ItemRemoved += Subs_ItemRemoved;
		}

		private void Subs_ItemRemoved(Entity obj)
		{
			Branch.ERDiagram.Controller.RemoveLine(Branch.View.Lines[obj]);
			Branch.View.Lines.Remove(obj);
			obj.Parents.Remove(Branch.Super);
		}

		private void Subs_ItemAdded(Entity obj)
		{

			Line l = new LineShape(Branch.View, obj.View);
			l.Pen.Color = Branch.ERDiagram.Preferences.BLineColor;
			Branch.ERDiagram.Controller.AddLine(l);
			Branch.View.Lines.Add(obj, l);
			obj.Parents.Add(Branch.Super);
			obj.View.Removed += p => Branch.Subs.Remove(obj);
		}

		public void AddEntity()
		{
			EntityPicker picker = new EntityPicker() { Text = "Pick Entity", Entities = Branch.ERDiagram.Entities.SkipWhile(e => Branch.Super == e.Entity || Branch.Subs.Any(t => t == e.Entity)) };
			picker.OnOk = () =>
			{
				Branch.Subs.Add(picker.Selected);
			};
			picker.ShowDialog();
		}

		public void Delete()
		{
			Branch.ERDiagram.Controller.RemoveBranch(Branch);
			Branch.Subs.ForEach(s => s.Parents.Remove(Branch.Super));
			Branch.Super.Branches.Remove(Branch);
		}

		public void Edit()
		{
			BranchEdit edit = new BranchEdit() { Text = "Edit Branch", Entities = Branch.ERDiagram.Entities };
			edit.Set(Branch);
			edit.OnOk = () =>
			{
				edit.Update(Branch);
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
