using Coban.Domain.Entities.Base;

namespace IdentityService.Domain.Entities;

public class UserEntity:BaseEntity
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }

    public virtual List<UserGroupEntity> UserGroupEntities { get; set; }
    public virtual List<RefreshTokenEntity> RefreshTokenEntities { get; set; }
}
