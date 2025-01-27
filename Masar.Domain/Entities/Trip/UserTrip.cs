using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using Masar.Domain.Entities.Comman;
using Masar.Domain.Enums;

namespace Masar.Domain.Entities
{
    public class UserTrip : BaseEntity<Guid>
    {
        public UserTrip()
        {
            UserTripStatusHistory = new List<UserTripStatusHistory>();
        }
        public Guid TripId { get; set; }
        public Guid UserId { get; set; }
        public int NumberOfIndividuals { get; set; }
        public double ReservationCost { get; set; }
        public UserTripStatus Status { get; set; }
        public virtual Trip Trip { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<UserTripStatusHistory> UserTripStatusHistory { get; set; }
    }
}
