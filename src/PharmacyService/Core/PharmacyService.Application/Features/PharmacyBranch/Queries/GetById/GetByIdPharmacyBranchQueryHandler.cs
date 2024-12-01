using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranch.Queries.GetById;

public class GetByIdPharmacyBranchQueryHandler : IRequestHandler<GetByIdPharmacyBranchQueryRequest, IResponse<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>>
{
    public Task<IResponse<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyBranchQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}