using MetaPAL2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Omics.Fragmentation;

namespace MetaPAL2.Data
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
                .Ignore("MatchedFragmentIon");

            base.OnModelCreating(builder);
        }
    }
}