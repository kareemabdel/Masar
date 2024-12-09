using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities;
using Masar.Domain.Enums;

namespace Masar.Application.DTOs
{
    public class UserTripDto : IMapFrom<UserTrip>
    {
        public Guid Id { get; set; }
        public Guid TripId { get; set; }
        public UserTripStatus Status { get; set; }
        public int NumberOfIndividuals { get; set; }
        public double ReservationCost { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public string TripName { get; set; }
        public string CityName { get; set; }
        public int Days { get; set; }
        public double Price { get; set; }
        public DateTimeOffset Date { get; set; }
        public string UserFullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserTripDto, UserTrip>().ReverseMap()
                .ForMember(u => u.TripName, t => t.MapFrom(t => t.Trip.Name))
                .ForMember(u => u.Days, t => t.MapFrom(t => t.Trip.Days))
                .ForMember(u => u.Price, t => t.MapFrom(t => t.Trip.Price))
                .ForMember(u => u.Date, t => t.MapFrom(t => t.Trip.Date))
                .ForMember(u => u.UserFullName, t => t.MapFrom(t => t.User.Name))
                .ForMember(u => u.Phone, t => t.MapFrom(t => t.User.Phone))
                .ForMember(u => u.Email, t => t.MapFrom(t => t.User.Email))
                .ForMember(u => u.CityName, t => t.MapFrom(t => t.Trip.City.ArabicDescription));
        }
    }
}
