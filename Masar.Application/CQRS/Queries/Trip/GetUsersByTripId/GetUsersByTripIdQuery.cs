


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
        private readonly IRepository<ApplicationUser> _TripRepository;

        public GetUsersByTripIdQueryHandler(
            IMapper mapper,
            IRepository<ApplicationUser> TripRepository
            )
        {
            _mapper = mapper;
            _TripRepository = TripRepository;
        }

        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetUsersByTripIdQuery request, CancellationToken cancellationToken)
        {            
            var data = await _TripRepository.TableNoTracking.Where(e=>e.UserTrips.Any(w=>w.TripId==request.TripId)).ToListAsync();
            return _mapper.Map<List<ApplicationUserDto>>(data);
        }
    }
}

   


