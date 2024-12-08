using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmacyCommandRequest : IBaseRequest, IRequest<IResponse<CreatePharmacyCommandResponse, GeneralErrorDto>>
{
    public String Name { get; set; } = string.Empty;
    public String Description { get; set; } = string.Empty;
    public String LicenseNumber { get; set; } = string.Empty;
}
