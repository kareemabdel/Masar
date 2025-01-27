// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.ApplicationUsers.DTOs;

using AutoMapper;
using MediatR;
using Masar.Domain;
using Masar.Domain.Enums;
using Masar.Application.Interfaces;

namespace Masar.Application.Commands
{
    public class DeleteApplicationUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

    }

    public class DeleteApplicationUserCommandHandler : IRequestHandler<DeleteApplicationUserCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public DeleteApplicationUserCommandHandler( IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> Handle(DeleteApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var item = _context.Users.FirstOrDefault(e=>e.Id==request.Id);
            if (item != null)
            {
                //soft delete;
                item.IsDeleted = true;
                item.IsActive = false;
                item.DeletedDate = DateTimeOffset.Now;

                return (await _context.SaveChangesAsync(cancellationToken)>0);
            }
            throw new Exception($"Entitie with id {request.Id} not found");
        }
    }
}



