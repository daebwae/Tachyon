using System.Collections.Generic;

namespace Shared
{
    public interface ISequence<out T>
    {
        IEnumerable<T> Get();
        void StreamTo(ISequentialAlgorithm<T> dataSink);
    }
}
