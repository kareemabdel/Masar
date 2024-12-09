using Masar.Domain.Entities.Comman;
using Masar.Domain.Enums;

namespace Masar.Domain.Entities
{
    public class UserTripStatusHistory : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid UserTripId { get; set; }
        public virtual UserTrip UserTrip { get; set; }
        public UserTripStatus Status { get; set; }
        public Guid ChagedById { get; set; }
        public virtual ApplicationUser ChagedBy { get; set; }
    }
}
