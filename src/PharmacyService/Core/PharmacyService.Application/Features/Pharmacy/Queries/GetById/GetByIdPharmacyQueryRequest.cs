using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using Newtonsoft.Json;

namespace PharmacyService.Application.Features.Pharmacy.Queries.GetById;

public class GetByIdPharmacyQueryRequest :  IRequest<IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDto>>
{

    [JsonProperty("Id")]
    public string EncId { get; set; }
    [JsonIgnore]
    public long Id { get; set; }
}

