using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using Newtonsoft.Json;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Delete;

public class DeletePharmacyCommandRequest : IRequest<IResponse<DeletePharmacyCommandResponse, GeneralErrorDto>>
{
    [JsonProperty("Id")]
    public string EncId { get; set; }
    [JsonIgnore]
    public long Id { get; set; }
}
