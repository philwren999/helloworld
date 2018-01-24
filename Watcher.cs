using System;
using System.Net;
using System.Net.Http;

namespace helloworld
{
    public class Watcher
    {
        internal void Go(string url)
        {
            var httpClient = new HttpClient();
            var result = httpClient.GetAsync(requestUri: url).Result;
            var content = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(value: content);
        }
    }
}
