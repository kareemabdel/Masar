using System;
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

        #endregion
        #region Ctor
        public CitiesController(IMediator mediator, ILoggerManager loggerManager, ICurrentUserService userServices)
        {
            _mediator = mediator;
            _loggerManager = loggerManager;
            _userServices = userServices;
        }

        #endregion

        #region Methods
        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<ActionResult<List<CitiesDto>>> GetCities()
        {
            try
            {
                var response = await _mediator.Send(new GetAllCitiesQuery() { IsAdmin=_userServices.IsAdmin()});
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<ActionResult<CitiesDto>> CreateCities(AddCitiesDto objDto)
        {
            try
            {
                var response = await _mediator.Send(new AddCitiesCommand() { obj = objDto });
                return CreatedAtAction(nameof(GetCities), new { id = response.Id }, response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<ActionResult<CitiesDto>> UpdateCities(CitiesDto objDto)
        {
            try
            {
                var response = await _mediator.Send(new UpdateCitiesCommand() { obj = objDto });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("GetCitiesById")]
        [MapToApiVersion("1")]
        [Authorize]
        public async Task<ActionResult<CitiesDto>> GetCitiesById([FromQuery] Guid Id)
        {
            try
            {
                var response = await _mediator.Send(new GetCitiesByIdQuery() { CitiesId = Id });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<ActionResult<bool>> DeleteCities([FromQuery] Guid Id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteCitiesCommand() { Id = Id });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

       

        #endregion
    }
}
