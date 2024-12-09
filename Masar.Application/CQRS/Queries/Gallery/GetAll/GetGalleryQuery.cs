


using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Masar.Application.DTOs;
using Masar.Application.Interfaces;
using MediatR;
using AutoMapper.QueryableExtensions;
using Masar.Domain.Entities;
using Masar.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Masar.Application.Queries
{
    public class GetGalleryQuery : IRequest<IEnumerable<GalleryDto>>
    {
        public bool IsAdmin { get; set; }
    }

    public class GetGalleryQueryHandler :
         IRequestHandler<GetGalleryQuery, IEnumerable<GalleryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Gallery> _GalleryRepository;

        public GetGalleryQueryHandler(
            IMapper mapper,
            IRepository<Gallery> GalleryRepository
            )
        {
            _mapper = mapper;
            _GalleryRepository = GalleryRepository;
        }

        public async Task<IEnumerable<GalleryDto>> Handle(GetGalleryQuery request, CancellationToken cancellationToken)
        {            
            var data =await _GalleryRepository.TableNoTracking.Where(x => !x.IsDeleted && request.IsAdmin ? true : x.IsActive).ToListAsync();
            return _mapper.Map<List<GalleryDto>>(data);
        }
    }
}

   


