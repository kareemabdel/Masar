using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Masar.Domain.Entities.Comman;

namespace Masar.Domain.Entities.Settings
{
    public class CompanySetting:BaseEntity<int>
    {
        public string  Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? TikTok { get; set; }
        public string? Twitter { get; set; }
        public string? Youtube { get; set; }
        public string About { get; set; }
    }
}
