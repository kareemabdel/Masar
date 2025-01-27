using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities
{
    public class ApplicationUserRole:BaseEntity<int>
    {  
        public int RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
