using Coban.Domain.Entities.Base;
using Coban.Identity.Entities.Base;

namespace Coban.Identity.Entities.Identity;

public class RefreshTokenEntity : BaseEntity
{
    public long UserEntityId { get; set; }
    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }
    public virtual UserEntity User { get; set; }
}
