using System.Text.Json.Serialization;

namespace Coban.Application.Requests.Decrypt;

public abstract class GetByIdQueryRequestBase
{
    public string Id { get; set; }

    [JsonIgnore] 
    public long DecryptedId { get; set; } = 0;
}
