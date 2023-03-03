using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Player.Command.Add
{
    public class PlayerCreateCommandHander : IRequestHandler<PlayerCreateCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlayerCreateCommandHander(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(PlayerCreateCommand request, CancellationToken cancellationToken)
        {
            var player = _mapper.Map<Domain.Entities.Player>(request);
            await _unitOfWork.Repository<Domain.Entities.Player>().AddAsync(player);
            await _unitOfWork.CommitAsync();
            return new Response<Guid>();
        }
    }
}
