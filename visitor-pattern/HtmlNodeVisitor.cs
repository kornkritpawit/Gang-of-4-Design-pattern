using visitor_pattern;

namespace pattern_visitor
{
    public interface HtmlNode
    {
        void Execute(Operation operation);
    }
}