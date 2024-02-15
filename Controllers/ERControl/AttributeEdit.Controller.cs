using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.EER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = DatabaseDesigner.Models.EER.Attribute;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal partial class AttributeEdit
	{

		public void Update(Attribute a)
		{
			//
			//
			//Name
			if (string.IsNullOrWhiteSpace(NameBox.Text) ||
				NameBox.Text.Any(c => !(char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '_')))
				throw new InvalidOperationException("Invalid Name!");
			if (NameBox.Text != a.Name)
			{
				CheckName(a, NameBox.Text);
			}
			if( KeyCheck.Checked && !ValidKey(a) )
			{
                throw new InvalidOperationException("Invalid Key !");
            }
			if( MultCheck.Checked && !ValidMultiple(a) )
			{
                throw new InvalidOperationException("Invalid Multiple !");
            }
			//
			//Update
			a.Name = NameBox.Text;
			a.Multiple = MultCheck.Checked;
			a.Drived = DrivedCheck.Checked;
			a.Key = KeyCheck.Checked;
			//
			//
			Close();
		}

		private void CheckName(Attribute a, string name)
		{
			if (a.Super.Attributes.Any(at => at.Name == name)) 
				throw new InvalidOperationException("Duplicate Name!");
			if(a.Super is Entity entity)
				if(entity.Branches.Any(b => b.Subs.Any(e => e.Attributes.Any(at => at.Name == name))))
                    throw new InvalidOperationException("Duplicate Name On Some Subs!");
        }

		private bool ValidKey(Attribute a)
		{
			HasAttributes h = a.Super;
			while(h is Attribute t)
			{
				if (t.Multiple || t.Drived)
					return false;
				h = t.Super;
			}
			return true;
		}
		
		private bool ValidMultiple(Attribute a)
		{
			HasAttributes h = a.Super;
			while(h is Attribute t)
			{
				if (t.Key)
					return false;
				h = t.Super;
			}
			return true;
		}

		public void Set(Attribute a)
		{
			NameBox.Text = a.Name;
			MultCheck.Checked = a.Multiple;
			DrivedCheck.Checked = a.Drived;
			KeyCheck.Checked = a.Key;

		}
		

		public void ExpandAtt(HasAttributes h, List<Attribute> l)
		{

			l.AddRange(h.Attributes);
			h.Attributes.ForEach(a =>
			{
				if (a.Attributes.Any())
					ExpandAtt(a, l);
			});
		}

		public List<Attribute> ExpandAtt(HasAttributes h)
		{
			List<Attribute> l = new List<Attribute>();
			while (h is Attribute a && a.Super != null)
				h = a.Super;

			ExpandAtt(h, l);
			if (h is Entity e && e.Parents.Any())
				e.Parents.ForEach(p => ExpandAtt(p, l));
			else if (h is Attribute d)
				l.Add(d);
			return l;
		}

	}
}
