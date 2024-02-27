using DatabaseDesigner.Models.Base;
using DatabaseDesigner.Models.Database;
using DatabaseDesigner.Models.EER;
using DatabaseDesigner.Views.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = DatabaseDesigner.Models.EER.Attribute;
using Property = DatabaseDesigner.Models.Database.Property;

namespace DatabaseDesigner.Controllers
{

	internal class ERAnalyser
	{
		public ERDiagram ERDiagram { get; }
		public Database Database { get; } = new Database();

		private List<Table> tables_to_remove = new List<Table>();

		public ERAnalyser(ERDiagram eRDiagram)
		{
			ERDiagram = eRDiagram;
			eRDiagram.Entities.ForEach(CreateTables);
			eRDiagram.Branches.ForEach(ExpandBranch);
			eRDiagram.Relations.ForEach(ExpandRelations);
			eRDiagram.Unions.ForEach(ExpandUnion);
			ExpandMult();
			FinalizeDatabase();
		}

        public void CreateTables(Entity entity)
		{
			Table table = new Table() { Name = entity.Name, Weak = entity.Weak };
			entity.Table = table;
			FillProperties(table, entity.Attributes);
			Database.Tables.Add(table);
		}

        public void ExpandBranch(Branch b)
		{
			Table table = b.Super.Table;
			if (b.Must && !b.Overlap && !HasRelation(b.Super))
			{
				foreach (Entity e in b.Subs)
				{
                    foreach (var att in table.Attributes)
                    {
                        var property = att.Clone(e.Table, link: false);
                        if (property.Key)
                            e.Table.Keys.Add(property);
                        e.Table.Attributes.Add(property);
                    }
                }
                Database.Tables.Remove(table);
			}
			else
			{
				foreach (Entity e in b.Subs)
				{
					var fks = table.Keys.ConvertAll(k => ForgienKey(k, e.Table));
                    e.Table.Keys.InsertRange(0, fks);
					e.Table.Attributes.InsertRange(0, fks);
				}
            }
		}

        private void ExpandRelations(Relation relation)
        {
			var srcs = relation.Entities.ConvertAll(e => e.Entity.Table);
			(var many, var other) = SplitMany(relation.Entities);
			Table table = new Table() { Name = string.Join(relation.Name, srcs) };
			FillProperties(table, relation.Attributes);
			if(many.Count <= 1 && !table.Keys.Any() && !relation.Weak)
			{
				Table target;
				if (many.Any())
					target = many[0];
				else
				{
					target = other[0];
					other.RemoveAt(0);
					many.Add(target);
                }
				var key = target.Weak && !relation.Weak;
                for (int i = 0; i < other.Count; i++)
                {
					var tb = other[i];
					if (other.IndexOf(tb) != i)
					{
						var fks = MakeFKs(target, tb, pre: "2", key: key);
						if (key)
							target.Keys.AddRange(fks);
						target.Attributes.AddRange(fks);
						if(target.Weak)
							Watchkeys(tb, target, prfx:"2", key: key);
                    } 
					else
					{
						var fks = MakeFKs(target, tb, key: key);
                        if (key)
                            target.Keys.AddRange(fks);
                        target.Attributes.AddRange(fks);
                        target.TableRalations.Add(new TableRalation() { Table = tb, RelationType =
                            many.Any() ? TableRelationType.ManyOne : TableRelationType.OneOne});
						if(tb.Weak)	
							Watchkeys(tb, target, key: key);
                    }
                }
                (var mult, var attrs) = SplitMult(table.Attributes);
                if (mult.Any())
				{
					table.Attributes = mult.ToUList();
					for (var i = 0; i < srcs.Count; i++)
                    {
						var tb = srcs[i];
						if (srcs.IndexOf(tb) != i)
                        {
                            table.Keys.AddRange(tb.Keys.ConvertAll(k => k.Clone(tb, dup: true)));
							WatchKeysOrg(tb, table.Keys, dup: true);
                        }
						else
                        {
                            table.Keys.AddRange(tb.Keys);
							WatchKeysOrg(tb, table.Keys);
                        }
                    }
                    Database.Tables.Add(table);
					tables_to_remove.Add(table);
                }
				else
				{
					target.Attributes.AddRange(target.Attributes);
				}
			}
			else
			{
				for (var i = 0; i < srcs.Count; i++)
                {
					var tb = srcs[i];
					if(srcs.IndexOf(tb) != i)
					{
						var fks = MakeFKs(table, tb, true, pre: "2");
                        table.Keys.AddRange(fks);
						table.Attributes.AddRange(fks);
                        Watchkeys(tb, table, prfx: "2", key: true);
                    }
					else
					{
						var fks = MakeFKs(table, tb, true);
                        table.Keys.AddRange(fks);
						table.Attributes.AddRange(fks);
						Watchkeys(tb, table, key: true);
                        table.TableRalations.Add(new TableRalation() { Table = tb, RelationType = TableRelationType.ManyMany });
                    }
                }
                Database.Tables.Add(table);
            }
        }

