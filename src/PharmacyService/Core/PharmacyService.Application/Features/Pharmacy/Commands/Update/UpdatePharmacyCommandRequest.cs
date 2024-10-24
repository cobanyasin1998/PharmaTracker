using MediatR;
using SharedLibrary.Core.Domain.Enums;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandRequest : IRequest<UpdatePharmacyCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public EStatus Status { get; set; }
}
