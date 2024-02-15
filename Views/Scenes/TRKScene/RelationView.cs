using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class RelationView : Baziar
	{
		public readonly TableView table1, table2;

		public RelationView(TableView table1, TableView table2)
		{
			this.table1 = table1;
			this.table2 = table2;
			RItemView = new RItemView(this);
			Align();
		}

		public void Align()
		{
			TableView t1, t2;
			if(table1.Location.Y > table2.Location.Y)
			{
				t1 = table1;	t2 = table2;
			}
			else
			{
				t1 = table2; t2 = table1;
			}
			Point p1 = t1.Location, p2 = t2.Location;
			if(t2.Location.X - t1.Location.X > t1.Width)
			{
				p1.X += t1.Width;
				Mode = BaziarMode.Z;
			}
			else if(t1.Location.X - t2.Location.X > t1.Width)
			{
				p2.X += t2.Width;
				Mode = BaziarMode.Z;
			}
			else if(t1.Location.X > t2.Location.X)
			{
				p1.X += t1.Width;
				p2.X += t2.Width;
				Mode = BaziarMode.UR;
			}
			else
			{
				Mode = BaziarMode.UL;
			}
			p1.Y += t1.TName.Height / 2;
			p2.Y += t2.TName.Height / 2;
			if(t1 == table1)
			{
				Start = p1;
				End = p2;
			}
			else
			{
				Start = p2;
				End = p1;
			}
		}
	}
}
