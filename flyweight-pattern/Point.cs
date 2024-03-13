namespace pattern_flyweight
{
    public class Point
    {
        private int x; // 4 bytes
        private int y; // 4 bytes
        private IconType type; // 4 bytes
        private byte[] icon; // 20 KB ==> 1000 point = 20MB (กิน mem เยอะมาก)
        // ใน Point มี Icon ถ้าหลาย Point icon ก็จะซ้ำๆ กันมาก

        public Point(int x, int y, IconType type, byte[] icon)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            this.icon = icon;
        }
        public void Draw() {
            System.Console.WriteLine($"{type} at ({x}, {y})");
        }
    }
}