using Coban.Domain.Entities.Base;

namespace IdentityService.Domain.Entities;

public class AuthModuleEntity : BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }

    public virtual List<AuthFormEntity> AuthFormEntities { get; set; }
}
//Pharmacy
//FileStorage