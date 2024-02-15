using DatabaseDesigner.Views.Scenes.Scene3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.EER
{
	internal class ERDiagram
	{
		public List<Entity> Entities { get; set; } 
		public List<Attribute> Attributes { get; set; } 
		public List<Relation> Relations { get; set; } 
		public List<Branch> Branches { get; set; } 
		public List<Union> Unions { get; set; }

		public ERDiagram(ERDiagramView v)
		{
			Entities = v.Entities.ConvertAll(e => e.Entity);
			Attributes = v.Attributes.ConvertAll(e => e.Attribute);
			Relations = v.Relations.ConvertAll(e => e.Relation);
			Branches = v.Branches.ConvertAll(e => e.Branch);
			Unions = v.Unions.ConvertAll(e => e.Union);

		}
	}
}
