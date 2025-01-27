// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.Findings.DTOs;

using AutoMapper;
using MediatR;
using Masar.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using Masar.Domain;
using Masar.Domain.Entities;
using Masar.Application.Interfaces;

namespace Masar.Application.Commands
{
    public class AddApplicationUserCommand : IRequest<ApplicationUserDto>
    {
        public AddApplicationUserDto obj { get; set; }
    }

    public class AddApplicationUserCommandHandler : IRequestHandler<AddApplicationUserCommand, ApplicationUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public AddApplicationUserCommandHandler(
            IMapper mapper
,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ApplicationUserDto> Handle(AddApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Domain.Entities.ApplicationUser>(request.obj);
            if (!await IsUserExists(item))
            {
                var result = _context.Users.Add(item);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<ApplicationUserDto>(result);
            }
            else
            {
                throw new Exception($" Email, Phone Or UserName already Exists");
            }
        }

        public async Task<bool> IsUserExists(ApplicationUser applicationUser)
        {
            var user = await _context.Users.Where(p => p.Email == applicationUser.Email||
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



