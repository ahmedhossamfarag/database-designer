using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Base
{
	internal struct MouseListner
	{
		public MouseEventHandler MouseClick;
		public MouseEventHandler MouseDown;
		public MouseEventHandler MouseUp;
	}
}
