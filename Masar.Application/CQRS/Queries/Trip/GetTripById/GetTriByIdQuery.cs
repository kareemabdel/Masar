


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
        private readonly IRepository<Trip> _TripRepository;

        public GetTripByIdQueryHandler(
            IMapper mapper,
            IRepository<Trip> TripRepository
            )
        {
            _mapper = mapper;
            _TripRepository = TripRepository;
        }

        public async Task<TripDto> Handle(GetTripByIdQuery request, CancellationToken cancellationToken)
        {            
            var data =await _TripRepository.TableNoTracking.Include(e=>e.TripPhotos).Include(e=>e.City).FirstOrDefaultAsync(x => x.Id==request.TripId);
            return _mapper.Map<TripDto>(data);
        }
    }
}

   


