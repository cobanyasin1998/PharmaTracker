using Coban.Domain.Entities.Base;
using Coban.Identity.Entities.Auth;

namespace Coban.Identity.Entities.Base;

public class GroupEntity : BaseEntity
{
    public string Name { get; set; }

    public virtual List<UserGroupEntity> UserGroupEntities { get; set; }

    public virtual List<GroupAuthDefinitionEntity> GroupAuthDefinitionEntities { get; set; }

}
