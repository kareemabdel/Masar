using AutoMapper;
using Masar.Domain.Entities;
using MediatR;
using Masar.Application.DTOs;
using Masar.Domain;
using Masar.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Masar.EmailServices;

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
        private readonly IRepository<Trip> _servicesRepository;
        private readonly IRepository<ApplicationUser> _UserservicesRepository;
        private readonly IEmailSender _emailSender;


        public AddTripCommandHandler(
            IRepository<Trip> servicesRepository,
            IRepository<ApplicationUser> UserservicesRepository,
            IMapper mapper,
            IEmailSender emailSender

            )
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _UserservicesRepository = UserservicesRepository;
            
        }
        public async Task<TripDto> Handle(AddTripCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Trip>(request.obj);
            item.TripStatus = TripStatus.New;
            var result = _servicesRepository.InsertWithEntityReturn(item);
            //await SendEmailToUsers();
            return _mapper.Map<TripDto>(result);
        }

        private async Task SendEmailToUsers()
        {
            // get all mail of users
            List<string> listofmails =new List<string>();
             listofmails = await _UserservicesRepository.TableNoTracking.Where(w => w.UserRoles.Any(f=>f.RoleId== (int)UserTypes.User)).Select(d => d.Email).ToListAsync();
            var message = new Message(listofmails, "Masar", "Hi, We are Pleased to inform u that A New Trip has been  Added ");
            _emailSender.SendEmail(message);
        }
    }
}



