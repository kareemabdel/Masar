


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
        private readonly IRepository<ApplicationUser> _ApplicationUserRepository;

        public GetApplicationUserByIdQueryHandler(
            IMapper mapper,
            IRepository<ApplicationUser> ApplicationUserRepository
            )
        {
            _mapper = mapper;
            _ApplicationUserRepository = ApplicationUserRepository;
        }

        public async Task<ApplicationUserDto> Handle(GetApplicationUserByIdQuery request, CancellationToken cancellationToken)
        {            
            var data = _ApplicationUserRepository.TableNoTracking.Include(e=>e.UserRoles).FirstOrDefaultAsync(x => x.Id==request.UserId);
            return _mapper.Map<ApplicationUserDto>(data.Result);
        }
    }
}

   


