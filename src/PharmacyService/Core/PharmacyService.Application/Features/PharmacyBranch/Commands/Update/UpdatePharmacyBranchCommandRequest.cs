using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Domain.Enums.Base;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Commands.Update;


public class UpdatePharmacyBranchCommandRequest : BaseRequest, IRequest<IResponse<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>>
{
    public EEntityStatus Status { get; set; }
    public string Name { get; set; }
}
