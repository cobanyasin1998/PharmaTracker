using Coban.Application.Responses.Base.Abstractions;
using Coban.Domain.Enums.Base;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Domain.Enums;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Update;



public class UpdatePharmacyBranchContactCommandRequest : IRequest<IResponse<UpdatePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    public EEntityStatus Status { get; set; }
    public String Id { get; set; }

    public EContactType Type { get; set; }
    public string Value { get; set; }
    public string PharmacyBranchEntityId { get; set; }

}
