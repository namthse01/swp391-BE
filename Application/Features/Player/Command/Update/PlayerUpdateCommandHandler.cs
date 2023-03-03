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

namespace Application.Features.Player.Command.Update
{
    public class PlayerUpdateCommandHandler : IRequestHandler<PlayerUpdateCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlayerUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(PlayerUpdateCommand request, CancellationToken cancellationToken)
        {
            var player = await _unitOfWork.Repository<Domain.Entities.Player>().FindSingleAsync(x => x.Id == request.Id);
            if (player == null)
            {
                throw new ApiException("ID not found");
            }
            player.UserId = request.Id;
            await _unitOfWork.Repository<Domain.Entities.Player>().UpdateAsync(player);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
