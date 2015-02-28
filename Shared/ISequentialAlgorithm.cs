namespace Shared
{
    public interface ISequentialAlgorithm<in T>
    {
        void Add(T item); 
    }
}
