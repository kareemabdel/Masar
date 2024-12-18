using Microsoft.EntityFrameworkCore;
using Masar.Domain;
using Masar.Domain.Entities.Comman;
using Masar.Domain.Entities;
using Masar.Domain.Entities.Settings;

namespace Masar.Application.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<City> Cities { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        DbSet<Role> Roles { get; set; } 
        DbSet<Gallery> Galleries { get; set; }
        DbSet<CompanySetting> CompanySettings { get; set; }
        DbSet<ContactUs> ContactUs { get; set; }
        DbSet<AuditTrial> AuditTrial { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
