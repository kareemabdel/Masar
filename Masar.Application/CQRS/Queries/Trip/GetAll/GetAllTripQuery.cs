


using AutoMapper;
using Masar.Application.DTOs;
using Masar.Application.Interfaces;
using MediatR;
using Masar.Domain.Entities;
using Masar.Domain;
using Microsoft.EntityFrameworkCore;
using Masar.Application.Models;
using AutoMapper.QueryableExtensions;

namespace Masar.Application.Queries
{
   
    public class GetAllTripQuery : IRequest<PaginatedList<TripDto>>
    {
        public bool IsAdmin { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }

    public class GetAllTripQueryHandler :
         IRequestHandler<GetAllTripQuery, PaginatedList<TripDto>>
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

        public async Task<PaginatedList<TripDto>> Handle(GetAllTripQuery request, CancellationToken cancellationToken)
        {
             var data =  _context.Trips.AsQueryable();
            if (!request.IsAdmin)
            {
                data = data.Where(x =>  x.IsActive && x.TripStatus == Domain.Enums.TripStatus.Posted);
            }
            var mappedItems = data.ProjectTo<TripDto>(_mapper.ConfigurationProvider);
            return await PaginatedList<TripDto>.CreateAsync(mappedItems, request.page, request.size);
        }
    }
}

   


