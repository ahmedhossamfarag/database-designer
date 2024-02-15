using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.TRK;
using Microsoft.VisualStudio.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace DatabaseDesigner.Views.Scenes.Scene6
{
	internal partial class PropertyView : IStateful<PropertyState>
	{
		public PropertyState Property { get; set; }
		public TRKScene Scene { get; set; }
		
		public TableView TableView { get; set; }

		public List<ForgeinKeyView> ForgeinKey { get; set; } = new List<ForgeinKeyView>();

		public List<PropertyView> LinkedProperties;


		public void Add()
		{
			if (LinkedProperties == null)
				AddEx();
			else
                LinkedProperties?.ForEach(p => p.AddEx());
        }

		public void AddEx()
		{
			TableView.PBox.Controls.Add(this);
        }

		public PropertyState CreateState()
		{
			return new PropertyState()
			{
				Name = Property.Name,
				DataType = Property.DataType,
				Length = Property.Length,
				Key = Property.Key,
				Unique = Property.Unique,
				Nullable = Property.Nullable,
				Default = Property.Default,
			};
		}

		public void Delete()
		{
			int n = TableView.PBox.Controls.IndexOf(this);
			var fks = ForgeinKey;
			Remove();
			Action un = () =>
			{
				Add();
				TableView.PBox.Controls.SetChildIndex(this, n);
				fks.ForEach(fk => fk.Add());
			};
			Scene.Record.Add((un, Remove));
		}

		public void Remove()
		{
            if (LinkedProperties == null)
                RemoveEx();
            else
                LinkedProperties?.ForEach(p => p.RemoveEx());
        }

		public void RemoveEx()
		{
			ForgeinKey = new List<ForgeinKeyView>();
			TableView.PBox.Controls.Remove(this);
        }

		public void Set(PropertyState state)
		{
            if (LinkedProperties == null)
                SetEx(state);
            else
                LinkedProperties?.ForEach(p => p.SetEx(state));
		}
		
		public void SetEx(PropertyState state)
        {
            Property = state;
            //
            //
            PName.Text = state.Name;
			PType.Text = state.DataType.ToString();
			SpreadType(state.DataType, state.Length);
			Font = new System.Drawing.Font(Font, Property.Key ? System.Drawing.FontStyle.Underline : System.Drawing.FontStyle.Regular);
            //
            //
        }

		public void Update(PropertyState state)
		{
			if (!Property.Equals(state))
			{
				PropertyState s = CreateState();
				Action un = () => Set(s);
				Action re = () => Set(state);
				re();
				Scene.Record.Add((un, re));
			}
		}


        internal void SetType(DataType type, int length)
        {
            if (Property.DataType != type || Property.Length != length)
            {
                Property.DataType = type;
                Property.Length = length;
                PType.Text = type.ToString();
				SpreadType(type, length);
            }
            
        }

		private void SpreadType(DataType type, int length)
		{
            foreach (var fk in ForgeinKey)
            {
                if (fk.property1 != this)
                    fk.property1.SetType(type, length);
                else
                    fk.property2.SetType(type, length);
            }
        }

        private void PView_DoubleClick(object sender, EventArgs e)
		{
			PropertyEdit edit = new PropertyEdit() { Property = this };
			edit.Delete.Visible = true;
			edit.OkButton.Select();
			DialogResult r = edit.ShowDialog();
			if (r == DialogResult.OK)
			{
				Update(edit.GetState());
			}
			else if (r == DialogResult.No)
			{
				Delete();
			}
		}

		public void ReadProperty(Property property)
		{
			PName.Text = property.Name;
			PType.Text= property.DataType.ToString();
			Set(new PropertyState()
			{
				Name = property.Name,
				DataType = property.DataType,
				Length = property.Length,
				Key = property.Key,
				Unique = property.Unique,
				Nullable = property.Nullable,
				Default = property.Default,
			}
			);
		}
	}
}
