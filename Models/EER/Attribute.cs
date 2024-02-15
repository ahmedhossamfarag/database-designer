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
	internal class Attribute : HasAttributes
	{
		public HasAttributes Super { get; set; }
		//
		//
		private bool multiple;

		public Action<bool> MultipleChanged;
		public bool Multiple
		{
			get => multiple;
			set
			{
				if (value != multiple)
				{
					multiple = value;
					MultipleChanged?.Invoke(value);
				}
			}
		}
		//
		//
		private bool drived;

		public Action<bool> DrivedChanged;
		public bool Drived
		{
			get => drived;
			set
			{
				if (value != drived)
				{
					drived = value;
					DrivedChanged?.Invoke(value);
				}
			}
		}
		//
		//
		private bool key;

		public Action<bool> KeyChanged;
		public bool Key
		{
			get => key;
			set
			{
				if (value != key)
				{
					key = value;
					KeyChanged?.Invoke(value);
				}
			}
		}

		//
		//
		//
		public AttributeView View { get; }

		public AttributeController Controller { get; }

		public ERDiagramView ERDiagram { get; }
		//
		//
		public Attribute(ERDiagramView eRDiagram)
		{
			ERDiagram = eRDiagram;
			Controller = new AttributeController(this);
			View = new AttributeView(this);
		}
	}
}
