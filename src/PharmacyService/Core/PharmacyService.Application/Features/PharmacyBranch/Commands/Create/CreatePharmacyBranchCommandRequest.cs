using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Create;

public class CreatePharmacyBranchCommandRequest : IRequest<IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public string Name { get; set; }
    public string PharmacyEntityId { get; set; }
}
