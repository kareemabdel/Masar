using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Masar.Application.Interfaces;
using Masar.Domain;
using Masar.Infrastructure.ApplicationContext;
using Masar.Infrastructure.EfRepositories;
using Masar.Infrastructure.Services;

namespace Masar.Infrastructure.IoC
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            //     services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer(configuration.GetConnectionString("MyConnection")));

        //    services.AddDbContext<ApplicationDbContext>(options =>
        //options.UseMySQL(configuration.GetConnectionString("MyConnection")));

            var mySqlConnectionStr = configuration.GetConnectionString("ApplicationDBConnection");
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr), actions =>
                {
                    actions.MigrationsHistoryTable("__efmigrationshistory");
                    actions.EnableRetryOnFailure(5);
                    actions.CommandTimeout(30);
                });
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<ICurrentUserService, CurrentUserService>();



            return services;
        }
    }
}
