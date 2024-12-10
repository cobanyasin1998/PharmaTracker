using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Domain.Enums.Base;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandRequest : BaseRequest, IRequest<IResponse<UpdatePharmacyCommandResponse, GeneralErrorDto>>
{
    public EEntityStatus Status { get; set; }
    public  String Name { get; set; } = string.Empty;
    public  String Description { get; set; } = string.Empty;
    public  String LicenseNumber { get; set; } = string.Empty;
}
