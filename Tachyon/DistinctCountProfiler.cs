using System.Collections.Generic;
using System.Diagnostics;
using DistinctCountAlgorithms;

namespace Tachyon
{
    class DistinctCountProfiler<T>
    {
        public ProfileResult Profile(IDistinctCountAlgorithm<T> algorithm, IEnumerable<T> data)
        {
            var time = Stopwatch.StartNew();

            foreach (var datum in data)
            {
                algorithm.Add(datum);
            }


            var distinctElements = algorithm.GetNumberOfDistinctElements(); 
            time.Stop();
            
            
            var bytes = ProfilingToolbox.SizeOf(algorithm);
            var milisecs = time.ElapsedMilliseconds;

            return new ProfileResult(success: true, bytes: bytes, miliseconds: milisecs, result: distinctElements);
        }


    }
}
