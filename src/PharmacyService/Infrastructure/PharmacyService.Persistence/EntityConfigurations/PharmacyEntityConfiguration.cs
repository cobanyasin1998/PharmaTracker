using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Application.Features.Pharmacy.Constants;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Persistence.EntityConfigurations;

public class PharmacyEntityConfiguration : IEntityTypeConfiguration<PharmacyEntity>
{
    public void Configure(EntityTypeBuilder<PharmacyEntity> builder)
    {
        builder
            .HasIndex(
                indexExpression: pharmacy => pharmacy.Name, 
                name: PharmacyConstants.PharmancyNameIndex)
            .IsUnique();
    }
}
