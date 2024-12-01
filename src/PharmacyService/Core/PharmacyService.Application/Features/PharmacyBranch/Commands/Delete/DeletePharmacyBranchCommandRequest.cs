using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Delete;


public class DeletePharmacyBranchCommandRequest : IRequest<IResponse<DeletePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public String Id { get; set; }
}