        public void ExpandUnion(Union u)
		{
			Table t = u.Sub.Table;
			foreach (Entity e in u.Supers)
			{
				e.Table.Attributes.AddRange(t.Keys.ConvertAll(k => ForgienKey(k, e.Table, false)));
				e.Table.TableRalations.Add(new TableRalation() { Table = t, RelationType = TableRelationType.OneOne });
			}
		}

        private void ExpandMult()
        {
            for (int i = 0; i < Database.Tables.Count; i++)
            {
				var table = Database.Tables[i];
				(var mult, var other) = SplitMult(table.Attributes);
				if (!mult.Any()) continue;
				table.Attributes = other.ToUList();
                foreach (var mprop in mult)
                {
                    Table newtable = new Table() { Name = $"{table}_{mprop}" };
                    var fks = table.Keys.ConvertAll(k =>
                            ForgienKey(k, newtable, true));
                    newtable.Keys.AddRange(fks);
                    newtable.Attributes.AddRange(fks);
                    if(table.Keys[0].Table == table)
					{
                        newtable.TableRalations.Add(new TableRalation() { Table = table, RelationType = TableRelationType.ManyOne });
                    }
                    else
					{
						var tables = table.Keys.ConvertAll(k => k.Table).ToUList();
						tables.ForEach(t =>
                        newtable.TableRalations.Add(new TableRalation() { Table = t, RelationType = TableRelationType.ManyOne })
						);

					}
					if (mprop.Attribute.Attributes.Any())
						FillProperties(newtable, mprop.Attribute.Attributes, make_keys: true);
					else
					{
						var mp = mprop.Clone(newtable, key: true, link: false);
                        newtable.Keys.Add(mp);
                        newtable.Attributes.Add(mp);
                    }
                    Database.Tables.Add(newtable);
                }
            }
        }

        public void FinalizeDatabase()
        {
            foreach (var table in tables_to_remove)
            {
				Database.Tables.Remove(table);
            }
            ERDiagram.Entities.ForEach(e => e.Table = null);
        }

        private void FillProperties(Table table, List<Attribute> atts, bool make_keys = false)
        {
            foreach (var at in atts)
            {
				var property = PropertyOf(at, table, make_keys);
                if (at.Key)
                    table.Keys.Add(property);
                table.Attributes.Add(property);
            }
            ExpandAttributes(table);
        }

        private void ExpandAttributes(Table table)
        {
            for (int i = 0; i < table.Attributes.Count;)
            {
                var at = table.Attributes[i];

                if (at.Attribute.Attributes.Any() && !at.Multiple)
                {
                    table.Attributes.RemoveAt(i);
                    foreach (var attribute in at.Attribute.Attributes)
                    {
						var property = PropertyOf(attribute, table, make_key: at.Key, pre: $"{at.Name}_");
						if (property.Key)
							table.Keys.Add(property);
                        table.Attributes.Add(property);
                    }
					continue;
                }
				i++;
            }
        }

		private bool HasRelation(Entity entity)
		{
            foreach (var relation in ERDiagram.Relations)
            {
                foreach (var en in relation.Entities)
                {
                    if (en.Entity == entity)
						return true;
                }

            }
			return false;
        }

		private (List<Property>, List<Property>) SplitMult(List<Property> properties)
			=> (properties.FindAll(a => a.Multiple).ToList(), properties.FindAll(a => !a.Multiple).ToList());

		private (List<Table>, List<Table>) SplitMany(List<RelationEntity> entities)
			=> (entities.FindAll(e => e.Many).ToList().ConvertAll(e => e.Entity.Table),
			entities.FindAll(e => !e.Many).ToList().ConvertAll(e => e.Entity.Table));

