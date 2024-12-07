﻿using Coban.Application.Responses.Base.Abstractions;
using Coban.Domain.Enums.Base;
using Coban.GeneralDto;
using MediatR;
using Newtonsoft.Json;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandRequest : IRequest<IResponse<UpdatePharmacyCommandResponse, GeneralErrorDto>>
{
    public EEntityStatus Status { get; set; }
    public  String Name { get; set; }
    public  String Description { get; set; }
    public  String LicenseNumber { get; set; }

    [JsonProperty("Id")]
    public string EncId { get; set; }
    [JsonIgnore]
    public long Id { get; set; }
}
