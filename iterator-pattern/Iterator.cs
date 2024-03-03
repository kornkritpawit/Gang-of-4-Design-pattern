namespace pattern_iterator
{
    public interface Iterator<T>
    {
        bool HasNext();
        T Current();
        void Next();
    }
}