using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.SQL;
using DatabaseDesigner.Views.Scenes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers
{
	internal class PHP
	{
		public static readonly string PHPHead =
@"<?php


$server_host = ""localhost"";

$database_name = ""phpsql"";

$database_username = ""user"";

$database_password = """";
	

$connect = new mysqli($server_host, $database_username, $database_password, $database_name);

if (!$connect) {

	die(""Failed to connect to database"");

}

session_start();
";
		public static string PHPEND =
@"	if (!$result) {

		print '<p class=""error"">Error: Failed to update user profile. ' . mysql_error() . '</p>';

	}";
		public static string Fetsh =>
@"$row = mysql_fetch_array($result);

if (!$row) {

	print ""<p>Error: No data returned from database.</p>"";

	exit();

}

$result_array = [];
for ($i=0; $i < $result->num_rows; $i++) {
    $a = $result->fetch_array(MYSQLI_NUM);
    array_push($result_array, $a);
};";


		public static string DefineVariable(SQLOperation operation)
		{
			if (operation is SelectX selectX)
				return DefineVariable(selectX.Select1) + DefineVariable(selectX.Select2);

			List<Property> P = new List<Property>();
			List<string> S = new List<string>();

			if (operation is Insert insert)
				P = insert.Table.Attributes;
			else if (operation is Update update)
			{

				P = update.Properities;
				S = VariablesFromWhere(update.Where);
			}
			else if (operation is Delete delete)
				S = VariablesFromWhere(delete.Where);
			else if (operation is Select select)
				S = VariablesFromWhere(select.Where);
			else if (operation is WriteSQL write)
				S = VariablesFromWhere(write.Value);

			List<string> strings = new List<string>(P.ConvertAll(p => p.Name.ToLower()));
			foreach (string s in S)
				if (!strings.Contains(s))
					strings.Add(s);

			StringBuilder builder = new StringBuilder();
			foreach (string s in strings)
			{
				builder.Append($"${s} = $_POST['{s}'] ;");
				builder.AppendLine(); builder.AppendLine();
			}

			builder.Append($"$query = '{operation.Write()}' ;");
			builder.AppendLine(); builder.AppendLine();

			builder.Append("$result = $connect->query($query);");
			builder.AppendLine(); builder.AppendLine();

			return builder.ToString();
		}

		public static List<string> VariablesFromWhere(string where)
		{
			List<string> l = new List<string>();
			string[] strings = where.Split(new char[] { '$' });
			if (strings.Length < 1)
				return l;
			l = strings.SkipWhile(s => string.IsNullOrWhiteSpace(s)).ToList();
			l.RemoveAt(0);
			return l.ConvertAll(s =>
			{
				int i = s.IndexOfAny(new char[] { ' ', ',', '(', ')', ';', '+', '-', '>', '<', '=', '*', '/' });
				if (i < 0)
					return s;
				return s.Substring(0, i);
			});
		}


		public static void Write(List<SQLOperation> sQLs)
		{
			SaveFileDialog dialog = new SaveFileDialog()
			{
				FileName = "sql.php",
				DefaultExt = "php",
				AddExtension = true
			};
			if (dialog.ShowDialog() == DialogResult.OK)
			{

				StreamWriter writer = new StreamWriter(File.Open(dialog.FileName, FileMode.OpenOrCreate, FileAccess.Write));
				Write(writer, sQLs);
				writer.Close();
			}
		}

		private static void Write(StreamWriter writer, List<SQLOperation> sQLs)
		{
			writer.Write(PHPHead);
			writer.WriteLine();writer.WriteLine();writer.WriteLine();

			foreach(SQLOperation s in sQLs)
			{
				writer.Write(DefineVariable(s));
				writer.WriteLine(); writer.WriteLine(); writer.WriteLine();
				writer.Write(PHPEND);
				writer.WriteLine(); writer.WriteLine();
				if (s is Select || s is SelectX)
				{
					writer.Write(Fetsh);
				}
				writer.WriteLine(); writer.WriteLine(); writer.WriteLine();
				writer.Write("##################################################");
				writer.WriteLine(); writer.WriteLine(); writer.WriteLine();

			}
		}
	}
}
