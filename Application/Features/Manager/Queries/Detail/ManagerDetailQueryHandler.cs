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
                    User = new ManagerUserResponse()
                    {
                        Username = x.User.Username,
                        Phone = x.User.Phone,
                    },
                    Role = new ManagerRoleResponse()
                    {
                        Name = x.Role.Name
                    }
                })
                .FirstOrDefaultAsync();

            return new Response<ManagerDetailResponse>(managerDetail);
        }
    }
}