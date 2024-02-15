using DatabaseDesigner.Views.Scenes.Scene2;
using DatabaseDesigner.Views.Scenes;
using DatabaseDesigner.Views.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseDesigner.Views.Scenes.Base;
using DatabaseDesigner.Models.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace DatabaseDesigner.Controllers
{
	internal abstract class DiagramController
	{
		public Diagram Diagram;

		public ScaleTool ScaleToolView;

		public Panel Tools;

		public bool Control;

		private Action<Point> ClickAction;

		public Action<Point> OnClick
		{
			get { return ClickAction; }
			set
			{
				ClickAction = value;
				Diagram.Cursor = value == null ? Cursors.Default : Cursors.Cross;
			}
		}

		
		public MouseListner MouseListner = new MouseListner();

		
		public List<IItemController> SelectedShapes = new List<IItemController>();

		private Point PastPoint;


		protected DiagramController(Diagram diagram, ScaleTool scaleToolView)
		{
			ScaleToolView = scaleToolView;
			Diagram = diagram;

			ScaleToolView.ZoomIn.Click += ZoomIn_Click;
			ScaleToolView.ZoomOut.Click += ZoomOut_Click;
			ScaleToolView.MoveEnable.Click += MoveEnable_Click;
			ScaleToolView.Center.Click += Center_Click;

		}



		//
		//	ScaleTools
		private void ZoomOut_Click(object sender, EventArgs e)
		{
			Diagram.DScale *= 10/11f;
			foreach(Control c in Diagram.Controls)
			{
				if (c is Shape s)
					s.Bounds = ScaleBounds(s.Bounds, 10/11f);
			}
		}
		 

		private void ZoomIn_Click(object sender, EventArgs e)
		{
			Diagram.DScale *= 1.1f;
			foreach (Control c in Diagram.Controls)
			{
				if (c is Shape s)
					s.Bounds = ScaleBounds(s.Bounds, 1.1f);
			}
		}


		private Rectangle ScaleBounds(Rectangle r, float d)
		{
			PointF p = new PointF(Diagram.Width / 2, Diagram.Height / 2);
			PointF f = new PointF(r.X - p.X, r.Y - p.Y);
			f = new PointF(f.X * d, f.Y * d);
			f = new PointF(p.X + f.X, p.Y + f.Y);
			return new Rectangle((int)f.X, (int)f.Y, (int)(r.Width * d), (int)(r.Height * d));
		}

		private void MoveEnable_Click(object sender, EventArgs e)
		{
			if (ScaleToolView.Movable)
				SetMoveMode();
			else
				SetDefault();
		}

		private void Center_Click(object sender, EventArgs e)
		{
			Diagram.Location = new Point((Diagram.Parent.Width - Diagram.Width) / 2, (Diagram.Parent.Height - Diagram.Height) / 2);
		}

		//
		//
		// Mode Change
		public virtual void ChangeMode()
		{
			OnClick = null;
		}


		//
		// Default Mode
		public void SetDefault()
		{
			ChangeMode();
			Escape();
			Tools.Enabled = true;
			ScaleToolView.Movable = false;
			SetDefaultMouseListner();
		}

		public void SetDefaultMouseListner()
		{
			MouseListner.MouseClick = DefaultMouseClick;
			MouseListner.MouseUp = null;
			MouseListner.MouseDown = null;
		}
		public abstract void DefaultMouseClick(object sender, MouseEventArgs e);

		//
		//Move Mode
		public void SetMoveMode()
		{
			ChangeMode();
			Escape();
			Tools.Enabled = false;
			SetMoveMouseListner();
		}

		public void SetMoveMouseListner()
		{
			MouseListner.MouseClick = null;
			MouseListner.MouseDown = MoveMouseDown;
			MouseListner.MouseUp = MoveMouseUp;
		}


		public void MoveMouseDown(object s, MouseEventArgs e)
		{
			PastPoint = e.Location;
			((Control)s).Cursor = Cursors.NoMove2D;
		}

		public void MoveMouseUp(object s, MouseEventArgs e)
		{
			Control p = (Control)s;
			int dx = e.X - PastPoint.X;
			int dy = e.Y - PastPoint.Y;
			if(p is Diagram)
			{
				p.Location = new Point(p.Location.X + dx, p.Location.Y + dy);
			}
			else
			{
                p.Location = new Point(Math.Max(0, Math.Min(Diagram.Width - p.Width, p.Location.X + dx)), Math.Max(0, Math.Min(Diagram.Height - p.Height, p.Location.Y + dy)));
            }
            if (p is ShapeText)
				p.Cursor = Cursors.Hand;
			else
				p.Cursor = Cursors.Default;
		}

		//
		// Control Mode


		public void SetControlMode()
		{
			ChangeMode();
			Tools.Enabled = false;
			SetControlMouseListner();
		}


        internal void CheckControlMode()
        {
			if (!SelectedShapes.Any())
				SetDefault();
        }

        public void SetControlMouseListner()
		{
			MouseListner.MouseClick = ControlMouseClick;
			MouseListner.MouseDown = null;
			MouseListner.MouseUp = null;
		}

		public void ControlMouseClick(object sender, MouseEventArgs e)
		{
			if (Control && sender is IControllable controllable)
			{
				controllable.Controller.SetSelect(true);
				SelectedShapes.Add(controllable.Controller);
			}
		}

		public void Move(int x, int y)
		{
			if (SelectedShapes.Any())
			{
				foreach (IItemController c in SelectedShapes)
				{
					c.Move(x, y);
				}
			}
		}

		public void Edit()
		{
			if (SelectedShapes.Count == 1)
			{
				SelectedShapes[0].Edit();
			}
		}

		public void Delete()
		{
			if (SelectedShapes.Any())
			{
				InfoDialog dialog = new InfoDialog("Are you sure ?");
				dialog.OnOk += () =>
				{
					new List<IItemController>(SelectedShapes).ForEach(p => p.Delete());
				};
				dialog.Show();

			}
		}


		public void Escape()
		{
			if (SelectedShapes.Any())
			{
				foreach (IItemController s in SelectedShapes)
				{
					s.SetSelect(false);
				}
				SelectedShapes.Clear();
			}
			OnClick = null;
		}
		//
		//
		public Point PointToScene(Point p) => new Point(p.X + Diagram.Location.X, p.Y + Diagram.Location.Y);

		public abstract void SetPreferences();

    }
}
