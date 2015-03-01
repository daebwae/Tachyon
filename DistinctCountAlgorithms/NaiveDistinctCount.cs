using System;
using System.Collections.Generic;

namespace DistinctCountAlgorithms
{
    [Serializable]
    public class NaiveDistinctCount<T>: IDistinctCountAlgorithm<T>
    {
        private readonly HashSet<T> _distinctElements = new HashSet<T>();

        public int GetNumberOfDistinctElements()
        {
            return _distinctElements.Count; 
        }

        public void Add(T item)
        {
            _distinctElements.Add(item); 
        }

    }
}
