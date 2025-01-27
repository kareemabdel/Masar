using AutoMapper;
using Masar.Domain.Entities;
using MediatR;
using Masar.Application.DTOs;
using Masar.Domain;
using Masar.Domain.Enums;
using Masar.Application.Interfaces;

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
        private readonly IApplicationDbContext _context;


        public AddGalleryCommandHandler(
            IMapper mapper
,
            IApplicationDbContext context
            )
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> Handle(AddGalleryCommand request, CancellationToken cancellationToken)
        {
           
                var items = _mapper.Map<List<Gallery>>(request.objs);
                items.ForEach(e => e.AddedById = request.UserId);
                 _context.Galleries.AddRange(items);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
            
        }

       
    }
}



