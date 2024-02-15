using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Controllers
{
	internal interface IItemController
	{
		void Edit();

		void Delete();

		void Move(int x, int y);

		void SetSelect(bool flg);

	}
}
