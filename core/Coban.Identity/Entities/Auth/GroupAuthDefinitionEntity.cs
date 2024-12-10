using Coban.Domain.Entities.Base;
using Coban.Identity.Entities.Base;

namespace Coban.Identity.Entities.Auth;

public class GroupAuthDefinitionEntity : BaseEntity
{
    public long GroupEntityId { get; set; }
    public long AuthDefinitionEntityId { get; set; }

    public virtual GroupEntity GroupEntity { get; set; }
    public virtual AuthDefinitionEntity AuthDefinitionEntity { get; set; }
}
