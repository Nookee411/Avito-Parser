using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace Avito_Parser.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader htmlLoader;
        bool isActive;

        #region Properties
        public IParser<T> Parser
        {
            get { return parser; }
            set { parser = value; }
        }
        public IParserSettings ParserSettings
        {
            get { return parserSettings; }
            set
            {
                parserSettings = value;
                htmlLoader = new HtmlLoader(parserSettings);
            }
        }

        public bool IsActive => isActive;

        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnComleted;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser, IParserSettings parserSettings):this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }

        public void Abort()
        {
            isActive = false;
        }

        private async void Worker()
        {
            for(int i = parserSettings.startPage;i<=parserSettings.endPage;i++)
            {
                if(!isActive)
                {
                    OnComleted?.Invoke(this);
                    return;
                }
                var source = await htmlLoader.GetSourceByPageId(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);
                var result = parser.Parse(document);

                OnNewData?.Invoke(this,result);
            }
            OnComleted?.Invoke(this);
            isActive = false;
        }
    }
}
