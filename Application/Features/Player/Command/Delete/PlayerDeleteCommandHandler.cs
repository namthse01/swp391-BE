using Application.Exceptions;
using Application.Features.Manager.Command.Delete;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Player.Command.Delete
{
    internal class PlayerDeleteCommandHandler : IRequestHandler<PlayerDeleteCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlayerDeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<Guid>> Handle(PlayerDeleteCommand request, CancellationToken cancellationToken)
        {
            var player = await _unitOfWork.Repository<Domain.Entities.Player>().FindSingleAsync(x => x.Id == request.Id);
            if (player == null)
            {
                throw new ApiException("ID not found");
            }
            await _unitOfWork.Repository<Domain.Entities.Player>().DeleteAsync(player);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
