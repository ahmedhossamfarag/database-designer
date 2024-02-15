using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	internal abstract class TransparentPanel : Panel
	{
		public event Action Added;

		public event Action<TransparentContainer> Removed;

		private Rectangle PastBounds;

		public TransparentPanel()
		{
			Move += TransparentPanel_Move;
			Added += TransparentPanel_Added;
			Removed += TransparentPanel_Removed;
			Resize += TransparentPanel_Resize;
		}


        public void RaiseAdded() => Added?.Invoke();

        public void RaiseRemoved(TransparentContainer c) => Removed?.Invoke(c);

        public bool Intersect(Control control) => Bounds.IntersectsWith(control.Bounds);

        public abstract void PaintContent(Graphics g);



        public void PaintBG(Graphics g)
        {
            int index = Parent.Controls.IndexOf(this);
            for (int i = Parent.Controls.Count - 1; i > index; i--)
            {
                if (Parent.Controls[i] is TransparentPanel tr && Intersect(tr))
                {
                    g.TranslateTransform(tr.Location.X - Location.X, tr.Location.Y - Location.Y);
                    tr.PaintContent(g);
                    g.ResetTransform();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintBG(e.Graphics);
            PaintContent(e.Graphics);
        }

        public void InvalidateUpper(Rectangle r, Control parent, int index)
        {
            for (int i = index - 1; i >= 0; i--)
            {
                if (parent.Controls[i] is TransparentPanel transparent && r.IntersectsWith(transparent.Bounds))
                {
                    transparent.Invalidate(new Region(new Rectangle(r.X - transparent.Location.X, r.Y - transparent.Location.Y, r.Width, r.Height)));
                }
            }
        }

        public void InvalidateUpper(Rectangle r1, Rectangle r2, Control parent, int index)
        {
            for (int i = index - 1; i >= 0; i--)
            {
                if (parent.Controls[i] is TransparentPanel transparent)
                {
                    if(r1.IntersectsWith(transparent.Bounds) || r2.IntersectsWith(transparent.Bounds))
                    {
                        Region r = new Region(new Rectangle(r1.X - transparent.Location.X, r1.Y - transparent.Location.Y, r1.Width, r1.Height));
                        r.Union(new Rectangle(r2.X - transparent.Location.X, r2.Y - transparent.Location.Y, r2.Width, r2.Height));
                        transparent.Invalidate(r);
                    }
                }
            }
        }

        protected virtual void TransparentPanel_Resize(object sender, EventArgs e)
        {
            if (Parent == null) return;
            int index = Parent.Controls.IndexOf(this);
            InvalidateUpper(PastBounds, Bounds, Parent, index);
            PastBounds = Bounds;
        }

        protected void TransparentPanel_Added()
        {
            if (Parent == null) return;
            int index = Parent.Controls.IndexOf(this);
            InvalidateUpper(Bounds, Parent, index);
            PastBounds = Bounds;
        }

        private void TransparentPanel_Removed(TransparentContainer parent)
        {
            InvalidateUpper(PastBounds, parent, parent.Controls.Count);
        }

        private void TransparentPanel_Move(object sender, EventArgs e)
        {
            Refresh();
            if (Parent == null) return;
            int index = Parent.Controls.IndexOf(this);
            InvalidateUpper(PastBounds, Bounds, Parent, index);
            PastBounds = Bounds;
        }

        public void Redraw()
        {
            Refresh();
            if (Parent == null) return;
            int index = Parent.Controls.IndexOf(this);
            InvalidateUpper(Bounds, Parent, index);
        }


        public new void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        public new void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        public new void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }
    }

	

}
