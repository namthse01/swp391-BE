using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Player.Queries.Detail
{
    public class PlayerDetailQueryHandler : IRequestHandler<PlayerDetailQuery, Response<PlayerDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<PlayerDetailResponse>> Handle(PlayerDetailQuery request, CancellationToken cancellationToken)
        {
            var playerDetail = await _unitOfWork.Repository<Domain.Entities.Player>().GetAll(x => x.Id == request.Id).Select(x => new PlayerDetailResponse
            {
                User = new PlayerUserResponse()
                {
                    Name = x.User.Username,
                    Phone = x.User.Phone
                }

            }).FirstOrDefaultAsync();
            return new Response<PlayerDetailResponse>(playerDetail);
        }
    }
}
