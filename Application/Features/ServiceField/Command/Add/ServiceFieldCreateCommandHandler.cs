using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceField.Command.Add
{
    public class ServiceFieldCreateCommandHandler : IRequestHandler<ServiceFieldCreateCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceFieldCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(ServiceFieldCreateCommand request, CancellationToken cancellationToken)
        {
            var serviceFields = _mapper.Map<Domain.Entities.ServiceField>(request);
            await _unitOfWork.Repository<Domain.Entities.ServiceField>().AddAsync(serviceFields);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();

        }
    }
}
