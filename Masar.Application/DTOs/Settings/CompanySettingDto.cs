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
    public class CompanySettingDto:IMapFrom<CompanySetting>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? TikTok { get; set; }
        public string? Twitter { get; set; }
        public string? Youtube { get; set; }
        public string About { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CompanySettingDto,CompanySetting>().ReverseMap();
        }
    }
}
