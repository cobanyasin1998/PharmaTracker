using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.Consts;

namespace PharmacyService.Persistence.EntityConfigurations;

public class PharmacyBranchEntityConfiguration : IEntityTypeConfiguration<PharmacyBranchEntity>
{
    public void Configure(EntityTypeBuilder<PharmacyBranchEntity> builder)
    {
        builder.ToTable(PharmacyPersistenceConsts.PharmacyBranches);

        builder.HasKey(pb => pb.Id);

        builder.Property(pb => pb.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(pb => pb.Name)
            .HasDatabaseName(PharmacyPersistenceConsts.PharmacyBranchesNameIndex);
        builder.HasIndex(p => p.Status)
            .HasDatabaseName(PharmacyPersistenceConsts.PharmacyBranchesStatusIndex);

    }
}