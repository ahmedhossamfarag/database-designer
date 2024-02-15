using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.SQL
{
	internal class WriteSQL : SQLOperation
	{
		public string Value { get; set; }

		public override string Write(SQLServer server = SQLServer.PHP)
		{
			return Value;
		}

		public override string ToString()
		{
			return "Written SQL";
		}
	}
}
