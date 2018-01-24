using System;

namespace helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var b= new Watcher();
            b.Fetch(url: "http://www.bbc.co.uk")
                .Parse();

            Console.WriteLine("=======================");
        }
    }
}
