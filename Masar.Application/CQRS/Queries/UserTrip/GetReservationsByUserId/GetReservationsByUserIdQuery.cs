using AutoMapper;
using Masar.Application.DTOs;
using MediatR;
using Masar.Domain.Entities;
using Masar.Domain;
using Microsoft.EntityFrameworkCore;

namespace Masar.Application.Queries
{
    public class GetReservationsByUserIdQuery : IRequest<IEnumerable<UserTripDto>>
    {
        public Guid UserId { get; set; }
    }

    public class GetReservationsByUserIdQueryHandler :
         IRequestHandler<GetReservationsByUserIdQuery, IEnumerable<UserTripDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UserTrip> _TripRepository;

        public GetReservationsByUserIdQueryHandler(
            IMapper mapper,
            IRepository<UserTrip> TripRepository
            )
        {
            _mapper = mapper;
            _TripRepository = TripRepository;
        }

        public async Task<IEnumerable<UserTripDto>> Handle(GetReservationsByUserIdQuery request, CancellationToken cancellationToken)
        {            
            var data =await _TripRepository.TableNoTracking.Include(w => w.Trip).Where(x =>x.UserId==request.UserId).ToListAsync();
            return _mapper.Map<List<UserTripDto>>(data);
        }
    }
}

   


