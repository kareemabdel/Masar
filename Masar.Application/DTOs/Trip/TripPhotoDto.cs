using AutoMapper;
using Microsoft.AspNetCore.Http;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities;

namespace Masar.Application.DTOs
{
    public class TripPhotoDto : IMapFrom<TripPhoto>
    {
        public Guid? Id { get; set; }
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public IFormFile? Photo { get; set; }
        public string? FilePath { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TripPhotoDto, TripPhoto>().ReverseMap();   
        }
    }
}
