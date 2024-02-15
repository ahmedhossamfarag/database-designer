using DatabaseDesigner.Controllers.SaveRead;
using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Views.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.SQL
{
	internal class Create : SQLOperation
	{
		public Table Table { get; set; }
		public override string Write(SQLServer server = SQLServer.PHP)
		{
			string[] att = Table.Attributes.ConvertAll(a => a.Write(server)).ToArray();
			string[] keys = server == SQLServer.PHP ? Table.Keys.ConvertAll(a => $"`{a.Name}`").ToArray() :
                Table.Keys.ConvertAll(a => a.Name.CapitalizeAll()).ToArray();
			string[] fKeys = Table.Attributes.Where(a => a.ForgienKey != null).ToList().ConvertAll(a => a.WriteF(server)).ToArray();

			return
$@"CREATE TABLE {(server == SQLServer.PHP? $"`{Table.Name}`" : Table.Name.CapitalizeAll())} (
{string.Join(" ,\n", att)} ,
PRIMARY KEY({string.Join(" ,", keys)})" +
(fKeys.Length > 0 ? $",\n{string.Join(" ,\n", fKeys)}" : "") 
+ "\n);";
		}

		public override string ToString()
		{
			return $"Create {Table.Name}";
		}
	}
}
