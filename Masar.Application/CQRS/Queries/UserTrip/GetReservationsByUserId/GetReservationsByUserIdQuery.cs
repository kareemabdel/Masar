using AutoMapper;
using Masar.Application.DTOs;
using MediatR;
using Masar.Domain.Entities;
using Masar.Domain;
using Microsoft.EntityFrameworkCore;
using Masar.Application.Interfaces;

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
        private readonly IApplicationDbContext _context;

        public GetReservationsByUserIdQueryHandler(
            IMapper mapper            )
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserTripDto>> Handle(GetReservationsByUserIdQuery request, CancellationToken cancellationToken)
        {            
            var data =await _context.UserTrips.Include(w => w.Trip).Where(x =>x.UserId==request.UserId).ToListAsync();
            return _mapper.Map<List<UserTripDto>>(data);
        }
    }
}

   


