


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
    public class GetTripsByUserIdQuery : IRequest<IEnumerable<UserTripDto>>
    {
        public Guid UserId { get; set; }
    }

    public class GetTripsByUserIdQueryHandler :
         IRequestHandler<GetTripsByUserIdQuery, IEnumerable<UserTripDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetTripsByUserIdQueryHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<UserTripDto>> Handle(GetTripsByUserIdQuery request, CancellationToken cancellationToken)
        {            
            var data = await _context.UserTrips.Include(r=>r.Trip).Where(x => x.UserId==request.UserId).ToListAsync();
            return _mapper.Map<List<UserTripDto>>(data);
        }
    }
}

   


