// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.Trips.DTOs;

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
using Masar.Domain.Enums;

namespace Masar.Application.Commands
{
    public class DeleteTripCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

    }

    public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public DeleteTripCommandHandler( IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var item = _context.Trips.FirstOrDefault(e => e.Id == request.Id);
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



