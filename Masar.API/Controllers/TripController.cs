﻿using AutoMapper;
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
    [Authorize]
    public class TripController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _rootpath;
        private readonly ILoggerManager _loggerManager;

        #endregion
        #region Ctor
        public TripController(IMediator mediator, ICurrentUserService currentUserService, IConfiguration config, IWebHostEnvironment rootpath, ILoggerManager loggerManager)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
            _config = config;
            _rootpath = rootpath;
            _loggerManager = loggerManager;
        }
        #endregion

        #region Methods
        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetTrips(int page = 1, int size = 10)
        {
                var response = await _mediator.Send(new GetAllTripQuery() { IsAdmin= _currentUserService.IsAdmin(),page=page,size=size});
                return Ok(response);
        }

        [HttpPost]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> CreateTrip([FromForm] AddTripDto objDto)
        {
                var userid= _currentUserService.GetUserId();
                objDto.TripPhotos = await UploadFiles(objDto.TripPhotos);
                var response = await _mediator.Send(new AddTripCommand() { obj = objDto,UserId= userid });
                return Ok(response);
        }

        [HttpPost("Update")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> UpdateTrip( TripDto objDto)
        {
                
                objDto.TripPhotos= await UploadFiles(objDto.TripPhotos);
                var response = await _mediator.Send(new UpdateTripCommand() { obj = objDto });
                return Ok(response);
        }

        [HttpGet("GetTripById")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetTripById([FromQuery] Guid Id)
        {
                var response = await _mediator.Send(new GetTripByIdQuery() { TripId = Id });
                return Ok(response);
        }

        [HttpPost("Delete")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> DeleteTrip([FromBody] Guid Id)
        {
                var response = await _mediator.Send(new DeleteTripCommand() { Id = Id });
                return Ok(response);
        }

        [HttpGet("GetTripsByUserId")]
        [MapToApiVersion("1")]
        [Authorize]
        public async Task<IActionResult> GetTripsByUserId()
        {
                var UserId = _currentUserService.GetUserId();
                var response = await _mediator.Send(new GetTripsByUserIdQuery() { UserId = UserId });
                return Ok(response);
        }


        private async Task<List<TripPhotoDto>?> UploadFiles(List<TripPhotoDto>? UploadedFiles)
        {

                if (UploadedFiles!=null)
                {
                    //var tripphotos=new List<TripPhotoDto>();
                    var configpath = _config["AttachmentPathConfig:TripPhotosPath"] + @"/";
                    string SavePath = _rootpath.WebRootPath + configpath;
                    foreach (var file in UploadedFiles)
                    {
                        if (file.Photo?.Length > 0)
                        {
                            var uniquefilename = ("Image_" + DateTime.Now.ToString() + DateTime.Now.Millisecond.ToString()).Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");

                            FileInfo fileInfo = new FileInfo(file.Photo.FileName);
                            string fileName = uniquefilename + fileInfo.Extension;
                            var filePath = Path.Combine(SavePath, fileName);
                            if (!Directory.Exists(SavePath))
                            {
                                DirectoryInfo di = Directory.CreateDirectory(SavePath);
                            }
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                await file.Photo.CopyToAsync(stream);
                            }
                            file.FilePath = Path.Combine(configpath, fileName);
                        }
                    }
                    return UploadedFiles;
                }
                else
                {
                    return null;
                }
        }

        #endregion
    }
}
