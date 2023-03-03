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

namespace Application.Features.Role.Command.Update
{
    public class RoleUpdateCommandHandler : IRequestHandler<RoleUpdateCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(RoleUpdateCommand request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.Repository<Domain.Entities.Role>().FindSingleAsync(x => x.Id == request.Id);
            if (role == null)
            {
                throw new ApiException("ID not found");
            }

            role.Name = request.Name;            
            await _unitOfWork.Repository<Domain.Entities.Role>().UpdateAsync(role);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
