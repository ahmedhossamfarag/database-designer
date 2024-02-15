using DatabaseDesigner.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.EER
{
	internal class HasAttributes : NamedItem
	{
		public EList<Attribute> Attributes { get; } = new EList<Attribute>();
	}
}
