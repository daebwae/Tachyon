using System.Collections.Generic;

namespace AlgorithmDomain
{
    interface ISequence<out T>
    {
        IEnumerable<T> Get();
        void StreamTo(ISequentialAlgorithm<T> dataSink);
    }
}
