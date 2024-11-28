using Coban.Application.Requests.Filter.Specification.Abstractions;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetAll.Specification.Custom;

public class PharmacyNameSpecification(string _name) : ISpecification<PharmacyEntity>
{
    public System.Linq.Expressions.Expression<Func<PharmacyEntity, bool>> ToExpression()
        => pharmacy => EF.Functions.Like(pharmacy.Name, $"%{_name}%");
}
