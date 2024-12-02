﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PharmacyService.Persistence.DbContexts;

#nullable disable

namespace PharmacyService.Persistence.Migrations
{
    [DbContext(typeof(PharmacyDbContext))]
    partial class PharmacyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchAddressEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DistrictId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsPrimary")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal(9,6)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal(9,6)");

                    b.Property<long?>("NeighbourhoodId")
                        .HasColumnType("bigint");

                    b.Property<long>("PharmacyBranchEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProvinceId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.Property<long?>("StreetId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyBranchEntityId");

                    b.HasIndex("Status")
                        .HasDatabaseName("IX_PharmacyBranchAddresses_Status");

                    b.ToTable("PharmacyBranchAddresses", (string)null);
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchContactEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("PharmacyBranchEntityId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyBranchEntityId");

                    b.HasIndex("Status")
                        .HasDatabaseName("IX_PharmacyBranchContacts_Status");

                    b.ToTable("PharmacyBranchContacts", (string)null);
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<long>("PharmacyEntityId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_PharmacyBranches_BranchName");

                    b.HasIndex("PharmacyEntityId");

                    b.HasIndex("Status")
                        .HasDatabaseName("IX_PharmacyBranches_Status");

                    b.ToTable("PharmacyBranches", (string)null);
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LicenseNumber")
                        .IsUnique();

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Pharmacies_Name");

                    b.HasIndex("Status")
                        .HasDatabaseName("IX_Pharmacies_Status");

                    b.ToTable("Pharmacies", (string)null);
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchAddressEntity", b =>
                {
                    b.HasOne("PharmacyService.Domain.Entities.PharmacyBranchEntity", "PharmacyBranchEntity")
                        .WithMany("PharmacyBranchAddressEntities")
                        .HasForeignKey("PharmacyBranchEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PharmacyBranchEntity");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchContactEntity", b =>
                {
                    b.HasOne("PharmacyService.Domain.Entities.PharmacyBranchEntity", "PharmacyBranchEntity")
                        .WithMany("PharmacyBranchContactEntities")
                        .HasForeignKey("PharmacyBranchEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PharmacyBranchEntity");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchEntity", b =>
                {
                    b.HasOne("PharmacyService.Domain.Entities.PharmacyEntity", "PharmacyEntity")
                        .WithMany("PharmacyBranchEntities")
                        .HasForeignKey("PharmacyEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PharmacyEntity");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchEntity", b =>
                {
                    b.Navigation("PharmacyBranchAddressEntities");

                    b.Navigation("PharmacyBranchContactEntities");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyEntity", b =>
                {
                    b.Navigation("PharmacyBranchEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
