using proxy_pattern;

namespace pattern_proxy
{
    public class RealBook : IBook
    {
        public string fileName {get;}

        public RealBook(string fileName)
        {
            this.fileName = fileName;
            Load();
        }
        private void Load() {
            System.Console.WriteLine("Loading book " + fileName);
        }
        public void Show() {
            System.Console.WriteLine("Showing book " + fileName);
        }
    }
}