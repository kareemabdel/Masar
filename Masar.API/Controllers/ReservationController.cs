using AutoMapper;
using Masar.Application.Commands;
using Masar.Application.Common.Extensions.Helpers;
using Masar.Application.DTOs;
using Masar.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Masar.Infrastructure.Services;
using Masar.Domain.Entities;
using Masar.Api.Helpers;
using Contracts;

namespace Masar.Api.Controllers.LookupControllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReservationController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoggerManager _loggerManager;

        #endregion
        #region Ctor
        public ReservationController(IMediator mediator, ICurrentUserService currentUserService, ILoggerManager loggerManager)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
            _loggerManager = loggerManager;
        }
        #endregion

        #region Methods


        [HttpGet]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<ActionResult<List<UserTripDto>>> GetAllReservations()
        {
            try
            {
                var response = await _mediator.Send(new GetAllReservationsQuery());
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetUsersByTripId")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<ActionResult<List<ApplicationUserDto>>> GetUsersByTripId([FromQuery] Guid TripId)
        {
            try
            {
                var response = await _mediator.Send(new GetUsersByTripIdQuery() { TripId = TripId });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("BookTrip")]
        [MapToApiVersion("1")]
        [Authorize]
        public async Task<ActionResult<bool>> BookTrip(AddUserTripDto objDto)
        {
            try
            {
                var UserId = _currentUserService.GetUserId();
                var response = await _mediator.Send(new BookTripCommand() { obj = objDto, UserId = UserId });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPost("Update")]
        [MapToApiVersion("1")]
        [Authorize]
        public async Task<ActionResult<bool>> UpdateReservation(UpdateUserTripDto objDto)
        {
            try
            {
                var UserId = _currentUserService.GetUserId();
                var response = await _mediator.Send(new UpdateUserTripCommand() { obj = objDto, UserId = UserId });
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        [HttpGet("GetReservationsByUserId")]
        [MapToApiVersion("1")]
        [Authorize]
        public async Task<ActionResult<List<UserTripDto>>> GetReservationsByUserId([FromQuery] Guid UserId)
        {
            try
            {
                var response = await _mediator.Send(new GetReservationsByUserIdQuery() { UserId = UserId });
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
