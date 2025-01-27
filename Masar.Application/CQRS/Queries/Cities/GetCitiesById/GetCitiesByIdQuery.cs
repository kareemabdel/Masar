


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
    public class GetCitiesByIdQuery : IRequest<CitiesDto>
    {
        public Guid CitiesId { get; set; }
    }

    public class GetCitiesByIdQueryHandler :
         IRequestHandler<GetCitiesByIdQuery, CitiesDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetCitiesByIdQueryHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CitiesDto> Handle(GetCitiesByIdQuery request, CancellationToken cancellationToken)
        {            
            var data = _context.Cities.FirstOrDefaultAsync(x => x.Id==request.CitiesId);
            return _mapper.Map<CitiesDto>(data.Result);
        }
    }
}

   


