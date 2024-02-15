using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.SQL
{
	public enum SQLServer
	{
		PHP,
		SQLLITE
	}

	internal abstract class SQLOperation
	{
		public abstract string Write(SQLServer server = SQLServer.PHP);
	}
}
