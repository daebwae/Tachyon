using System.Collections.Generic;
using System.IO;
using Shared;

namespace DataRetrieval
{
    public class WordsFromTextFiles: ISequence<string>
    {
        private readonly string _directory;
        private readonly string _ext;
        private Stack<string> _files;


        private Stack<string> Files
        {
            get
            {
                if (_files == null)
                    InitFiles();

                return _files; 
            }
        }


        public WordsFromTextFiles(string directory, string ext = "txt")
        {
            _directory = directory;
            _ext = ext;
        }

        private void InitFiles()
        {
            _files = new Stack<string>();
            string[] files = Directory.GetFiles(_directory, string.Format("*.{0}", _ext));

            foreach (var file in files)
            {
                _files.Push(file);
            }
        }

        private string[] GetWordsFromFile(string path)
        {
            // assumption: the text files are below a few mega-bytes => reading it in memory isn't horrible
            // => trade-off higher memory consumpion but faster IO by reading all of the file at once
            // Todo: meassure speed increase of IO when reading the whole file vs charcter by charcter vs line by line 

            return File.ReadAllText(path).Split(); 
        }

        public IEnumerable<string> Get()
        {
            // Goal: spread out IO and memory consumption

            while (Files.Count > 0)
            {
                var currentFile = Files.Pop();

                var words = GetWordsFromFile(currentFile);

                foreach (var word in words)
                {
                    yield return word; 
                }
            }
        }

        public void StreamTo(ISequentialAlgorithm<string> dataSink)
        {
            foreach (var word in Get())
            {
                dataSink.Add(word);
            }
        }
    }
}
