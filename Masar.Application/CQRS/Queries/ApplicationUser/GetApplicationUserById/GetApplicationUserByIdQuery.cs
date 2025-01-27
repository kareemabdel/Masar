


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
    public class GetApplicationUserByIdQuery : IRequest<ApplicationUserDto>
    {
        public Guid UserId { get; set; }
    }

    public class GetApplicationUserByIdQueryHandler :
         IRequestHandler<GetApplicationUserByIdQuery, ApplicationUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetApplicationUserByIdQueryHandler(
            IMapper mapper
, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ApplicationUserDto> Handle(GetApplicationUserByIdQuery request, CancellationToken cancellationToken)
        {            
            var data = _context.Users.Include(e=>e.UserRoles).FirstOrDefaultAsync(x => x.Id==request.UserId);
            return _mapper.Map<ApplicationUserDto>(data.Result);
        }
    }
}

   


