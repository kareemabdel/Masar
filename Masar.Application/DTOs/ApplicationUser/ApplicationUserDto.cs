using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities;

namespace Masar.Application.DTOs
{
    public class ApplicationUserDto : IMapFrom<ApplicationUser>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<ApplicationUserRolesDto>? UserRoles { get; set; }
        public List<UserTripDto>? UserTrips { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();
        }
    }
}
