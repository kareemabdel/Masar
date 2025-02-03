using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities
{
    public class UserRole
    {  
        public int RoleId { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
