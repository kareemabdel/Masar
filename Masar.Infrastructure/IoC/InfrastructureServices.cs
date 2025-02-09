using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Masar.Application.Interfaces;
using Masar.Domain;
using Masar.Infrastructure.ApplicationContext;
using Masar.Infrastructure.Services;
using Microsoft.Extensions.Options;
using System.Runtime.InteropServices;

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
                options.UseSqlServer(mySqlConnectionStr);
            });

            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());


            return services;
        }
    }
}
