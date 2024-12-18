using AutoMapper;
using MediatR;
using Masar.Application.DTOs;
using Masar.Domain;
using Masar.Domain.Entities;
using Masar.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Masar.Application.Queries.Auth.Login;

namespace Masar.Application.Commands
{
    public class RegisterCommand : IRequest<LoginQueryResponse>
    {
        public RegisterDto obj { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, LoginQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.ApplicationUser> _servicesRepository;

        public RegisterCommandHandler(
            IRepository<Domain.Entities.ApplicationUser> servicesRepository,
            IMapper mapper
            )
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }
        public async Task<LoginQueryResponse?> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<ApplicationUser>(request.obj);
            if (!await IsUserExists(item))
            {
                // add default role
                item.UserRoles.Add(new ApplicationUserRole { RoleId = (int)UserTypes.User });
                var result = _servicesRepository.InsertWithEntityReturn(item);
                return new LoginQueryResponse
                {
                    IsSuccess = true,
                    UserDetails = _mapper.Map<ApplicationUserDto>(result),
                    Msg = "User Registered Successfully"
                };
            }
            else
            {
                return new LoginQueryResponse
                {
                    IsSuccess = false,
                    Msg = "UserName Or Phone already In Use"
                };
            }
        }

        public async Task<bool> IsUserExists(ApplicationUser applicationUser)
        {
            var user = await _servicesRepository.TableNoTracking.Where(p => p.Email  == applicationUser.Email 
            || p.Phone  == applicationUser.Phone 
            || p.UserName  == applicationUser.UserName 
            ).FirstOrDefaultAsync();

            if (user != null)
            {
                if (user.IsDeleted)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

    }
}



