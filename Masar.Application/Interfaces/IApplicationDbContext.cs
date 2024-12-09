using Microsoft.EntityFrameworkCore;
using Masar.Domain;
using Masar.Domain.Entities.Comman;
using Masar.Domain.Entities;
using Masar.Domain.Entities.Settings;

namespace Masar.Application.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Cities> Cities { get; set; }
        DbSet<ApplicationUser> ApplicationUser { get; set; }
        DbSet<ApplicationUserRoles> ApplicationUserRole { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<Trip> Trips { get; set; }
        DbSet<Gallery> Gallery { get; set; }
        DbSet<CompanySetting> CompanySetting { get; set; }
        DbSet<ContactUs> ContactUs { get; set; }
        DbSet<AuditTrial> AuditTrial { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
