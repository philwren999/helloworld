using System;
using System.Net;
using System.Net.Http;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;

namespace helloworld
{
    public class Watcher
    {
        private string _content = string.Empty;
        private HtmlDocument _htmlDocument = null;
        private List<HtmlImage> _imageList = new List<HtmlImage>();        
        
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

            return this;
        }

        public Watcher FindImages()
        {
            var nodes = _htmlDocument.DocumentNode.SelectNodes("//img");
            
            foreach(var node in nodes)
            {
                var img = new HtmlImage(node);
                if (!img.Valid()) continue;
                _imageList.Add(img);

                Console.WriteLine(img);
            }

            return this;
        }
    }
}
