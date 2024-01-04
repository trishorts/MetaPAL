using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaPAL.Resources.MetaData.SDRF;

namespace Test
{
    internal class TestMetaDataExtraction
    {
        private string _sdrfPath_2137 = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "MetaData",
            "PXD002137.sdrf.tsv");

        private string[] _expectedHeaders_2137 = new[]
        {
            "source name", "organism", "organism part", "cell type", "cell line", "developmental stage", "disease",
            "ancestry category", "phenotype", "sex", "age", "biological replicate", "individual", "Material Type",
            "assay name", "technology type", "data file", "file uri", "technical replicate", "fraction identifier",
            "label", "instrument", "cleavage agent details", "modification parameters", "dissociation method",
            "collision energy", "precursor mass tolerance", "fragment mass tolerance"
        };

        [Test]
        public void TestHeaderParsing()
        {
            var parsedHeader = SdrfToMetaData.ParseMetaDataFile(_sdrfPath_2137);
            CollectionAssert.AreEqual(_expectedHeaders_2137, parsedHeader.Keys);
            Assert.That(parsedHeader["data file"].Count, Is.EqualTo(192));
            Assert.That(parsedHeader["source name"].Count, Is.EqualTo(32));
            Assert.That(parsedHeader["organism"].Count, Is.EqualTo(1));
            Assert.That(parsedHeader["sex"].Count, Is.EqualTo(2));
            Assert.That(parsedHeader["sex"].Contains("male"));
            Assert.That(parsedHeader["sex"].Contains("Female"));
        }

        [Test]
        public void TestGetMetaData()
        {
            var metaData = SdrfToMetaData.GetMetaData(_sdrfPath_2137).ToList();
            Assert.That(metaData.Count(p => p.Name == "data file"), Is.EqualTo(192));
            Assert.That(metaData.Count(p => p.Name == "source name"), Is.EqualTo(32));
            Assert.That(metaData.Count(p => p.Name == "organism"), Is.EqualTo(1));
        }
    }
}
