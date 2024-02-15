using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.TRK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class ForgeinKeyView : IStateful<Color>
	{
		public TRKScene Scene { get; set; }
		public FKItemView FKItemView;
		private (DataType type, int length) saved_type; 
		public void Add()
		{
			Scene.TPanel.Controls.Add(this);
			property1.Move += Property_Move;
			property2.Move += Property_Move;
			property1.Parent.Parent.Move += Property_Move;
			property2.Parent.Parent.Move += Property_Move;
			property1.ForgeinKey.Add(this);
			property2.ForgeinKey.Add(this);
			property1.TableView.ForgeinKeys.Add(this);
			property2.TableView.ForgeinKeys.Add(this);
			Scene.FKRContainer.Controls.Add(FKItemView);
			Scene.FKViews.Add(this);
			saved_type = (property1.Property.DataType, property1.Property.Length);
			property1.SetType(property2.Property.DataType, property2.Property.Length);
		}

		private void Property_Move(object sender, EventArgs e) => Align();

		public Color CreateState()
		{
			return Pen.Color;
		}

		public void Delete()
		{
			int n = Scene.FKRContainer.Controls.IndexOf(FKItemView);
			Remove();
			Action un = () => { Add(); Scene.FKRContainer.Controls.SetChildIndex(FKItemView, n); };
			Scene.Record.Add((un, Remove));
		}

		public void Remove()
		{
			Scene.TPanel.Controls.Remove(this);
			property1.Move -= Property_Move;
			property2.Move -= Property_Move;
			property1.Parent.Parent.Move -= Property_Move;
			property2.Parent.Parent.Move -= Property_Move;
			property1.ForgeinKey.Remove(this);
			property2.ForgeinKey.Remove(this);
			property1.TableView.ForgeinKeys.Remove(this);
			property2.TableView.ForgeinKeys.Remove(this);
			Scene.FKRContainer.Controls.Remove(FKItemView);
			Scene.FKViews.Remove(this);
            property1.SetType(saved_type.type, saved_type.length);
        }

		public void Set(Color state)
		{
			Pen.Color = state;
			FKItemView.IColor.BackColor = state;
			if(Parent != null)
				Redraw();
		}

		public void Update(Color state)
		{
			if(Pen.Color != state)
			{
				Color c = CreateState();
				Action un = () => Set(c);
				Action re = () => Set(state);
				re();
				Scene.Record.Add((un, re));
			}
		}
	}
}
