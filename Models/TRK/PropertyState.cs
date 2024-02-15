using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseDesigner.Models.TRK
{
	internal class PropertyState
	{
		public string Name;
		public bool Key;
		public bool Unique;
		public bool Nullable;

		public DataType DataType = DataType.VarChar;

		public int Length;

		public string Default;

		public override bool Equals(object obj)
		{
			return obj is PropertyState state &&
				   Name == state.Name &&
				   Key == state.Key &&
				   Unique == state.Unique &&
				   Nullable == state.Nullable &&
				   DataType == state.DataType &&
				   Length == state.Length &&
				   Default == state.Default;
		}

		public override int GetHashCode()
		{
			int hashCode = 1771701708;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + Key.GetHashCode();
			hashCode = hashCode * -1521134295 + Unique.GetHashCode();
			hashCode = hashCode * -1521134295 + Nullable.GetHashCode();
			hashCode = hashCode * -1521134295 + DataType.GetHashCode();
			hashCode = hashCode * -1521134295 + Length.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Default);
			return hashCode;
		}
	}
}
