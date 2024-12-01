using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;


public class CreatePharmacyBranchAddressCommandRequest : IRequest<IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    
}
