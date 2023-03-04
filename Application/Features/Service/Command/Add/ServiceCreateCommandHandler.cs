using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Service.Command.Add
{
    public class ServiceCreateCommandHandler : IRequestHandler<ServiceCreateCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(ServiceCreateCommand request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<Domain.Entities.Service>(request);
            await _unitOfWork.Repository<Domain.Entities.Service>().AddAsync(service);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
