using Coban.Domain.Enums.Base;

namespace Coban.Domain.Entities.Base.Abstraction;

public interface IBaseEntity
{
    long Id { get; set; }

    DateTime CreatedTime { get; set; }
    long CreatedUserId { get; set; }

    DateTime? UpdatedTime { get; set; }
    long? UpdatedUserId { get; set; }

    EEntityStatus Status { get; set; }
}
