//using AutoMapper;
//using MediatR;
//using Masar.Domain;
//using Masar.Domain.Entities;
//using Masar.Domain.Enums;
//using Masar.Application.Interfaces;

//namespace InternalAudit.Application.Commands.TripPhotos.AddEdit
//{
//    public class AddTripPhotoCommand : IRequest<bool>
//    {
//        public List<TripPhoto> objs { get; set; }
//    }

//    public class AddTripPhotoCommandHandler : IRequestHandler<AddTripPhotoCommand, bool>
//    {
//        private readonly IMapper _mapper;
//        private readonly IApplicationDbContext _context;

//        public AddTripPhotoCommandHandler(
//            IRepository<TripPhoto,Guid> TripPhotoServicesRepository,
//            IMapper mapper
//            )
//        {
//            _TripPhotoServicesRepository = TripPhotoServicesRepository;
//            _mapper = mapper;
//        }
//        public async Task<bool> Handle(AddTripPhotoCommand request, CancellationToken cancellationToken)
//        {
//          return _TripPhotoServicesRepository.Insert(request.objs)==Result.Success;
//        }
      
//    }
//}



