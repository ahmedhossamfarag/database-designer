using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Models.TRK
{
	internal class TableState
	{
		public string Name;
		public Color TBackColor;
		public Color TForColor;
		public Color PBackColor;
		public Color PForColor;

		public override bool Equals(object obj)
		{
			return obj is TableState state &&
				   Name == state.Name &&
				   EqualityComparer<Color>.Default.Equals(TBackColor, state.TBackColor) &&
				   EqualityComparer<Color>.Default.Equals(TForColor, state.TForColor) &&
				   EqualityComparer<Color>.Default.Equals(PBackColor, state.PBackColor) &&
				   EqualityComparer<Color>.Default.Equals(PForColor, state.PForColor);
		}

		public override int GetHashCode()
		{
			int hashCode = -906062498;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			hashCode = hashCode * -1521134295 + TBackColor.GetHashCode();
			hashCode = hashCode * -1521134295 + TForColor.GetHashCode();
			hashCode = hashCode * -1521134295 + PBackColor.GetHashCode();
			hashCode = hashCode * -1521134295 + PForColor.GetHashCode();
			return hashCode;
		}

	}
}
