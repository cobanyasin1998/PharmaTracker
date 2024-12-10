using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Create;

public class CreatePharmacyBranchCommandRequest : Coban.Application.Requests.IBaseRequest, IRequest<IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public string Name { get; set; } = string.Empty;
    public string PharmacyEntityId { get; set; } = string.Empty;
}
