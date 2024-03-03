namespace pattern_command.UndoCommand
{
    public class HtmlDocument
    {
        public string Content {get; set;}
        public void MakeBold() {
            Content = $"<b>{Content}</b>";
        }

        public override string ToString()
        {
            return Content;
        }
    }
}