using Application.Features.Manager.Queries.Detail;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Role.Queries.Detail
{
    public class RoleDetailQueryHandler : IRequestHandler<RoleDetailQuery, Response<RoleDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        async Task<Response<RoleDetailResponse>> IRequestHandler<RoleDetailQuery, Response<RoleDetailResponse>>.Handle(RoleDetailQuery request, CancellationToken cancellationToken)
        {
            var roleDetail = await _unitOfWork.Repository<Domain.Entities.Role>()
                .GetAll(x => x.Id == request.Id)
                .Select(x => new RoleDetailResponse
                {
                    Name = x.Name,
                })
                .FirstOrDefaultAsync();

            return new Response<RoleDetailResponse>(roleDetail);
        }
    }
}
