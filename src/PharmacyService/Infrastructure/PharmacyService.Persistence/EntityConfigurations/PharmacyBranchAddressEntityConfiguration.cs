using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.Consts;

namespace PharmacyService.Persistence.EntityConfigurations;

public class PharmacyBranchAddressEntityConfiguration : IEntityTypeConfiguration<PharmacyBranchAddressEntity>
{
    public void Configure(EntityTypeBuilder<PharmacyBranchAddressEntity> builder)
    {
        builder.ToTable("PharmacyBranchAddresses");

        builder.HasKey(pba => pba.Id);

        builder.Property(pba => pba.IsPrimary)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(pba => pba.Address)
            .IsRequired()
            .HasMaxLength(500); 

        builder.Property(pba => pba.ProvinceId)
            .IsRequired(false);

        builder.Property(pba => pba.DistrictId)
            .IsRequired(false);

        builder.Property(pba => pba.NeighbourhoodId)
            .IsRequired(false);

        builder.Property(pba => pba.StreetId)
            .IsRequired(false);

        builder.Property(pba => pba.Latitude)
            .HasColumnType("decimal(9,6)") 
            .IsRequired(false);

        builder.Property(pba => pba.Longitude)
            .HasColumnType("decimal(9,6)")
            .IsRequired(false);

        builder.HasIndex(p => p.Status)
            .HasDatabaseName(PharmacyPersistenceConsts.PharmacyBranchAddressStatusIndex);

    }
}