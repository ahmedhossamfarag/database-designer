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
	internal class AttributeController : IItemController
	{
		private readonly Models.EER.Attribute Attribute;
		private AttributeView View => Attribute.View;

		public AttributeController(Models.EER.Attribute attribute)
		{
			Attribute = attribute;
			attribute.Attributes.ItemAdded += Attributes_ItemAdded;
		}

		private void Attributes_ItemAdded(Attribute obj)
		{
			Line l = new LineShape(Attribute.View, obj.View);
			l.Pen.Color = Attribute.ERDiagram.Preferences.ALineColor;
			Attribute.ERDiagram.Controller.AddLine(l);
		}

		public void AddAttribute()
		{
			AttributeEdit edit = new AttributeEdit() { Text = "New Attribute" };
			Attribute a = new Attribute(Attribute.ERDiagram) { Super = Attribute };
			edit.OnOk = () => {
				edit.Update(a);
				Attribute.ERDiagram.Controller.OnClick = (p) =>
				{
					a.View.Center = p;
					Attribute.ERDiagram.Controller.AddAttribute(a);
					Attribute.Attributes.Add(a);
					Attribute.ERDiagram.Controller.OnClick = null;
				};
			};
			edit.ShowDialog();
		}


		public void Delete()
		{
			Attribute.Super?.Attributes.Remove(Attribute);
			new List<Attribute>(Attribute.Attributes).ForEach(t => t.Controller.Delete());
			Attribute.ERDiagram.Controller.RemoveAttribute(Attribute);
		}

		public void Edit()
		{
			AttributeEdit edit = new AttributeEdit() { Text = "Edit Attribute"};
			edit.Set(Attribute);
			edit.OnOk = () =>
			{
				edit.Update(Attribute);
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
