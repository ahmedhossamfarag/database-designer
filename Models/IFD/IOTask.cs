using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.IFD
{
	internal class IOTask : InOut
	{
		public Task Task { get; set; }

		public Arrow Arrow { get; set; }

		public IOTask() { }
		public IOTask(Task task, bool i, bool o) => (Task, In, Out) = (task, i, o);

		public override string ToString() => $"{Task.Name},{In},{Out}";

	}
}
