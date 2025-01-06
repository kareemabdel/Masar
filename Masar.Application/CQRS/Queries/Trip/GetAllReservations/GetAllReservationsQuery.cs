using AutoMapper;
using Masar.Application.DTOs;
using MediatR;
using Masar.Domain.Entities;
using Masar.Domain;
using Microsoft.EntityFrameworkCore;

namespace Masar.Application.Queries
{
    public class GetAllReservationsQuery : IRequest<IEnumerable<UserTripDto>>
    {

    }

    public class GetAllReservationsQueryHandler :
         IRequestHandler<GetAllReservationsQuery, IEnumerable<UserTripDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UserTrip> _UserTripRepository;

        public GetAllReservationsQueryHandler(
            IMapper mapper,
            IRepository<UserTrip> UserTripRepository
            )
        {
            _mapper = mapper;
            _UserTripRepository = UserTripRepository;
        }

        public async Task<IEnumerable<UserTripDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {            
            var data =await _UserTripRepository.TableNoTracking.Include(e => e.User).Include(w => w.Trip).ThenInclude(e=>e.City).Where(x => !x.IsDeleted && x.IsActive).ToListAsync();
            return _mapper.Map<List<UserTripDto>>(data);
        }
    }
}

   


