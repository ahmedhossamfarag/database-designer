using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.IFD
{
	internal class FlowDiagram
	{
		public List<Task> Tasks { get; set; } = new List<Task>();

		public List<IOScreen> IOScreens { get; set; } = new List<IOScreen>();

	}
}
