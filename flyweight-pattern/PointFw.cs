using flyweight_pattern;

namespace pattern_flyweight
{
    public class Point
    {
        private int x; // 4 bytes
        private int y; // 4 bytes
        private PointIcon icon; // เก็บแยก Structure ออกไป
        public Point(int x, int y, PointIcon icon)
        {
            this.x = x;
            this.y = y;
            this.icon = icon;
        }
        public void Draw() {
            System.Console.WriteLine($"{icon.type} at ({x}, {y})");
        }
    }
}