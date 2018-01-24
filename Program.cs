using System;

namespace helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var b= new Watcher();
            b.Go(url: "http://www.bbc.co.uk");

            Console.WriteLine("=======================");
            Console.ReadLine();
        }
    }
}
