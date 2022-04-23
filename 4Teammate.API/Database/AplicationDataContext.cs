using _4Teammate.API.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _4Teammate.API.Database
{
    public class AplicationDataContext : IdentityDbContext<User>
    {
        public AplicationDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<SportCategoryEntity> SportCategories { get; set; }
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
