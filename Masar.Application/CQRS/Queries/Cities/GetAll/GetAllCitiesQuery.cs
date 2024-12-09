


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
        private readonly IRepository<Cities> _CitiesRepository;
        private readonly IStringLocalizer<GetAllCitiesQuery> _localizer;
        public GetAllCitiesQueryHandler(IMapper mapper, IRepository<Cities> CitiesRepository, IStringLocalizer<GetAllCitiesQuery> localizer)
        {
            _mapper = mapper;
            _CitiesRepository = CitiesRepository;
            _localizer = localizer;
        }

        public async Task<IEnumerable<CitiesDto>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {  
            var data =await _CitiesRepository.TableNoTracking.Where(x => !x.IsDeleted && request.IsAdmin? true:x.IsActive).ToListAsync();
            return _mapper.Map<List<CitiesDto>>(data);
        }
    }
}

   


