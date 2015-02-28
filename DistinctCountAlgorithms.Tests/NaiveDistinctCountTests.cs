using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistinctCountAlgorithms.Tests
{
    [TestClass]
    public class NaiveDistinctCountTests: BasicDistinctCountTest
    {
        protected override IDistinctCountAlgorithm<string> Algorithm { get; set; }

        protected override string OutputPrefix { get; set; }

        [TestInitialize]
        public void Init()
        {
            Algorithm = new NaiveDistinctCount<string>();
            OutputPrefix = "Naive Distinct Count"; 
        }
    }
}
