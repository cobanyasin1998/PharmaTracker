using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetAll;

public class GetAllPharmacyBranchQueryHandler : IRequestHandler<GetAllPharmacyBranchQueryRequest, IResponse<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>>
{
    public Task<IResponse<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>> Handle(GetAllPharmacyBranchQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
