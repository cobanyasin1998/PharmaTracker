using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.Entities.Common;

namespace PharmacyService.Persistence.ExtensionMethod;

public static class ModelBuilderExtensions
{
    public static EntityTypeBuilder ConfigureEntity<T>(
        this EntityTypeBuilder builder,
        string tableName = null,
        string keyColumnName = "Id") where T :  BaseEntity
    {
        builder.ToTable(tableName ?? typeof(T).Name);

        builder.HasKey(keyColumnName);

        builder.Property(keyColumnName)
               .HasColumnName(keyColumnName)
               .IsRequired();

        return builder;
    }
}