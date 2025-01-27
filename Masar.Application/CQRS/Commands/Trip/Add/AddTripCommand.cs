using AutoMapper;
using Masar.Domain.Entities;
using MediatR;
using Masar.Application.DTOs;
using Masar.Domain;
using Masar.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Masar.EmailServices;
using Masar.Application.Interfaces;

namespace Masar.Application.Commands
{
    public class AddTripCommand : IRequest<TripDto>
    {
        public AddTripDto obj { get; set; }
        public Guid UserId { get; set; }
    }

    public class AddTripCommandHandler : IRequestHandler<AddTripCommand, TripDto>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _contex;
        private readonly IEmailSender _emailSender;


        public AddTripCommandHandler(
           IApplicationDbContext contex,  
            IMapper mapper,
            IEmailSender emailSender

            )
        {
            _contex = contex;
            _mapper = mapper;
            _emailSender = emailSender;            
        }
        public async Task<TripDto> Handle(AddTripCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Trip>(request.obj);
            item.TripStatus = TripStatus.New;
            var result =await _contex.Trips.AddAsync(item);
            await _contex.SaveChangesAsync(cancellationToken);
            //await SendEmailToUsers();
            return _mapper.Map<TripDto>(result.Entity);
        }

        private async Task SendEmailToUsers()
        {
            // get all mail of users
            List<string> listofmails =new List<string>();
             listofmails = await _contex.Users.Where(w => w.UserRoles.Any(f=>f.RoleId== (int)UserTypes.User)).Select(d => d.Email).ToListAsync();
            var message = new Message(listofmails, "Masar", "Hi, We are Pleased to inform u that A New Trip has been  Added ");
            _emailSender.SendEmail(message);
        }
    }
}



