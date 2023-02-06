using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace differentSymbols.Tests
{
    [TestClass()]
    public class maxDifferentSymbolsTests
    {       
        [TestMethod]
        [DataRow("through333789hh123uuuuu0000000llordoftherings")]
        [DataRow("lordoftheringssthrough333789hh123uuuuu0000000")]
        public void mainTest(string value)
        {
            Assert.AreEqual("lordoftherings", maxDifferentSymbols.maxDiffSymbols(value));
            Assert.AreEqual("uuuuu", maxDifferentSymbols.maxSameSymbols(value));
            Assert.AreEqual("0000000", maxDifferentSymbols.maxSameNumbers(value));
        }

    }
}