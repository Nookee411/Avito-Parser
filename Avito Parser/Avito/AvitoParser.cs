using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Avito_Parser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Avito_Parser.Avito
{
    class AvitoParser : IParser<AvitoNote[]>
    {
        public AvitoNote[] Parse(IHtmlDocument document)
        {
            var items = document.QuerySelectorAll("div").Where(item => item.ClassName!=null && item.ClassName== "description item_table-description");
            
            var list = new List<AvitoNote>();
            foreach(var item in items)
            {
                list.Add(new AvitoNote(item.Children.ElementAt(0).TextContent, item.Children.ElementAt(1).TextContent));
            }
            return list.ToArray();
        }
    }
}
