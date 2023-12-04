using MetaPAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            builder.Entity<SpectrumMatch>()
                .Ignore("MatchedIons");
            builder.Entity<SpectrumMatch>()
                .Ignore("ChildScanMatchedIons");
            builder.Entity<SpectrumMatch>()
                .Ignore("VariantCrossingIons");

            base.OnModelCreating(builder);
        }
    }
}