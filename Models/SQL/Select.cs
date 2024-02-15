using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.SQL
{
	enum Order
	{
		DESC,
		ASC
	}
	enum SelectType
	{
		SUM,
		COUNT,
		MIN,
		MAX,
		AVG,
		None
	}
	struct SelectProperty
	{
		public Property P;
		public SelectType T;

		public SelectProperty(Property p, SelectType t)
		{
			P = p;
			T = t;
		}
	}
	internal class Select : SQLOperation
	{
		public List<Table> Tables { get; set; } = new List<Table>();

		public bool Distinct { get; set; }

		public bool Count { get; set; }

		public SelectType Type { get; set; } = SelectType.None;

		public List<SelectProperty> Properities { get; set; } = new List<SelectProperty>();


		public string Where { get; set; } = string.Empty;

		public List<(SelectProperty P, Order O)> OrderBy { get; set; } = new List<(SelectProperty P, Order O)>();

		public Property GroupBy { get; set; }

		public string Having { get; set; } = string.Empty;


		public int Limit { get; set; }

		public override string Write(SQLServer server = SQLServer.PHP)
		{
			string[] props = { };
			string[] ords = { };
			if (GroupBy != null)
			{
				props = Properities.ConvertAll(p => p.P == GroupBy ? $"`{p.P.Name}`" : $"{(p.T == SelectType.None ? "COUNT" : p.T.ToString())}(`{p.P.Name}`) AS {p.P.Name}{p.T}").ToArray();
				ords = OrderBy.ConvertAll(o => o.P.P == GroupBy ? $"`{o.P.P.Name}` {o.O}" : $"{o.P.P.Name}{o.P.T} {o.O}").ToArray();
			}
			else
			{
				props = Properities.ConvertAll(p => $"`{p.P.Name}`").ToArray();
				ords = OrderBy.ConvertAll(o => $"`{o.P.P.Name}` {o.O}").ToArray();
			}
			string[] tabs = Tables.ConvertAll(t => $"`{t.Name}`").ToArray();

			string sp = string.Join(", ", props);
			if (Distinct)
			{
				sp = "DISTINCT " + sp;
				if (Count & GroupBy == null)
					sp = $"COUNT({sp})";

			}
			else if (Properities.Count == 1 && Properities[0].T != SelectType.None)
				sp = $"{Properities[0].T}({sp})";
			string st = string.Join(", ", tabs);

			string so = string.Join(", ", ords);

			return $"SELECT {sp} \n FROM {st}" +
				(Where.Any() ? $"\n WHERE {Where}" : "") +
				(GroupBy == null ? "" : $"\n GROUP BY `{GroupBy.Name}`") +
				(Having.Any() ? $"\n HAVING {Having}" : "") +
				(OrderBy.Any() ? $"\n ORDER BY {so}" : "") +
				(Limit > 0 ? $"\n LIMIT {Limit}" : "") +
				"\n;";
		}

		public override string ToString()
		{
			return "Select " + string.Join(",", Tables.ConvertAll(t => t.Name)) + " : " + string.Join(",", Properities.ConvertAll(p => p.P.Name));
		}
	}
}
