using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avito_Parser.Core
{
    interface IParserSettings
    {
        string baseUrl { get; set; }
        string prefix { get; set; }

        int startPage { get; set; }
        int endPage { get; set; }
        
    }
}
