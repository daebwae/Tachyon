using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistinctCountAlgorithms.Tests
{
    public abstract class BasicDistinctCountTest
    {
        protected abstract IDistinctCountAlgorithm<string> Algorithm { get; set; }
        protected abstract string OutputPrefix { get; set;  }

        [TestMethod]
        public void NoRepeatedItemsTest()
        {
            string[] noRepeats = {"The", "cake", "is", "a", "lie"}; 

            AssertCount(noRepeats, 5, "no repeated input items");
        }

        [TestMethod]
        public void NoItemsTest()
        {
            string[] noRepeats = { };

            AssertCount(noRepeats, 0, "when there's no item, we expect a count of 0");
        }

        [TestMethod]
        public void OneRepeatedInputItemTest()
        {
            string[] noRepeats = { "LLAP", "LLAP", "LLAP", "LLAP", "LLAP", "Logic", "Logic", "TributeToSpock", "TributeToSpock" };

            AssertCount(noRepeats, 3, "item was counted multiple times");
        }

        [TestMethod]
        public void MultipleRepeatedInputItemTest()
        {
            string[] noRepeats = { "LLAP", "LLAP", "LLAP", "LLAP", "LLAP" };

            AssertCount(noRepeats, 1, "item was counted multiple times");
        }

        protected void AssertCount(string[] input, int expected, string error = "Something went wrong")
        {
            foreach (var current in input)
            {
                Algorithm.Add(current);
            }

            Assert.AreEqual(expected, Algorithm.GetNumberOfDistinctElements(), CreateErrorMesssae(input, error)); 
        }

        private string CreateErrorMesssae(string[] input, string error)
        {
            return OutputPrefix + ": " + error + "(" + string.Join(", ", input) + ")";
        }
    }
}
