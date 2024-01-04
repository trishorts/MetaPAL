using MetaPAL.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
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
        public void Test1()
        {

            var metaData = new List<MetaData>
            {
                new MetaData(){Name = "Organism", Value = "Human"},
                new MetaData(){Name = "Tissue", Value = "Pancreas"}
            };

            var spectralMatches = SpectrumMatchTsvReader.ReadPsmTsv(_psmPath, out _)
                .Select(SpectrumMatch.FromSpectrumMatchTsv)
                .ToList();
            var dataFile1 = DataFile.FromFilePath(_dataPath1, 1, metaData);
            var dataFile2 = DataFile.FromFilePath(_dataPath2, 1, metaData);

            var experiment = new Experiment()
            {
                DataFiles = new List<DataFile>() { dataFile1, dataFile2},
                SpectrumMatches = spectralMatches,
                RepositoryIdentifier = "PRIDE: PXD000001"
            };

            using var context = new TestingDbContext();
            if (context.Database.EnsureCreated())
            {
                context.Experiments.Add(experiment);
                context.SaveChanges();
            }
        }
    }

    public class TestingDbContext : ApplicationDbContext
    {
        private static readonly DbConnection _connection;
        private static readonly DbContextOptions<ApplicationDbContext> _contextOptions;

        static TestingDbContext()
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(_connection)
                .Options;
        }

        public TestingDbContext() : base(_contextOptions)
        {
            Database.OpenConnection();
        }

        public override void Dispose()
        {
            _connection.Close();
            base.Dispose();
        }
    }
}