


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
using Masar.Domain.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace Masar.Application.Queries
{
    public class GetUsersByUserTypeQuery : IRequest<IEnumerable<ApplicationUserDto>>
    {
        public int [] UserTypes { get; set; }
    }

    public class GetUsersByUserTypeQueryHandler :
         IRequestHandler<GetUsersByUserTypeQuery, IEnumerable<ApplicationUserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ApplicationUser> _ApplicationUserRepository;

        public GetUsersByUserTypeQueryHandler(
            IMapper mapper,
            IRepository<ApplicationUser> ApplicationUserRepository
            )
        {
            _mapper = mapper;
            _ApplicationUserRepository = ApplicationUserRepository;
        }

        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetUsersByUserTypeQuery request, CancellationToken cancellationToken)
        {            
            var data = _ApplicationUserRepository.TableNoTracking.Include(e=>e.UserRoles).Where(e=>e.UserRoles.Any(x=>request.UserTypes.Contains(x.RoleId))).ToList();
            return _mapper.Map<List<ApplicationUserDto>>(data);
        }
    }
}

   


