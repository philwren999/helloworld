using System;
using HtmlAgilityPack;

namespace helloworld
{
    internal class HtmlImage
    {
        public string Src { get; }

        public HtmlImage(HtmlNode node)
        {
            Src = node.Attributes["src"]?.Value;

            //Console.WriteLine($"{i:000};NodeType:{node.NodeType};Name:{node.Name};SRC:{src?.Value}");

/*             if (Src == null) {
                foreach(var att in node.Attributes)
                {
                    Console.WriteLine($"+ {att.Name}: {att.Value}");
                }
            } */
        }

        public bool Valid()
        {
            return !string.IsNullOrEmpty(Src); 
        }

        public override string ToString()
        {
            return $"Img;Src='{Src}'";
        }
    }
}