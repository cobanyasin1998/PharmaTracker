using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetById;

public class GetByIdPharmacyBranchAddressQueryRequest : IRequest<IResponse<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>>
{
    public String Id { get; set; }
}
