using System;
using System.Net;
using System.Net.Http;
using HtmlAgilityPack;
using System.Linq;

namespace helloworld
{
    public class Watcher
    {
        private string _content = string.Empty;
        private HtmlDocument _htmlDocument = null;
        
        public Watcher Fetch(string url)
        {
            var httpClient = new HttpClient();
            var result = httpClient.GetAsync(requestUri: url).Result;
            _content = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(value: _content);

            return this;
        }

        public Watcher Parse()
        {
            if (_content == null) throw new Exception("Failed to parse. No content.");

            _htmlDocument = new HtmlDocument();
            _htmlDocument.LoadHtml(_content);

            var nodes = _htmlDocument.DocumentNode.SelectNodes("//img");
            
            var i = 0;
            foreach(var node in nodes)
            {
                var src = node.Attributes["src"];

                Console.WriteLine($"{i:000};NodeType:{node.NodeType};Name:{node.Name};SRC:{src?.Value}");

                foreach(var att in node.Attributes)
                {
                    Console.WriteLine($"+ {att.Name}: {att.Value}");
                }
                Console.WriteLine(node.InnerText);
                i++;
            }

            return this;
        }
    }
}
