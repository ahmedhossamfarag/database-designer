using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.SQL
{
	internal class Insert : SQLOperation
	{
		public Table Table { get; set; }

		public override string Write(SQLServer server = SQLServer.PHP)
		{
			string[] names = Table.Attributes.ConvertAll(a => $"`{a.Name}`").ToArray();
			string[] values = Table.Attributes.ConvertAll(a => $"'${a.Name.ToLower()}'").ToArray();
			return $"INSERT INTO `{Table.Name}`({string.Join(", ", names)}) \n" +
				$"VALUES ({string.Join(", ", values)})\n;";
		}

		public override string ToString()
		{
			return "Insert " + Table.Name;
		}
	}
}
