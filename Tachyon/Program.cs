using System;
using System.Diagnostics;
using System.Linq;
using DataRetrieval;
using DistinctCountAlgorithms;
using Shared;

namespace Tachyon
{
    class Program
    {
        private const string PathToTextFiles = @"C:\texts\";

        static void Main(string[] args)
        {
            Console.WriteLine("Brave new Tachyon world");

            NaiveDistinctCount<string> naiveAlgorith = new NaiveDistinctCount<string>();
            ISequence<string> wordsFromTextFile = new WordsFromTextFiles(PathToTextFiles);

            var words = wordsFromTextFile.Get().ToList();


            DistinctCountProfiler<string> profiler = new DistinctCountProfiler<string>();
            ProfileResult result = profiler.Profile(naiveAlgorith, words); 

            Console.WriteLine("Computer says: {0}", result.Result);
            Console.WriteLine("Naive mem consumption: {0}", result.Bytes);
            Console.WriteLine("Naive time: {0}", result.Miliseconds);

            Console.ReadKey(); 
        }
    }
}
