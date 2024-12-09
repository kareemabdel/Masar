using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities.Settings
{
    public class ContactUs:BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool Read { get; set; }
    }
}
