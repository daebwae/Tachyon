using System;

namespace DistinctCountAlgorithms
{
    /// <summary>
    /// This here is not really a HyperLogLog algorithm; it's an algorithm that 
    /// represents the main idea of the HyperLogLog algorithm for the short time 
    /// of a demo 
    /// </summary>
    [Serializable]
    public class NaiveHyperLogLogForDemo<T>: IDistinctCountAlgorithm<T>
    {
        // ReSharper disable once RedundantDefaultMemberInitializer
        // I love you Resharper, but some things you find redudant helps people understand
        private int _max = 0; 

        public void Add(T item)
        {
            int hash = item.GetHashCode();
            const int bitsInInt = sizeof (int)*8;

            int numberOfTrailingZeros = 0;
            int iNumberOfTrailingZeros = 1; 

            for (int i = 1; i <= bitsInInt; i++)
            {
                iNumberOfTrailingZeros <<= 1;
                var hasINumberOfZeros = (hash & iNumberOfTrailingZeros) == iNumberOfTrailingZeros; 

                if(!hasINumberOfZeros)
                    break;

                numberOfTrailingZeros = i; 
            }

            _max = Math.Max(_max, numberOfTrailingZeros); 
        }

        public int GetNumberOfDistinctElements()
        {
            return (int) Math.Pow(2, _max + 1); 
        }
    }
}
