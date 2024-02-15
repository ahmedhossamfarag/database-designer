using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.EER
{
	internal class NamedItem
	{

		private string name;

		public Action<string> NameChanged;

		public string Name { 
			get => name;
			set
			{
				if(value != name)
				{
					name = value;
					NameChanged?.Invoke(value);
				}
			}
		}

		public override string ToString() => Name;
	}
}
