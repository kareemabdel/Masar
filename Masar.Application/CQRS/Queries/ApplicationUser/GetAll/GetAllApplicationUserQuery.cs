


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
        private readonly IRepository<ApplicationUser> _ApplicationUserRepository;

        public GetAllApplicationUserQueryHandler(
            IMapper mapper,
            IRepository<ApplicationUser> ApplicationUserRepository
            )
        {
            _mapper = mapper;
            _ApplicationUserRepository = ApplicationUserRepository;
        }

        public async Task<IEnumerable<ApplicationUserDto>> Handle(GetAllApplicationUserQuery request, CancellationToken cancellationToken)
        {
            var data = _ApplicationUserRepository.TableNoTracking.Include(e => e.UserRoles).Where(x => !x.IsDeleted).ToList();
            return _mapper.Map<List<ApplicationUserDto>>(data);
        }
    }
}

   


