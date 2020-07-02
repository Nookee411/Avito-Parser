using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avito_Parser.Core
{
    class Post
    {
        string name;
        int price;

        public Post(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        string Name { get; set; }
        int Price { get; set; }
    }
}
