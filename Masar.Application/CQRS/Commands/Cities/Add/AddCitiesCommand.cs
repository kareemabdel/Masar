// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.Findings.DTOs;

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
    public class AddCitiesCommand : IRequest<CitiesDto>
    {
        public AddCitiesDto obj { get; set; }
    }

    public class AddCitiesCommandHandler : IRequestHandler<AddCitiesCommand, CitiesDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;


        public AddCitiesCommandHandler(
            IMapper mapper
,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<CitiesDto> Handle(AddCitiesCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<City>(request.obj);
            var result = _context.Cities.Add(item);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CitiesDto>(result.Entity);
        }
    }
}



