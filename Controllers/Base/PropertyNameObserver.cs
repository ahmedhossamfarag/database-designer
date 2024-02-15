using DatabaseDesigner.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDesigner.Controllers.Base
{
    class PropertyNameObserver
    {
        private bool remove = true;
        public Property ChangeProperty { get; set; }
        public Property ObserveProperty { get; set; }
        public string Pre { get; set; }
        public bool Dup { get; set; }


        public void ChangeName(string name)
        {
            remove = false;
            ChangeProperty.Name = Pre + name + (Dup ? "2" : "");
            remove = true;
        }

        public void RemoveObserver(string name)
        {
            if (remove)
                ObserveProperty.NameChanged -= this.ChangeName;
        }
    }
}
