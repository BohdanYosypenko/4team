using _4Teammate.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4Teammate.Data.Context;

public static class ModelsConfigure
{
    public static void AddConfigures(ModelBuilder modelBuilder) {

        modelBuilder.Entity<SportCategoryEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<SportCategoryEntity>()
            .HasMany(c => c.SportTypes)
            .WithOne(c => c.SportCategory);

        modelBuilder.Entity<SportTypeEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<SportTypeEntity>()
            .HasMany(c => c.SportLookups)
            .WithOne(c => c.SportType);
        modelBuilder.Entity<SportTypeEntity>()
            .HasOne(c => c.SportCategory)
            .WithMany(c => c.SportTypes);

        modelBuilder.Entity<SportLookupEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<SportLookupEntity>()
            .HasOne(c => c.SportType)
            .WithMany(c => c.SportLookups);
        modelBuilder.Entity<SportLookupEntity>()
            .HasOne(c => c.LookupCategory)
            .WithMany(c => c.SportLookups);

        modelBuilder.Entity<LookupCategoryEntity>().HasKey(c => c.Id);
        modelBuilder.Entity<LookupCategoryEntity>()
            .HasMany(c => c.SportLookups)
            .WithOne(c => c.LookupCategory);
    }
}

