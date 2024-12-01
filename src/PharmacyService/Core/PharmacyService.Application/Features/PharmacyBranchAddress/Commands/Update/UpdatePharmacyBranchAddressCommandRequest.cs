using Coban.Application.Responses.Base.Abstractions;
using Coban.Domain.Enums.Base;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Update;

public class UpdatePharmacyBranchAddressCommandRequest : IRequest<IResponse<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    public EEntityStatus Status { get; set; }
    public String Id { get; set; }

}
