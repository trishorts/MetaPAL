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

        [Test]
        [Ignore("This test works on local devices but when building via github actions, it will fail to find the psm files :(")]
        public void TestBaseImplementaionOfExperiment()
        {
            // load dummy data
            var metaData = new List<MetaData>
            {
                new MetaData(){Name = "Organism", Value = "Human"},
                new MetaData(){Name = "Tissue", Value = "Pancreas"}
            };

            var spectralMatches = SpectrumMatchTsvReader.ReadPsmTsv(_psmPath, out _)
                .Select(SpectrumMatch.FromSpectrumMatchTsv)
                .ToList();
            int psmCount = spectralMatches.Count;
            var dataFile1 = DataFile.FromFilePath(_dataPath1, 1, metaData);
            var dataFile2 = DataFile.FromFilePath(_dataPath2, 1, metaData);

            var experiment = new Experiment()
            {
                DataFiles = new List<DataFile>() { dataFile1, dataFile2 },
                SpectrumMatches = spectralMatches,
                RepositoryIdentifier = "PRIDE: PXD000001"
            };

            // insert dummy data into database
            using var context = new TestingDbContext();
            if (context.Database.EnsureCreated())
            {
                context.Experiments.Add(experiment);
                context.MetaData.Add(new MetaData() { Name = "Age", Value = "21" });
                context.SaveChanges();
            }

            var experiments = context.Experiments.ToList();
            var dataFiles = context.MsDataFiles.ToList();
            var spectrumMatches = context.SpectrumMatch.ToList();
            var metaDataList = context.MetaData.ToList();

            Assert.That(experiments.Count, Is.EqualTo(1));
            experiment = experiments[0];

            // ensure data file has virtual experiment
            Assert.That(experiment.DataFiles.Count, Is.EqualTo(2));
            Assert.That(dataFiles.Count, Is.EqualTo(2));
            Assert.That(dataFiles[0].Experiment.RepositoryIdentifier, Is.EqualTo(experiment.RepositoryIdentifier));
            Assert.That(dataFiles[1].Experiment.RepositoryIdentifier, Is.EqualTo(experiment.RepositoryIdentifier));
            
            // ensure all spectrum matches are callable from experiment
            Assert.That(experiment.SpectrumMatches!.Count, Is.EqualTo(psmCount));
            Assert.That(spectrumMatches.Count, Is.EqualTo(psmCount));

            // ensure meta data was added to experiments correctly
            Assert.That(metaDataList.Count, Is.EqualTo(3));
            Assert.That(experiment.DataFiles[0].MetaData.Count, Is.EqualTo(2));
            Assert.That(experiment.DataFiles[1].MetaData.Count, Is.EqualTo(2));
        }
    }
}