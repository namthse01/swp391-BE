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

namespace Application.Features.User.Queries.GetList
{
    public class UserGetListQueryHandler : IRequestHandler<UserGetListQuery, PagedResponse<List<UserListViewModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserGetListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<UserListViewModel>>> Handle(UserGetListQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Repository<Domain.Entities.User>()
            .GetAll(x => string.IsNullOrEmpty(request.Username) || x.Username.ToLower().Contains(request.Username));
            int total = await query.CountAsync();
            if (total == 0)
            {
                new PagedResponse<List<UserListViewModel>>(0);
            }

            var users = await query.ToListAsync();
            var viewUsers = _mapper.Map<List<UserListViewModel>>(users);

            return new PagedResponse<List<UserListViewModel>>(total, viewUsers);
        }
    }
}
