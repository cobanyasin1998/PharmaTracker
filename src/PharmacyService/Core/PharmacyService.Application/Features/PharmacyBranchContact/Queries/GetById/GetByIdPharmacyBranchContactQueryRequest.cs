using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetById;

public class GetByIdPharmacyBranchContactQueryRequest : BaseRequest, IRequest<IResponse<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>>
{
}