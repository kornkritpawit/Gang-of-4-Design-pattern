// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using pattern_mediator;

// namespace pattern_mediator
// {
//     public class TextBoxBadNoMediator
//     {
//         private string _text;
//         private Button _saveButton;
//         private TextBoxBadNoMediator(Button saveButton) {
//             _saveButton = saveButton;
//         }
//         public string Text
//         {
//             get
//             {
//                 return _text;
//             }
//             set
//             {
//                 _text = value;
//                 if (!string.IsNullOrEmpty(_text)) {
//                     _saveButton.IsEnabled = true;
//                 }
//             }
//         }
//     }
// }