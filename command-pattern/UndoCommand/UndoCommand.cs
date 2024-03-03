using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pattern_command.UndoCommand
{
    public class UndoCommand : Command
    {
        private readonly History _history;

        public UndoCommand(History history)
        {
            _history = history;
        }

        public void Execute()
        {
            if (_history.Size > 0)
            {
                var lastCommand = _history.Pop();
                lastCommand.UnExecute();
            }

        }
    }
}