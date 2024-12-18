﻿// Licensed to the .NET Foundation under one or more agreements.
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
        private readonly IRepository<City> _servicesRepository;


        public AddCitiesCommandHandler(
            IRepository<City> servicesRepository,
            IMapper mapper
            )
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }
        public async Task<CitiesDto> Handle(AddCitiesCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<City>(request.obj);
            var result = _servicesRepository.InsertWithEntityReturn(item);
            return _mapper.Map<CitiesDto>(result);
        }
    }
}



