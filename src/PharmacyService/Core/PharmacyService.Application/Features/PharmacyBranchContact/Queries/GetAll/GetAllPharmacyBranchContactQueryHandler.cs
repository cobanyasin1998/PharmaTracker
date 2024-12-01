using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetAll;

public class GetAllPharmacyBranchContactQueryHandler : IRequestHandler<GetAllPharmacyBranchContactQueryRequest, IResponse<GetAllPharmacyBranchContactQueryResponse, GeneralErrorDto>>
{
    public Task<IResponse<GetAllPharmacyBranchContactQueryResponse, GeneralErrorDto>> Handle(GetAllPharmacyBranchContactQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
