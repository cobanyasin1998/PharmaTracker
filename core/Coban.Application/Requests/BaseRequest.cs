using Newtonsoft.Json;

namespace Coban.Application.Requests;

public abstract class BaseRequest : IBaseRequest
{
    [JsonProperty("Id")]
    public string? EncId { get; set; }
    [JsonIgnore]
    public long Id { get; set; }
}
