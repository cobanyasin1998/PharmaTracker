using Coban.Domain.Entities.Base;
using Coban.Identity.Entities.Identity;

namespace Coban.Identity.Entities.Base;

public class UserEntity : BaseEntity
{
    public long OrganizationEntityId { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public int FailedLoginAttempts { get; set; }
    public string Bio { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }

    public virtual List<UserGroupEntity> UserGroupEntities { get; set; }
    public virtual List<RefreshTokenEntity> RefreshTokenEntities { get; set; }
    public virtual OrganizationEntity OrganizationEntity { get; set; }



}
