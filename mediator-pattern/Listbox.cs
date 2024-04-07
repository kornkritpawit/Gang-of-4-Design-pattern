// using mediator_pattern;

// namespace pattern_mediator
// {
//     public class ListBox : UIControl
//     {
//         private string _selection;
//         public ListBox(DialogBox owner) : base(owner)
//         {
//         }
//         public string Selection
//         {
//             get
//             {
//                 return _selection;
//             }
//             set
//             {
//                 _selection = value;
//                 _owner.OnChanged(this);
//             }
//         }
//     }
// }