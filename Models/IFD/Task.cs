using DatabaseDesigner.Controllers.FDControl;
using DatabaseDesigner.Models.Base;
using DatabaseDesigner.Views.Scenes.Scene2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.IFD
{
	internal class Task : InOut
	{
		private string name = string.Empty;
		

		public Action<string> NameChanged;
		

		public string Name {
			get => name;
			set
			{
				if(value != name)
				{
					name = value;
					NameChanged?.Invoke(value);
				}
			}
		} 

		

		public Task Parent { get; set; }

		public EList<Task> SubTasks { get; } = new EList<Task>();

		public TaskView View { get; }

		public TaskController Controller { get;}

		public FlowDiagramView FlowDiagram { get; }

		public Task(FlowDiagramView flowDiagram)
		{
			FlowDiagram = flowDiagram;
			View = new TaskView(this);
			Controller = new TaskController(this);
			
		}

		public override string ToString() => Name;
	}
}
