using MedicineService.Domain.Entities.Common;

namespace MedicineService.Domain.Entities;

public class Medicine : BaseEntity
{
    public string Name { get; set; }
    public string GenericName { get; set; }
    public string Description { get; set; }
    public string Barcode { get; set; }





}
