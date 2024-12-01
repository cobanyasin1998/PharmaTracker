using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Commands.Delete;


public class DeletePharmacyBranchContactCommandRequest : IRequest<IResponse<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>>
{
    public String Id { get; set; }
}
