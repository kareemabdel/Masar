using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities.Settings;

namespace Masar.Application.DTOs.Settings
{
    public class ContactUsDto:IMapFrom<ContactUs>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool Read { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContactUsDto,ContactUs>().ReverseMap();
        }
    }
}
