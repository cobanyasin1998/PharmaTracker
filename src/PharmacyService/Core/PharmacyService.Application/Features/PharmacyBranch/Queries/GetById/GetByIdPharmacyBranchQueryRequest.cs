using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetById;

public class GetByIdPharmacyBranchQueryRequest : IRequest<IResponse<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>>
{
    public String Id { get; set; }
}