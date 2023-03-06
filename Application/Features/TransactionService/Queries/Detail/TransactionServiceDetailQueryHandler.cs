using Application.Features.Field.Queries.Detail;
using Application.Features.Manager.Queries.Detail;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionService.Queries.Detail
{
    public class TransactionServiceDetailQueryHandler : IRequestHandler<TransactionServiceDetailQuery, Response<TransactionServiceDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionServiceDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<TransactionServiceDetailResponse>> Handle(TransactionServiceDetailQuery request, CancellationToken cancellationToken)
        {
            var transactionServiceDetail = await _unitOfWork.Repository<Domain.Entities.TransactionService>()
                .GetAll(x => x.Id == request.Id)
                .Select(x => new TransactionServiceDetailResponse
                {
                    Transaction = new TransactionServiceAndTransactionResponse()
                    {
                        Name = x.Transaction.Name,
                        Slot = x.Transaction.Slot,
                    },
                    Service = new TransactionServiceAndServiceResponse()
                    {
                        Name = x.Service.Name,
                        Price = x.Service.Price
                    }
                })
                .FirstOrDefaultAsync();

            return new Response<TransactionServiceDetailResponse>(transactionServiceDetail);
        }
    }
}
