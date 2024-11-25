using Coban.Domain.Entities.Base.Abstraction;
using Coban.Domain.Enums.Base;

namespace Coban.Domain.Entities.Base;

public abstract class BaseEntity : IBaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public long CreatedUserId { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public long? UpdatedUserId { get; set; }
    public EEntityStatus Status { get; set; }
}
