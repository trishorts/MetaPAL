using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaPAL.Data;
using MetaPAL.DataOperations;
using MetaPAL.Resources;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    internal class TestMetaDataExtraction
    {
        private string _sdrfPath_2137 = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "MetaData",
            "PXD002137.sdrf.tsv");
        private string _sdrfPath_6482 = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "MetaData",
            "PXD006482.sdrf.tsv");


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
            var parsedHeader = SdrfFile.ParseDelimitedFile(_sdrfPath_2137);
            CollectionAssert.AreEqual(_expectedHeaders_2137, parsedHeader.Keys);
            Assert.That(parsedHeader["data file"].Count, Is.EqualTo(192));
            Assert.That(parsedHeader["source name"].Count, Is.EqualTo(32));
            Assert.That(parsedHeader["organism"].Count, Is.EqualTo(1));
            Assert.That(parsedHeader["sex"].Count, Is.EqualTo(2));
            Assert.That(parsedHeader["sex"].Contains("male"));
            Assert.That(parsedHeader["sex"].Contains("Female"));
        }

        [Test]
        public void TestMetaDataFile()
        {
            var sdrfFile = new SdrfFile(_sdrfPath_2137);
            var results = sdrfFile.Results;

            Assert.That(results.Count(p => p.Name == "data file"), Is.EqualTo(192));
            Assert.That(results.Count(p => p.Name == "source name"), Is.EqualTo(32));
            Assert.That(results.Count(p => p.Name == "organism"), Is.EqualTo(1));   
        }

        [Test]
        public void TestDatabaseInsertion()
        {
            // add first sdrf file and check that all metadata is added
            using var context = new TestingDbContext();
            if (context.Database.EnsureCreated())
            {
                DataOperations.AddMetaDataFromSdrf(context, _sdrfPath_2137).Wait();
            }
            
            Assert.That(context.MetaData.Count(p => p.Name == "data file"), Is.EqualTo(0));
            Assert.That(context.MetaData.Count(p => p.Name == "organism"), Is.EqualTo(1));
            Assert.That(context.MetaData.Count(p => p.Name == "organism part"), Is.EqualTo(1));
            Assert.That(context.MetaData.First(p => p.Name == "organism part").Value, Is.EqualTo("colon"));

            // add second sdrf file and check that no metadata was duplicated
            DataOperations.AddMetaDataFromSdrf(context, _sdrfPath_6482).Wait();
            Assert.That(context.MetaData.Count(p => p.Name == "data file"), Is.EqualTo(0));
            Assert.That(context.MetaData.Count(p => p.Name == "organism"), Is.EqualTo(1));
            Assert.That(context.MetaData.Count(p => p.Name == "organism part"), Is.EqualTo(3));
            Assert.That(context.MetaData.Where(p => p.Name == "organism part").Select(p => p.Value).Contains("colon"));
            Assert.That(context.MetaData.Where(p => p.Name == "organism part").Select(p => p.Value).Contains("kidney cancer"));
            Assert.That(context.MetaData.Where(p => p.Name == "organism part").Select(p => p.Value).Contains("adjacent tissues"));
        }
    }
}
