using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Delete;


public class DeletePharmacyBranchAddressCommandRequest : IRequest<IResponse<DeletePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    public String Id { get; set; }
}
