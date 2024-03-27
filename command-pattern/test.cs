using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pattern_command
{
    public class test
    {
        static void Main(string[] args)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Content = "Hello Design Pattern!";
            Console.WriteLine(htmlDocument);
            var history = new History();
            var makeBoldCommand = new MakeBoldCommand(htmlDocument, history);
            var boldButton = new Button();
            boldButton.OnClick = makeBoldCommand;
            boldButton.Click();
            Console.WriteLine(htmlDocument);

            var undoButton = new Button();
            var UndoCommand = new UndoCommand(history);
            undoButton.OnClick = UndoCommand;
            undoButton.Click();
            Console.WriteLine(htmlDocument);
        }
    }
    }
}