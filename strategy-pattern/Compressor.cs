namespace pattern_strategy
{
    public interface Compressor
    {
        // byte[] Compress(byte[] image); ถ้างานจริง
        void Compress(string fileName);
    }
}