using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Masar.Application.Common.Mappers;
using Masar.Domain.Entities;
using Masar.Domain.Enums;

namespace Masar.Application.DTOs
{
    public class UpdateUserTripDto : IMapFrom<UserTrip>
    {
        public Guid Id { get; set; }
        public UserTripStatus Status { get; set; }
        public int NumberOfIndividuals { get; set; }
        public double ReservationCost { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserTripDto, UserTrip>().ReverseMap();   
        }
    }
}
