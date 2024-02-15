using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.IFD
{
	internal class InOut
	{
		private bool in_;
		private bool out_;

		public Action<bool> InChanged;
		public Action<bool> OutChanged;

		public bool In
		{
			get => in_;
			set
			{
				if (value != in_)
				{
					in_ = value;
					InChanged?.Invoke(value);
				}
			}
		}

		public bool Out
		{
			get => out_;
			set
			{
				if (value != out_)
				{
					out_ = value;
					OutChanged?.Invoke(value);
				}
			}
		}
	}
}
