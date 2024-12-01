using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetById;

public class GetByIdPharmacyBranchContactQueryRequest : IRequest<IResponse<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>>
{
    public String Id { get; set; }
}