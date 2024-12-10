using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Domain.Enums;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Create;


public class CreatePharmacyBranchContactCommandRequest : Coban.Application.Requests.IBaseRequest, IRequest<IResponse<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    public EContactType Type { get; set; }
    public string Value { get; set; }
    public string PharmacyBranchEntityId { get; set; }
}
