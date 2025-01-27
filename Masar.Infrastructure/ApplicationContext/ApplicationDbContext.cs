using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Masar.Application.Interfaces;
using Masar.Domain;
using Masar.Domain.Entities;
using Masar.Domain.Entities.Comman;
using Masar.Domain.Entities.Settings;
using Masar.Infrastructure.Seed;
using Masar.Infrastructure.Services;
using System.Linq.Expressions;

namespace Masar.Infrastructure.ApplicationContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        //private readonly ICurrentUserService _currentUserService;
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options/*, ICurrentUserService currentUserService*/) : base(options)
        {
            //_currentUserService = currentUserService;
        }


        public virtual DbSet<City> Cities { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }   
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<CompanySetting> CompanySettings { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<UserTrip> UserTrips { get; set; }
        public DbSet<TripPhoto> TripPhotos { get; set; }
        public DbSet<AuditTrial> AuditTrial { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                // Check if the entity inherits from BaseEntity<>
                if (entry.Entity.GetType().BaseType != null &&
                    entry.Entity.GetType().BaseType.IsGenericType &&
                    entry.Entity.GetType().BaseType.GetGenericTypeDefinition() == typeof(BaseEntity<>))
                {
                    // Use dynamic to access properties of BaseEntity<TId>
                    dynamic entity = entry.Entity;

                    // Skip entities that are Detached or Unchanged
                    if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    {
                        continue;
                    }

                    // Handle Added and Modified states
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = DateTimeOffset.UtcNow;
                            // entity.CreatedBy = _currentUserService.GetUserId(); // Uncomment if applicable
                            break;

                        case EntityState.Modified:
                            entity.UpdatedDate = DateTimeOffset.UtcNow;
                            break;
                    }
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply the filter to all entities that inherit from BaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Check if the entity inherits from BaseEntity<>
                if (entityType.ClrType.BaseType != null &&
                    entityType.ClrType.BaseType.IsGenericType &&
                    entityType.ClrType.BaseType.GetGenericTypeDefinition() == typeof(BaseEntity<>))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, nameof(BaseEntity<object>.IsDeleted));
                    var filter = Expression.Lambda(
                        Expression.Equal(property, Expression.Constant(false)),
                        parameter
                    );

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }
           

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
           
        }
    }
}
