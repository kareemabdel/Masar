using AutoMapper;
using Masar.Application.Commands;
using Masar.Application.Common.Extensions.Helpers;
using Masar.Application.DTOs;
using Masar.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Masar.Api.Helpers;
using Contracts;

namespace Masar.Api.Controllers.LookupControllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private readonly ILoggerManager _loggerManager;

        #endregion
        #region Ctor
        public UserController(IMediator mediator, IConfiguration config, ILoggerManager loggerManager)
        {
            _mediator = mediator;
            _config = config;
            _loggerManager = loggerManager;
        }
        #endregion

        #region Methods
        [HttpGet]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> GetApplicationUser()
        {
                var response = await _mediator.Send(new GetAllApplicationUserQuery());
                return Ok(response);
        }

        [HttpPost]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> CreateApplicationUser(AddApplicationUserDto objDto)
        {
                objDto.Password = CryptoHelper.Encrypt(objDto.Password, _config["AppSettings:PasswordKey"]);
                var response = await _mediator.Send(new AddApplicationUserCommand() { obj = objDto });
                return Ok(response);
        }

        [HttpPost("Update")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> UpdateApplicationUser(ApplicationUserDto objDto)
        {
                var response = await _mediator.Send(new UpdateApplicationUserCommand() { obj = objDto });
                return Ok(response);
        }


        [HttpGet("GetById")]
        [MapToApiVersion("1")]
        [Authorize]
        public async Task<IActionResult> GetApplicationUserById([FromQuery] Guid Id)
        {
                var response = await _mediator.Send(new GetApplicationUserByIdQuery() { UserId = Id });
                return Ok(response);
        }

        [HttpPost("Delete")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> DeleteApplicationUser([FromBody] Guid Id)
        {
                var response = await _mediator.Send(new DeleteApplicationUserCommand() { Id = Id });
                return Ok(response);
        }

       

        #endregion
    }
}
