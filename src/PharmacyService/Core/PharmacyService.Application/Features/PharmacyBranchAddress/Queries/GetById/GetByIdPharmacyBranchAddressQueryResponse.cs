﻿using Coban.Application.Responses;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetById;

public class GetByIdPharmacyBranchAddressQueryResponse : BaseResponse
{
    public string Name { get; set; }
}
