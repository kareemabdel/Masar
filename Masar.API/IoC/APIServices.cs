using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using NLog;
using Masar.API.Middleware.ResponseHandling;
using Masar.Application.Common.Mappers;
using Masar.EmailServices;

namespace Masar.API.IoC
{
    public static class APIServices
    {
        public static void AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
                {
                    options.Filters.Add<UnifyResponseFilter>();
                });

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Masar API", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                };
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{{ securityScheme, Array.Empty<string>() }});
            });

            var hosts = configuration.GetSection("Cors:AllowedOrigins").Get<List<string>>();
            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowedOrigins", p =>
                {
                    p.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(hosts.ToArray());
                });
            });

            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
             services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();


           services.AddAutoMapper(typeof(MappingProfile));
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            // return services;
        }
    }
}
