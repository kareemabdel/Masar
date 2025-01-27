// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.Trips.DTOs;

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
using Microsoft.EntityFrameworkCore;
using Masar.Domain.Enums;
using Masar.EmailServices;
using Microsoft.Extensions.Localization;

namespace Masar.Application.Commands
{
    public class UpdateUserTripCommand : IRequest<bool>
    {
        public UpdateUserTripDto obj { get; set; }
        public Guid UserId { get; set; }

    }

    public class UpdateUserTripCommandHandler : IRequestHandler<UpdateUserTripCommand, bool>
    {        
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IStringLocalizer<SharedResource> _Localizer;

        public UpdateUserTripCommandHandler(
            IMapper mapper,
            IEmailSender emailSender
,
            IApplicationDbContext context)
        {
            _mapper = mapper;
            _emailSender = emailSender;
            _context = context;
        }
        public async Task<bool> Handle(UpdateUserTripCommand request, CancellationToken cancellationToken)
        {
            var item = _context.UserTrips.Include(e=>e.User).Include(w=>w.UserTripStatusHistory).FirstOrDefault(e=>e.Id==request.obj.Id);
            if (item != null)
            {
                if (item.Status!= UserTripStatus.Confirmed)
                {
                    item.Status = request.obj.Status;
                    item.UserTripStatusHistory.Add(new UserTripStatusHistory { Status = item.Status, ChangedById = request.UserId });
                    
                    if (await _context.SaveChangesAsync(cancellationToken)>0)
                    {  
                            // send email to user to notify that trip reservation confirmed;
                            SendEmailToUser(item.User.Email, request.obj.Status);
                        return true;
                    }
                    return false;
                }
                throw new Exception(_Localizer["Can't_Update_Reservation_after_being_Confirmed"]);
            }
            throw new Exception($"Entitie with id {request.obj.Id} not found");
        }


        private void SendEmailToUser(string UserEmail,UserTripStatus ReservationStaus)
        {
            var content = ReservationStaus == UserTripStatus.Confirmed ? "Hi, Kindly be informed that you reservation has been confirmed, Thanks!" :
                "Hello, Your Reservation has been cancelled Please feel free to contact us , Thanks!";
            var message = new Message(new string[] { UserEmail }, "Masar", content);
            _emailSender.SendEmail(message);
        }
    }
}

   

