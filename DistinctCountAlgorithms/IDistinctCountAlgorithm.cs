using Shared;

namespace DistinctCountAlgorithms
{
    public interface IDistinctCountAlgorithm<in T>: ISequentialAlgorithm<T>
    {
        int GetNumberOfDistinctElements(); 
    }

}
