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

namespace Application.Features.Role.Command.Delete
{
    public class RoleDeleteCommandHandler : IRequestHandler<RoleDeleteCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleDeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<Guid>> Handle(RoleDeleteCommand request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.Repository<Domain.Entities.Role>().FindSingleAsync(x => x.Id == request.Id);
            if (role == null)
            {
                throw new ApiException("ID not found");
            }
            await _unitOfWork.Repository<Domain.Entities.Role>().DeleteAsync(role);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
