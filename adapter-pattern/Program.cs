using System;
using adapter_pattern;
using pattern_adapter.AvaFilter;

namespace pattern_adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var image1 = new Image();
            var imageView = new ImageView(image1);
            imageView.Apply(new VividFilter());
            // imageView.Apply(new Caramel()); // Error (third party implement ไม่ได้)
        }

        // static void Main(string[] args)
        // {
        //     var image1 = new Image();
        //     var imageView = new ImageView(image1);
        //     imageView.Apply(new VividFilter());
        //     // imageView.Apply(new Caramel()); // Error (third party implement ไม่ได้)
        //     // มี Adaptee ที่เป็น class Caramel แล้วก็มา Implement เป็น Adapter ใหม่ให้ใช้ Filter ได้
        //     imageView.Apply(new CaramelFilter(new Caramel())); //รับเป็นทอดๆ ( Composition )
        //     imageView.Apply(new CaramelAdapter()); //Inheritance
        //     // Choose composition over Inheritance
        // }
    }
}