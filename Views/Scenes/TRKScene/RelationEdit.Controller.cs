using DatabaseDesigner.Models.TRK;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class RelationEdit : IEdit<RelationView, (Color, ManyMode)>
	{
		public (Color, ManyMode) GetState()
		{
			ManyMode m;
			if (C11.Checked)
				m = Source.ManyMode.None;
			else if (C1N.Checked)
				m = Source.ManyMode.N;
			else if (CN1.Checked)
				m = Source.ManyMode.N1;
			else
				m = Source.ManyMode.NN;
			return (Color.BackColor, m);
		}
		public void Set(RelationView v)
		{
			switch (v.Many)
			{
				case Source.ManyMode.N: { CN1.Checked = true; break; }
				case Source.ManyMode.N1: { C1N.Checked = true; break; }
				case Source.ManyMode.NN: { CNM.Checked = true; break; }
			}
			Color.BackColor = v.Pen.Color;
		}

		public void Valid()
		{
			
		}
	}
}
