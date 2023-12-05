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
            builder.Entity<SpectrumMatch>()
                .Property(p => p.IdentifiedSequenceVariations)
                .IsRequired(false);
            builder.Entity<SpectrumMatch>()
                .Property(p => p.IntersectingSequenceVariations)
                .IsRequired(false);
            builder.Entity<SpectrumMatch>()
                .Property(p => p.PEP)
                .HasConversion(v => double.IsNaN(v) ? -1 : v,
                    v => v);
            builder.Entity<SpectrumMatch>()
                .Property(p => p.PEP_QValue)
                .HasConversion(v => double.IsNaN(v) ? -1 : v,
                                       v => v);

            base.OnModelCreating(builder);
        }

        public DbSet<MetaPAL.Models.SpectrumMatch>? SpectrumMatch { get; set; }
    }
}