using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public record GetByIdPharmacyQueryResponse(
    string Id,
    string Name,
    string Description,
    string LicenseNumber,
    EEntityStatus Status
);