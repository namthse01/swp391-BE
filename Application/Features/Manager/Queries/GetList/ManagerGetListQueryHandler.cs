using Application.Features.Field.Queries.GetList;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Manager.Queries.GetList
{
    public class ManagerGetListQueryHandler : IRequestHandler<ManagerGetListQuery, PagedResponse<List<ManagerListViewModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ManagerGetListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<ManagerListViewModel>>> Handle(ManagerGetListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Repository<Domain.Entities.Manager>()
                .GetAll();
            int total = await query.CountAsync();
            if (total == 0)
            {
                new PagedResponse<List<ManagerListViewModel>>(0);
            }

            var managers = await query.ToListAsync();
            var viewManagers = _mapper.Map<List<ManagerListViewModel>>(managers);

            return new PagedResponse<List<ManagerListViewModel>>(total, viewManagers);
        }
    }
}
