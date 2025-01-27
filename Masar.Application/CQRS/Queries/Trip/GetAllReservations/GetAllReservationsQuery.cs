using AutoMapper;
using Masar.Application.DTOs;
using MediatR;
using Masar.Domain.Entities;
using Masar.Domain;
using Microsoft.EntityFrameworkCore;
using Masar.Application.Interfaces;

namespace Masar.Application.Queries
{
    public class GetAllReservationsQuery : IRequest<IEnumerable<UserTripDto>>
    {

    }

    public class GetAllReservationsQueryHandler :
         IRequestHandler<GetAllReservationsQuery, IEnumerable<UserTripDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllReservationsQueryHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<UserTripDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {            
            var data =await _context.UserTrips
                .Include(e => e.User).Include(w => w.Trip)
                .ThenInclude(e=>e.City)
                .Where(x =>  x.IsActive).ToListAsync();
            return _mapper.Map<List<UserTripDto>>(data);
        }
    }
}

   


