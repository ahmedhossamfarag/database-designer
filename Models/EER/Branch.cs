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
	internal class Branch
	{
		public Entity Super { get; set; }
		//
		public EList<Entity> Subs { get; } = new EList<Entity>();
		//
		//
		private bool overlap;

		public Action<bool> OverlapChanged;
		public bool Overlap
		{
			get => overlap;
			set
			{
				if(value != overlap)
				{
					overlap = value;
					OverlapChanged?.Invoke(value);
				}
			}
		}
		//
		//
		private bool must;

		public Action<bool> MustChanged;
		public bool Must
		{
			get => must;
			set
			{
				if(value != must)
				{
					must = value;
					MustChanged?.Invoke(value);
				}
			}
		}

		//
		//
		public BranchView View { get; }

		public BranchController Controller { get; }

		public ERDiagramView ERDiagram { get; }

		//
		//
		public Branch(ERDiagramView eRDiagram)
		{
			ERDiagram = eRDiagram;
			Controller = new BranchController(this);
			View = new BranchView(this);
		}
	}
}
