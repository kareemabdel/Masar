using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        public User()
        {
            UserRoles = new List<UserRole>();
            UserTrips = new List<UserTrip>();
        }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string UserName { get; set; }
        public string Password { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserTrip> UserTrips { get; set; }
    }
}
