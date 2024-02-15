using DatabaseDesigner.Controllers.Base;
using DatabaseDesigner.Controllers.SaveRead;
using DatabaseDesigner.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Attribute = DatabaseDesigner.Models.EER.Attribute;
namespace DatabaseDesigner.Models.Database
{
	internal class Property
	{
		private string Name_;
		public event Action<string> NameChanged;
		public string Name
		{
			get { return Name_; }
			set
			{
				var x = Name_;
				Name_ = value.Replace(' ', '_');
				if(x != value)
					NameChanged?.Invoke(value);
			}
		}

		public bool Key { get; set; }

		public bool Unique { get; set; }

		public bool Nullable { get; set; }

		private DataType DataType_ = DataType.VarChar;
		public event Action<DataType> DataTypeChanged;
		public DataType DataType
		{
			get => DataType_;
			set
			{
				var x = DataType_;
				DataType_ = value;
				if (x != value)
				{
                    DataTypeChanged?.Invoke(value);
					LinkedTypes.ForEach(p => p.DataType = value);
                }
			}
		}

		private int Length_ = 50;
		public event Action<int> LengthChanged;
		public int Length
		{
			get => Length_;
			set
			{
				var x = Length_;
				Length_ = value;
				if (x != value)
                {
                    LengthChanged?.Invoke(value);
					LinkedTypes.ForEach((p) => p.Length = value);
                }
			}
		}

		public string Default { get; set; } = string.Empty;

		public bool Multiple { get; set; }

		public Table Table { get; set; }

		public Property ForgienKey { get; set; }

		public List<Property> LinkedTypes { get; set; }  = new List<Property>();

		public Attribute Attribute { get; set; }

		public bool Duplicate;
		public Property Original;

		#region Overriden Methods
		public override string ToString() => Name;

		public override bool Equals(object obj)
		{
			if (obj is Property p)
				return p.Name_ == Name_;
			return false;
		}

		public override int GetHashCode() => base.GetHashCode();


		#endregion

		public Property Clone(Table t, string pre = "", bool key = false, bool dup = false, bool link = true, bool link_name = false)
		{
			var pr = new Property()
			{
				Name = pre + Name + (dup ? "2" : ""),
				Key = key || Key,
				Unique = Unique,
				Nullable = Nullable,
				DataType = DataType,
				Length = Length,
				Multiple = key ? false : Multiple,
				Table = t,
				ForgienKey = ForgienKey,
				Attribute = Attribute,
				Duplicate = dup,
				Original = dup ? Original ?? this : null,
			};
			if(link)
			{
                LinkedTypes.Add(pr);
                pr.LinkedTypes.Add(this);
				PropertyNameObserver nameObserver = new PropertyNameObserver() {ObserveProperty = this, ChangeProperty = pr, Dup = dup, Pre = pre };
                NameChanged += nameObserver.ChangeName;
				if (link_name)
					pr.NameChanged += nm => Name = nm;
				else
					pr.NameChanged += nameObserver.RemoveObserver;
            }
			return pr;
		}

		public string Write(SQLServer server = SQLServer.PHP)
		{
			var datatype = DataType.ToString();
			if (DataType == DataType.Boolean && server == SQLServer.SQLLITE)
				datatype = "Bit";
			return (server == SQLServer.PHP ? $"`{Name}` " : Name.CapitalizeAll()) + ' ' +
				datatype + (DataType == DataType.VarChar || DataType == DataType.Float ? $"({Length})" : "")
				+ (Nullable ? "" : " NOT NULL" 
				+ (Unique ? " UNIQUE" : (Default.Any()? $" DEFAULT {Default}" : "")));
		}

		public string WriteF(SQLServer server = SQLServer.PHP)
		{
			if (ForgienKey == null)
				return "";
			if(server == SQLServer.PHP)
				return $"FOREIGN KEY(`{Name}`) REFERENCES `{ForgienKey.Table.Name}`(`{(ForgienKey.Duplicate? ForgienKey.Original.Name : ForgienKey.Name)}`)";
			else
                return $"FOREIGN KEY({Name.CapitalizeAll()}) REFERENCES {ForgienKey.Table.Name.CapitalizeAll()}({(ForgienKey.Duplicate ? ForgienKey.Original.Name.CapitalizeAll() : ForgienKey.Name.CapitalizeAll())})";
        }
    }
}
