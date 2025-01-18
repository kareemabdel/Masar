using System;
using System.Collections.Generic;
using System.Text;

namespace Masar.Domain.Entities.Comman
{
    public class BaseEntity
    {
        public bool IsActive { get; set; } = true;
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
