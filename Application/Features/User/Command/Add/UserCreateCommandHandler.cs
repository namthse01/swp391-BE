using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Command.Add
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserCreateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Guid>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.User>(request);
            await _unitOfWork.Repository<Domain.Entities.User>().AddAsync(user);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
