// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.Citiess.DTOs;

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

namespace Masar.Application.Commands
{
    public class UpdateCitiesCommand : IRequest<CitiesDto>
    {
        public CitiesDto obj { get; set; }

    }

    public class UpdateCitiesCommandHandler : IRequestHandler<UpdateCitiesCommand, CitiesDto>
    {        
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateCitiesCommandHandler(
            IMapper mapper
,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<CitiesDto> Handle(UpdateCitiesCommand request, CancellationToken cancellationToken)
        {
            var item = _context.Cities.FirstOrDefault(e=>e.Id== request.obj.Id);
            if (item != null)
            {
                item = _mapper.Map(request.obj, item);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<CitiesDto>(item);
            }
            throw new Exception($"Entitie with id {request.obj.Id} not found");
        }
    }
}

   

