using Coban.Domain.Entities.Base;
using Coban.Domain.Enums.General;

namespace Coban.Domain.Entities.General;

public class GeneralFileEntity : BaseEntity
{
    public long TableRowId { get; set; }
    public FileEnumType FileEnumType { get; set; }
}
