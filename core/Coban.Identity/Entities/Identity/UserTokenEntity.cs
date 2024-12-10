using Coban.Domain.Entities.Base;
using Coban.Identity.Entities.Base;

namespace Coban.Identity.Entities.Identity;

public class UserTokenEntity : BaseEntity
{
    public long UserEntityId { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public bool IsExpired { get; set; }
    public bool IsRevoked { get; set; }
    public string ReplacedByToken { get; set; }
    public string RemoteIpAddress { get; set; }
    public string RemoteUserAgent { get; set; }
    public virtual UserEntity UserEntity { get; set; }
}
