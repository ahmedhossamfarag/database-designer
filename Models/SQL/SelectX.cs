using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.SQL
{
	enum XType
	{
		UNION,
		INTERSECT,
		EXCEPT
	}
	internal class SelectX : SQLOperation
	{
		public Select Select1 { get; set; }
		public Select Select2 { get; set; }
		public XType Type { get; set; }

		public override string Write(SQLServer server = SQLServer.PHP)
		{
			return $"{Select1} \n" +
				$" {Type} \n" +
				$"{Select2}\n;";
		}

		public override string ToString()
		{
			return $"{Select1} {Type} {Select2}";
		}
	}
}
