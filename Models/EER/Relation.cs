using DatabaseDesigner.Controllers.ERControl;
using DatabaseDesigner.Models.Base;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Scenes.Scene3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.EER
{
	class RelationEntity
	{
		public Entity Entity { get; set; }

		private bool many;

		public Action<bool> ManyChanged;

		public bool Many
		{
			get => many;
			set
			{
				if(value != many)
				{
					many = value;
					ManyChanged?.Invoke(value);
				}
			}
		}


		public RelationEntity(Entity entity, bool many)
		{
			Entity = entity;
			Many = many;
		}

		public override string ToString() => $"{Entity.Name},{Many}";
	}
	internal class Relation : HasAttributes
	{

		public EList<RelationEntity> Entities { get; set; } = new EList<RelationEntity>();
		//
		//

		private bool weak;

		public Action<bool> WeakChanged;
		
		public bool Weak {
			get => weak;
			set
			{
				if(value != weak)
				{
					weak = value;
					WeakChanged?.Invoke(value);
				}
			}
		}

		//
		//

		public RelationView View { get; }

		public RelationController Controller { get; }

		public ERDiagramView ERDiagram { get; }

		//
		//

		public Relation(ERDiagramView eRDiagram)
		{
			ERDiagram = eRDiagram;
			Controller = new RelationController(this);
			View = new RelationView(this);
		}

	}
}
