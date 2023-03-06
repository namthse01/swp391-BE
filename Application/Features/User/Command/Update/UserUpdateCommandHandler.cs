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

namespace Application.Features.User.Command.Update
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, Response<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserUpdateCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Guid>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<Domain.Entities.User>().FindSingleAsync(x => x.Id == request.Id);
            if (user == null)
            {
                throw new ApiException("ID not found");
            }

            user.Username = request.UserName;
            user.Password = request.Password;
            user.Email = request.Email;
            user.Phone = request.Phone;
            await _unitOfWork.Repository<Domain.Entities.User>().UpdateAsync(user);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
