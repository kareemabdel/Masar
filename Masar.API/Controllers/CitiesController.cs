﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Masar.Application.Commands;
using Masar.Application.Common.Extensions.Helpers;
using Masar.Application.DTOs;
using Masar.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using MaxMind.GeoIP2.Exceptions;
using System.Net;
using Masar.Infrastructure.Services;
using Microsoft.Extensions.Localization;
using Masar.API;
using Microsoft.Extensions.Caching.Memory;
using Masar.API.Helpers;
using JasperFx.Core;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Masar.Api.Controllers.LookupControllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class CitiesController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ILoggerManager _loggerManager;
        private readonly ICurrentUserService _userServices;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _cache;
        #endregion
        #region Ctor
        public CitiesController(IMediator mediator, ILoggerManager loggerManager, ICurrentUserService userServices, IMemoryCache memoryCache, IDistributedCache cache)
        {
            _mediator = mediator;
            _loggerManager = loggerManager;
            _userServices = userServices;
            _memoryCache = memoryCache;
            _cache = cache;
        }

        #endregion

        #region Methods
        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetCities()
        {  
                if (!_memoryCache.TryGetValue(CacheKeys.Cities, out IEnumerable<CitiesDto>? response))
                {
                    response = await _mediator.Send(new GetAllCitiesQuery() { IsAdmin = _userServices.IsAdmin() });
                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                        SlidingExpiration = TimeSpan.FromMinutes(2),
                        Size = 1024,
                    };
                    _memoryCache.Set(CacheKeys.Cities, response, cacheEntryOptions);
                }
                return Ok(response);
        }

        [HttpGet("GetCitiesDist")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetCitiesDist()
        {
           
                string cacheKey = "cities_list";
                IEnumerable<CitiesDto>? cities;

                // Try to get data from Redis cache
                var cachedData = await _cache.GetStringAsync(cacheKey);
                if (!string.IsNullOrEmpty(cachedData))
                {
                    _loggerManager.LogInfo("Returning data from Redis cache...");
                    cities = JsonConvert.DeserializeObject<List<CitiesDto>>(cachedData);
                    return Ok(cities);
                }

                _loggerManager.LogInfo("Fetching data from database...");

                // Simulating database call
                cities  = await _mediator.Send(new GetAllCitiesQuery() { IsAdmin = _userServices.IsAdmin() });


                // Convert list to JSON and store in Redis with expiration
                var cacheOptions = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(cities), cacheOptions);

                return Ok(cities);  
        }

        [HttpPost]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> CreateCities(AddCitiesDto objDto)
        {
                var response = await _mediator.Send(new AddCitiesCommand() { obj = objDto });
                return CreatedAtAction(nameof(GetCities), new { id = response.Id }, response);    
        }

        [HttpPost("Update")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> UpdateCities(CitiesDto objDto)
        {
                var response = await _mediator.Send(new UpdateCitiesCommand() { obj = objDto });
                return Ok(response);
        }


        [HttpGet("GetById")]
        [MapToApiVersion("1")]
        [Authorize]
        public async Task<IActionResult> GetCitiesById([FromQuery] Guid Id)
        {
                var response = await _mediator.Send(new GetCitiesByIdQuery() { CitiesId = Id });
                return Ok(response);
        }

        [HttpPost("Delete")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> DeleteCities([FromBody] Guid Id)
        {
                var response = await _mediator.Send(new DeleteCitiesCommand() { Id = Id });
                return Ok(response);
        }
        #endregion
    }
}
