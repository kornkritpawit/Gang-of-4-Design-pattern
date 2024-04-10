// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace composite_pattern
// {
//     public class Group
//     {
//         private List<Shape> _shapes;
//         public Group() {
//             _shapes = new List<Shape>();
//         }

//         public void Add(Shape shape) {
//             _shapes.Add(shape);
//         }

//         public void Render() {
//             foreach (var shape in _shapes)
//             {
//                 shape.Render();
//             }
//         }
//     }
// }