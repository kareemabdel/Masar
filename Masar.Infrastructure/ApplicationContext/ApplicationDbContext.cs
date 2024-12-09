using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Masar.Application.Interfaces;
using Masar.Domain;
using Masar.Domain.Entities;
using Masar.Domain.Entities.Comman;
using Masar.Domain.Entities.Settings;
using Masar.Infrastructure.Seed;

namespace Masar.Infrastructure.ApplicationContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public virtual DbSet<Cities> Cities { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationUserRoles> ApplicationUserRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<CompanySetting> CompanySetting { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<AuditTrial> AuditTrial { get; set; }




        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            modelBuilder.Entity<ApplicationUserRoles>().HasKey(c => new { c.UserId, c.RoleId });
        }
    }
}
