using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Create;

public class CreatePharmacyBranchCommandRequest : Coban.Application.Requests.IBaseRequest, IRequest<IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public String Name { get; set; } = string.Empty;
    public String PharmacyEntityId { get; set; } = string.Empty;
}
