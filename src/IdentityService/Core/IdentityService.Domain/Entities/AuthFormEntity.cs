using Coban.Domain.Entities.Base;

namespace IdentityService.Domain.Entities;

public class AuthFormEntity : BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }

    public long AuthModuleEntityId { get; set; }
    public virtual AuthModuleEntity AuthModuleEntity { get; set; }

    public virtual List<AuthDefinitionEntity> AuthDefinitionEntities { get; set; }


}
//Pharmacy
//PharmacyBranch