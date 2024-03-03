using System;
using pattern_command;
using pattern_command.UndoCommand;

namespace pattern_command
{
    class Program
    {
        static void Main(string[] args)
        {
            var button1 = new Button();
            var customerService = new CustomerService();
            var addCustomerCommand = new AddCustomerCommand(customerService);
            button1.OnClick = addCustomerCommand;
            // button1.Click();

            var compositeCommand = new CompositeCommand();
            compositeCommand.Commands.Add(addCustomerCommand);
            compositeCommand.Commands.Add(new AddOrderCommand(new OrderService()));

            button1.OnClick = compositeCommand;
            // button1.Click();

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
            var UndoCommand = new UndoCommand.UndoCommand(history); //namespace ซ้ำกัน
            undoButton.OnClick = UndoCommand;
            undoButton.Click();
            Console.WriteLine(htmlDocument);

        }
    }
}