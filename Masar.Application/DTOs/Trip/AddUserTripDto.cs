using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities;
using Masar.Domain.Enums;

namespace Masar.Application.DTOs
{
    public class AddUserTripDto : IMapFrom<UserTrip>
    {
        public Guid TripId { get; set; }
        public Guid UserId { get; set; }
        public int NumberOfIndividuals { get; set; }
        public double ReservationCost { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddUserTripDto, UserTrip>().ReverseMap();   
        }
    }
}
