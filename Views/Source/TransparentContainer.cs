using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	internal class TransparentContainer : Panel
	{
        private Shape MD_shape;

		public TransparentContainer()
		{
			ControlAdded += TransparentContainer_ControlAdded;
			ControlRemoved += TransparentContainer_ControlRemoved;
		}

		private void TransparentContainer_ControlRemoved(object sender, ControlEventArgs e)
		{
			if (e.Control is TransparentPanel transparent)
				transparent.RaiseRemoved(this);
		}

		private void TransparentContainer_ControlAdded(object sender, ControlEventArgs e)
		{
			if (e.Control is TransparentPanel transparent)
				transparent.RaiseAdded(); 
			if (e.Control is TransparentPanel && !(e.Control is Shape))
            {
                e.Control.MouseClick += Control_MouseClick;
                e.Control.MouseDown += Control_MouseDown;
                e.Control.MouseUp += Control_MouseUp;
				e.Control.MouseMove += (sn, ev) => OnMouseMove(MapEvent((Control)sn, ev));
            }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (MD_shape != null)
                MD_shape.OnMouseUp(MapEvent((Control)sender, e, MD_shape.Location));
            else
                OnMouseUp(MapEvent((Control)sender, e));
            MD_shape = null;
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            var shape = FindShape((Control)sender, e.Location);
            if (shape != null)
            {
                MD_shape = shape;
                shape.OnMouseDown(MapEvent((Control)sender, e, shape.Location));
            }
            else
                OnMouseDown(MapEvent((Control)sender, e));
        }

        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            var shape = FindShape((Control)sender, e.Location);
            if (shape != null)
                shape.OnMouseClick(MapEvent((Control)sender, e, shape.Location));
            else
                OnMouseClick(MapEvent((Control)sender, e));
        }

		private Shape FindShape(Control sender, Point point)
		{
            point = new Point(point.X + sender.Location.X, point.Y + sender.Location.Y);
            for(int i = Controls.IndexOf(sender)  + 1; i < Controls.Count; i++)
            {
                if(Controls[i] is  Shape shape && shape.Bounds.Contains(point))
                    return shape;
            }
            return null;
        }

        private MouseEventArgs MapEvent(Control c, MouseEventArgs e, Point org = new Point())
        {
            return new MouseEventArgs(e.Button, e.Clicks, e.X + c.Location.X - org.X, e.Y + c.Location.Y - org.Y, e.Delta); ;
        }



    }
}
