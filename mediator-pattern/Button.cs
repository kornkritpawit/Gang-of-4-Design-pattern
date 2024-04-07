// using mediator_pattern;

// namespace pattern_mediator
// {
//     public class Button : UIControl
//     {
//         private bool _isEnabled;
//         public Button(DialogBox owner) : base(owner)
//         {
//         }
//         public bool IsEnabled
//         {
//             get
//             {
//                 return _isEnabled;
//             }
//             set
//             {
//                 _isEnabled = value;
//                 _owner.OnChanged(this);
//             }
//         }
//     }
// }