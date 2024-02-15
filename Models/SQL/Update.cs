using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.SQL
{
	internal class Update : SQLOperation
	{
		public Table Table { get; set; }
		public List<Property> Properities { get; set; } = new List<Property>();
		public string Where { get; set; } = string.Empty;


		public override string Write(SQLServer server = SQLServer.PHP)
		{
			string[] names = Table.Attributes.ConvertAll(a => $"`{a.Name}` = '${a.Name.ToLower()}'").ToArray();
			return $"UPDATE TABLE `{Table.Name}` " +
				$"\nSET {string.Join(",", names)} " +
				(Where.Any() ? $"\nWHERE {Where}" : "") + "\n;";
		}

		public override string ToString()
		{
			return "Update " + Table.Name;
		}
	}
}
