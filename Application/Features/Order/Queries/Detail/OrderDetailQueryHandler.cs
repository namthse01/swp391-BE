using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Order.Queries.Detail
{
    public class OrderDetailQueryHandler : IRequestHandler<OrderDetailQuery, Response<OrderDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<OrderDetailResponse>> Handle(OrderDetailQuery request,
            CancellationToken cancellationToken)
        {
            var orderDetail = await _unitOfWork.Repository<Domain.Entities.Order>()
                .GetAll(x => x.Id == request.Id)
                .Select(x => new OrderDetailResponse
                {
                    Name =x.Name,
                    TotalPrice= x.TotalPrice,
                    Transaction = new OrderTransactionResponse()
                    {
                        Name = x.Transaction.Name
                    }

                })
                .FirstOrDefaultAsync();

            return new Response<OrderDetailResponse>(orderDetail);
        }
    }
}