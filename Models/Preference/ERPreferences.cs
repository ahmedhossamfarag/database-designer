using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.Preference
{
	internal class ERPreferences
	{
		//
		// Diagram

		public Size DiagramSize { get; set; }
		public bool Fill { get; set; }

		public int Scale { get; set; }

		//
		// Entity

		public Size ESize { get; set; }
		public Color EColor { get; set; }
		public Color ESelectColor { get; set; }
		public Color ETextColor { get; set; }
		public Color ELineColor { get; set; }

		//
		// Attribute

		public Size ASize { get; set; }
		public Color AColor { get; set; }
		public Color ASelectColor { get; set; }
		public Color ATextColor { get; set; }
		public Color ALineColor { get; set; }
		
		//
		// Relation

		public Size RSize { get; set; }
		public Color RColor { get; set; }
		public Color RSelectColor { get; set; }
		public Color RTextColor { get; set; }
		public Color RLineColor { get; set; }

		//
		// Branch

		public Size BSize { get; set; }
		public Color BColor { get; set; }
		public Color BSelectColor { get; set; }
		public Color BTextColor { get; set; }
		public Color BLineColor { get; set; }
		
		//
		// Union

		public Size USize { get; set; }
		public Color UColor { get; set; }
		public Color USelectColor { get; set; }
		public Color UTextColor { get; set; }
		public Color ULineColor { get; set; }

	}
}
