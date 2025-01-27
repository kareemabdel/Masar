


using AutoMapper;
using Masar.Application.DTOs;
using Masar.Application.Interfaces;
using MediatR;
using Masar.Domain.Entities;
using Masar.Domain;
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
        private readonly IApplicationDbContext _context;
        public GetAllTripQueryHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<TripDto>> Handle(GetAllTripQuery request, CancellationToken cancellationToken)
        {
             var data =  _context.Trips.AsQueryable();
            if (!request.IsAdmin)
            {
                data = data.Where(x =>  x.IsActive && x.TripStatus == Domain.Enums.TripStatus.Posted);
            }   
            return _mapper.Map<List<TripDto>>(await data.ToListAsync());
        }
    }
}

   


