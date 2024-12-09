using Microsoft.EntityFrameworkCore;

namespace Masar.Infrastructure.Seed
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            LookupSeeder.SeedLookUps(modelBuilder);
            DataSeeder.SeedData(modelBuilder);
        }
    }
}
