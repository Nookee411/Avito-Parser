using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Avito_Parser.Core;

namespace Avito_Parser.Avito
{
    class AvitoNote
    {
        public string Name { get; set; }
        
        public string Price { get; set; }

        public string Description { get; set; }

        public AvitoNote(string name, string price)
        {
            this.Name = name;
            this.Price = price;
        }
        public AvitoNote(string name)
        { 
            this.Name = name;
        }
        public AvitoNote()
        {

        }

        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
}
