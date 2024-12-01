using Coban.Application.Responses.Base.Abstractions;
using Coban.Domain.Enums.Base;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Update;


public class UpdatePharmacyBranchCommandRequest : IRequest<IResponse<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public EEntityStatus Status { get; set; }
    public String Id { get; set; }
 
}