		private List<Property> MakeFKs(Table table, Table src, bool key = false, string pre = "")
		{
			return src.Keys.ConvertAll(k => ForgienKey(k, table, key, prefix: pre));
		}

        private void Watchkeys(Table t, Table des, string prfx = "", bool key = false)
        {
			if(t == des)  return;
			t.Keys.ItemAdded += (k) =>
			{
				var fk = ForgienKey(k, t, key, prefix: prfx);
				if(key)
					des.Keys.Add(fk);
				des.Attributes.Add(fk);
            };
        }

		private void WatchKeysOrg(Table table, List<Property> des, bool dup = false)
        {
			if(des == table.Keys) return;
            table.Keys.ItemAdded += k => des.Add(k.Clone(table, dup: dup));
		}

        public Property PropertyOf(Attribute a, Table t, bool make_key = false, string pre = "")
		{
			bool key = make_key ? !a.Multiple : a.Key;
			return new Property()
			{
				Name = pre + a.Name,
				Key = key,
				Unique = key,
				Nullable = !key,
				Multiple = a.Multiple,
				Table = t,
				Attribute = a,
				DataType = a.Key ? DataType.Int : DataType.VarChar
			};
		}

		public Property ForgienKey(Property p, Table t, bool k = true, bool pre = true, string prefix = "")
		{
			Property Property = p.Clone(t, pre ? $"{p.Table.Name}{prefix}_" : "");
			Property.Key = k;
			Property.ForgienKey = p.Duplicate ? p.Original : p;
			return Property;
		}

	}
	/*
	internal class ERAnalyser
	{
		public ERDiagram ERDiagram { get; }
		public Database Database { get; } = new Database();

		private Dictionary<Table, List<Table>> mirror_tables = new Dictionary<Table, List<Table>>();

		public ERAnalyser(ERDiagram eRDiagram)
		{
			ERDiagram = eRDiagram;
			eRDiagram.Entities.ForEach(CreateTables);
			eRDiagram.Branches.ForEach(ExpandBranch);
			eRDiagram.Relations.ForEach(ExpandRelations);
			eRDiagram.Unions.ForEach(ExpandUnion);
			ExpandMult();
			FinalizeDatabase();
		}

        public void CreateTables(Entity entity)
		{
			Table table = new Table() { Name = entity.Name, Weak = entity.Weak };
			entity.Table = table;
			(var keys, var attributes) = SplitKey(entity.Attributes);
			FillProperties(table, keys, table.Keys, true);
			FillProperties(table, attributes, table.Attributes);
			Database.Tables.Add(table);
		}

        public void ExpandBranch(Branch b)
		{
			Table table = b.Super.Table;
			if (b.Must && !b.Overlap)
			{
				List<Table> join_tables = new List<Table>();
				foreach (Entity e in b.Subs)
				{
					e.Table.Attributes.InsertRange(0, table.Attributes.ConvertAll(a => a.Clone(e.Table, link_name: true)));
					e.Table.Keys.InsertRange(0, table.Keys.ConvertAll(a => a.Clone(e.Table, link_name: true)));
					join_tables.Add(e.Table);
				}
                Database.Tables.Remove(table);
				table.InnerJoin = true;
				Database.InnerJoinTables.Add(table, join_tables);
				WatchTable(table, b.Subs, true, true, false);
			}
			else
			{
				foreach (Entity e in b.Subs)
				{
					e.Table.Keys.InsertRange(0, table.Keys.ConvertAll(k => ForgienKey(k, e.Table)));
				}
            }
		}

        private void ExpandRelations(Relation relation)
        {
			var srcs = relation.Entities.ConvertAll(e => e.Entity.Table);
			(var many, var other) = SplitMany(relation.Entities);
			if(many.Count <= 1)
			{
				Table target;
				if (many.Any())
					target = many[0];
				else
				{
					target = other[0];
					other.RemoveAt(0);
					many.Add(target);
                }
				var key = target.Weak && !relation.Weak;
                var des = key ? target.Keys : target.Attributes;
                for (int i = 0; i < other.Count; i++)
                {
					var tb = other[i];
					if (other.IndexOf(tb) != i)
					{
                        des.AddRange(MakeFKs(target, tb, pre: "2", key: key));
                        Watchkeys(tb, des, prfx:"2", key: key);
                    } 
					else
					{
                        des.AddRange(MakeFKs(target, tb, key: key));
                        AddTableRelations(target, GetOriginals(tb),
                            many.Any() ? TableRelationType.ManyOne : TableRelationType.OneOne);
                        Watchkeys(tb, des, key: key);
                    }
                }
                if (HasMult(relation.Attributes))
				{
					var list = new List<Attribute>();
					FillAttributes(relation.Attributes, list);
					(var mult, var attrs) = SplitMult(relation.Attributes);

                    FillProperties(target, attrs, target.Attributes);

                    Table table = new Table() { Name = string.Join(relation.Name, srcs) };
					for (var i = 0; i < srcs.Count; i++)
                    {
						var tb = srcs[i];
						if (srcs.IndexOf(tb) != i)
                        {
                            table.Keys.AddRange(tb.Keys.ConvertAll(k => k.Clone(tb, dup: true)));
							WatchKeysOrg(tb, table.Keys, dup: true);
                        }
						else
                        {
                            table.Keys.AddRange(tb.Keys);
							WatchKeysOrg(tb, table.Keys);
                        }
                    }
                    FillProperties(table, mult, table.Attributes);
                    Database.Tables.Add(table);
					mirror_tables.Add(table, srcs.ToList());
                }
				else
				{
					FillProperties(target, relation.Attributes, target.Attributes);
				}
			}
			else
			{
				Table table = new Table() { Name = string.Join(relation.Name, srcs) };
                for (var i = 0; i < srcs.Count; i++)
                {
					var tb = srcs[i];
					if(srcs.IndexOf(tb) != i)
					{
                        table.Keys.AddRange(MakeFKs(table, tb, true, pre: "2"));
                        Watchkeys(tb, table.Keys,prfx: "2", key: true);
                    }
					else
					{
                        table.Keys.AddRange(MakeFKs(table, tb, true));
                        AddTableRelations(table, GetOriginals(tb), TableRelationType.ManyMany);
						Watchkeys(tb, table.Keys, key: true);
                    }
                }
				FillProperties(table, relation.Attributes, table.Attributes);
				Database.Tables.Add(table);
            }
        }

        public void ExpandUnion(Union u)
		{
			Table t = u.Sub.Table;
			foreach (Entity e in u.Supers)
			{
				e.Table.Attributes.AddRange(t.Keys.ConvertAll(k => ForgienKey(k, e.Table, false)));
				e.Table.TableRalations.Add(new TableRalation() { Table = t, RelationType = TableRelationType.OneOne });
			}
		}

        private void ExpandMult()
        {
            for (int i = 0; i < Database.Tables.Count; i++)
            {
				var table = Database.Tables[i];
				var originals = GetOriginals(table);
				(var mult, var other) = SplitMult(table.Attributes);
				if (!mult.Any()) continue;
				table.Attributes = other.ToUList();
                foreach (var mprop in mult)
                {
					if (mprop.Attribute.Attributes.Any())
					{
						var list = new List<Attribute>();
						FillAttributes(mprop.Attribute.Attributes, list);
						(var muls, var keys) = SplitMult(list);
						if(keys.Any())
						{
                            Table newtable = new Table() { Name = $"{table}_{mprop}" };
                            newtable.Keys.AddRange(table.Keys.ConvertAll(k => ForgienKey(k, newtable, true)));
							AddTableRelations(newtable, originals, TableRelationType.ManyOne);
							FillProperties(newtable, keys, newtable.Keys, true);
                            FillProperties(newtable, muls, newtable.Attributes);
                            Database.Tables.Add(newtable);
                        }
						else
						{
                            Table newtable = new Table() { Name = $"{table}_{mprop}" };
                            newtable.Keys.AddRange(table.Keys);
							newtable.TableRalations = table.TableRalations;
                            FillProperties(newtable, keys, newtable.Keys, true);
                            FillProperties(newtable, muls, newtable.Attributes);
                            Database.Tables.Add(newtable);
							mirror_tables.Add(newtable, new List<Table>() { table });
                        }
					}
					else
					{
                        Table newtable = new Table() { Name = $"{table}_{mprop}" };
                        newtable.Keys.AddRange(table.Keys.ConvertAll(k => 
								ForgienKey(k, newtable, true)));
						AddTableRelations(newtable, originals, TableRelationType.ManyOne);
						newtable.Keys.Add(mprop.Clone(newtable, key: true));
                        Database.Tables.Add(newtable);
                    }
                }
            }
        }

        public void FinalizeDatabase()
        {
            foreach (var table in mirror_tables.Keys)
            {
				Database.Tables.Remove(table);
            }
            foreach (Table table in Database.Tables)
            {
                table.Attributes.InsertRange(0, table.Keys);
            }
            foreach (Table table in Database.InnerJoinTables.Keys)
            {
                table.Attributes = SplitMult(table.Attributes).Item2.ToUList();
                table.Attributes.InsertRange(0, table.Keys);
            }
            ERDiagram.Entities.ForEach(e => e.Table = null);
        }

       
        private void FillProperties(Table table, List<Attribute> atts, UList<Property> list, bool make_key = false)
        {
            foreach (var attribute in atts)
            {
                if (!attribute.Multiple && attribute.Attributes.Any())
                    FillProperties(table, attribute.Attributes, list, );
                else
                    list.Add(PropertyOf(attribute, table, make_key));
            }
        }
		
        private void FillAttributes(List<Attribute> atts, List<Attribute> list)
        {
            foreach (var attribute in atts)
            {
                if (!attribute.Multiple && attribute.Attributes.Any())
                    FillAttributes(attribute.Attributes, list);
                else
                    list.Add(attribute);
            }
        }

        public bool HasMult(List<Attribute> attributes)
        {
            foreach (Attribute a in attributes)
            {
                if (a.Multiple)
                    return true;
                if (a.Attributes.Any())
                    if (HasMult(a.Attributes))
                        return true;
            }
            return false;
        }

        private (List<Attribute>, List<Attribute>) SplitKey(List<Attribute> attributes)
			=> (attributes.FindAll(a => a.Key).ToList(), attributes.FindAll(a => !a.Key).ToList());

		private (List<Property>, List<Property>) SplitMult(List<Property> properties)
			=> (properties.FindAll(a => a.Multiple).ToList(), properties.FindAll(a => !a.Multiple).ToList());

		private (List<Attribute>, List<Attribute>) SplitMult(List<Attribute> attributes)
			=> (attributes.FindAll(a => a.Multiple).ToList(), attributes.FindAll(a => !a.Multiple).ToList());

		private (List<Table>, List<Table>) SplitMany(List<RelationEntity> entities)
			=> (entities.FindAll(e => e.Many).ToList().ConvertAll(e => e.Entity.Table),
			entities.FindAll(e => !e.Many).ToList().ConvertAll(e => e.Entity.Table));

		private List<Property> MakeFKs(Table table, Table src, bool key = false, string pre = "")
		{
			return src.Keys.ConvertAll(k => ForgienKey(k, table, key, prefix: pre));
		}

		private List<Table> GetOriginals(Table table)
		{
			if(mirror_tables.ContainsKey(table))
			{
				var originals = mirror_tables[table].ToUList();
                for (var i = 0; i < originals.Count; i++)
                {
					var x = originals[i];
					originals.RemoveAt(i);
					originals.AddRange(GetOriginals(x));
                }
				return originals;
            }	
			return new List<Table> { table };
		}

		private void AddTableRelations(Table table, List<Table> tables, TableRelationType type)
		{
            foreach (var tb in tables)
            {
				table.TableRalations.Add(new TableRalation() { Table = tb, RelationType = type });
            }
        }

        private void Watchkeys(Table t, List<Property> des, string prfx = "", bool key = false)
        {
            t.Keys.ItemAdded += (k) => des.Add(ForgienKey(k, t, key, prefix: prfx));
        }

		private void WatchKeysOrg(Table table, List<Property> des, bool dup = false)
		{
			table.Keys.ItemAdded += k => des.Add(k.Clone(table, dup: dup));
		}

        private void WatchTable(Table t, List<Entity> ens, bool keys, bool atrs, bool rels)
        {
            ens = new List<Entity>(ens);
            if (keys)
            {
                t.Keys.ItemAdded += (k) => ens.ForEach(en => en.Table.Keys.Add(k.Clone(en.Table)));
            }
            if (atrs)
            {
                t.Attributes.ItemAdded += (a) => ens.ForEach(en => en.Table.Attributes.Add(a.Clone(en.Table)));
            }
            if (rels)
            {
                t.TableRalations.ItemAdded += (r) => ens.ForEach(en => en.Table.TableRalations.Add(r));
            }
        }

        public Property PropertyOf(Attribute a, Table t, bool make_key = false, string pre = "")
		{
			bool key = make_key ? !a.Multiple : a.Key;
			return new Property()
			{
				Name = pre + a.Name,
				Key = key,
				Unique = key,
				Nullable = !key,
				Multiple = a.Multiple,
				Table = t,
				Attribute = a,
				DataType = a.Key ? DataType.Int : DataType.VarChar
			};
		}

		public Property ForgienKey(Property p, Table t, bool k = true, bool pre = true, string prefix = "")
		{
			Property Property = p.Clone(t, pre ? $"{p.Table.Name}{prefix}_" : "");
			Property.Key = k;
			Property.ForgienKey = p.Duplicate ? p.Original : p;
			Property.ForgienKey.LinkedTypes.Add(Property);
			return Property;
		}

	}
	*/
    /*
	internal class ERAnalyser
	{
		public ERDiagram ERDiagram { get; }
		public Database Database { get; } = new Database();
		public ERAnalyser(ERDiagram eRDiagram)
		{
			ERDiagram = eRDiagram;
			eRDiagram.Entities.ForEach(CreateTables);
			eRDiagram.Branches.ForEach(ExpandBranch);
			eRDiagram.Relations.ForEach(ExpandRelations);
			//eRDiagram.Branches.ForEach(ExpandBranch);
			eRDiagram.Unions.ForEach(ExpandUnion);
			ExpandMult();
			FinalizeDatabase();
		}

		public void CreateTables(Entity entity)
		{
			Table table = new Table() { Name = entity.Name, Weak = entity.Weak };
			entity.Table = table;
			FillTable(table, entity.Attributes);
			Database.Tables.Add(table);
		}

		public void FillTable(Table table, List<Attribute> attributes)
		{
			ExpandPositive(table, attributes);
		}

		public void ExpandPositive(Table table, List<Attribute> attributes)
		{
			foreach (Attribute a in attributes)
			{
				if (a.Drived) continue;
				if (a.Multiple)
				{
					table.Attributes.Add(PropertyOf(a, table));
					continue;
				}
				if (a.Attributes.Any())
				{
					if(a.Key)
                        ExpandNegative(table, a.Attributes);
					else
                        ExpandPositive(table, a.Attributes);
                    continue;
				}
				if (a.Key)
					table.Keys.Add(PropertyOf(a, table));
				else
					table.Attributes.Add(PropertyOf(a, table));
			}
		}


		public void ExpandNegative(Table table, List<Attribute> attributes)
		{
			foreach (Attribute a in attributes)
			{
                if (a.Drived) continue;
				if(a.Multiple)
				{
					Table newTable = new Table() 
					{
                        Name = $"{table.Name}_{a.Name}",
                        Weak = true
                    };
					newTable.Keys = new UList<Property>(table.Keys.ConvertAll(k => ForgienKey(k, newTable, true)));
                    Database.Tables.Add(newTable);
                    if (a.Attributes.Any())
					{
						ExpandNegative(table, a.Attributes);
					}
					else
					{
						newTable.Keys.Add(PropertyOf(a, newTable, true));
					}
					Watchkeys(table, newTable);
					continue;
                }
                if (a.Attributes.Any())
                {
                    ExpandNegative(table, a.Attributes);
                    continue;
                }
                table.Keys.Add(PropertyOf(a, table, true));
			}
		}

		public void ExpandRelations(Relation relation)
		{
			if (HasMult(relation.Attributes))
			{
				for (int i = 0; i < relation.Entities.Count; i++)
				{
					for (int j = i + 1; j < relation.Entities.Count; j++)
						ExpandRelationNew(relation.Name, relation.Entities[i], relation.Entities[j], relation.Attributes);
				}
			}
			else
			{
				for (int i = 0; i < relation.Entities.Count; i++)
				{
					for (int j = i + 1; j < relation.Entities.Count; j++)
						if (relation.Weak && !relation.Entities[i].Entity.Weak && !relation.Entities[j].Entity.Weak)
							ExpandRelationNew(relation.Name, relation.Entities[i], relation.Entities[j], relation.Attributes);
						else
							ExpandRelation(relation.Name, relation.Entities[i], relation.Entities[j], relation.Attributes);
				}
			}
		}

		public bool HasMult(List<Attribute> attributes)
		{
			foreach (Attribute a in attributes)
			{
				if (a.Multiple)
					return true;
				if (a.Attributes.Any())
					if (HasMult(a.Attributes))
						return true;
			}
			return false;
		}

		public void ExpandRelation(string name, RelationEntity r1, RelationEntity r2, List<Attribute> attributes)
		{
			//if (r1.Entity.Weak && r2.Entity.Weak) return;
			if (!r2.Many) // && !r2.Entity.Weak
			{
				Table table = r1.Entity.Table;
				if (r1.Entity.Weak)
					//table.KeysExtended.AddRange(r2.Entity.Table.Keys.ConvertAll(k => ForgienKey(k, table, prefix : $"_{name}_")));
					table.Keys.AddRange(r2.Entity.Table.Keys.ConvertAll(k => ForgienKey(k, table, prefix : $"_{name}_")));
                else
                    table.Attributes.AddRange(r2.Entity.Table.Keys.ConvertAll(k => ForgienKey(k, table, false, prefix: $"_{name}_")));
				table.TableRalations.Add(new TableRalation() { Table = r2.Entity.Table, RelationType = r1.Many ? TableRelationType.OneMany : TableRelationType.OneOne });
				if (attributes.Any())
					FillTable(table, attributes);
			}
			else if (!r1.Many) // && !r1.Entity.Weak
			{
				Table table = r2.Entity.Table;
				if (r2.Entity.Weak)
					//table.KeysExtended.AddRange(r1.Entity.Table.Keys.ConvertAll(k => ForgienKey(k, table, prefix: $"_{name}_")));
					table.Keys.AddRange(r1.Entity.Table.Keys.ConvertAll(k => ForgienKey(k, table, prefix: $"_{name}_")));
				else
					table.Attributes.AddRange(r1.Entity.Table.Keys.ConvertAll(k => ForgienKey(k, table, false, prefix: $"_{name}_")));
				table.TableRalations.Add(new TableRalation() { Table = r1.Entity.Table, RelationType = r2.Many ? TableRelationType.OneMany : TableRelationType.OneOne });
				if (attributes.Any())
					FillTable(table, attributes);
			}
			else
			{
				ExpandRelationNew(name, r1, r2, attributes);
			}
		}

		private void Watchkeys(Table t, Table dis, string prfx = "")
		{
            t.Keys.ItemAdded += (k) => dis.Keys.Add(ForgienKey(k, t, true,prefix: prfx));
        }

		public void ExpandRelationNew(string name, RelationEntity r1, RelationEntity r2, List<Attribute> attributes)
		{
			Table table = new Table()
			{
				Name = $"{r1.Entity.Name}_{name}_{r2.Entity.Name}",
				Weak = true
			};
			if(r1.Entity != r2.Entity)
			{
				table.Keys.AddRange(r1.Entity.Table.Keys.ConvertAll(k => ForgienKey(k, table)));
				table.Keys.AddRange(r2.Entity.Table.Keys.ConvertAll(k => ForgienKey(k, table)));
				var reltyp = r1.Many || r2.Many ? TableRelationType.ManyMany : TableRelationType.OneOne;
				table.TableRalations.Add(new TableRalation() { Table = r1.Entity.Table, RelationType = reltyp});
				table.TableRalations.Add(new TableRalation() { Table = r2.Entity.Table, RelationType = reltyp });
                Watchkeys(r1.Entity.Table, table);
                Watchkeys(r2.Entity.Table, table);
            }
			else
			{
				table.Keys.AddRange(r1.Entity.Table.Keys.ConvertAll(k => ForgienKey(k, table, prefix : "1")));
				table.Keys.AddRange(r2.Entity.Table.Keys.ConvertAll(k => ForgienKey(k, table, prefix : "2")));
				table.TableRalations.Add(new TableRalation() { Table = r1.Entity.Table, RelationType = TableRelationType.ManyMany });
                Watchkeys(r1.Entity.Table, table, "1");
                Watchkeys(r2.Entity.Table, table, "2");
            }
			if (attributes.Any())
			{
                ExpandNegative(table, attributes);
            }
			Database.Tables.Add(table);
		}

		private void WatchTable(Table t, List<Entity> ens, bool keys, bool atrs, bool rels)
		{
			ens = new List<Entity>(ens);
			if (keys)
			{
                t.Keys.ItemAdded += (k) => ens.ForEach(en => en.Table.Keys.Add(k.Clone(en.Table)));
			}
			if (atrs)
			{
                t.Attributes.ItemAdded += (a) => ens.ForEach(en => en.Table.Attributes.Add(a.Clone(en.Table)));
            }
			if (rels)
			{
                t.TableRalations.ItemAdded += (r) => ens.ForEach(en => en.Table.TableRalations.Add(r));
            }
		}

		public void ExpandBranch(Branch b)
		{
			Table table = b.Super.Table;
			if (b.Must && !b.Overlap)
			{
				List<Table> join_tables = new List<Table>();
				foreach (Entity e in b.Subs)
				{
					e.Table.Attributes.InsertRange(0, table.Attributes.ConvertAll(a => a.Clone(e.Table)));
					e.Table.Keys.InsertRange(0, table.Keys.ConvertAll(a => a.Clone(e.Table)));
					//e.Table.KeysExtended.InsertRange(0, table.KeysExtended.ConvertAll(a => a.Clone(e.Table)));
					//e.Table.TableRalations.AddRange(table.TableRalations);
					join_tables.Add(e.Table);
				}
				Database.Tables.Remove(table);
				table.InnerJoin = true;
				Database.InnerJoinTables.Add(table, join_tables);
				WatchTable(table, b.Subs, true, true, false);
			}
			else
			{
				foreach (Entity e in b.Subs)
				{
					e.Table.Keys.InsertRange(0, table.Keys.ConvertAll(k => ForgienKey(k, e.Table)));
					//e.Table.TableRalations.Add(new TableRalation() { Table = table, RelationType = TableRelationType.OneOne});
				}
            }
		}

		public void ExpandUnion(Union u)
		{
			Table t = u.Sub.Table;
			foreach (Entity e in u.Supers)
			{
				e.Table.Attributes.AddRange(t.Keys.ConvertAll(k => ForgienKey(k, e.Table, false)));
				e.Table.TableRalations.Add(new TableRalation() { Table = t, RelationType = TableRelationType.OneOne });
			}
		}

		public void ExpandMult()
		{
			foreach (Table table in new List<Table>(Database.Tables))
			{
				IEnumerable<Attribute> mult = table.Attributes.FindAll(a => a.Multiple).ConvertAll(a => a.Attribute);
				table.Attributes.RemoveAll(a => a.Multiple);
				ExpandMult(table, mult);
			}
		}

		public void ExpandMult(Table table, IEnumerable<Attribute> mult)
		{
			foreach (Attribute a in mult)
			{
				Table t = new Table()
				{
					Name = $"{table.Name}_{a.Name}",
					Weak = true
				};
				t.Keys.AddRange(table.Keys.ConvertAll(k => ForgienKey(k, t, true, false)));
				t.TableRalations.Add(new TableRalation() { Table = table, RelationType = TableRelationType.ManyOne });
				if (a.Attributes.Any())
					ExpandNegative(t, a.Attributes);
				else
					t.Keys.Add(PropertyOf(a, t));
				t.Keys.ForEach(k => k.Key = true);
				Database.Tables.Add(t);
			}
		}

		public Property PropertyOf(Attribute a, Table t, bool make_key = false)
		{
			bool key = make_key ? true : a.Key;
			return new Property()
			{
				Name = a.Name,
				Key = key,
				Unique = key,
				Nullable = !key,
				Multiple = a.Multiple,
				Table = t,
				Attribute = a,
				DataType = a.Key ? DataType.Int : DataType.VarChar
			};
		}

		public Property ForgienKey(Property p, Table t, bool k = true, bool pre = true, string prefix = "")
		{
			Property Property = p.Clone(t, pre ? $"{p.Table.Name}{prefix}_" : "");
			Property.Key = k;
			Property.ForgienKey = p;
			
			return Property;
		}

		public void FinalizeDatabase()
		{
			foreach (Table table in Database.Tables)
			{
				table.Attributes.InsertRange(0, table.Keys);
			}
            foreach (Table table in Database.InnerJoinTables.Keys)
			{
				table.Attributes.InsertRange(0, table.Keys);
			}
            ERDiagram.Entities.ForEach(e => e.Table = null);
        }

	}
	*/
}

