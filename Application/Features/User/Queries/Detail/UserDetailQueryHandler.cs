using Application.Features.Field.Queries.Detail;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries.Detail
{
    public class UserDetailQueryHandler : IRequestHandler<UserDetailQuery, Response<UserDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<UserDetailResponse>> Handle(UserDetailQuery request, CancellationToken cancellationToken)
        {
            var userDetail = await _unitOfWork.Repository<Domain.Entities.User>()
                .GetAll(x => x.Id == request.Id)
                .Select(x => new UserDetailResponse
                {
                    Username = x.Username,
                    Password = x.Password,
                    Phone = x.Phone,
                    Email = x.Email
                })
                .FirstOrDefaultAsync();

            return new Response<UserDetailResponse>(userDetail);
        }
    }
}
