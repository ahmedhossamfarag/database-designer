using DatabaseDesigner.Models.TRK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class ForgeinKeyEdit : IEdit<ForgeinKeyView, Color>
	{
		public Color GetState() =>Color.BackColor;

		public void Set(ForgeinKeyView v)
		{
			Color.BackColor = v.Pen.Color;
		}

		public void Valid()
		{
			
		}
	}
}
