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
        private readonly IApplicationDbContext _context;

        public UpdateApplicationUserCommandHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ApplicationUserDto> Handle(UpdateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var item =await _context.Users.Include(w=>w.UserRoles)
                .FirstOrDefaultAsync(e=>e.Id==request.obj.Id);
            if (item != null)
            {
                item = _mapper.Map(request.obj, item);
                if (!await IsUserExists(item))
                {
                    await _context.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<ApplicationUserDto>(item);

                }
                else
                {
                    throw new Exception($" Email, Phone Or UserName already Exists");
                }
            }
            throw new Exception($"Entitie with id {request.obj.Id} not found");
        }

        public async Task<bool> IsUserExists(User applicationUser)
        {
            var user = await _context.Users.Where(p =>
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

   

