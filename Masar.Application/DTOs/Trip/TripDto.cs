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
    public class TripDto : IMapFrom<Trip>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
        public double Price { get; set; }
        public TripStatus TripStatus { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public Guid CityId { get; set; }
        public List<TripPhotoDto>? TripPhotos { get; set; }
       // public List<IFormFile>? Photos { get; set; }
        public  string? City { get; set; }
        public int MaxReservations { get; set; }
        public bool IsActive { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TripDto, Trip>().ReverseMap()
                .ForMember(w=>w.City,e=>e.MapFrom(w=>w.City.ArabicDescription));   
        }
    }
}
