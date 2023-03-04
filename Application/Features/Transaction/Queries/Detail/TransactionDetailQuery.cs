using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transaction.Queries.Detail
{
    public class TransactionDetailQuery : IRequest<Response<TransactionDetailResponse>>
    {
        public Guid Id { get; set; }
    }
}
