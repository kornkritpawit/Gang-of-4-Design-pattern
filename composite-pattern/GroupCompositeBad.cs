// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace composite_pattern
// {
//     public class Group
//     {
//         private List<object> _objects;
//         public Group()
//         {
//             _objects = new List<object>();
//         }
//         public void Add(object obj)
//         {
//             _objects.Add(obj);
//         }
//         public void Render()
//         {
//             foreach (var obj in _objects)
//             { // ถ้ามี obj 100 ชนิด ก็ต้องใส่ 100 case
//                 if (obj is Shape) {
//                     ((Shape)obj).Render(); //Cask Object to Shape
//                 }
//                 if (obj is Group) {
//                     ((Group)obj).Render();
//                 }
//             }
//         }
//     }
// }