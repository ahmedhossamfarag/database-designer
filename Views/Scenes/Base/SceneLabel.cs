using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Base
{
	public class SceneLabel : Label
	{
		public Scene scene;
		public Action<Scene> OnDClick;
		public SceneLabel(Scene sc)
		{
			scene = sc;
			InitializeComponent();
			Text = sc.ToString();
		}

		private void InitializeComponent()
		{
			Size = new System.Drawing.Size(180, 25);
			TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			Padding = new Padding(10, 0, 0, 0);
			MouseEnter += SceneLabel_MouseEnter;
			MouseDoubleClick += SceneLabel_MouseDoubleClick;
			MouseLeave += SceneLabel_MouseLeave;
		}

		private void SceneLabel_MouseLeave(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.None;
		}

		private void SceneLabel_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			OnDClick?.Invoke(scene);
		}

		private void SceneLabel_MouseEnter(object sender, EventArgs e)
		{
			BorderStyle = BorderStyle.FixedSingle;
		}
	}
}
