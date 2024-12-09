using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Masar.Application.Queries.Auth.Login;
using Masar.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Masar.Application.DTOs;

namespace Masar.Api.Helpers
{
    public static class JwtHelper
    {
        public static string GenerateJwtToken(ApplicationUserDto userInfo, IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("UserName", userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Id", userInfo.Id.ToString()),
            };

            foreach (var role in userInfo.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, ((UserTypes)role.RoleId).ToString()));

            }

            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(14),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
