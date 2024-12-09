// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.ApplicationUsers.DTOs;

using AutoMapper;
using Masar.Application.Interfaces;
using Masar.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Masar.Application.DTOs;
using System;
using Masar.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Masar.Application.Commands
{
    public class UpdateApplicationUserCommand : IRequest<ApplicationUserDto>
    {
        public ApplicationUserDto obj { get; set; }

    }

    public class UpdateApplicationUserCommandHandler : IRequestHandler<UpdateApplicationUserCommand, ApplicationUserDto>
    {        
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.ApplicationUser> _servicesRepository;

        public UpdateApplicationUserCommandHandler(
            IRepository<Domain.Entities.ApplicationUser> servicesRepository,
            IMapper mapper
            )
        {
            _servicesRepository = servicesRepository;            
            _mapper = mapper;
        }
        public async Task<ApplicationUserDto> Handle(UpdateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var item =await _servicesRepository.Table.Include(w=>w.UserRoles).FirstOrDefaultAsync(e=>e.Id==request.obj.Id);
            if (item != null)
            {
                item = _mapper.Map(request.obj, item);
                if (!await IsUserExists(item))
                {
                    var result = _servicesRepository.UpdateWithEntityReturn(item);
                    return _mapper.Map<ApplicationUserDto>(result);

                }
                else
                {
                    throw new Exception($" Email, Phone Or UserName already Exists");
                }
            }
            throw new Exception($"Entitie with id {request.obj.Id} not found");
        }

        public async Task<bool> IsUserExists(ApplicationUser applicationUser)
        {
            var user = await _servicesRepository.TableNoTracking.Where(p =>
            (p.Email == applicationUser.Email ||
            p.Phone == applicationUser.Phone ||
             p.UserName == applicationUser.UserName) && p.Id!=applicationUser.Id)
                .FirstOrDefaultAsync();
            if (user != null)
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

   

