using DatabaseDesigner.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseDesigner.Models.Database
{
	enum TableRelationType
	{
		OneOne,
		OneMany,
		ManyOne,
		ManyMany,
	}

	class TableRalation
	{
		public Table Table { get; set; }

		public TableRelationType RelationType { get; set; }
	}

	internal class Table
	{
		private string Name_;
		public string Name
		{
			get { return Name_; }
			set
			{
				Name_ = value.Replace(' ', '_');
			}
		}
		public UList<Property> Attributes { get; set; } = new UList<Property>();
		public UList<Property> Keys { get; set; } = new UList<Property>();

		//public List<Property> KeysExtended { get; set; } = new UList<Property>();

		public EList<TableRalation> TableRalations { get; set; } = new EList<TableRalation>();

		public bool Weak { get; set; }

		public bool InnerJoin { get; set; }

		public override string ToString() => Name;
	}
}
