using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;


public class CreatePharmacyBranchAddressCommandRequest : IRequest<IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    public bool IsPrimary { get; set; }
    public string Address { get; set; }
    public long? ProvinceId { get; set; }
    public long? DistrictId { get; set; }
    public long? NeighbourhoodId { get; set; }
    public long? StreetId { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public string PharmacyBranchEntityId { get; set; }


}
