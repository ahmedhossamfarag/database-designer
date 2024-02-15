using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.Database
{
	internal class Database
	{
		public List<Table> Tables { get; } = new List<Table>();

		public Table FindTable(string tableName)
		{
			return Tables.Find(t => t.Name == tableName);
		}
	}
}
