using System;
using mediator_pattern;

namespace pattern_mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an article dialog
            // Simulate changes        
            var articleDialog = new ArticleDialogBox();
            articleDialog.SimulateChanges();

            // var articleDialog = new ArticleDialogBoxObserver();
            // articleDialog.SimulateChanges();
        }
    }
}