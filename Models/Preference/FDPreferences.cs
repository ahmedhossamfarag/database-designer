using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.Preference
{
	internal class FDPreferences
	{
		//
		// Diagram

		public Size DiagramSize { get; set; }
		public bool Fill { get; set; }

		public int Scale { get; set; }

		//
		// Database View

		public Size DBSize { get; set; }
		public Color DBColor { get; set; }
		public Color DBTextColor { get; set; }

		//
		// Tasks

		public Size TSize { get; set; }
		public Color TColor { get; set; }
		public Color TSelectColor { get; set; }
		public Color TTextColor { get; set; }
		public Color TArrowColor { get; set; }

		//
		// IOScreens

		public Size IOSize { get; set; }
		public Color IOColor { get; set; }
		public Color IOSelectColor { get; set; }
		public Color IOTextColor { get; set; }
		public Color IOArrowColor { get; set; }


	}
}
