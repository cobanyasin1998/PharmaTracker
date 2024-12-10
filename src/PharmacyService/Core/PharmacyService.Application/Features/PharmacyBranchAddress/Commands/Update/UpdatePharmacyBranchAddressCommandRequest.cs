using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.Domain.Enums.Base;
using Coban.GeneralDto;
using MediatR;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Update;

public class UpdatePharmacyBranchAddressCommandRequest : BaseRequest, IRequest<IResponse<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>>
{
    public EEntityStatus Status { get; set; }

    public bool IsPrimary { get; set; }
    public string Address { get; set; }
    public long? ProvinceId { get; set; }
    public long? DistrictId { get; set; }
    public long? NeighbourhoodId { get; set; }
    public long? StreetId { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

}
