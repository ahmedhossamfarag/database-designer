using DatabaseDesigner.Models.EER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal partial class EntityEdit
	{
		public void Update(Entity entity)
		{
			//
			//Check Name
			if (string.IsNullOrWhiteSpace(NameBox.Text) ||
				NameBox.Text.Any(c => !(char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '_'))
				)
				throw new InvalidOperationException("Invalid Name	!");
			if (NameBox.Text != entity.Name &&
				entity.ERDiagram.Entities.Any(e => e.Entity.Name == NameBox.Text))
				throw new InvalidOperationException("Invalid Name	!");
			//
			//Update
			entity.Name = NameBox.Text;
			entity.Weak = WeakCheck.Checked;
			//
			//
			Close();
		}

		public void Set(Entity entity)
		{
			NameBox.Text = entity.Name;
			WeakCheck.Checked = entity.Weak;
			Text = "Edit Entity";
		}
	}
}
