using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetById;

public class GetByIdPharmacyBranchContactQueryHandler : IRequestHandler<GetByIdPharmacyBranchContactQueryRequest, IResponse<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>>
{
    public Task<IResponse<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyBranchContactQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
