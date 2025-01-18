using AutoMapper;
using Masar.Domain.Entities;
using MediatR;
using Masar.Domain;
using Masar.Domain.Enums;

namespace Masar.Application.Commands
{
    public class DeleteGalleryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

    }

    public class DeleteGalleryCommandHandler : IRequestHandler<DeleteGalleryCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Gallery> _servicesRepository;

        public DeleteGalleryCommandHandler(IRepository<Gallery> servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
        {
            var item = _servicesRepository.GetById(request.Id);
            if (item != null)
            {
                //soft delete;
                item.IsDeleted = true;
                item.IsActive = false;
                item.DeletedDate = DateTimeOffset.Now;
                return (_servicesRepository.Update(item) == Result.Success);
            }
            throw new Exception($"Entitie with id {request.Id} not found");
        }
    }
}



