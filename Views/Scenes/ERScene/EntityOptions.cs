using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Views.Scenes.Scene2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseDesigner.Views.Scenes.Scene3
{
	internal class EntityOptions : FlowLayoutPanel
	{
		private Button AddAtt;
		private Button AddBra;
		private Button AddUni;
		private Button Edit;
		private Button Delete;

		public Entity Entity;

		public EntityView View
		{
			set
			{
				if (value != null)
				{
					if (value.Entity != Entity)
					{
						Entity?.Controller.SetSelect(false);
						Entity = value.Entity;
						AddUni.Enabled = !value.Entity.HasUnion;
						Visible = true;
						Entity.Controller.SetSelect(true);
					}
				}
				else
				{
					Entity?.Controller.SetSelect(false);
					Entity = null;
					Visible = false;
				}
			}
		}


		public EntityOptions()
		{
			InitializeComponent();
			Visible = false;
		}

		private void InitializeComponent()
		{
			//
			//Add Att
			AddAtt = new Button()
			{
				Text = "+ Attribute",
				//Size = new System.Drawing.Size(120, 35),
				AutoSize = true,
				FlatStyle = FlatStyle.Standard
			};

			AddAtt.FlatAppearance.BorderSize = 0;
			AddAtt.Click += AddAtt_Click;
			//
			//Add Bra
			AddBra = new Button()
			{
				Text = "+ Branch",
				//Size = new System.Drawing.Size(120, 35),
				AutoSize = true,
				FlatStyle = FlatStyle.Standard
			};
			AddBra.FlatAppearance.BorderSize = 0;
			AddBra.Click += AddBra_Click;
			//
			//Add Uni
			AddUni = new Button()
			{
				Text = "+ Union",
				//Size = new System.Drawing.Size(120, 35),
				AutoSize = true,
				FlatStyle = FlatStyle.Standard
			};
			AddUni.FlatAppearance.BorderSize = 0;
			AddUni.Click += AddUni_Click;
			//
			//Edit
			Edit = new Button()
			{
				Text = "Edit",
				//Size = new System.Drawing.Size(120, 35),
				AutoSize = true,
				FlatStyle = FlatStyle.Standard
			};
			Edit.FlatAppearance.BorderSize = 0;
			Edit.Click += Edit_Click;
			//
			//Delete
			Delete = new Button()
			{
				Text = "Delete",
				//Size = new System.Drawing.Size(120, 35),
				AutoSize = true,
				FlatStyle = FlatStyle.Standard
			};
			Delete.FlatAppearance.BorderSize = 0;
			Delete.Click += Delete_Click;
			//
			//this
			FlowDirection = FlowDirection.LeftToRight;
			AutoSize = true;
			//Size = new System.Drawing.Size(125, 200);
			Margin = new Padding(0);
			Controls.Add(AddAtt);
			Controls.Add(AddBra);
			Controls.Add(AddUni);
			Controls.Add(Edit);
			Controls.Add(Delete);

		}

		private void Delete_Click(object sender, EventArgs e)
		{
			InfoDialog dialog = new InfoDialog("Are You Sure ?")
			{
				OnOk = () =>
				{
					Entity.Controller.Delete();
					View = null;
				}
			};
			dialog.Show();
		}

		private void Edit_Click(object sender, EventArgs e)
		{
			Entity.Controller.Edit();
		}

		private void AddUni_Click(object sender, EventArgs e)
		{
			Entity.Controller.AddUnion();
		}

		private void AddBra_Click(object sender, EventArgs e)
		{
			Entity.Controller.AddBranch();
		}

		private void AddAtt_Click(object sender, EventArgs e)
		{
			Entity.Controller.AddAttribute();
		}
	}
}
