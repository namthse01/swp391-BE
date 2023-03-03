using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Role.Command.Add
{
    public class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RoleCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Guid>> Handle(RoleCreateCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<Domain.Entities.Role>(request);
            await _unitOfWork.Repository<Domain.Entities.Role>().AddAsync(role);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
