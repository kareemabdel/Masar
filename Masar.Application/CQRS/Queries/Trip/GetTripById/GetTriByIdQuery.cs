


using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Masar.Application.DTOs;
using Masar.Application.Interfaces;
using MediatR;
using AutoMapper.QueryableExtensions;
using Masar.Domain.Entities;
using Masar.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Masar.Application.Queries
{
    public class GetTripByIdQuery : IRequest<TripDto>
    {
        public Guid TripId { get; set; }
    }

    public class GetTripByIdQueryHandler :
         IRequestHandler<GetTripByIdQuery, TripDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetTripByIdQueryHandler(
            IMapper mapper,
            IApplicationDbContext context
            )
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TripDto> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
        {            
            var data =await _context.Trips.Include(e=>e.TripPhotos).Include(e=>e.City).FirstOrDefaultAsync(x => x.Id==request.TripId);
            return _mapper.Map<TripDto>(data);
        }
    }
}

   


