using System;
using System.Runtime.Intrinsics.Arm;
using composite_pattern;

namespace pattern_composite
{
    class Program
    {
        static void Main(string[] args)
        {
            // var shape1 = new Shape();
            // var shape2 = new Shape();

            var shape1 = new ShapeComposite();
            var shape2 = new ShapeComposite();

            // var group1 = new Group();
            // var group1 = new GroupCompositeBad();
            var group1 = new GroupComposite();
            group1.Add(shape1);
            group1.Add(shape2);

            var shape3 = new ShapeComposite();
            var shape4 = new ShapeComposite();
            // var group2 = new Group();
            // var group2 = new GroupCompositeBad();
            var group2 = new GroupComposite();
            group1.Add(shape3);
            group1.Add(shape4);

            // var topGroup = new Group(); //เอา Group ใส่ group ไม่ได้
            // topGroup.Add(group1);
            // topGroup.Add(group2); //

            // var topGroup = new GroupCompositeBad();
            var topGroup = new GroupComposite();
            topGroup.Add(group1);
            topGroup.Add(group2);
            topGroup.Render();
            topGroup.Move();

        }
    }
}