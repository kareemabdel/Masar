


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

namespace Masar.Application.Queries
{
    public class GetAllApplicationUserQuery : IRequest<IEnumerable<ApplicationUserDto>>
    {

    }

    public class GetAllApplicationUserQueryHandler :
         IRequestHandler<GetAllApplicationUserQuery, IEnumerable<ApplicationUserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllApplicationUserQueryHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetAllApplicationUserQuery request, CancellationToken cancellationToken)
        {
            var data = _context.Users.Include(e => e.UserRoles).ToList();
            return _mapper.Map<List<ApplicationUserDto>>(data);
        }
    }
}

   


