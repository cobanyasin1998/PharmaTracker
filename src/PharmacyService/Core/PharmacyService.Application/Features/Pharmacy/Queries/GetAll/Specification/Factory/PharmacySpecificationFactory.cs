using Coban.Application.Requests.Filter.Specification.Abstractions;
using Coban.Application.Requests.Filter.Specification.Concretes;
using Coban.Domain.Enums.Base;
using PharmacyService.Application.Features.Pharmacy.Queries.GetAll.Specification.Custom;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll.Specification.Factory;

public class PharmacySpecificationFactory
{
    public ISpecification<PharmacyEntity> GetNameSpecification(string? name)
    {
        return string.IsNullOrEmpty(name)
            ? new NullSpecification<PharmacyEntity>()
            : new PharmacyNameSpecification(name);
    }

    public ISpecification<PharmacyEntity> GetStatusSpecification(EEntityStatus? status)
    {
        return status == null
            ? new NullSpecification<PharmacyEntity>()
            : new PharmacyStatusSpecification(status.Value);
    }
    public ISpecification<PharmacyEntity> GetLicenseNumberSpecification(string? licenseNumber)
    {
        return string.IsNullOrEmpty(licenseNumber)
            ? new NullSpecification<PharmacyEntity>()
            : new PharmacyLicenseNumberSpecification(licenseNumber);
    }
}
