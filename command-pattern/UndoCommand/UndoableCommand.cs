using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pattern_command.UndoCommand
{
    public interface UndoableCommand : Command
    {
        void UnExecute(); 
    }
}