using Coban.Domain.Entities.Base;

namespace IdentityService.Domain.Entities;

public class AuthDefinitionEntity:BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }

    public long AuthFormEntityId { get; set; }
    public virtual AuthFormEntity AuthFormEntity { get; set; }

    public virtual List<GroupAuthDefinitionEntity> GroupAuthDefinitionEntities { get; set; }

}
//Save//Update