using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.TRK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class PropertyEdit : IEdit<PropertyView, PropertyState>
	{
		private PropertyView view;
		public PropertyView Property
		{
			set
			{
				view = value;
				Set(value);
			}
		}


		public PropertyState GetState()
		{
			return new PropertyState()
			{
				Name = NameBox.Text,
				DataType = (DataType)TypeBox.SelectedItem,
				Length = (int)LengthBox.Value,
				Key = KeyCheck.Checked,
				Unique = UniqueCheck.Checked,
				Nullable = NullCheck.Checked,
				Default = DefaultBox.Text
		};
		}

		public void Set(PropertyView v)
		{
			PropertyState property = v.Property;
			NameBox.Text = property.Name;
			TypeBox.SelectedItem = property.DataType;
			LengthBox.Value = property.Length;
			KeyCheck.Checked = property.Key;
			UniqueCheck.Checked = property.Unique;
			NullCheck.Checked = property.Nullable;
			DefaultBox.Text = property.Default;
		}

		public void Valid()
		{
			//
			//Name
			if (string.IsNullOrWhiteSpace(NameBox.Text) ||
				NameBox.Text.Any(c => !(char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '_')))

				throw new InvalidOperationException("Invalid Name!");
			if (NameBox.Text != view.Property.Name)
			{
				if (view.TableView.Properties.Any(r => r.Property.Name == NameBox.Text))
					throw new InvalidOperationException("Invalid Name/Parent !");
			}
			if (DefaultBox.Enabled && DefaultBox.Text.Any())
				switch ((DataType)TypeBox.SelectedItem)
				{
				case DataType.Int:
					{
						if (!int.TryParse(DefaultBox.Text, out _))
							throw new InvalidOperationException("Default Value Not Valid !");
						break;
					}
				case DataType.Float:
					{
						if (!float.TryParse(DefaultBox.Text, out _))
							throw new InvalidOperationException("Default Value Not Valid !");
						break;
					}
				case DataType.DateTime:
					{
						if (!DateTime.TryParse(DefaultBox.Text, out _))
							throw new InvalidOperationException("Default Value Not Valid !");
						break;
					}
				}
		}


		

	}
}
