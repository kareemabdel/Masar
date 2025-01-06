// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.Trips.DTOs;

using AutoMapper;
using Masar.Application.Interfaces;
using Masar.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Masar.Application.DTOs;
using System;
using Masar.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Masar.Application.Commands
{
    public class UpdateTripCommand : IRequest<TripDto>
    {
        public TripDto obj { get; set; }

    }

    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand, TripDto>
    {        
        private readonly IMapper _mapper;
        private readonly IRepository<Trip> _servicesRepository;

        public UpdateTripCommandHandler(
            IRepository<Trip> servicesRepository,
            IMapper mapper
            )
        {
            _servicesRepository = servicesRepository;            
            _mapper = mapper;
        }
        public async Task<TripDto> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var item = await _servicesRepository.Table.Include(e=>e.TripPhotos).FirstOrDefaultAsync(r=>r.Id==request.obj.Id);
            if (item != null)
            {
                item = _mapper.Map(request.obj, item);
                var result = _servicesRepository.UpdateWithEntityReturn(item);

                return _mapper.Map<TripDto>(result);
            }
            throw new Exception($"Entitie with id {request.obj.Id} not found");
        }
    }
}

   

