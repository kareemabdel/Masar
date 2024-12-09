﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities;
using Masar.Domain.Enums;

namespace Masar.Application.DTOs
{
    public class AddApplicationUserDto : IMapFrom<ApplicationUser>
    {

        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Name is Required")]
        public string Password { get; set; }
        public string Name { get; set; }
        [RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "Please Enter Valid Egyption Phone Number"), Required(ErrorMessage = "Phone is Required")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string Email { get; set; }
        public List<ApplicationUserRolesDto> UserRoles { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddApplicationUserDto, ApplicationUser>().ReverseMap();
        }
    }
}
