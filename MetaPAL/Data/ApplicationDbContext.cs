using System.Data.Common;
using MetaPAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Omics.Fragmentation;
using Proteomics;

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
        public DbSet<Repo>? Repos { get; set; }
        public DbSet<SpectrumMatch>? SpectrumMatch { get; set; }

        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<SampleMetaData> MetaData { get; set; }
    }

    

}