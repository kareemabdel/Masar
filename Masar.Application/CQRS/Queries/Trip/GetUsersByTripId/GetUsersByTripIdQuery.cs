


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
    public class GetUsersByTripIdQuery : IRequest<IEnumerable<ApplicationUserDto>>
    {
        public Guid TripId { get; set; }
    }

    public class GetUsersByTripIdQueryHandler :
         IRequestHandler<GetUsersByTripIdQuery, IEnumerable<ApplicationUserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetUsersByTripIdQueryHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetUsersByTripIdQuery request, CancellationToken cancellationToken)
        {            
            var data = await _context.Users.Where(e=>e.UserTrips.Any(w=>w.TripId==request.TripId)).ToListAsync();
            return _mapper.Map<List<ApplicationUserDto>>(data);
        }
    }
}

   


