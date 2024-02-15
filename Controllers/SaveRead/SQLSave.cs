using DatabaseDesigner.Models.SQL;
using DatabaseDesigner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers
{
	internal class SQLSave
	{
		public static void WriteSQL(List<SQLOperation> sQL)
		{
			SaveFileDialog dialog = new SaveFileDialog()
			{
				FileName = "SQL Queries.txt",
				DefaultExt = "txt",
				AddExtension = true
			};
			if (dialog.ShowDialog() == DialogResult.OK)
			{

				StreamWriter writer = new StreamWriter(File.Open(dialog.FileName,FileMode.OpenOrCreate, FileAccess.Write));
				foreach (SQLOperation operation in sQL)
				{
					writer.WriteLine($"\n\n\n--  {operation}\n");
					writer.WriteLine(operation.Write(SQLServer.SQLLITE));
				}
				writer.WriteLine("\n\n\n");
				writer.Close();
			}
		}
	}
}
