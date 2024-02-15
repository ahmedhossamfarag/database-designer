using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.TRK
{
	internal interface IEdit<T, U>
	{
		void Set(T v);

		void Valid();

		U GetState();
	}
}
