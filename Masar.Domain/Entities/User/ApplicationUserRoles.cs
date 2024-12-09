using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities
{
    [Table("ApplicationUserRole")]
    public class ApplicationUserRoles:BaseEntity
    {
        public int RoleId { get; set; }
        public Guid UserId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
