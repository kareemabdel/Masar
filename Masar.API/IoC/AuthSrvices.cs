﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Masar.Application.Common.Extensions.Helpers;

namespace Masar.API.IoC
{
    public static class AuthSrvices
    {
        public static void AddAuthSrvices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });


            services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                config.AddPolicy(Policies.User, Policies.AuditorPolicy());

            });

            //return services;
        }
    }
}
