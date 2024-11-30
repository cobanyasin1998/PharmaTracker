using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.Consts;

namespace PharmacyService.Persistence.EntityConfigurations;

public class PharmacyEntityConfiguration : IEntityTypeConfiguration<PharmacyEntity>
{
    public void Configure(EntityTypeBuilder<PharmacyEntity> builder)
    {
        builder.ToTable(PharmacyPersistenceConsts.Pharmacies);

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .HasMaxLength(500);

        builder.Property(p => p.LicenseNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(p => p.Name).HasDatabaseName(PharmacyPersistenceConsts.PharmaciesNameIndex);
        builder.HasIndex(p => p.Status).HasDatabaseName(PharmacyPersistenceConsts.PharmaciesStatusIndex);
        builder.HasIndex(p => p.LicenseNumber).IsUnique();
    }
}