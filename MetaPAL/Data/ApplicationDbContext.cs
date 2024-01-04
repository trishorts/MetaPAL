using System.Data.Common;
using MetaPAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Omics.Fragmentation;

namespace MetaPAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<SpectrumMatch>? SpectrumMatch { get; set; }

        public DbSet<MsDataScanModel> MsDataScans { get; set; }

        public DbSet<DataFile> MsDataFiles { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<MetaData> MetaData { get; set; }
    }

    

}