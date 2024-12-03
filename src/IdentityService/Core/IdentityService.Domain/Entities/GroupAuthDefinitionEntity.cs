using Coban.Domain.Entities.Base;

namespace IdentityService.Domain.Entities;

public class GroupAuthDefinitionEntity : BaseEntity
{
    public long GroupEntityId { get; set; }
    public long AuthDefinitionEntityId { get; set; }

    public virtual GroupEntity GroupEntity { get; set; }
    public virtual AuthDefinitionEntity AuthDefinitionEntity { get; set; }
}
