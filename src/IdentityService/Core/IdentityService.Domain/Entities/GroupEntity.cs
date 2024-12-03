using Coban.Domain.Entities.Base;

namespace IdentityService.Domain.Entities;

public class GroupEntity : BaseEntity
{
    public string Name { get; set; }

    public virtual List<UserGroupEntity> UserGroupEntities { get; set; }

    public virtual List<GroupAuthDefinitionEntity> GroupAuthDefinitionEntities { get; set; }

}
