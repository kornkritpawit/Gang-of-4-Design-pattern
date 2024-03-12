using adapter_pattern;

namespace pattern_adapter.AvaFilter
{
    public class Caramel
    { //Assume third party
        public void Init() {
            // Do some task on Init
        }
        public void Render(Image image) {
            System.Console.WriteLine("Applying caramel filter");
        }
    }
}