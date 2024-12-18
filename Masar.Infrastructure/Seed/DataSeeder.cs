//using CaseType = Masar.Infrastructure.Entities.Application.Cases.CaseType;
using Microsoft.EntityFrameworkCore;
using Masar.Domain.Entities;
using Masar.Domain.Enums;

namespace Masar.Infrastructure.Seed
{
    public static class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {       
            //add  admin user,  password:123 
            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser { Id = Guid.Parse("8667a9bf-c714-43cc-9a3c-fd3981c8a3d8"), Name = "Admin admin ", Email = "admin@company.com" ,Password= "iBbtmDi0qFeHHFgh+IXz5GklG0Jqy75i81vlpg136MY=", Phone= "11111111111",UserName="admin" }
           );
            modelBuilder.Entity<Role>().HasData(
              new Role { Id = (int)UserTypes.Admin, Name = UserTypes.Admin.ToString(), NameAr="مدير" },
              new Role { Id = (int)UserTypes.User, Name = UserTypes.User.ToString(), NameAr="مستخدم" }
          );

            modelBuilder.Entity<ApplicationUserRole>().HasData(
             new ApplicationUserRole { UserId = Guid.Parse("8667a9bf-c714-43cc-9a3c-fd3981c8a3d8"), RoleId = (int)UserTypes.Admin }
         );

        }
    }
}
