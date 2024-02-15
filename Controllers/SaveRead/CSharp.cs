using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.SQL;
using Microsoft.VisualStudio.Services.Common.CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Controllers.SaveRead
{
    internal static class CSharp
    {
        public static void CreateCSharp(Database database)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                FileName = "Tables.cs",
                DefaultExt = "cs",
                AddExtension = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                StreamWriter writer = new StreamWriter(File.Open(dialog.FileName, FileMode.OpenOrCreate, FileAccess.Write));
                Write(writer, database);
                writer.Close();
            }
        }

        public static void Write(StreamWriter writer, Database database)
        {
            writer.WriteLine("using System.ComponentModel.DataAnnotations;");
            writer.WriteLine("using Microsoft.EntityFrameworkCore;");
            writer.WriteLine();
            writer.WriteLine("namespace Data");
            writer.WriteLine('{');
            foreach(var table in database.Tables)
                WriteTable(writer, table);
            writer.WriteLine('}');
            writer.WriteLine();
            writer.WriteLine();
            WriteDBContext(writer, database);
        }

        public static void WriteTable(StreamWriter writer, Table table)
        {
            writer.WriteLine($"\t[PrimaryKey({string.Join(", ", table.Keys.ConvertAll(k => $"\"{k.Name.CapitalizeAll()}\""))})]");
            writer.WriteLine($"\tpublic class {table.Name.CapitalizeAll()}");
            writer.WriteLine("\t{");
            foreach(var property in table.Attributes)
                WriteProperty(writer, property);
            writer.WriteLine("\t}");
            writer.WriteLine();
            writer.WriteLine();
        }

        public static void WriteProperty(StreamWriter writer, Property property)
        {
            DataType type = property.DataType;
            var name = property.Name.CapitalizeAll();
            switch (type)
            {
                case DataType.VarChar:
                    writer.WriteLine($"\t\t[MaxLength({property.Length})]");
                    writer.WriteLine($"\t\tpublic string {name} {{ get; set; }} = string.Empty;");
                    break;
                case DataType.Int:
                    writer.WriteLine($"\t\tpublic int {name} {{ get; set; }}");
                    break;
                case DataType.Boolean:
                    writer.WriteLine($"\t\tpublic bool {name} {{ get; set; }}");
                    break;
                case DataType.Float:
                    writer.WriteLine($"\t\tpublic double {name} {{ get; set; }}");
                    break;
                case DataType.Text:
                    writer.WriteLine("\t\t[DataType(DataType.Text)]");
                    writer.WriteLine($"\t\tpublic string {name} {{ get; set; }} = string.Empty;");
                    break;
                case DataType.DateTime:
                    writer.WriteLine("\t\t[DataType(DataType.DateTime)]");
                    writer.WriteLine($"\t\tpublic DateTime {name} {{ get; set; }}");
                    break;
                case DataType.Date:
                    writer.WriteLine("\t\t[DataType(DataType.Date)]");
                    writer.WriteLine($"\t\tpublic DateOnly {name} {{ get; set; }}");
                    break;
                case DataType.Time:
                    writer.WriteLine("\t\t[DataType(DataType.Time)]");
                    writer.WriteLine($"\t\tpublic TimeOnly {name} {{ get; set; }}");
                    break;
                
            }
            writer.WriteLine();
        }

        public static void WriteDBContext(StreamWriter writer, Database database)
        {
            writer.WriteLine("\tpublic class DatabaseContext : DbContext");
            writer.WriteLine("\t{");
            writer.WriteLine("\t\tpublic DatabaseContext (DbContextOptions<DatabaseContext> options): base(options) { }");
            writer.WriteLine();
            foreach (var table in database.Tables)
            {
                var tname = table.Name.CapitalizeAll();
                writer.WriteLine($"\t\tpublic DbSet<{tname}> {tname} {{ get; set; }} = default!;");
            }
            writer.WriteLine();
            writer.WriteLine("\t}");
        }

        public static string Capitalize(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            return char.ToUpper(input[0]) + input.Substring(1);
        }

        //  //  //

        internal static void CreateCSharp(List<SQLOperation> sqllist)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                FileName = "SQLs.cs",
                DefaultExt = "cs",
                AddExtension = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                StreamWriter writer = new StreamWriter(File.Open(dialog.FileName, FileMode.OpenOrCreate, FileAccess.Write));
                Write(writer, sqllist);
                writer.Close();
            }
        }

        //  //  //

        private static void Write(StreamWriter writer, List<SQLOperation> sQLs)
        {

        }

        public static string CapitalizeAll(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            return string.Join("", input.Split('_').ToList().ConvertAll(s => s.Capitalize()));
        }

    }
}
