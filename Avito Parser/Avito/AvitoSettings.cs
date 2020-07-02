using Avito_Parser.Core;

namespace Avito_Parser.Avito
{
    class AvitoSettings : IParserSettings
    {
        public AvitoSettings(int start,int end)
        {
            this.startPage = start;
            this.endPage = end;
        }
        public string baseUrl { get; set; } = "https://www.avito.ru/kirovskaya_oblast_kirov/velosipedy?s=104";
        public string prefix { get; set; } = "&{currentID}";
        public int startPage { get; set; }
        public int endPage { get; set; }
    }
}
