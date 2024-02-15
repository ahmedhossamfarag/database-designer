using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.Base
{
	public class EList<T> : List<T>
	{
		public event Action<T> ItemAdded;
		public event Action<T> ItemRemoved;

		public EList() : base() { }

		public EList(IEnumerable<T> c) : base(c) { }

		public new void Add(T e)
		{
			base.Add(e);
			ItemAdded?.Invoke(e);
		}

		public new void AddRange(IEnumerable<T> e)
		{
			foreach (T i in e)
			{
				base.Add(i);
				ItemAdded?.Invoke(i);
			}
		}

		public new void Remove(T t)
		{
			base.Remove(t);
			ItemRemoved?.Invoke(t);
		}

		public string Join(string pt) => Join(pt, i => i.ToString());

		public string Join(string pt, Converter<T, string> f) => string.Join(pt, ConvertAll(f));
	}
}
