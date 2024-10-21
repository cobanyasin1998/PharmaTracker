using PharmacyService.Domain.Enums;

namespace PharmacyService.Domain.Entities.Common;

public class BaseEntity
{
    public long Id { get; set; }
    public EStatus Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
