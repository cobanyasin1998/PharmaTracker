using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmacyCommandRequest : IRequest<CreatePharmacyCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
