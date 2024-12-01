using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetAll;

public class GetAllPharmacyBranchAddressQueryHandler : IRequestHandler<GetAllPharmacyBranchAddressQueryRequest, IResponse<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>>
{
    public Task<IResponse<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>> Handle(GetAllPharmacyBranchAddressQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
