using DatabaseDesigner.Controllers.ERControl;
using DatabaseDesigner.Models.Base;
using DatabaseDesigner.Views.Scenes.Scene3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.EER
{
	internal class Union
	{
		public Entity Sub { get; set; }
		//
		public EList<Entity> Supers { get; } = new EList<Entity>();
		//
		//
		//
		public UnionView View { get; }

		public UnionController Controller { get; }

		public ERDiagramView ERDiagram { get; }

		//
		//
		public Union(ERDiagramView eRDiagram)
		{
			ERDiagram = eRDiagram;
			Controller = new UnionController(this);
			View = new UnionView(this);
		}
	}
}
