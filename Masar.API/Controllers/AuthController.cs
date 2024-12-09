﻿using AutoMapper;
using Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Masar.Api.Helpers;
using Masar.Application.Commands;
using Masar.Application.DTOs;
using Masar.Application.Queries.Auth.Login;
using Masar.EmailServices;

namespace Masar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;
        private readonly ILoggerManager _loggerManager;

        //test

        public AuthController(IMediator mediator, IConfiguration config, IEmailSender emailSender, ILoggerManager loggerManager)
        {
            _mediator = mediator;
            _config = config;
            _emailSender = emailSender;
            _loggerManager = loggerManager;
        }


        [HttpPost("Login")]
        [MapToApiVersion("1")]
        public async Task<ActionResult<LoginQueryResponse>> Login([FromBody] LoginQuery requestDto)
        {
            try
            {
                requestDto.HashedPassword = CryptoHelper.Encrypt(requestDto.Password, _config["AppSettings:PasswordKey"]);
                var response = await _mediator.Send(new LoginQuery()
                {
                    UserName = requestDto.UserName,
                    UserType = requestDto.UserType,
                    Password = requestDto.Password,
                    HashedPassword = requestDto.HashedPassword
                });
                if (response.IsSuccess)
                {
                    var tokenString = JwtHelper.GenerateJwtToken(response.UserDetails, _config);
                    response.Token = tokenString;
                    return Ok(response);
                }
                else
                {
                    return Unauthorized(response.Msg);
                }
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost("RegisterUser")]
        [MapToApiVersion("1")]
        public async Task<ActionResult<LoginQueryResponse>> RegisterUser(RegisterDto objDto)
        {
            try
            {
                objDto.Password = CryptoHelper.Encrypt(objDto.Password, _config["AppSettings:PasswordKey"]);
                var response = await _mediator.Send(new RegisterCommand() { obj = objDto });
                if (response.IsSuccess)
                {
                    var tokenString = JwtHelper.GenerateJwtToken(response.UserDetails, _config);
                    response.Token = tokenString;
                    return Ok(response);
                }
                else
                {
                    return Conflict(response.Msg);
                }
            }
            catch (System.Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("TestSendingMail")]
        public ActionResult<bool> Get()
        {
            try
            {
                var message = new Message(new string[] { "ka1264@fayoum.edu.eg" }, "TestEmail", "html");
                _emailSender.SendEmail(message);
                return true;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something Went Wrong: {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

    }
}
