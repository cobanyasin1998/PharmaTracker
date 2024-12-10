using Coban.Domain.Entities.Base;

namespace Coban.Identity.Entities.Auth;

public class AuthFormEntity : BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public long AuthModuleEntityId { get; set; }
    public virtual AuthModuleEntity AuthModuleEntity { get; set; }
    public virtual List<AuthDefinitionEntity> AuthDefinitionEntities { get; set; }
}
