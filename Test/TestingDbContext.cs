using System.Data.Common;
using MetaPAL.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Test;

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