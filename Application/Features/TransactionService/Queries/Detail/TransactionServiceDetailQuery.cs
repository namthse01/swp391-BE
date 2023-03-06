using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TransactionService.Queries.Detail
{
    public class TransactionServiceDetailQuery : IRequest<Response<TransactionServiceDetailResponse>>
    {
        public Guid Id { get; set; }
    }
}
