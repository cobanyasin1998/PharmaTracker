using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.Consts;

namespace PharmacyService.Persistence.EntityConfigurations;

public class PharmacyEntityConfiguration : IEntityTypeConfiguration<PharmacyEntity>
{
    public void Configure(EntityTypeBuilder<PharmacyEntity> builder)
    {
        builder
            .HasIndex(
                indexExpression: pharmacy => pharmacy.Name, 
                name: PharmacyPersistenceConsts.PharmancyNameIndex)
            .IsUnique();
    }
}
