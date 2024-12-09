using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities;
using Masar.Domain.Enums;

namespace Masar.Application.DTOs
{
    public class AddTripDto : IMapFrom<Trip>
    {
        public string Name { get; set; }
        public int Days { get; set; }
        public double Price { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public Guid CityId { get; set; }
        public List<TripPhotoDto>? TripPhotos { get; set; }
        public int MaxReservations { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddTripDto, Trip>().ReverseMap();
        }
    }
}
