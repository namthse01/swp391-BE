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

namespace Application.Features.ServiceField.Command.Delete
{
    public class ServiceFieldDeleteCommandHandler : IRequestHandler<ServiceFieldDeleteCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceFieldDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(ServiceFieldDeleteCommand request, CancellationToken cancellationToken)
        {
            var serviceFields = await _unitOfWork.Repository<Domain.Entities.ServiceField>().FindSingleAsync(x => x.Id == request.Id);
            if (serviceFields == null) 
            {
                throw new ApiException("Id not found !");
            }
            await _unitOfWork.Repository<Domain.Entities.ServiceField>().DeleteAsync(serviceFields);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
