﻿using _4Teammate.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _4Teammate.Data.Context;

public class AplicationDataContext : IdentityDbContext<AccountUser>
{
  public AplicationDataContext(DbContextOptions options) : base(options)
  {

  }

  public DbSet<SportCategoryEntity> SportCategories { get; set; }
  public DbSet<LookupCategoryEntity> LookupCategories { get; set; }
  public DbSet<SportLookupEntity> SportLookups { get; set; }
  public DbSet<SportTypeEntity> SportTypes { get; set; }
  public DbSet<MessageEntity> Messages { get; set; }
  public DbSet<TeammateUserEntity> TeammateUsers { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    ModelsConfigure.AddConfigures(modelBuilder);
    base.OnModelCreating(modelBuilder);
  }
}

