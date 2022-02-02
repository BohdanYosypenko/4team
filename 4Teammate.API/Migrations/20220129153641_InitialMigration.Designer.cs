﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _4Teammate.API.Database;

namespace _4Teammate.API.Migrations
{
    [DbContext(typeof(AplicationDataContext))]
    [Migration("20220129153641_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_4Teammate.API.Database.Entities.LookupCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DefaultName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LookupCategories");
                });

            modelBuilder.Entity("_4Teammate.API.Database.Entities.SportCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DefaultName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("_4Teammate.API.Database.Entities.SportLookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeEnd")
                        .HasColumnType("int");

                    b.Property<int>("AgeStart")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("LookupCategoryFID")
                        .HasColumnType("int");

                    b.Property<int?>("LookupCategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceEnd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceStart")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SportTypeFID")
                        .HasColumnType("int");

                    b.Property<int?>("SportTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LookupCategoryId");

                    b.HasIndex("SportTypeId");

                    b.ToTable("SportLookups");
                });

            modelBuilder.Entity("_4Teammate.API.Database.Entities.SportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryFID")
                        .HasColumnType("int");

                    b.Property<string>("DefaultName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SportCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SportCategoryId");

                    b.ToTable("SportTypes");
                });

            modelBuilder.Entity("_4Teammate.API.Database.Entities.SportLookup", b =>
                {
                    b.HasOne("_4Teammate.API.Database.Entities.LookupCategory", "LookupCategory")
                        .WithMany("SportLookups")
                        .HasForeignKey("LookupCategoryId");

                    b.HasOne("_4Teammate.API.Database.Entities.SportType", "SportType")
                        .WithMany("SportLookups")
                        .HasForeignKey("SportTypeId");

                    b.Navigation("LookupCategory");

                    b.Navigation("SportType");
                });

            modelBuilder.Entity("_4Teammate.API.Database.Entities.SportType", b =>
                {
                    b.HasOne("_4Teammate.API.Database.Entities.SportCategory", "SportCategory")
                        .WithMany("SportTypes")
                        .HasForeignKey("SportCategoryId");

                    b.Navigation("SportCategory");
                });

            modelBuilder.Entity("_4Teammate.API.Database.Entities.LookupCategory", b =>
                {
                    b.Navigation("SportLookups");
                });

            modelBuilder.Entity("_4Teammate.API.Database.Entities.SportCategory", b =>
                {
                    b.Navigation("SportTypes");
                });

            modelBuilder.Entity("_4Teammate.API.Database.Entities.SportType", b =>
                {
                    b.Navigation("SportLookups");
                });
#pragma warning restore 612, 618
        }
    }
}