using MediatR;
using PharmacyService.Domain.Enums;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmacyCommandRequest : IRequest<CreatePharmacyCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public EStatus Status { get; set; }
}
