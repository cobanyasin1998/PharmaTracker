using Newtonsoft.Json;

namespace Coban.Application.Requests;

public abstract class BaseRequest : IBaseRequest
{
    [JsonProperty(propertyName: nameof(Id))]
    public string? EncId { get; set; }
    [JsonIgnore]
    public long Id { get; set; }
}
