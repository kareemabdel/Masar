


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
using Microsoft.Extensions.Localization;

namespace Masar.Application.Queries
{
    public class GetAllCitiesQuery : IRequest<IEnumerable<CitiesDto>>
    {
        public bool IsAdmin { get; set; }

    }

    public class GetAllCitiesQueryHandler :IRequestHandler<GetAllCitiesQuery, IEnumerable<CitiesDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IStringLocalizer<GetAllCitiesQuery> _localizer;
        public GetAllCitiesQueryHandler(IMapper mapper, IStringLocalizer<GetAllCitiesQuery> localizer, IApplicationDbContext context)
        {
            _mapper = mapper;
            _localizer = localizer;
            _context = context;
        }

        public async Task<IEnumerable<CitiesDto>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {  
            var data =await _context.Cities.Where(x => request.IsAdmin? true:x.IsActive).ToListAsync();
            return _mapper.Map<List<CitiesDto>>(data);
        }
    }
}

   


