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

namespace Application.Features.User.Command.Delete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<Domain.Entities.User>().FindSingleAsync(x => x.Id == request.Id);
            if (user == null)
            {
                throw new ApiException("ID not found");
            }
            await _unitOfWork.Repository<Domain.Entities.User>().DeleteAsync(user);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
