using System;
using System.Runtime.Intrinsics.Arm;
using composite_pattern;

namespace pattern_composite
{
    class Program
    {

        // static void Main(string[] args)
        // {
        //     var shape1 = new Shape();
        //     var shape2 = new Shape();
        //     var group1 = new Group();
        //     group1.Add(shape1);
        //     group1.Add(shape2);

        //     var shape3 = new Shape();
        //     var shape4 = new Shape();
        //     var group2 = new Group();

        //     group2.Add(shape3);
        //     group2.Add(shape4);

        //     var topGroup = new Group(); //เอา Group ใส่ group ไม่ได้
        //     topGroup.Add(group1);
        //     topGroup.Add(group2); //
        // }

        // static void Main(string[] args)
        // {
        //     var shape1 = new Shape();
        //     var shape2 = new Shape();

        //     var group1 = new Group();
        //     group1.Add(shape1);
        //     group1.Add(shape2);

        //     var shape3 = new Shape();
        //     var shape4 = new Shape();
        //     var group2 = new Group();
        //     group2.Add(shape3);
        //     group2.Add(shape4);

        //     var topGroup = new Group();
        //     topGroup.Add(group1);
        //     topGroup.Add(group2);
        //     topGroup.Render();
        // }

        static void Main(string[] args)
        {
            var shape1 = new Shape();
            var shape2 = new Shape();

            var group1 = new Group();
            group1.Add(shape1);
            group1.Add(shape2);

            var shape3 = new Shape();
            var shape4 = new Shape();
            var group2 = new Group();
            group2.Add(shape3);
            group2.Add(shape4);

            var topGroup = new Group();
            topGroup.Add(group1);
            topGroup.Add(group2);
            topGroup.Render();
            topGroup.Move();
        }

    }
}