using System.Drawing;
using Masar.Domain.Entities.Comman;

using Masar.Domain.Enums;

namespace Masar.Domain.Entities
{


    public class Trip : BaseEntity
    {
        public Trip()
        {
            UserTrips =new List<UserTrip>();
            TripPhotos = new List<TripPhoto>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
        public double Price { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public int MaxReservations { get; set; }
        public TripStatus TripStatus { get; set; }
        public DateTimeOffset Date { get; set; }  
        public Guid CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<UserTrip> UserTrips { get; set; }
        public virtual ICollection<TripPhoto> TripPhotos { get; set; }

       
      
    }
}
