using Coban.Application.Requests.Filter.Specification.Abstractions;
using Coban.Domain.Enums.Base;
using PharmacyService.Domain.Entities;
using System.Linq.Expressions;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll.Specification.Custom;

public class PharmacyStatusSpecification(EEntityStatus _status) : ISpecification<PharmacyEntity>
{
    public Expression<Func<PharmacyEntity, bool>> ToExpression()
        => pharmacy => pharmacy.Status == _status;
}
