namespace AlgorithmDomain
{
    interface IDistinctCountAlgorithm<in T>: ISequentialAlgorithm<T>
    {
        int GetNumberOfDistinctElements(); 
    }
}
