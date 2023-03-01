using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Manager.Queries.Detail
{
    public class ManagerDetailQueryHandler : IRequestHandler<ManagerDetailQuery, Response<ManagerDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagerDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ManagerDetailResponse>> Handle(ManagerDetailQuery request,
            CancellationToken cancellationToken)
        {
            var managerDetail = await _unitOfWork.Repository<Domain.Entities.Manager>()
                .GetAll(x => x.Id == request.Id)
                .Select(x => new ManagerDetailResponse
                {
                    UserId = (ManagerUserResponse)x.Users.Select(y => new ManagerUserResponse()
                    {
                        UserName = y.Username,
                        UserPhone = y.Phone,
                    }),
                    RoleId = (ManagerRoledResponse)x.Roles.Select(y => new ManagerRoledResponse()
                    {
                        RoleName = y.Name
                    })
                })
                .FirstOrDefaultAsync();

            return new Response<ManagerDetailResponse>(managerDetail);
        }
    }
}