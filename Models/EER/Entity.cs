using DatabaseDesigner.Controllers.ERControl;
using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Views.Scenes.Scene3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.EER
{
	internal class Entity : HasAttributes
	{

		//
		//

		private bool weak;

		public Action<bool> WeakChanged;

		public bool Weak
		{
			get => weak;
			set
			{
				if (value != weak)
				{
					weak = value;
					WeakChanged?.Invoke(value);
				}
			}
		}

		//
		//

		public List<Entity> Parents { get; set; } = new List<Entity>();

		public List<Branch> Branches { get; set; } = new List<Branch>();

		public bool HasUnion {  get; set; }

		//
		//
		public EntityView View { get; }

		public EntityController Controller { get; }

		public ERDiagramView ERDiagram { get; }

		public Table Table { get; set; }

		//
		//
		public Entity(ERDiagramView eRDiagram)
		{
			ERDiagram = eRDiagram;
			Controller = new EntityController(this);
			View = new EntityView(this);
		}
	}
}
