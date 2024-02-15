using DatabaseDesigner.Views.Scenes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Source
{
	internal class ShapeText : Shape
	{
		private readonly Label textLabel;

		public new string Text
		{
			get => textLabel.Text;
			set => textLabel.Text = value;
		}

		public new Font Font
		{
			get => textLabel.Font;
			set => textLabel.Font = value;
		}

		public ShapeText()
		{
			textLabel = new Label() { AutoSize = true};
			textLabel.TextChanged += TextLabel_TextChanged;
			textLabel.FontChanged += TextLabel_FontChanged;
			textLabel.TextAlign = ContentAlignment.MiddleCenter;
			textLabel.MouseClick += (s, e) => this.OnMouseClick(Local(e));
			textLabel.MouseDown += (s, e) => this.OnMouseDown(Local(e));
			textLabel.MouseUp += (s, e) => this.OnMouseUp(Local(e));
			Controls.Add(textLabel);
			Cursor = Cursors.Hand;
			SizeChanged += ShapeText_SizeChanged;
			FillChanged += ShapeText_FillChanged;
			SelectedChanged += ShapeText_FillChanged;
		}

		private void ShapeText_FillChanged()
		{
			textLabel.BackColor = Brush.Color;
		}

		private void TextLabel_FontChanged(object sender, EventArgs e) => AlignText();

		private void ShapeText_SizeChanged(object sender, EventArgs e) => AlignText();
		private void TextLabel_TextChanged(object sender, EventArgs e) => AlignText();

		private void AlignText()
		{
			var size = new Size(2 * Width, 2 * Height);
            Size s = textLabel.GetPreferredSize(size);
            string txt = textLabel.Text;
            int i = txt.LastIndexOf(' ');
            textLabel.TextChanged -= TextLabel_TextChanged;
            textLabel.FontChanged -= TextLabel_FontChanged;
            while (s.Width > Width && i != -1)
			{
                textLabel.Text = txt.Insert(i, "\n");
                s = textLabel.GetPreferredSize(size);
                i = txt.LastIndexOf(' ', i - 1);
            }
            textLabel.TextChanged += TextLabel_TextChanged;
            textLabel.FontChanged += TextLabel_FontChanged;
            int x = (Width - s.Width) / 2;
			int y = (Height - s.Height) / 2;
			textLabel.Location = new Point(x, y);
			
		}

        public override void PaintContent(Graphics g)
        {
            base.PaintContent(g);
			if (textLabel.Width == 0 || textLabel.Height == 0) return;
			Bitmap bm = new Bitmap(textLabel.Width, textLabel.Height);
			textLabel.DrawToBitmap(bm, new Rectangle(0, 0, textLabel.Width, textLabel.Height));
			g.DrawImage(bm, textLabel.Location);
        }

        private MouseEventArgs Local(MouseEventArgs e) => new MouseEventArgs(e.Button, e.Clicks, e.X + textLabel.Location.X, e.Y + textLabel.Location.Y, e.Delta);
	}
}
