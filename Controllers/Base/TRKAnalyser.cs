using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.TRK;
using DatabaseDesigner.Views.Scenes.Scene6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Controllers.Base
{
	internal class TRKAnalyser
	{
		Dictionary<PropertyView, Property> props = new Dictionary<PropertyView, Property>();
		public Database Analyse(TRKScene scene)
		{
			Database d = new Database();
			scene.TableViews.ForEach(v => CreateTable(v, d));
			scene.FKViews.ForEach(AddFKey);
			return d;
		}

		private void CreateTable(TableView view, Database d)
		{
			Table t = new Table() { Name = view.TName.Text };
			foreach (PropertyView p in view.Properties)
			{
				AddProperty(p, t);
			}
            if (!view.InnerJoinTable) 
				d.Tables.Add(t);
		}

		private void AddProperty(PropertyView v, Table t)
		{
			PropertyState s = v.Property;
			Property p = new Property()
			{
				Table = t,
				Name = s.Name,
				DataType = s.DataType,
				Length = s.Length,
				Key = s.Key,
				Unique = s.Unique,
				Nullable = s.Nullable,
				Default = s.Default
			};
			t.Attributes.Add(p);
			if (p.Key)
				t.Keys.Add(p);
			if (v.ForgeinKey.Any())
				props.Add(v, p);
		}

		private void AddFKey(ForgeinKeyView view)
		{
			props[view.property1].ForgienKey = props[view.property2];
		}
	}
}
