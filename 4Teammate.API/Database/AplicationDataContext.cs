using _4Teammate.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4Teammate.API.Database
{
    public class AplicationDataContext : DbContext
    {
        public AplicationDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<SportCategoryEntity> Categories { get; set; }
        public DbSet<LookupCategoryEntity> LookupCategories { get; set; }
        public DbSet<SportLookupEntity> SportLookups { get; set; }
        public DbSet<SportTypeEntity> SportTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelsConfigure.AddConfigures(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
