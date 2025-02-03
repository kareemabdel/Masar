using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities
{
    public class Role:BaseEntity<int>
    {
        public Role()
        {
            UserRoles = new List<UserRole>();
        }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int RoleId { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string NameAr { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
