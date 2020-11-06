
using System.Collections.Generic;

namespace _1.Prototype
{
   public class SandwichMenu
    {
        private readonly Dictionary<string, SandwichPrototype> menu;

        public SandwichMenu()
        {
            this.menu = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name]
        {
            get
            {
                return this.menu[name];
            }
            set
            {
                this.menu.Add(name, value);
            }
        } 
    }
}
