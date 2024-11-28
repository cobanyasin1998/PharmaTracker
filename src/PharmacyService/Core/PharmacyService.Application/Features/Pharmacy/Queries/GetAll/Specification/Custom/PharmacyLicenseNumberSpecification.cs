using Coban.Application.Requests.Filter.Specification.Abstractions;
using PharmacyService.Domain.Entities;
using System.Linq.Expressions;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll.Specification.Custom;

public class PharmacyLicenseNumberSpecification(string _licenseNumber) : ISpecification<PharmacyEntity>
{
    public Expression<Func<PharmacyEntity, bool>> ToExpression()
    {
        return pharmacy => pharmacy.LicenseNumber == _licenseNumber;
    }
}
