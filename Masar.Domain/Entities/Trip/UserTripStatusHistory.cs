using Masar.Domain.Entities.Comman;
using Masar.Domain.Enums;

namespace Masar.Domain.Entities
{
    public class UserTripStatusHistory : BaseEntity<Guid>
    {
        public Guid UserTripId { get; set; }
        public virtual UserTrip UserTrip { get; set; }
        public UserTripStatus Status { get; set; }
        public Guid ChangedById { get; set; }
        public virtual User ChangedBy { get; set; }
    }
}
