using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Create;


public class CreatePharmacyBranchContactCommandRequest : IRequest<IResponse<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{

}
