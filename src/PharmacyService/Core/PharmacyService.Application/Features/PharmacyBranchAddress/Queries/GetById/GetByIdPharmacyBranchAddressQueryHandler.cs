using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetById;

public class GetByIdPharmacyBranchAddressQueryHandler : IRequestHandler<GetByIdPharmacyBranchAddressQueryRequest, IResponse<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>>
{
    public Task<IResponse<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>> Handle(GetByIdPharmacyBranchAddressQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
