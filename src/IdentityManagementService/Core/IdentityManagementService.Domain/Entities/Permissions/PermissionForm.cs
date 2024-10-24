namespace IdentityManagementService.Domain.Entities.Permissions;

public class PermissionForm
{
    public int FormId { get; set; } // Formun benzersiz kimliği
    public int ModuleId { get; set; } // İlişkili modülün kimliği
    public string FormName { get; set; } // Formun adı
    public string Description { get; set; } // Formun açıklaması
    public DateTime CreatedAt { get; set; } // Oluşturulma tarihi
    public DateTime UpdatedAt { get; set; } // Güncellenme tarihi

    // İlişkiler
    public PermissionModule PermissionModule { get; set; }
}
