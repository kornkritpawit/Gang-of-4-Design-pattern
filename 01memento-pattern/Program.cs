// See https://aka.ms/new-console-template for more information

using System;

namespace pattern_memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var stateManager = new CareTaker<Editor>();
            var editor = new Editor("T1", "Text 1", 14, "TH SarabunPSK");
            Console.WriteLine(editor);
            var state1 = editor.CreateState();
            stateManager.PushMemento(state1);
            editor = new Editor("T2", "Text 2", 15, "TH SarabunPSK");
            Console.WriteLine(editor);
            stateManager.PushMemento(editor.CreateState());
            editor = new Editor("T3", "Text 3", 16, "TH Sarabun New");
            Console.WriteLine(editor);
            var undoState = stateManager.Undo();
            editor.RestoreState(undoState);
            Console.WriteLine(editor);
            editor.RestoreState(stateManager.Undo());
            Console.WriteLine(editor);
            editor.RestoreState(stateManager.Redo());
            Console.WriteLine(editor);
            editor = new Editor("T3", "Text 3", 16, "TH Sarabun New");
            Console.WriteLine(editor);
            stateManager.PushMemento(editor.CreateState());
            editor = new Editor("T4", "Text 4", 17, "TH Sarabun New");
            Console.WriteLine(editor);
            editor.RestoreState(stateManager.Undo());
            Console.WriteLine(editor);
        }
    }
}