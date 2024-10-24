using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManagementService.Domain.Entities.Permissions
{
    public class PermissionModule
    {
        public int ModuleId { get; set; } // Modülün benzersiz kimliği
        public string ModuleName { get; set; } // Modülün adı
        public string Description { get; set; } // Modülün açıklaması
        public DateTime CreatedAt { get; set; } // Oluşturulma tarihi
        public DateTime UpdatedAt { get; set; } // Güncellenme tarihi

        // İlişkiler
        public ICollection<PermissionDefinition> PermissionDefinitions { get; set; }
        public ICollection<PermissionForm> PermissionForms { get; set; }
    }
}
