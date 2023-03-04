using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transaction.Queries.Detail
{
    public class TransactionDetailQueryHandler : IRequestHandler<TransactionDetailQuery, Response<TransactionDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Task<Response<TransactionDetailResponse>> Handle(TransactionDetailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
