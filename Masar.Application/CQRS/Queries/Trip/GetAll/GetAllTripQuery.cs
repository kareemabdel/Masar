


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

namespace Masar.Application.Queries
{
    public class GetAllTripQuery : IRequest<IEnumerable<TripDto>>
    {
        public bool IsAdmin { get; set; }
    }

    public class GetAllTripQueryHandler :
         IRequestHandler<GetAllTripQuery, IEnumerable<TripDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Trip> _TripRepository;

        public GetAllTripQueryHandler(
            IMapper mapper,
            IRepository<Trip> TripRepository
            )
        {
            _mapper = mapper;
            _TripRepository = TripRepository;
        }

        public async Task<IEnumerable<TripDto>> Handle(GetAllTripQuery request, CancellationToken cancellationToken)
        {            
            var data =await _TripRepository.TableNoTracking.Include(e => e.TripPhotos).Include(w => w.City).Where(x => !x.IsDeleted && request.IsAdmin ? true : x.IsActive).ToListAsync();
            return _mapper.Map<List<TripDto>>(data);
        }
    }
}

   


