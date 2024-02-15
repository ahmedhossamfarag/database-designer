using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Source
{
	internal class LineShape : Line
	{
		public LineShape(Shape s1, Shape s2) : base(s1.Center, s2.Center)
		{
			s1.Move += (s, e) => Start = s1.Center;
			s2.Move += (s, e) => End = s2.Center;
			s1.Resize += (s, e) => Start = s1.Center;
			s2.Resize += (s, e) => End = s2.Center;
			s1.Removed += p => p.Controls.Remove(this);
			s2.Removed += p => p.Controls.Remove(this);
		}
	}
}
