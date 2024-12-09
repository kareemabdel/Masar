﻿// Licensed to the .NET Foundation under one or more agreements.
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
using Masar.Domain.Enums;

namespace Masar.Application.Commands
{
    public class DeleteCitiesCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

    }

    public class DeleteCitiesCommandHandler : IRequestHandler<DeleteCitiesCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Cities> _servicesRepository;

        public DeleteCitiesCommandHandler(IRepository<Cities> servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteCitiesCommand request, CancellationToken cancellationToken)
        {
            var item = _servicesRepository.GetById(request.Id);
            if (item != null)
            {
                //soft delete;
                item.IsDeleted = true;
                item.IsActive = false;
                item.DeletionDate = DateTimeOffset.Now;
                return (_servicesRepository.Update(item) == Result.Success);
            }
            throw new Exception($"Entitie with id {request.Id} not found");
        }
    }
}



