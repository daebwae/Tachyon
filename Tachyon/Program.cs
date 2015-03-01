using System;
using System.Collections.Generic;

using System.Linq;
using DataRetrieval;
using DistinctCountAlgorithms;
using Shared;

namespace Tachyon
{
    class Program
    {
        private const string PathToTextFiles = @"C:\texts\";

        static void Main()
        {
            Console.WriteLine("Brave new Tachyon world");
            Console.WriteLine();

            ISequence<string> wordsFromTextFile = new WordsFromTextFiles(PathToTextFiles);

            var words = LogConsoleWithOk(() => wordsFromTextFile.Get().ToList(), "Retrieving data"); 
            var algorithms = new Dictionary<string, IDistinctCountAlgorithm<string>>()
            {
                 {"Naive algorithm", new NaiveDistinctCount<string>()},
                 {"Naive HyperLogLog for demo", new NaiveHyperLogLogForDemo<string>()},
            };

            Run(algorithms, words);

            

            Console.ReadKey();

        }

        private static void Run<T>(Dictionary<string, IDistinctCountAlgorithm<T>> algorithms, IList<T> data)
        {
            DistinctCountProfiler<T> profiler = new DistinctCountProfiler<T>();


            foreach (var algorithm in algorithms)
            {
                var algorithm1 = algorithm;
                var result = LogConsoleWithOk(() => profiler.Profile(algorithm1.Value, data),string.Format("Running Algorithm: {0}", algorithm.Key));

                Console.WriteLine("Computer says: {0:0,0}", result.Result);
                Console.WriteLine("Memory consumption: {0:0,0}", result.Bytes);
                Console.WriteLine("Time: {0:0,0}", result.Miliseconds);
                Console.WriteLine("---");
                Console.WriteLine();
            }
        }

        private static T LogConsoleWithOk<T>(Func<T> longRunningOperation, string text)
        {
            Console.Write(text);
            Console.Write("... ");

            T result = longRunningOperation();

            ConsoleColor restore = Console.ForegroundColor; 
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine("[OK]");
            Console.ForegroundColor = restore;

            return result; 

        }
    }
}
