using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.Consts;

namespace PharmacyService.Persistence.EntityConfigurations;
public class PharmacyBranchContactEntityConfiguration : IEntityTypeConfiguration<PharmacyBranchContactEntity>
{
    public void Configure(EntityTypeBuilder<PharmacyBranchContactEntity> builder)
    {
        builder.ToTable(PharmacyPersistenceConsts.PharmacyBranchContacts);

        builder.HasKey(pbc => pbc.Id);

        builder.Property(pbc => pbc.Value)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(p => p.Status).HasDatabaseName(PharmacyPersistenceConsts.PharmacyBranchContactsStatusIndex);

    }
}