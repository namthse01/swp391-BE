using Application.Features.Manager.Queries.GetList;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Player.Queries.GetList
{
    public class PlayerGetListQueryHandler : IRequestHandler<PlayerGetListQuery, PagedResponse<List<PlayerListViewModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PlayerGetListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<PlayerListViewModel>>> Handle(PlayerGetListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Repository<Domain.Entities.Player>()
                .GetAll();
            int total = await query.CountAsync();
            if (total == 0)
            {
                new PagedResponse<List<PlayerListViewModel>>(0);
            }

            var player = await query.ToListAsync();
            var viewPlayer = _mapper.Map<List<PlayerListViewModel>>(player);

            return new PagedResponse<List<PlayerListViewModel>>(total, viewPlayer);
        }
    }
}