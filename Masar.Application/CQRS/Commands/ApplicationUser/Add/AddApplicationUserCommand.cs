// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.Findings.DTOs;

using AutoMapper;
using MediatR;
using Masar.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using Masar.Domain;
using Masar.Domain.Entities;

namespace Masar.Application.Commands
{
    public class AddApplicationUserCommand : IRequest<ApplicationUserDto>
    {
        public AddApplicationUserDto obj { get; set; }
    }

    public class AddApplicationUserCommandHandler : IRequestHandler<AddApplicationUserCommand, ApplicationUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.ApplicationUser> _applicationUserRepository;

        public AddApplicationUserCommandHandler(
            IRepository<Domain.Entities.ApplicationUser> applicationUserRepository,
            IMapper mapper
            )
        {
            _applicationUserRepository = applicationUserRepository;
            _mapper = mapper;
        }
        public async Task<ApplicationUserDto> Handle(AddApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Domain.Entities.ApplicationUser>(request.obj);
            if (!await IsUserExists(item))
            {
                var result = _applicationUserRepository.InsertWithEntityReturn(item);
                return _mapper.Map<ApplicationUserDto>(result);
            }
            else
            {
                throw new Exception($" Email, Phone Or UserName already Exists");
            }
        }

        public async Task<bool> IsUserExists(ApplicationUser applicationUser)
        {
            var user = await _applicationUserRepository.TableNoTracking.Where(p => p.Email == applicationUser.Email||
            p.Phone==applicationUser.Phone
            ||p.UserName==applicationUser.UserName).FirstOrDefaultAsync();
            if (user!=null)
            {
                if (user.IsDeleted)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}



