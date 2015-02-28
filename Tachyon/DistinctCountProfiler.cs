using System;
using System.Collections.Generic;
using System.Diagnostics;
using DistinctCountAlgorithms;

namespace Tachyon
{
    class DistinctCountProfiler<T>
    {
        public ProfileResult Profile(IDistinctCountAlgorithm<T> algorithm, IEnumerable<T> data)
        {
            var bytes = GC.GetTotalMemory(true);
            var time = Stopwatch.StartNew();

            foreach (var datum in data)
            {
                algorithm.Add(datum);
            }


            var distinctElements = algorithm.GetNumberOfDistinctElements(); 
            time.Stop();


            bytes = GC.GetTotalMemory(true) - bytes; 
            var milisecs = time.ElapsedMilliseconds;

            return new ProfileResult(success: true, bytes: bytes, miliseconds: milisecs, result: distinctElements);
        }
    }
}
