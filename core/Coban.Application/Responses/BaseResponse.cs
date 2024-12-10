

using Newtonsoft.Json;

namespace Coban.Application.Responses
{
    public class BaseResponse
    {
        [JsonIgnore]
        public long Id { get; set; }
        [JsonProperty(nameof(Id))]
        public String EncId { get; set; } = string.Empty;
    }
}
