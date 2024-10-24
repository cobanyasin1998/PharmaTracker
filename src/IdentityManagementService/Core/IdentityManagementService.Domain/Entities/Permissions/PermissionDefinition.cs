using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManagementService.Domain.Entities.Permissions
{
    public class PermissionDefinition
    {
        public int PermissionId { get; set; } // Yetkinin benzersiz kimliği
        public int ModuleId { get; set; } // İlişkili modülün kimliği
        public string PermissionName { get; set; } // Yetkinin adı
        public string Description { get; set; } // Yetkinin açıklaması
        public DateTime CreatedAt { get; set; } // Oluşturulma tarihi
        public DateTime UpdatedAt { get; set; } // Güncellenme tarihi

        // İlişkiler
        public PermissionModule PermissionModule { get; set; }
    }
}
