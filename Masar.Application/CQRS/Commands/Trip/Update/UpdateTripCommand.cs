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
        private readonly IApplicationDbContext _context;

        public UpdateTripCommandHandler(
            IMapper mapper
,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<TripDto> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Trips.Include(e=>e.TripPhotos).FirstOrDefaultAsync(r=>r.Id==request.obj.Id);
            if (item != null)
            {
                item = _mapper.Map(request.obj, item);
               await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<TripDto>(item);
            }
            throw new Exception($"Entitie with id {request.obj.Id} not found");
        }
    }
}

   

