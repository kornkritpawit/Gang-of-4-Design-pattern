namespace pattern_proxy
{
    public class Book
    {
        public string fileName {get;}

        public Book(string fileName)
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