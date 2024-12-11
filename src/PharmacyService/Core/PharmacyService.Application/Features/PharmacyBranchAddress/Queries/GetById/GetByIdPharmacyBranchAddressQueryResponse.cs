﻿using Coban.Application.Responses;
using Coban.Domain.Enums.Base;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetById;

public class GetByIdPharmacyBranchAddressQueryResponse : BaseResponse
{
    public EEntityStatus Status { get; set; }

    public string Name { get; set; }

    public bool IsPrimary { get; set; }
    public string Address { get; set; }
    public long? ProvinceId { get; set; }
    public long? DistrictId { get; set; }
    public long? NeighbourhoodId { get; set; }
    public long? StreetId { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

    public long PharmacyBranchEntityId { get; set; }
}
