using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.Base
{
    public class UList<T> : EList<T>
	{

		public UList() : base() { }

		public UList(IEnumerable<T> c) : base()
		{
			AddRange(c);
		}

		public new void Add(T e)
		{
			if (!Contains(e))
				base.Add(e);
		}

		public new void AddRange(IEnumerable<T> e)
		{
			foreach (T i in e)
			{
				if (!Contains(i))
					base.Add(i);
			}
		}
	}

    public static class ListExtensions
    {
        public static UList<T> ToUList<T>(this List<T> list) => new UList<T>(list);

    }
}
