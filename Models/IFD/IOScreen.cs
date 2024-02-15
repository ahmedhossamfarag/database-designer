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

	internal class IOScreen
	{

		private string name = string.Empty;


		public Action<string> NameChanged;


		public string Name
		{
			get => name;
			set
			{
				if (value != name)
				{
					name = value;
					NameChanged?.Invoke(value);
				}
			}
		}

		
		public EList<IOTask> Tasks = new EList<IOTask>();

		public IOScreenView View { get; set; }

		public IOScreenController Controller { get; set; }
		
		public FlowDiagramView FlowDiagram { get; }
		public IOScreen(FlowDiagramView flowDiagram)
		{
			FlowDiagram = flowDiagram;
			View = new IOScreenView(this);
			Controller = new IOScreenController(this);
			
		}

		public override string ToString() => Name;
	}
}
