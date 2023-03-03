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

namespace Application.Features.Role.Queries.GetList
{
    public class RoleGetListQueryHandler : IRequestHandler<RoleGetListQuery, PagedResponse<List<RoleListViewModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RoleGetListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<RoleListViewModel>>> Handle(RoleGetListQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Repository<Domain.Entities.Role>()
            .GetAll(x => string.IsNullOrEmpty(request.Name) || x.Name.ToLower().Contains(request.Name));
            int total = await query.CountAsync();
            if (total == 0)
            {
                new PagedResponse<List<RoleListViewModel>>(0);
            }

            var roles = await query.ToListAsync();
            var viewRoles = _mapper.Map<List<RoleListViewModel>>(roles);

            return new PagedResponse<List<RoleListViewModel>>(total, viewRoles);
        }
    }
}
