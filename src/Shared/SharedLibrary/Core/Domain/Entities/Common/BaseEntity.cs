using SharedLibrary.Core.Domain.Enums;

namespace SharedLibrary.Core.Domain.Entities.Common;

public class BaseEntity
{
    public long Id { get; set; }
    public EStatus Status { get; set; }
    public long CreatedUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public long? UpdatedUserId { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
