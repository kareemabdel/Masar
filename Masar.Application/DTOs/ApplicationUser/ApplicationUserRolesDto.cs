using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities;
using Masar.Domain.Enums;

namespace Masar.Application.DTOs
{
    public class ApplicationUserRolesDto : IMapFrom<ApplicationUserRoles>
    {
        public int RoleId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUserRolesDto, ApplicationUserRoles>().ReverseMap();
        }
    }
}
