using AutoMapper;
using Masar.Domain.Entities;
using MediatR;
using Masar.Application.DTOs;
using Masar.Domain;
using Masar.Domain.Enums;

namespace Masar.Application.Commands
{
    public class AddGalleryCommand : IRequest<bool>
    {
        public List<GalleryDto> objs { get; set; }
        public Guid UserId { get; set; }
    }

    public class AddGalleryCommandHandler : IRequestHandler<AddGalleryCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Gallery> _servicesRepository;


        public AddGalleryCommandHandler(
            IRepository<Gallery> servicesRepository,
            IMapper mapper

            )
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
            
        }
        public async Task<bool> Handle(AddGalleryCommand request, CancellationToken cancellationToken)
        {
           
                var items = _mapper.Map<List<Gallery>>(request.objs);
                items.ForEach(e => e.AddedById = request.UserId);
                return _servicesRepository.Insert(items) == Result.Success;
            
        }

       
    }
}



