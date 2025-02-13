


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
using Masar.Application.Models;
using Org.BouncyCastle.Utilities;

namespace Masar.Application.Queries
{
    public class GetGalleryQuery : IRequest<PaginatedList<GalleryDto>>
    {
        public bool IsAdmin { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }

    public class GetGalleryQueryHandler :
         IRequestHandler<GetGalleryQuery, PaginatedList<GalleryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetGalleryQueryHandler(
            IMapper mapper,IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PaginatedList<GalleryDto>> Handle(GetGalleryQuery request, CancellationToken cancellationToken)
        {            
            var data = _context.Galleries.Where(x => request.IsAdmin ? true : x.IsActive);
            var mappedItems = data.ProjectTo<GalleryDto>(_mapper.ConfigurationProvider);
            return await PaginatedList<GalleryDto>.CreateAsync(mappedItems, request.page, request.size);
        }
    }
}

   


