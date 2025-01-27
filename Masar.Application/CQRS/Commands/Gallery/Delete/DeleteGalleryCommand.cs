using AutoMapper;
using Masar.Domain.Entities;
using MediatR;
using Masar.Domain;
using Masar.Domain.Enums;
using Masar.Application.Interfaces;

namespace Masar.Application.Commands
{
    public class DeleteGalleryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

    }

    public class DeleteGalleryCommandHandler : IRequestHandler<DeleteGalleryCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public DeleteGalleryCommandHandler( IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
        {
            var item = _context.Galleries.FirstOrDefault(e=>e.Id==request.Id);
            if (item != null)
            {
                //soft delete;
                item.IsDeleted = true;
                item.IsActive = false;
                item.DeletedDate = DateTimeOffset.Now;
                return (await _context.SaveChangesAsync(cancellationToken)>0);
            }
            throw new Exception($"Entitie with id {request.Id} not found");
        }
    }
}



