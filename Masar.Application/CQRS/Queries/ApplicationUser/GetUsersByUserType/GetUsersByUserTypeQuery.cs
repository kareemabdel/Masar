


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
        private readonly IApplicationDbContext _context;

        public GetUsersByUserTypeQueryHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetUsersByUserTypeQuery request, CancellationToken cancellationToken)
        {            
            var data = _context.Users.Include(e=>e.UserRoles).Where(e=>e.UserRoles.Any(x=>request.UserTypes.Contains(x.RoleId))).ToList();
            return _mapper.Map<List<ApplicationUserDto>>(data);
        }
    }
}

   


