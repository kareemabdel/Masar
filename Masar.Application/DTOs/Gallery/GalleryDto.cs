using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities;
using Masar.Domain.Enums;

namespace Masar.Application.DTOs
{
    public class GalleryDto : IMapFrom<Gallery>
    {
        public Guid? Id { get; set; }
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public IFormFile? File { get; set; }
        public string? FilePath { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GalleryDto, Gallery>().ReverseMap();   
        }
    }
}
