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


        public virtual DbSet<City> Cities { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }  
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<CompanySetting> CompanySettings { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Trip> Trip { get; set; }
      
        public DbSet<AuditTrial> AuditTrial { get; set; }




        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>()
                .HasOne(g => g.Trip)
                .WithMany(p => p.UserTrips)
                .HasForeignKey(p => p.TripId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserTripStatusHistory>()
               .HasOne(g => g.UserTrip)
               .WithMany(p => p.UserTripStatusHistory)
               .HasForeignKey(p => p.UserTripId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Seed();
            modelBuilder.Entity<ApplicationUserRole>().HasKey(c => new { c.UserId, c.RoleId });
        }
    }
}
