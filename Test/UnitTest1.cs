using MetaPAL.Models;
using Readers;

namespace Test
{
    public class Tests
    {
        private static string _psmPath =
            Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "AllPsms.psmtsv");
        private static string _dataPath1 =
            Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "HeLa_1ng.mzML");
        private static string _dataPath2 = 
            Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "HeLa_250pg.mzML");

        [SetUp]
        public void Setup()
        {
        }
    }
}