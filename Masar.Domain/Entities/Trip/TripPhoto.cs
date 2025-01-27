using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities
{
    public class TripPhoto:BaseEntity<Guid>
    {
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public string FilePath { get; set; }
        public Guid TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
