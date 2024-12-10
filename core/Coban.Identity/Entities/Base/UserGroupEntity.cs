using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Base;

public class UserGroupEntity : BaseEntity
{
    public long UserEntityId { get; set; }
    public long GroupEntityId { get; set; }


    public virtual UserEntity UserEntity { get; set; }
    public virtual GroupEntity GroupEntity { get; set; }

}
