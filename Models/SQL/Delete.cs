using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.SQL
{
	internal class Delete : SQLOperation
	{
		public Table Table { get; set; }
		public string Where { get; set; } = string.Empty;

		public override string Write(SQLServer server = SQLServer.PHP)
		{
			return $"DELETE FROM `{Table.Name}` " +
				(Where.Any() ? $"\nWHERE {Where}" : "") + "\n;";
		}

		public override string ToString()
		{
			return "Delete " + Table.Name;
		}
	}
}
