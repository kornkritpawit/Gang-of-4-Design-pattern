using System;
using visitor_pattern;

namespace pattern_visitor
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     var htmlDocument = new HtmlDocument();
        //     htmlDocument.Add(new HeadingNode());
        //     htmlDocument.Add(new AnchorNode());
        //     htmlDocument.Highlight();
        // }
        static void Main(string[] args)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Add(new HeadingNode());
            htmlDocument.Add(new AnchorNode());

            htmlDocument.Execute(new HighlightOperation());
            htmlDocument.Execute(new PlainTextOperation());
        }
    }
}