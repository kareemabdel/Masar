using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities;

namespace Masar.Application.DTOs
{
    public class AddCitiesDto : IMapFrom<Cities>
    {
        public string Code { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddCitiesDto, Cities>().ReverseMap();
        }
    }
}
