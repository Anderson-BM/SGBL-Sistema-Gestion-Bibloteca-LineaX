using SGBL.Core.Domain.Common;

namespace SGBL.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {        
        public string Username { get; set; }
        
        public string Password { get; set; }
     
        public string Name { get; set; }
     
        public string Email { get; set; }
     
        public string Phone { get; set; }

        //navigation property
        public int RolId { get; set; } // Foreign Key
        //public Rol Rol { get; set; }   // Navigation property

    }
}
