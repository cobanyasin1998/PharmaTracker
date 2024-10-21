using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.Entities;
using PharmacyService.Persistence.ExtensionMethod;

namespace PharmacyService.Persistence.EntityConfigurations;


public class PharmacyEntityConfiguration : IEntityTypeConfiguration<PharmacyEntity>
{
    public void Configure(EntityTypeBuilder<PharmacyEntity> builder)
    {
        builder.ConfigureEntity<PharmacyEntity>("Pharmacy", "Id");

        builder.Property(b => b.Name)
               .HasColumnName("Name")
               .IsRequired();

        builder.HasIndex(b => b.Name)
               .HasDatabaseName("UK_Pharmacy_Name")
               .IsUnique();

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Pharmacy_Name").IsUnique();
    }
}
