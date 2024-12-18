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
        private readonly IRepository<City> _servicesRepository;

        public UpdateCitiesCommandHandler(
            IRepository<City> servicesRepository,
            IMapper mapper
            )
        {
            _servicesRepository = servicesRepository;            
            _mapper = mapper;
        }
        public async Task<CitiesDto> Handle(UpdateCitiesCommand request, CancellationToken cancellationToken)
        {
            var item = _servicesRepository.GetById(request.obj.Id);
            if (item != null)
            {
                item = _mapper.Map(request.obj, item);
                var result = _servicesRepository.UpdateWithEntityReturn(item);
                return _mapper.Map<CitiesDto>(result);
            }
            throw new Exception($"Entitie with id {request.obj.Id} not found");
        }
    }
}

   

