using Coban.Domain.Entities.Base;

namespace IdentityService.Domain.Entities;

public class RefreshTokenEntity : BaseEntity
{
    public int UserEntityId { get; set; }
    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }
    public virtual UserEntity User { get; set; }
}
