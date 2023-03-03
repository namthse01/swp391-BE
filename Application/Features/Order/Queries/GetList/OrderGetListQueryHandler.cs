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

namespace Application.Features.Order.Queries.GetList
{
    public class OrderGetListQueryHandler : IRequestHandler<OrderGetListQuery, PagedResponse<List<OrderListViewModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrderGetListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResponse<List<OrderListViewModel>>> Handle(OrderGetListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Repository<Domain.Entities.Order>()
                .GetAll();
            int total = await query.CountAsync();
            if (total == 0)
            {
                new PagedResponse<List<OrderListViewModel>>(0);
            }

            var orders = await query.ToListAsync();
            var viewOrders = _mapper.Map<List<OrderListViewModel>>(orders);

            return new PagedResponse<List<OrderListViewModel>>(total, viewOrders);
        }
    }
}
