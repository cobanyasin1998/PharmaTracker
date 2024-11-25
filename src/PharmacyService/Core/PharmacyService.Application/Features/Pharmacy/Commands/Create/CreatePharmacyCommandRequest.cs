using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmacyCommandRequest : IRequest<IResponse<CreatePharmacyCommandResponse, GeneralErrorDTO>>
{
    public String Name { get; set; }
    public String Description { get; set; }
    public String LicenseNumber { get; set; }
}
