// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//using CleanArchitecture.Razor.Application.Findings.DTOs;

using AutoMapper;
using Masar.Domain.Entities;
using MediatR;
using Masar.Application.DTOs;
using Masar.Domain;
using Masar.Domain.Enums;
using Masar.EmailServices;
using Microsoft.EntityFrameworkCore;

namespace Masar.Application.Commands
{
    public class BookTripCommand : IRequest<bool>
    {
        public AddUserTripDto obj { get; set; }
        public Guid UserId { get; set; }
    }

    public class BookTripCommandHandler : IRequestHandler<BookTripCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IRepository<UserTrip> _servicesRepository;
        private readonly IRepository<ApplicationUser> _UserservicesRepository;
        private readonly IRepository<Trip> _TripservicesRepository;


        public BookTripCommandHandler(
            IRepository<UserTrip> servicesRepository,
            IRepository<ApplicationUser> userservicesRepository,
            IMapper mapper,
            IEmailSender emailSender,
            IRepository<Trip> tripservicesRepository)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
            _UserservicesRepository = userservicesRepository;
            _emailSender = emailSender;
            _TripservicesRepository = tripservicesRepository;
        }
        public async Task<bool> Handle(BookTripCommand request, CancellationToken cancellationToken)
        {
            // check if user book this trip before 
            var check = await _servicesRepository.TableNoTracking.FirstOrDefaultAsync(e => e.UserId == request.UserId && e.TripId == request.obj.TripId);
            if (check!=null)
                throw new Exception("Can't Reserve This trip again");
            
            var item = _mapper.Map<UserTrip>(request.obj);
            var tripcost=await _TripservicesRepository.TableNoTracking.Where(e => e.Id == request.obj.TripId).Select(r=>r.Price).FirstOrDefaultAsync();
            item.ReservationCost = tripcost * request.obj.NumberOfIndividuals;
            item.Status = UserTripStatus.New;
            item.UserTripStatusHistory.Add(new UserTripStatusHistory { Status =UserTripStatus.New, ChangedById = request.UserId });
           var res= _servicesRepository.Insert(item)==Result.Success;
            if (res)
            {
                //await SendEmailToAdmin();
                return true;    
            }
            return false;
        }

        private async Task SendEmailToAdmin()
        {
            // get  mail of admin
            //List<string> listofmails = new List<string>();
            var email = await _UserservicesRepository.TableNoTracking.Where(w => w.UserRoles.Any(f => f.RoleId == (int)UserTypes.Admin)).Select(d => d.Email).FirstOrDefaultAsync();
            if (email!=null)
            {
            var message = new Message(new string[] {email }, "Masar", "New trip reservation submitted ");
            _emailSender.SendEmail(message);
            }
        }
        
    }
}



