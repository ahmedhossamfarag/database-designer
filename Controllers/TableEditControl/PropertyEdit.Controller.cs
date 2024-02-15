using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.TEScene
{
	internal partial class PropertyEdit
	{
		public void Set(Property p)
		{
			NameBox.Text = p.Name;
            TypeBox.SelectedItem = p.DataType;
            TypeBox.Enabled = p.ForgienKey == null;
            LengthBox.Value = p.Length;
			LengthBox.Enabled = TypeBox.Enabled && (p.DataType == DataType.VarChar || p.DataType == DataType.Float);
			UniqueCheck.Checked = p.Unique;
			NullCheck.Checked = p.Nullable;
			DefaultBox.Text = p.Default;
			UniqueCheck.Enabled = !p.Key;
		}

		public void Update(Property p)
		{
			Valid(p);
			p.Name = NameBox.Text;
			p.DataType = (DataType)TypeBox.SelectedItem;
			p.Length = (int)LengthBox.Value;
			p.Unique = UniqueCheck.Checked;
			p.Nullable = NullCheck.Enabled && NullCheck.Checked;
			p.Default = DefaultBox.Enabled ? DefaultBox.Text : p.Default;
		}

		public void Valid(Property p)
		{
			if(!NameBox.Text.Any() || 
				NameBox.Text.Any(c => !char.IsLetterOrDigit(c) && c != '_') ||
				!char.IsLetter(NameBox.Text[0]))
			{
				throw new InvalidOperationException("Name Not Valid !");
            }
			if(p.Name != NameBox.Text && p.Table.Attributes.Count(a => a.Name == NameBox.Text) >= 1)
			{
                throw new InvalidOperationException("Duplicate Name !");
            }
			if(!DefaultBox.Enabled || !DefaultBox.Text.Any())
			{
				return;
			}
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
