﻿using Masar.Application.Commands;
using Masar.Application.Common.Extensions.Helpers;
using Masar.Application.DTOs;
using Masar.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Masar.Infrastructure.Services;
using Contracts;


namespace Masar.Api.Controllers.LookupControllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GalleryController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _rootpath;
        private readonly ILoggerManager _loggerManager;

        #endregion
        #region Ctor
        public GalleryController(IMediator mediator, ICurrentUserService currentUserService, IConfiguration config, IWebHostEnvironment rootpath, ILoggerManager loggerManager)
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
        public async Task<IActionResult> GetGallery(int page = 1, int size = 10)
        {
            var response = await _mediator.Send(new GetGalleryQuery() { IsAdmin = _currentUserService.IsAdmin(), page = page, size = size });
                return Ok(response);
        }

        [HttpPost("Delete")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> DeleteGallery([FromBody] DeleteGalleryDto obj)
        {
                var fullPath =_rootpath.WebRootPath+ obj.FilePath;
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                var response = await _mediator.Send(new DeleteGalleryCommand() { Id =obj.Id });
                return Ok(response);
        }

        [HttpPost("AddToGallery")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> AddToGallery([FromForm] List<GalleryDto> objsDto)
        {
                var userid = _currentUserService.GetUserId();
                objsDto = await UploadFiles(objsDto);
                var response = await _mediator.Send(new AddGalleryCommand() { objs = objsDto, UserId = userid });
                return Ok(response);
        }

        [HttpPost("AddSinglePic")]
        [MapToApiVersion("1")]
        [Authorize(Roles = Policies.Admin)]
        public async Task<IActionResult> AddSinglePic([FromForm] GalleryDto objsDto)
        {
                var list = new List<GalleryDto> { objsDto };
                var userid = _currentUserService.GetUserId();
                list = await UploadFiles(list);
                var response = await _mediator.Send(new AddGalleryCommand() { objs = list, UserId = userid });
                return Ok(response);
        }

        private async Task<List<GalleryDto>> UploadFiles(List<GalleryDto>? UploadedFiles)
        {
                if (UploadedFiles!=null)
                {
                    //var tripphotos=new List<TripPhotoDto>();
                    var configpath = _config["AttachmentPathConfig:GalleryPath"] + @"/";
                    string SavePath = _rootpath.WebRootPath + configpath;
                    foreach (var file in UploadedFiles)
                    {
                        if (file.File?.Length > 0)
                        {
                            var uniquefilename = ("Image_" + DateTime.Now.ToString() + DateTime.Now.Millisecond.ToString()).Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");

                            FileInfo fileInfo = new FileInfo(file.File.FileName);
                            string fileName = uniquefilename + fileInfo.Extension;
                            var filePath = Path.Combine(SavePath, fileName);
                            if (!Directory.Exists(SavePath))
                            {
                                DirectoryInfo di = Directory.CreateDirectory(SavePath);
                            }
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                await file.File.CopyToAsync(stream);
                            }
                            file.FilePath = Path.Combine(configpath, fileName);
                  }
                    }
                    return UploadedFiles;
                }
                else
                {
                    return new List<GalleryDto>();
                }
        }

        #endregion
    }
}
