using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Views.Scenes.TEScene
{
    internal partial class TableEdit
    {
        

        public void Set(Table table) 
        {  
            NameBox.Text = table.Name;
        }

        public void Update(Table table, Database database)
        {
            Valid(table, database);
            table.Name = NameBox.Text;
        }


        private void Valid(Table table, Database database)
        {
            if (!NameBox.Text.Any() ||
                NameBox.Text.Any(c => !char.IsLetterOrDigit(c) && c != '_') ||
                !char.IsLetter(NameBox.Text[0]))
            {
                throw new InvalidOperationException("Name Not Valid !");
            }
            if(NameBox.Text != table.Name && database.Tables.Count(t => t.Name == NameBox.Text) >= 1)
            {
                throw new InvalidOperationException("Duplicate Name !");
            }
        }
    }
}
