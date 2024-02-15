using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.TRK
{
	internal interface IStateful<T>
	{
		void Set(T state);

		T CreateState();

		void Add();

		void Update(T state);

		void Remove();

		void Delete();
	}
}
