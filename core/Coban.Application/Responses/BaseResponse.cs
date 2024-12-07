

using Newtonsoft.Json;

namespace Coban.Application.Responses
{
    public class BaseResponse
    {
        [JsonIgnore]
        public long Id { get; set; }
        [JsonProperty("Id")]
        public string EncId { get; set; }
    }
}
