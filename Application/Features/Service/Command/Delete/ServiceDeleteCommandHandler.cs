using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Service.Command.Delete
{
    public class ServiceDeleteCommandHandler : IRequestHandler<ServiceDeleteCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(ServiceDeleteCommand request, CancellationToken cancellationToken)
        {
            var service = await _unitOfWork.Repository<Domain.Entities.Service>().FindSingleAsync(x => x.Id == request.Id);
            if (service == null)
            {
                throw new ApiException("ID not found");
            }
            await _unitOfWork.Repository<Domain.Entities.Service>().DeleteAsync(service);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
